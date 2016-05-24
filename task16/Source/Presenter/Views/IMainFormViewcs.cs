using System;
using System.ComponentModel;
using Model;
using Presenter.Common;

namespace Presenter.Views
{
    public interface IMainFormView : IView
    {
        event EventHandler Load;
        event EventHandler Closed;
        event EventHandler<Person> EditWorker;
        event EventHandler<Person> DeleteWorker;
        event EventHandler<Person> AddWorker;

        event EventHandler ShowAbout;

        BindingList<Person> GridSourceBindingList { get; set; }
    }
}
