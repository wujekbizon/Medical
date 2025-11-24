using Medical.Models;
using Medical.Models.EntitiesForView;
using Medical.ViewModels.Abstract;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Medical.ViewModels
{
    /// <summary>
    /// ViewModel for displaying all Pacjent (Patient) records
    /// </summary>
    public class WszyscyPacjenciViewModel : WszystkieViewModel<PacjentForAllView>
    {
        #region Fields
        private readonly MedicalEntities _medicalEntities;
        #endregion

        #region Constructor
        public WszyscyPacjenciViewModel()
        {
            base.DisplayName = "Wszyscy Pacjenci";
            _medicalEntities = new MedicalEntities();
            Load();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Load all patients from database
        /// </summary>
        public override void Load()
        {
            List.Clear();

            var patients = (
                from pacjent in _medicalEntities.Pacjent
                where pacjent.CzyAktywny == true
                orderby pacjent.Nazwisko, pacjent.Imie
                select new PacjentForAllView
                {
                    IdPacjenta = pacjent.IdPacjenta,
                    Imie = pacjent.Imie,
                    Nazwisko = pacjent.Nazwisko,
                    DataUrodzenia = pacjent.DataUrodzenia,
                    Pesel = pacjent.Pesel,
                    Plec = pacjent.Plec,
                    TelefonKontaktowy = pacjent.TelefonKontaktowy,
                    AdresEmail = pacjent.AdresEmail,
                    Miasto = pacjent.Miasto,
                    GrupaKrwi = pacjent.GrupaKrwi,
                    UbezpieczenieZdrowotne = pacjent.UbezpieczenieZdrowotne,
                    InformacjeAlergie = pacjent.InformacjeAlergie,
                    ChorobyPrzewlekle = pacjent.ChorobyPrzewlekle,
                    CzyAktywny = pacjent.CzyAktywny,
                    KiedyDodal = pacjent.KiedyDodal
                }).ToList();

            List = new ObservableCollection<PacjentForAllView>(patients);
        }

        /// <summary>
        /// Open Add New Patient view
        /// </summary>
        protected override void Add()
        {
            // This will be implemented when we add the workspace navigation
            // For now, we'll show a message
            ShowMessageBox("Funkcja dodawania nowego pacjenta zostanie wkrótce dodana.");
        }

        /// <summary>
        /// Search/filter patients
        /// </summary>
        protected override void Search()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                Load();
                return;
            }

            var searchLower = SearchText.ToLower();

            var filteredPatients = (
                from pacjent in _medicalEntities.Pacjent
                where pacjent.CzyAktywny == true
                && (pacjent.Imie.ToLower().Contains(searchLower)
                    || pacjent.Nazwisko.ToLower().Contains(searchLower)
                    || pacjent.Pesel.Contains(searchLower)
                    || pacjent.TelefonKontaktowy.Contains(searchLower))
                orderby pacjent.Nazwisko, pacjent.Imie
                select new PacjentForAllView
                {
                    IdPacjenta = pacjent.IdPacjenta,
                    Imie = pacjent.Imie,
                    Nazwisko = pacjent.Nazwisko,
                    DataUrodzenia = pacjent.DataUrodzenia,
                    Pesel = pacjent.Pesel,
                    Plec = pacjent.Plec,
                    TelefonKontaktowy = pacjent.TelefonKontaktowy,
                    AdresEmail = pacjent.AdresEmail,
                    Miasto = pacjent.Miasto,
                    GrupaKrwi = pacjent.GrupaKrwi,
                    UbezpieczenieZdrowotne = pacjent.UbezpieczenieZdrowotne,
                    InformacjeAlergie = pacjent.InformacjeAlergie,
                    ChorobyPrzewlekle = pacjent.ChorobyPrzewlekle,
                    CzyAktywny = pacjent.CzyAktywny,
                    KiedyDodal = pacjent.KiedyDodal
                }).ToList();

            List = new ObservableCollection<PacjentForAllView>(filteredPatients);
        }
        #endregion

        #region Dispose
        public override void Dispose()
        {
            _medicalEntities?.Dispose();
            base.Dispose();
        }
        #endregion
    }
}
