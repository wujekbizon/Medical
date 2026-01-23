using Medical.Helper;
using Medical.Models;
using Medical.Models.EntitiesForView;
using Medical.Models.Enums;
using Medical.Models.Validatory;
using Medical.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace Medical.ViewModels
{
    public class NowyPacjentViewModel : JedenViewModel<Pacjent>, IDataErrorInfo
    {
        #region Konstruktor
        public NowyPacjentViewModel()
           : base()
        {
            base.DisplayName = "Pacjent";
            item = new Pacjent();
        }
        #endregion

        #region Wlasciwosci
        public string Imie
        {
            get
            {
                return item.Imie;
            }
            set
            {
                if (item.Imie != value)
                {
                    item.Imie = value;
                    OnPropertyChanged(() => Imie);
                }
            }
        }

        public string Nazwisko
        {
            get
            {
                return item.Nazwisko;
            }
            set
            {
                if (item.Nazwisko != value)
                {
                    item.Nazwisko = value;
                    OnPropertyChanged(() => Nazwisko);
                }
            }
        }

        public DateTime DataUrodzenia
        {
            get
            {
                return item.DataUrodzenia;
            }
            set
            {
                if (item.DataUrodzenia != value)
                {
                    item.DataUrodzenia = value;
                    OnPropertyChanged(() => DataUrodzenia);
                }
            }
        }

        public string AdresZamieszkania
        {
            get
            {
                return item.AdresZamieszkania;
            }
            set
            {
                if (item.AdresZamieszkania != value)
                {
                    item.AdresZamieszkania = value;
                    OnPropertyChanged(() => AdresZamieszkania);
                }
            }
        }

        public string Miasto
        {
            get
            {
                return item.Miasto;
            }
            set
            {
                if (item.Miasto != value)
                {
                    item.Miasto = value;
                    OnPropertyChanged(() => Miasto);
                }
            }
        }

        public string KodPocztowy
        {
            get
            {
                return item.KodPocztowy;
            }
            set
            {
                if (item.KodPocztowy != value)
                {
                    item.KodPocztowy = value;
                    OnPropertyChanged(() => KodPocztowy);
                }
            }
        }

        public string TelefonKontaktowy
        {
            get
            {
                return item.TelefonKontaktowy;
            }
            set
            {
                if (item.TelefonKontaktowy != value)
                {
                    item.TelefonKontaktowy = value;
                    OnPropertyChanged(() => TelefonKontaktowy);
                }
            }
        }

        public string AdresEmail
        {
            get
            {
                return item.AdresEmail;
            }
            set
            {
                if (item.AdresEmail != value)
                {
                    item.AdresEmail = value;
                    OnPropertyChanged(() => AdresEmail);
                }
            }
        }

        public string Pesel
        {
            get
            {
                return item.Pesel;
            }
            set
            {
                if (item.Pesel != value)
                {
                    item.Pesel = value;
                    OnPropertyChanged(() => Pesel);
                }
            }
        }

        public string Plec
        {
            get
            {
                return item.Plec;
            }
            set
            {
                if (item.Plec != value)
                {
                    item.Plec = value;
                    OnPropertyChanged(() => Plec);
                }
            }
        }

        public string NumerKartyPacjenta
        {
            get
            {
                return item.NumerKartyPacjenta;
            }
            set
            {
                if (item.NumerKartyPacjenta != value)
                {
                    item.NumerKartyPacjenta = value;
                    OnPropertyChanged(() => NumerKartyPacjenta);
                }
            }
        }

        public string GrupaKrwi
        {
            get
            {
                return item.GrupaKrwi;
            }
            set
            {
                if (item.GrupaKrwi != value)
                {
                    item.GrupaKrwi = value;
                    OnPropertyChanged(() => GrupaKrwi);
                }
            }
        }

        public string InformacjeAlergie
        {
            get
            {
                return item.InformacjeAlergie;
            }
            set
            {
                if (item.InformacjeAlergie != value)
                {
                    item.InformacjeAlergie = value;
                    OnPropertyChanged(() => InformacjeAlergie);
                }
            }
        }

        public string UbezpieczenieZdrowotne
        {
            get
            {
                return item.UbezpieczenieZdrowotne;
            }
            set
            {
                if (item.UbezpieczenieZdrowotne != value)
                {
                    item.UbezpieczenieZdrowotne = value;
                    OnPropertyChanged(() => UbezpieczenieZdrowotne);
                }
            }
        }

        public string UwagiDodatkowe
        {
            get
            {
                return item.UwagiDodatkowe;
            }
            set
            {
                if (item.UwagiDodatkowe != value)
                {
                    item.UwagiDodatkowe = value;
                    OnPropertyChanged(() => UwagiDodatkowe);
                }
            }
        }

        public string KontaktAwaryjnyImieNazwisko
        {
            get
            {
                return item.KontaktAwaryjnyImieNazwisko;
            }
            set
            {
                if (item.KontaktAwaryjnyImieNazwisko != value)
                {
                    item.KontaktAwaryjnyImieNazwisko = value;
                    OnPropertyChanged(() => KontaktAwaryjnyImieNazwisko);
                }
            }
        }

        public string KontaktAwaryjnyTelefon
        {
            get
            {
                return item.KontaktAwaryjnyTelefon;
            }
            set
            {
                if (item.KontaktAwaryjnyTelefon != value)
                {
                    item.KontaktAwaryjnyTelefon = value;
                    OnPropertyChanged(() => KontaktAwaryjnyTelefon);
                }
            }
        }

        public string ChorobyPrzewlekle
        {
            get
            {
                return item.ChorobyPrzewlekle;
            }
            set
            {
                if (item.ChorobyPrzewlekle != value)
                {
                    item.ChorobyPrzewlekle = value;
                    OnPropertyChanged(() => ChorobyPrzewlekle);
                }
            }
        }

        public string RodzajNiepełnosprawności
        {
            get
            {
                return item.RodzajNiepełnosprawności;
            }
            set
            {
                if (item.RodzajNiepełnosprawności != value)
                {
                    item.RodzajNiepełnosprawności = value;
                    OnPropertyChanged(() => RodzajNiepełnosprawności);
                }
            }
        }

        public bool CzyAktywny
        {
            get
            {
                return item.CzyAktywny;
            }
            set
            {
                if (item.CzyAktywny != value)
                {
                    item.CzyAktywny = value;
                    OnPropertyChanged(() => CzyAktywny);
                }
            }
        }

        #region Validation
        public string Error
        {
            get
            {
                return null;
            }
        }
        public string this[string name]
        {
            get
            {
                string komunikat = null;
                if (name == "Pesel")
                {
                    komunikat =
                    StringValidator.SprawdzPesel(this.Pesel);
                }
                if (name == "NumerKartyPacjenta")
                {
                    komunikat = BiznesValidator.SprawdzNumerKartyPacjenta(this.NumerKartyPacjenta);
                }
                return komunikat;
            }
        }
        #endregion

        public override bool IsValid()
        {
            if (this["Nazwa"] == null && this["StawkaVatSprzedazy"] == null)
                return true;
            return false;
        }

        public IEnumerable<KeyAndValue> GrupaKrwiItems
        {
            get
            {
                return EnumHelper.GetEnumKeyAndValues<GrupaKrwiEnum>();
            }
        }

        public IEnumerable<KeyAndValue> PlecItems
        {
            get
            {
                return EnumHelper.GetEnumKeyAndValues<PlecEnum>();
            }
        }
        #endregion

        #region Komendy
        public override void Save()
        {
            item.CzyAktywny = true;
            item.KiedyDodal = DateTime.Now;
            item.KtoDodal = "AdminSystem";
            item.WersjaDanych = 1;

            medicalEntities.Pacjent.Add(item);
            medicalEntities.SaveChanges();
        }
        #endregion
    }
}