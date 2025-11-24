using Medical.Models;
using Medical.ViewModels.Abstract;
using System;
using System.Windows;

namespace Medical.ViewModels
{
    /// <summary>
    /// ViewModel for adding a new Pacjent (Patient)
    /// </summary>
    public class NowyPacjentViewModel : JedenViewModel<Pacjent>
    {
        #region Constructor
        public NowyPacjentViewModel()
        {
            base.DisplayName = "Nowy Pacjent";

            // Initialize new patient with default values
            Item.CzyAktywny = true;
            Item.KiedyDodal = DateTime.Now;
            Item.KtoDodal = "System"; // TODO: Replace with actual logged-in user
            Item.WersjaDanych = 1;
            Item.DataUrodzenia = DateTime.Now.AddYears(-30); // Default age
        }
        #endregion

        #region Properties
        // Convenient properties for data binding

        public string Imie
        {
            get => Item.Imie;
            set
            {
                Item.Imie = value;
                OnPropertyChanged(() => Imie);
            }
        }

        public string Nazwisko
        {
            get => Item.Nazwisko;
            set
            {
                Item.Nazwisko = value;
                OnPropertyChanged(() => Nazwisko);
            }
        }

        public DateTime DataUrodzenia
        {
            get => Item.DataUrodzenia;
            set
            {
                Item.DataUrodzenia = value;
                OnPropertyChanged(() => DataUrodzenia);
            }
        }

        public string AdresZamieszkania
        {
            get => Item.AdresZamieszkania;
            set
            {
                Item.AdresZamieszkania = value;
                OnPropertyChanged(() => AdresZamieszkania);
            }
        }

        public string Miasto
        {
            get => Item.Miasto;
            set
            {
                Item.Miasto = value;
                OnPropertyChanged(() => Miasto);
            }
        }

        public string KodPocztowy
        {
            get => Item.KodPocztowy;
            set
            {
                Item.KodPocztowy = value;
                OnPropertyChanged(() => KodPocztowy);
            }
        }

        public string TelefonKontaktowy
        {
            get => Item.TelefonKontaktowy;
            set
            {
                Item.TelefonKontaktowy = value;
                OnPropertyChanged(() => TelefonKontaktowy);
            }
        }

        public string AdresEmail
        {
            get => Item.AdresEmail;
            set
            {
                Item.AdresEmail = value;
                OnPropertyChanged(() => AdresEmail);
            }
        }

        public string Pesel
        {
            get => Item.Pesel;
            set
            {
                Item.Pesel = value;
                OnPropertyChanged(() => Pesel);
            }
        }

        public string Plec
        {
            get => Item.Plec;
            set
            {
                Item.Plec = value;
                OnPropertyChanged(() => Plec);
            }
        }

        public string NumerKartyPacjenta
        {
            get => Item.NumerKartyPacjenta;
            set
            {
                Item.NumerKartyPacjenta = value;
                OnPropertyChanged(() => NumerKartyPacjenta);
            }
        }

        public string GrupaKrwi
        {
            get => Item.GrupaKrwi;
            set
            {
                Item.GrupaKrwi = value;
                OnPropertyChanged(() => GrupaKrwi);
            }
        }

        public string InformacjeAlergie
        {
            get => Item.InformacjeAlergie;
            set
            {
                Item.InformacjeAlergie = value;
                OnPropertyChanged(() => InformacjeAlergie);
            }
        }

        public string UbezpieczenieZdrowotne
        {
            get => Item.UbezpieczenieZdrowotne;
            set
            {
                Item.UbezpieczenieZdrowotne = value;
                OnPropertyChanged(() => UbezpieczenieZdrowotne);
            }
        }

        public string UwagiDodatkowe
        {
            get => Item.UwagiDodatkowe;
            set
            {
                Item.UwagiDodatkowe = value;
                OnPropertyChanged(() => UwagiDodatkowe);
            }
        }

        public string KontaktAwaryjnyImieNazwisko
        {
            get => Item.KontaktAwaryjnyImieNazwisko;
            set
            {
                Item.KontaktAwaryjnyImieNazwisko = value;
                OnPropertyChanged(() => KontaktAwaryjnyImieNazwisko);
            }
        }

        public string KontaktAwaryjnyTelefon
        {
            get => Item.KontaktAwaryjnyTelefon;
            set
            {
                Item.KontaktAwaryjnyTelefon = value;
                OnPropertyChanged(() => KontaktAwaryjnyTelefon);
            }
        }

        public string ChorobyPrzewlekle
        {
            get => Item.ChorobyPrzewlekle;
            set
            {
                Item.ChorobyPrzewlekle = value;
                OnPropertyChanged(() => ChorobyPrzewlekle);
            }
        }

        public string RodzajNiepełnosprawności
        {
            get => Item.RodzajNiepełnosprawności;
            set
            {
                Item.RodzajNiepełnosprawności = value;
                OnPropertyChanged(() => RodzajNiepełnosprawności);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Save new patient to database
        /// </summary>
        protected override void Save()
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(Imie))
                {
                    MessageBox.Show("Imię jest wymagane.", "Walidacja", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(Nazwisko))
                {
                    MessageBox.Show("Nazwisko jest wymagane.", "Walidacja", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(Pesel))
                {
                    MessageBox.Show("PESEL jest wymagany.", "Walidacja", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Add to database
                _medicalEntities.Pacjent.Add(Item);

                // Save changes
                base.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas zapisywania pacjenta: {ex.Message}",
                    "Błąd",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
        #endregion
    }
}
