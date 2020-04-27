using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using WinForms.Model;
using WinForms.Services;
using WinForms.Views;

namespace WinForms.Presenters
{
    public class LoadReportPresenter : PresenterBase<ILoadReportView>, ILoadReportPresenter
    {
        private readonly IInputFileService inputFileService;
        private readonly IDatabaseRepository databaseRepository;
        private readonly IFileParsingService fileParsingService;
        public LoadReportPresenter(ILoadReportView view,
            IInputFileService inputFileService,
            IDatabaseRepository databaseRepository,
            IFileParsingService fileParsingService
            ) : base(view)
        {
            this.inputFileService = inputFileService;
            this.databaseRepository = databaseRepository;
            this.fileParsingService = fileParsingService;
        }


        public string Title => "Wczytywanie pliku";

        public Control GetControl()
        {
            return View.Control;
        }

        public void LoadFile()
        {
            View.ClearReport();
            View.WriteMessage("Start");
            var filesInInputDirectory = inputFileService.GetFilesToLoad();
            if (filesInInputDirectory != null && filesInInputDirectory.Any())
            {
                foreach (var file in filesInInputDirectory)
                {
                    View.WriteMessage($"Going to check file: {file}");
                    var status = databaseRepository.CheckIfFileImported(file.Name, DateTime.UtcNow.Date);
                    View.WriteMessage($"file: {file} status for import on {DateTime.UtcNow.Date} date is {status}");
                    if (!status)
                    {
                        View.WriteMessage($"Giong To Parse file: {file}");

                        var parseErrors = fileParsingService.Validate(file);
                        if (parseErrors != null && parseErrors.Any())
                        {
                            View.WriteMessage($"file: {file} got errors from parsing process");
                            foreach (var error in parseErrors)
                            {
                                View.WriteMessage(error);
                            }
                            View.WriteMessage("skipping file...");
                            continue;
                        }
                        var results = fileParsingService.Parse(file);
                        if (results != null && results.Any())
                        {
                            View.WriteMessage($"Giong To save parsed file: {file}, got {results.Count} transaction results from parsing");
                            databaseRepository.SaveResults(file.Name, DateTime.UtcNow.Date, results);
                        }
                        else
                        {
                            View.WriteMessage($"file: {file} doesn't contain any parsed transation... skipping...");
                            continue;
                        }


                        View.WriteMessage($"Giong To move parsed and stored file: {file.Name} to output directory");
                        inputFileService.MoveFileToUutputDirectory(file);
                        View.WriteMessage($"process ended for file: {file} , moved  successfully");
                    }
                    else
                    {
                        View.WriteMessage($" file: {file} was parsed for current date {DateTime.UtcNow.Date} skipping..");
                    }
                }

            }
            else
            {

                View.WriteMessage($" has 0 filles to load");
            }
            View.WriteMessage("End");
        }
    }
}
