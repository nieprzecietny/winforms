using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms.Services
{
    public interface IInputFileService
    {
        FileInfo[] GetFilesToLoad();
        void MoveFileToUutputDirectory(FileInfo filename);
    }
}
