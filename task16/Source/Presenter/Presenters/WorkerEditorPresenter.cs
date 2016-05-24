using Model;
using Presenter.Common;
using Presenter.ViewModels;
using Presenter.Views;
using WorkersManagement.IoC;

namespace Presenter.Presenters
{
    public class WorkerEditorPresenter : BasePresenter<IWorkerEditorView, Person>
    {
        private Person _worker;
        private ICorrectnessChecker _correctnessChecker;

        public WorkerEditorPresenter(IApplicationController controller, IWorkerEditorView view, ICorrectnessChecker correctnessChecker)
            : base(controller, view)
        {
            View.SaveChanges += ViewSaveChanges;
            View.DiscaredChanges += ViewDiscaredChanges;
            _correctnessChecker = correctnessChecker;
        }

        void ViewDiscaredChanges()
        {
            _worker.Id = -1;
            View.Close();
        }
        void ViewSaveChanges()
        {
            View.Close();
        }
        public override void Run(Person worker)
        {
            _worker = worker;
            View.ViewModel = new WorkerEditorViewModel(_worker, _correctnessChecker);
            View.Show();
        }
    }
}
