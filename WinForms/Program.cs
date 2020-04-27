using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using WinForms.Presenters;
using WinForms.Services;
using WinForms.Views;

namespace WinForms
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var presenter = container.Resolve<IShellPresenter>();
            Application.Run(presenter.GetWindow());
        }


    
        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IShellView, Shell>();
            currentContainer.RegisterType<IShellPresenter, ShellPresenter>();
            currentContainer.RegisterType<IFileParsingService, FileParsingService>();
            currentContainer.RegisterType<IInputFileService, InputFileService>();
            currentContainer.RegisterType<IDatabaseRepository, DatabaseRepository>();
            currentContainer.RegisterType<ILoadReportPresenter, LoadReportPresenter>();
            currentContainer.RegisterType<ILoadReportView, LoadReportView>();
            return currentContainer;
        }

    }
}
