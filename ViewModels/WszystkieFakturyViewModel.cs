using GalaSoft.MvvmLight.Messaging;
using Medical.Models.EntitiesForView;
using Medical.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.ViewModels
{
    public class WszystkieFakturyViewModel : WszystkieViewModel<FakturaForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<FakturaForAllView>
                (
                   medicalEntities.Faktura
                   .Where(faktura => faktura.CzyAktywny == true)
                   .Select(faktura => new FakturaForAllView
                   {
                       IdFaktury = faktura.IdFaktury,
                       Numer = faktura.Numer,
                       DataWystawienia = faktura.DataWystawienia,
                       TerminPlatnosci = faktura.TerminPlatnosci,
                       Waluta = faktura.Waluta,
                       StatusPlatnosci = faktura.StatusPlatnosci,
                       Opis = faktura.Opis,
                       KategoriaKosztu = faktura.KategoriaKosztu,
                       OkresKsiegowy = faktura.OkresKsiegowy,
                       CzyZatwierdzona = faktura.CzyZatwierdzona ? "TAK" : "NIE",
                       NazwaFirmy = faktura.Kontrahent.Nazwa,
                       NazwaSposobuPlatnosci = faktura.SposobPlatnosci.Nazwa
                   })
                   .ToList()
                );
        }
        #endregion

        #region Konstruktor
        public WszystkieFakturyViewModel()
            : base()
        {
            base.DisplayName = "Faktury";
        }
        #endregion

        #region Właściwosci
        private FakturaForAllView _WybranaFaktura;
        public FakturaForAllView WybranaFaktura
        {
            get
            {
                return _WybranaFaktura;
            }
            set
            {
                if (_WybranaFaktura != value)
                {
                    _WybranaFaktura = value;
                    Messenger.Default.Send(_WybranaFaktura);
                    OnRequestClose();
                }
            }
        }
        #endregion

        #region Sortowanie i Filtrowanie
        public override List<string> getComboBoxSortList()
        {
            return new List<string>
    {
        "numer",
        "dataWystawienia",
        "terminPlatnosci",
        "statusPlatnosci",
        "nazwaFirmy",
        "kategoriaKosztu",
        "okresKsiegowy",
        "czyZatwierdzona",
        "waluta",
        "nazwaSposobuPlatnosci"
    };
        }

        public override List<string> getComboBoxFindList()
        {
            return new List<string>
    {
        "numer",
        "nazwaFirmy",
        "statusPlatnosci",
        "kategoriaKosztu",
        "okresKsiegowy",
        "czyZatwierdzona",
        "opis"
    };
        }

        public override void Sort()
        {
            switch (SortField)
            {
                case "numer":
                    List = new ObservableCollection<FakturaForAllView>(List.OrderBy(item => item.Numer));
                    break;
                case "dataWystawienia":
                    List = new ObservableCollection<FakturaForAllView>(List.OrderBy(item => item.DataWystawienia));
                    break;
                case "terminPlatnosci":
                    List = new ObservableCollection<FakturaForAllView>(List.OrderBy(item => item.TerminPlatnosci));
                    break;
                case "statusPlatnosci":
                    List = new ObservableCollection<FakturaForAllView>(List.OrderBy(item => item.StatusPlatnosci));
                    break;
                case "nazwaFirmy":
                    List = new ObservableCollection<FakturaForAllView>(List.OrderBy(item => item.NazwaFirmy));
                    break;
                case "kategoriaKosztu":
                    List = new ObservableCollection<FakturaForAllView>(List.OrderBy(item => item.KategoriaKosztu));
                    break;
                case "okresKsiegowy":
                    List = new ObservableCollection<FakturaForAllView>(List.OrderBy(item => item.OkresKsiegowy));
                    break;
                case "czyZatwierdzona":
                    List = new ObservableCollection<FakturaForAllView>(List.OrderBy(item => item.CzyZatwierdzona));
                    break;
                case "waluta":
                    List = new ObservableCollection<FakturaForAllView>(List.OrderBy(item => item.Waluta));
                    break;
                case "nazwaSposobuPlatnosci":
                    List = new ObservableCollection<FakturaForAllView>(List.OrderBy(item => item.NazwaSposobuPlatnosci));
                    break;
                default:
                    break;
            }
        }

        public override void Find()
        {
            switch (FindField)
            {
                case "numer":
                    List = new ObservableCollection<FakturaForAllView>(List.Where(item =>
                        item.Numer != null && item.Numer.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "nazwaFirmy":
                    List = new ObservableCollection<FakturaForAllView>(List.Where(item =>
                        item.NazwaFirmy != null && item.NazwaFirmy.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "statusPlatnosci":
                    List = new ObservableCollection<FakturaForAllView>(List.Where(item =>
                        item.StatusPlatnosci != null && item.StatusPlatnosci.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "kategoriaKosztu":
                    List = new ObservableCollection<FakturaForAllView>(List.Where(item =>
                        item.KategoriaKosztu != null && item.KategoriaKosztu.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "okresKsiegowy":
                    List = new ObservableCollection<FakturaForAllView>(List.Where(item =>
                        item.OkresKsiegowy != null && item.OkresKsiegowy.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "czyZatwierdzona":
                    List = new ObservableCollection<FakturaForAllView>(List.Where(item =>
                        item.CzyZatwierdzona != null && item.CzyZatwierdzona.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "opis":
                    List = new ObservableCollection<FakturaForAllView>(List.Where(item =>
                        item.Opis != null && item.Opis.Contains(FindTextBox)));
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}