using Material.Icons;
using Medical.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Medical.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields
        private ReadOnlyCollection<CommandSection> _Commands;
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        #endregion

        #region Commands
        

        public ReadOnlyCollection<CommandSection> Commands 
        {
            get
            {
                if (_Commands == null)
                {
                    List<CommandSection> cmds = this.CreateCommands();
                    _Commands = new ReadOnlyCollection<CommandSection>(cmds);
                }
                return _Commands;
            }
        }

        private List<CommandSection> CreateCommands()
        {
            var sections = new List<CommandSection>();

            var aktywneSection = new CommandSection
            {
                SectionName = "AKTYWNE",
                ShowSectionHeader = true
            };
            aktywneSection.Commands.Add(new CommandViewModel(
                "Pacjenci",
                new BaseCommand(() => this.ShowAllView<WszyscyPacjenciViewModel>()),
                MaterialIconKind.AccountMultiple));
            aktywneSection.Commands.Add(new CommandViewModel(
                "Nowy Pacjent",
                new BaseCommand(() => this.CreateView(new NowyPacjentViewModel())),
                MaterialIconKind.AccountPlus));
            aktywneSection.Commands.Add(new CommandViewModel(
                "Zespoły Ratunkowe",
                new BaseCommand(() => this.ShowAllView<WszystkieZespolyRatunkoweViewModel>()),
                MaterialIconKind.AccountGroup));
            aktywneSection.Commands.Add(new CommandViewModel(
                "Zlecenie Wyjazdu",
                new BaseCommand(() => this.CreateView(new NoweZlecenieWyjazduViewModel())),
                MaterialIconKind.ClipboardText));
            sections.Add(aktywneSection);

            var ksiegoweSection = new CommandSection
            {
                SectionName = "KSIĘGOWE",
                ShowSectionHeader = true
            };
            ksiegoweSection.Commands.Add(new CommandViewModel(
                "Wszystkie Faktury",
                new BaseCommand(() => this.ShowAllView<WszystkieFakturyViewModel>()),
                MaterialIconKind.FileDocument));
            ksiegoweSection.Commands.Add(new CommandViewModel(
                "Nowa Faktura",
                new BaseCommand(() => this.CreateView(new NowaFakturaViewModel())),
                MaterialIconKind.FileDocumentPlus));
            ksiegoweSection.Commands.Add(new CommandViewModel(
                "Pozycje Faktur",
                new BaseCommand(() => this.ShowAllView<WszystkiePozycjeFakturyViewModel>()),
                MaterialIconKind.FormatListBulleted));
            ksiegoweSection.Commands.Add(new CommandViewModel(
                "Kontrahenci",
                new BaseCommand(() => this.ShowAllView<WszyscyKontrahenciViewModel>()),
                MaterialIconKind.Domain));
            ksiegoweSection.Commands.Add(new CommandViewModel(
                "Nowy Kontrahent",
                new BaseCommand(() => this.CreateView(new NowyKontrahentViewModel())),
                MaterialIconKind.DomainPlus));
            ksiegoweSection.Commands.Add(new CommandViewModel(
                "Sposoby Płatności",
                new BaseCommand(() => this.ShowAllView<WszystkieSposobyPlatnosciViewModel>()),
                MaterialIconKind.CreditCard));
            sections.Add(ksiegoweSection);

            var flotaSection = new CommandSection
            {
                SectionName = "UTRZYMANIE FLOTY",
                ShowSectionHeader = true
            };
            flotaSection.Commands.Add(new CommandViewModel(
                "Wszystkie Karetki",
                new BaseCommand(() => this.ShowAllView<WszystkieKaretkiViewModel>()),
                MaterialIconKind.Ambulance));
            flotaSection.Commands.Add(new CommandViewModel(
                "Nowa Karetka",
                new BaseCommand(() => this.CreateView(new NowaKaretkaViewModel())),
                MaterialIconKind.Car2Plus));
            flotaSection.Commands.Add(new CommandViewModel(
                "Historia Napraw",
                new BaseCommand(() => this.ShowAllView<WszystkieHistorieNaprawViewModel>()),
                MaterialIconKind.Tools));
            flotaSection.Commands.Add(new CommandViewModel(
                "Nowa Naprawa",
                new BaseCommand(() => this.CreateView(new NowaHistoriaNaprawViewModel())),
                MaterialIconKind.Wrench));
            flotaSection.Commands.Add(new CommandViewModel(
                "Koszty Utrzymania",
                new BaseCommand(() => this.ShowAllView<WszystkieKosztyUtrzymaniaViewModel>()),
                MaterialIconKind.CurrencyUsd));
            flotaSection.Commands.Add(new CommandViewModel(
                "Nowy Koszt",
                new BaseCommand(() => this.CreateView(new NoweKosztyUtrzymaniaViewModel())),
                MaterialIconKind.CashPlus));
            sections.Add(flotaSection);

            var zespolySection = new CommandSection
            {
                SectionName = "ZESPOŁY I PRACOWNICY",
                ShowSectionHeader = true
            };
            zespolySection.Commands.Add(new CommandViewModel(
                "Pracownicy",
                new BaseCommand(() => this.ShowAllView<WszyscyPracownicyViewModel>()),
                MaterialIconKind.PeopleGroup));
            zespolySection.Commands.Add(new CommandViewModel(
                "Nowy Pracownik",
                new BaseCommand(() => this.CreateView(new NowyPracownikViewModel())),
                MaterialIconKind.AccountPlus));
            zespolySection.Commands.Add(new CommandViewModel(
                "Zespoły-Pracownicy",
                new BaseCommand(() => this.ShowAllView<WszystkieZespolPracownikViewModel>()),
                MaterialIconKind.AccountMultiple));
            zespolySection.Commands.Add(new CommandViewModel(
                "Nowy Zespół-Pracownik",
                new BaseCommand(() => this.CreateView(new NowyZespolPracownikViewModel())),
                MaterialIconKind.AccountPlusOutline));
            zespolySection.Commands.Add(new CommandViewModel(
                "Nowy Zespół Ratunkowy",
                new BaseCommand(() => this.CreateView(new NowyZespolRatunkowyViewModel())),
                MaterialIconKind.AccountGroupOutline));
            zespolySection.Commands.Add(new CommandViewModel(
                "Role Pracowników",
                new BaseCommand(() => this.ShowAllView<WszystkieRolePracownikaViewModel>()),
                MaterialIconKind.AccountKey));
            zespolySection.Commands.Add(new CommandViewModel(
                "Nowa Rola",
                new BaseCommand(() => this.CreateView(new NowaRolaPracownikaViewModel())),
                MaterialIconKind.KeyPlus));
            sections.Add(zespolySection);

            var medyczneSection = new CommandSection
            {
                SectionName = "MEDYCZNE",
                ShowSectionHeader = true
            };
            medyczneSection.Commands.Add(new CommandViewModel(
                "Udzielone Pomoce",
                new BaseCommand(() => this.ShowAllView<WszystkieUdzielonePomoceViewModel>()),
                MaterialIconKind.MedicalBag));
            medyczneSection.Commands.Add(new CommandViewModel(
                "Nowa Pomoc",
                new BaseCommand(() => this.CreateView(new NowaUdzielonaPomocViewModel())),
                MaterialIconKind.PlusBox));
            medyczneSection.Commands.Add(new CommandViewModel(
                "Oceny Zespołów",
                new BaseCommand(() => this.ShowAllView<WszystkieOcenyZespoluViewModel>()),
                MaterialIconKind.StarCircle));
            medyczneSection.Commands.Add(new CommandViewModel(
                "Nowa Ocena",
                new BaseCommand(() => this.CreateView(new NowaOceanZespoluViewModel())),
                MaterialIconKind.StarPlus));
            medyczneSection.Commands.Add(new CommandViewModel(
                "Zlecenia Wyjazdu",
                new BaseCommand(() => this.ShowAllView<WszystkieZleceniaWyjazduViewModel>()),
                MaterialIconKind.ClipboardList));
            sections.Add(medyczneSection);

            var placowkiSection = new CommandSection
            {
                SectionName = "PLACÓWKI",
                ShowSectionHeader = true
            };
            placowkiSection.Commands.Add(new CommandViewModel(
                "Wszystkie Placówki",
                new BaseCommand(() => this.ShowAllView<WszystkiePlacowkiViewModel>()),
                MaterialIconKind.Hospital));
            placowkiSection.Commands.Add(new CommandViewModel(
                "Nowa Placówka",
                new BaseCommand(() => this.CreateView(new NowaPlacowkaViewModel())),
                MaterialIconKind.HospitalBuilding));
            sections.Add(placowkiSection);

            return sections;
        }
        #endregion

        #region Workspaces
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.OnWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }
        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            //workspace.Dispos();
            this.Workspaces.Remove(workspace);
        }

        #endregion // Workspaces

        #region Private Helpers

        private void CreateView(WorkspaceViewModel workspace)
        {
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllView<T>() where T : WorkspaceViewModel, new()
        {
            T workspace = this.Workspaces.OfType<T>().FirstOrDefault();
            if (workspace == null)
            {
                workspace = new T();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }
        #endregion
    }
}
