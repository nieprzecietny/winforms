using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms.Views
{
    

    public interface IShellView :IView
    {
        EventHandler LoadMenu { get; set; }
        void SetText(string newText);
        void LoadComponent(Control control);
        Form Window { get; }
    }
}
