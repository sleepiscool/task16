using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presenter.Common;
using Presenter.ViewModels;
using Presenter.Views;
using WorkersManagement.IoC;

namespace Presenter.Presenters
{
    public class AboutDialogPresenter : BasePresenter<IAboutDialogView>
    {
        public AboutDialogPresenter(IApplicationController controller, IAboutDialogView view)
            : base(controller, view)
        {

        }

        public override void Run()
        {
            View.ViewModel = new AboutDialogViewModel();
            View.Show();
        }
    }
}
