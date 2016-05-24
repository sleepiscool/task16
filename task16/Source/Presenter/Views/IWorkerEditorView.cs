using System;
using Presenter.Common;
using Presenter.ViewModels;

namespace Presenter.Views
{
    public interface IPersonEditorView : IView
    {
        event Action SaveChanges;
        event Action DiscaredChanges;

        WorkerEditorViewModel ViewModel { get; set; }
    }
}
