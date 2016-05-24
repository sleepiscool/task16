using Presenter.Common;
using Presenter.ViewModels;

namespace Presenter.Views
{
    public interface IAboutDialogView : IView
    {
        AboutDialogViewModel ViewModel { get; set; }
    }
}
