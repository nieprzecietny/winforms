using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms.Presenters
{
    public interface ILoadReportPresenter
    {
        string Title { get; }

        Control GetControl();
        void LoadFile();
    }
}
