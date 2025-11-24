using Medical.Helper;
using Medical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            // tworzenie obiektu z db
            medicalEntities = new MedicalEntities();
        }
        #endregion

        #region Komendy
        //to jest komenda ktora zostanie podpieta pod przycisk ZapisziZamknij
        private BaseCommand _SaveAndCloseCommand;
        public ICommand SaveAndCloseCommand
        {
            get
            {
                if (_SaveAndCloseCommand == null) _SaveAndCloseCommand = new BaseCommand(saveAndCLose);// ta komenda wywola metode saveAndClose ktora jest zdefiniowana nizej
                return _SaveAndCloseCommand;
            }
        }
        public abstract void Save();

        private void saveAndCLose()
        {
            Save();
            //zamykamy zakladke przez metode z WorkspaceViewModel
            OnRequestClose(); // koniecznie zmien w WorkspaceViewModel dostep do tej metody na protected
        }
        #endregion
    }
}
