using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForms.Model;

namespace WinForms.Services
{
    public interface  IDatabaseRepository
    {
        bool CheckIfFileImported(string filename, DateTime date);
        void SaveResults(string fileName, DateTime date, IList<Transaction> transactions);
    }
}
