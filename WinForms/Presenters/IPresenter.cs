using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForms.Views;

namespace WinForms.Presenters
{
   public  interface IPresenter<TView> where TView : Views.IView
    {
        TView View { get; set; }
    }
}
