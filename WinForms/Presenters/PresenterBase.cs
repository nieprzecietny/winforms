using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForms.Views;

namespace WinForms.Presenters
{
    public abstract class PresenterBase<TView> : IPresenter<TView> where TView : Views.IView
    {
        public PresenterBase(TView view)
        {
            this.View = view;
        }
        public TView View { get; set; }
    }
}
