using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.ComponentModel;
using Model;
using Presenter.Common;
using Presenter.Views;
using WorkersManagement.IoC;

namespace Presenter.Presenters
{
    public class MainPresenter : BasePresenter<IMainFormView>
    {
        private readonly IApplicationController _controller;
        private readonly IMainFormView _view;
        private readonly IWorkersRepository _workersRepository;
        private BindingList<Worker> _workers;
        public MainPresenter(IApplicationController controller, IMainFormView view, IWorkersRepository repository)
            : base(controller, view)
        {
            _controller = controller;
            _view = view;

            _workersRepository = repository;
            SubscribeForEvents();
        }

        private void SubscribeForEvents()
        {
            _view.Load += OnLoad;
            _view.EditWorker += ViewEditWorker;
            _view.DeleteWorker += ViewDeleteWorker;
            _view.ShowAbout += ViewShowAbout;
        }

        void ViewShowAbout(object sender, EventArgs e)
        {
            _controller.Run<AboutDialogPresenter>();
        }

        void ViewDeleteWorker(object sender, Person worker)
        {
            _workersRepository.DeletePerson(worker);
        }

        void ViewEditWorker(object sender, Person worker)
        {
            var editWorker = worker.Clone() as Person;
            _controller.Run<WorkerEditorPresenter, Person>(editWorker);

            if (editWorker.Id == -1)
                return;

            editWorker.Initials = editWorker.Name[0] + "." + editWorker.MiddleName[0] + ".";
            var index = _workers.IndexOf(worker);
            _workers[index] = editWorker;

            _workersRepository.ChangeWorker(worker);
        }

        void OnLoad(object sender, EventArgs e)
        {
            _workers = _workersRepository.GetWorkersList();
            _workers.AddingNew += WorkersOnAddingNew;
            _view.GridSourceBindingList = _workers;
        }

        void WorkersOnAddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new Person 
            {
                LastName = "Введите фамилию",
                Name = "Введите имя",
                MiddleName = "Введите отчество",
                Login = "Введите логин",
                Password = "Введите пароль",
                JobTitle = "Введите должность"
            };

            Controller.Run<WorkerEditorPresenter, Person>((Person)e.NewObject);

            if (((Person)e.NewObject).Id == -1)
            {
                _workers.Remove((Person)e.NewObject);
                return;
            }

            ((Person)e.NewObject).Initials = ((Person)e.NewObject).Name[0] + "." +
                                              ((Person)e.NewObject).MiddleName[0] + ".";

            _workersRepository.AddWorker((Person)e.NewObject);
        }

    }
}