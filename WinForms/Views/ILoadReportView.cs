using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms.Views
{
    

    public interface ILoadReportView : IView
    {
        Control Control { get; }
        void ClearReport();
        void WriteMessage(string message);
    }
}
