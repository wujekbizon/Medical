using Medical.Helper;
using Medical.Models;
using System.Windows.Input;

namespace Medical.ViewModels.Abstract
{
    public abstract class JedenViewModel<T> : WorkspaceViewModel
    {
        #region BazaDanych
        protected readonly MedicalEntities medicalEntities;
        protected T item;
        #endregion

        #region Konstruktor 
        public JedenViewModel()
        {
            medicalEntities = new MedicalEntities();
        }
        #endregion

        #region Komendy
        private BaseCommand _SaveAndCloseCommand;
        public ICommand SaveAndCloseCommand
        {
            get
            {
                if (_SaveAndCloseCommand == null) _SaveAndCloseCommand = new BaseCommand(saveAndCLose);
                return _SaveAndCloseCommand;
            }
        }

        private BaseCommand _CancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                if (_CancelCommand == null) _CancelCommand = new BaseCommand(close);
                return _CancelCommand;
            }
        }

        public abstract void Save();

        private void saveAndCLose()
        {
            Save();
            OnRequestClose(); 
        }

        private void close()
        {
            OnRequestClose();
        }
        #endregion
    }
}
