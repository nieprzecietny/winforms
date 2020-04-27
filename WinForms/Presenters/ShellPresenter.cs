using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForms.Views;

namespace WinForms.Presenters
{
    public class ShellPresenter: PresenterBase<IShellView> , IShellPresenter
    {

        public ShellPresenter(IShellView view, ILoadReportPresenter loadReportPresenter) :base(view)
        {

            base.View.LoadMenu = (s, e) => 
            {
                var sender = s as IShellView;
                if (sender != null)
                {
                    sender.LoadComponent(loadReportPresenter.GetControl());
                    
                    sender.SetText(loadReportPresenter.Title);
                    loadReportPresenter.LoadFile();
                }

            };


        }
        

        public Form GetWindow()
        {
            return View.Window;
        }
    }
}
