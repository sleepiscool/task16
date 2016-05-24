using System;
using System.Windows.Forms;
using Aapplication_model;
using Model;
using Presenter.Common;
using Presenter.Presenters;
using Presenter.Views;
using SqlDataAccess;

namespace WorkersManagement
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var controller = new ApplicationController(new LightInjectAdapder())
                .RegisterView<IMainFormView, application_model>()
                .RegisterView<IPersonEditorView, application_model_table>()
                .RegisterView<IAboutDialogView, AboutDialogView>()
                .RegisterService<IWorkersRepository, WorkersRepository>(LifeTime.PerContainer)
                .RegisterService<ICorrectnessChecker, CorrectnessChecker>(LifeTime.PerContainer)
                .RegisterInstance(new ApplicationContext());

            controller.Resolve<IWorkersRepository>().Initialize("workersrepository", "root", "root", "workers");

            controller.Run<MainPresenter>();
        }
    }
}
