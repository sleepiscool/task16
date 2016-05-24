using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using Model;

namespace Presenter.ViewModels
{
    public class WorkerEditorViewModel : INotifyPropertyChanged
    {
        private Person _worker;
        private ICorrectnessChecker _correctnessChecker;

        public WorkerEditorViewModel(Person worker, ICorrectnessChecker correctnessChecker)
        {
            _worker = worker;
            _correctnessChecker = correctnessChecker;
            _loginCorrectly = new InputDataCorrectly(0, "");
            _passwordCorrectly = new InputDataCorrectly(0, "");
        }

        #region Base fields without possible errors (Last name, name, middle name, job title)
        public string LastName
        {
            get { return _worker.LastName; }
            set
            {
                if (value != "" && char.IsLower(value[0]))
                    _worker.LastName = char.ToUpperInvariant(value[0]) + value.Substring(1);
                else
                    _worker.LastName = value;

                NotifyPropertyChanged();
            }
        }

        public string Name
        {
            get { return _worker.Name; }
            set
            {
                if (value != "" && char.IsLower(value[0]))
                    _worker.Name = char.ToUpperInvariant(value[0]) + value.Substring(1);
                else
                    _worker.Name = value;

                NotifyPropertyChanged();
            }
        }

        public string MiddleName
        {
            get { return _worker.MiddleName; }
            set
            {
                if (value != "" && char.IsLower(value[0]))
                    _worker.MiddleName = char.ToUpperInvariant(value[0]) + value.Substring(1);
                else
                    _worker.MiddleName = value;

                NotifyPropertyChanged();
            }
        }

        public string JobTitle
        {
            get { return _worker.JobTitle; }
            set
            {
                _worker.JobTitle = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

     

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            OnPropertyChanged(propertyName);
            OnPropertyChanged("SaveButtonEnabled");
            OnPropertyChanged("LoginColor");
            OnPropertyChanged("LoginWarning");
            OnPropertyChanged("PasswordColor");
            OnPropertyChanged("PasswordWarning");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
