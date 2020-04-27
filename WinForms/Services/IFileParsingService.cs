using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForms.Model;

namespace WinForms.Services
{
    public interface IFileParsingService
    {
        List<string> Validate(FileInfo fileInfo);
        List<Transaction> Parse(FileInfo fileInfo);
    }
}
