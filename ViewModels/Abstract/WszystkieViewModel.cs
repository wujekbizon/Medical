using Medical.Helper;
using Medical.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Medical.ViewModels.Abstract
{
    // to jest klasa z której będa dziedziczyc wszystkie ViewModel wyswietlajace wszystkie obiekty biznesowe  
    public abstract class WszystkieViewModel<T> : WorkspaceViewModel // to jest typ przechowywanej kolekcji
    {
        #region BazaDanych 
        // to jest obiekt który reprezentuje cala baze danych 
        protected readonly MedicalEntities medicalEntities;
        #endregion
        #region Command
        //komendy to takie cos co podlacza sie pod element widoku np przycisk i ona wywoulje funkcje
        // czyli podlaczamy komende ktora wywoluje funkcje
        // to jest komenda do ladowania obiektow z bazy,zostaje podpieta pod przycisk odswiez.
        // _ oznacza ze dane pole bedzie mialo properties
        private BaseCommand _LoadCommand;
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null) _LoadCommand = new BaseCommand(Load);// ta komenda wywola metode load ktora jest zdefiniowana nizej
                return _LoadCommand;
            }
        }

        //private BaseCommand _AddCommand;
        //public ICommand AddCommand
        //{
        //    get
        //    {
        //        if (_AddCommand == null) _AddCommand = new BaseCommand(Add);
        //        return _AddCommand;
        //    }
        //}

        //protected abstract void Add();
        #endregion
        #region Lista
        //tu beda przechowywane wszystkie towary
        private ObservableCollection<T> _List;
        public ObservableCollection<T> List
        {
            get
            {
                if (_List == null) Load(); // jezeli lista jest pusta to ja ladujemy metoda load
                return _List;
            }

            set
            {
                if (_List != value)
                {
                    _List = value;
                    OnPropertyChanged(() => List);// odswieza wyswietlanie listy obiektów
                }
            }
        }

        //poniewaz ladowanie z bazy danych jest inne dla kazdego obiektu biznesowego wiec Load jest 
        //metoda abstrakcyjna a bedzie dopiero zdefiniowana w klasach dziedziczacych 
        public abstract void Load();

        #endregion
        #region Konstruktor 
        public WszystkieViewModel()
        {
            // tworzenie obiektu z db
            medicalEntities = new MedicalEntities();
        }
        #endregion
    }
}
