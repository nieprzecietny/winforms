using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms.Services
{
    public class InputFileService : IInputFileService
    {
        public FileInfo[] GetFilesToLoad()
        {
            var fileInfo = new System.IO.DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "in")).GetFiles();
            return fileInfo;
        }

        public void MoveFileToUutputDirectory(FileInfo filename)
        {
            if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "out")))
            {
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "out"));
            }

            filename.MoveTo(Path.Combine(Directory.GetCurrentDirectory(), "out", filename.Name+DateTime.Now.Ticks));
        }
    }
}
