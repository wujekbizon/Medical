using GalaSoft.MvvmLight.Messaging;
using Material.Icons;
using Medical.Helper;
using Medical.Models.EntitiesForView;
using Medical.ViewModels.RAG;
using Medical.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Medical.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Pola
        private ReadOnlyCollection<CommandSection> _Commands;
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        private bool _isLoading;
        private string _loadingMessage = "Ładowanie...";
        private UserForAllView _CurrentUser;
        #endregion

        #region Właściwości - Pola
        public UserForAllView CurrentUser
        {
            get { return _CurrentUser; }
            set
            {
                if (_CurrentUser != value)
                {
                    _CurrentUser = value;
                    OnPropertyChanged(() => CurrentUser);
                    OnPropertyChanged(() => CurrentUserDisplayName);
                }
            }
        }

        public string CurrentUserDisplayName
        {
            get
            {
                if (CurrentUser == null)
                    return "Nieznany użytkownik";

                return $"{CurrentUser.Name} {CurrentUser.LastName}".Trim();
            }
        }
        #endregion
        #region Komendy

        private BaseCommand _LogoutCommand;
        public ICommand LogoutCommand
        {
            get
            {
                if (_LogoutCommand == null)
                {
                    _LogoutCommand = new BaseCommand(ExecuteLogout);
                }
                return _LogoutCommand;
            }
        }

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
            Messenger.Default.Register<string>(this, open);

            var sections = new List<CommandSection>();

            var aiAssistantSection = new CommandSection
            {
                SectionName = "ASYSTENT AI",
                ShowSectionHeader = true
            };

            aiAssistantSection.Commands.Add(new CommandViewModel(
                "RAG",
                new BaseCommand(() => this.CreateView(new RAGMainViewModel())),
                MaterialIconKind.Brain 
            ));
            sections.Add(aiAssistantSection);

            var businessLogic = new CommandSection
            {
                SectionName = "LOGIKA BIZNESOWA",
                ShowSectionHeader = true
            };

            businessLogic.Commands.Add(new CommandViewModel(
                "Ranking Efektywności",
                new BaseCommand(() => this.CreateView(new RankingEfektywnosciZespolowMedycznychViewModel())),
                MaterialIconKind.Rank));
            businessLogic.Commands.Add(new CommandViewModel(
                "Koszty Utrzymania Karetek",
                new BaseCommand(() => this.CreateView(new KosztyKaretekViewModel())),
                MaterialIconKind.ChartDonut));
            businessLogic.Commands.Add(new CommandViewModel(
                "Akredtacja Placówek",
                new BaseCommand(() => this.CreateView(new AkredytacjaPlacowekViewModel())),
                MaterialIconKind.Certificate));
            sections.Add(businessLogic);

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
                new BaseCommand(() => this.CreateView(new NoweZlecenieWyjazduViewModel(CurrentUser))),
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
                new BaseCommand(() => this.CreateView(new NowaFakturaViewModel(CurrentUser))),
                MaterialIconKind.FileDocumentPlus));
            ksiegoweSection.Commands.Add(new CommandViewModel(
                "Pozycje Faktur",
                new BaseCommand(() => this.ShowAllView<WszystkiePozycjeFakturyViewModel>()),
                MaterialIconKind.FormatListBulleted));
            ksiegoweSection.Commands.Add(new CommandViewModel(
                "Nowa Pozycja",
                new BaseCommand(() => this.CreateView(new NowaPozycjaFakturyViewModel(CurrentUser))),
                MaterialIconKind.FormatListGroupAdd));
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
            ksiegoweSection.Commands.Add(new CommandViewModel(
                "Sposób Płatności",
                new BaseCommand(() => this.CreateView(new NowySposobPlatnosciViewModel())),
                MaterialIconKind.Money));

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
                new BaseCommand(() => this.CreateView(new NowaKaretkaViewModel(CurrentUser))),
                MaterialIconKind.Car2Plus));
            flotaSection.Commands.Add(new CommandViewModel(
                "Historia Napraw",
                new BaseCommand(() => this.ShowAllView<WszystkieHistorieNaprawViewModel>()),
                MaterialIconKind.Tools));
            flotaSection.Commands.Add(new CommandViewModel(
                "Nowa Naprawa",
                new BaseCommand(() => this.CreateView(new NowaHistoriaNaprawViewModel(CurrentUser))),
                MaterialIconKind.Wrench));
            flotaSection.Commands.Add(new CommandViewModel(
                "Koszty Utrzymania",
                new BaseCommand(() => this.ShowAllView<WszystkieKosztyUtrzymaniaViewModel>()),
                MaterialIconKind.CurrencyUsd));
            flotaSection.Commands.Add(new CommandViewModel(
                "Nowy Koszt",
                new BaseCommand(() => this.CreateView(new NoweKosztyUtrzymaniaViewModel(CurrentUser))),
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
                "Skład Zespołów",
                new BaseCommand(() => this.ShowAllView<WszystkieZespolPracownikViewModel>()),
                MaterialIconKind.AccountMultiple));
            zespolySection.Commands.Add(new CommandViewModel(
                "Nowy Członek Zespołu",
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
                new BaseCommand(() => this.CreateView(new NowaUdzielonaPomocViewModel(CurrentUser))),
                MaterialIconKind.PlusBox));
            medyczneSection.Commands.Add(new CommandViewModel(
                "Oceny Zespołów",
                new BaseCommand(() => this.ShowAllView<WszystkieOcenyZespoluViewModel>()),
                MaterialIconKind.StarCircle));
            medyczneSection.Commands.Add(new CommandViewModel(
                "Nowa Ocena",
                new BaseCommand(() => this.CreateView(new NowaOceanZespoluViewModel(CurrentUser))),
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

            OnPropertyChanged(() => HasNoWorkspaces);
        }

        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            //workspace.Dispose();
            this.Workspaces.Remove(workspace);
        }

        #endregion 

        #region Loading State Properties

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                if (_isLoading != value)
                {
                    _isLoading = value;
                    OnPropertyChanged(() => IsLoading);
                }
            }
        }

        public string LoadingMessage
        {
            get { return _loadingMessage; }
            set
            {
                if (_loadingMessage != value)
                {
                    _loadingMessage = value;
                    OnPropertyChanged(() => LoadingMessage);
                }
            }
        }

        public bool HasNoWorkspaces
        {
            get { return _Workspaces == null || _Workspaces.Count == 0; }
        }

        #endregion

        #region Loading Helper Methods

        public void ShowLoading(string message = "Ładowanie...")
        {
            LoadingMessage = message;
            IsLoading = true;
        }

        public void HideLoading()
        {
            IsLoading = false;
        }

        public async Task ExecuteWithLoadingAsync(Func<Task> action, string loadingMessage = "Ładowanie...")
        {
            try
            {
                ShowLoading(loadingMessage);
                await action();
            }
            finally
            {
                HideLoading();
            }
        }

        #endregion

        #region Private Helpers

        private void ExecuteLogout()
        {
            this.Workspaces.Clear();

            var loginView = new Medical.Views.LoginView();
            loginView.Show();

            var currentWindow = System.Windows.Application.Current.Windows
                .OfType<Medical.Views.MainWindow>()
                .FirstOrDefault();

            currentWindow?.Close();
        }


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

        private void open(string name)
        {
            switch (name)
            {
                case "FakturyAdd":
                    CreateView(new NowaFakturaViewModel(CurrentUser));
                    break;
                case "KontrahenciAdd":
                    CreateView(new NowyKontrahentViewModel());
                    break;
                case "PacjenciAdd":
                    CreateView(new NowyPacjentViewModel());
                    break;
                case "PracownicyAdd":
                    CreateView(new NowyPracownikViewModel());
                    break;
                case "Historie NaprawAdd":
                    CreateView(new NowaHistoriaNaprawViewModel(CurrentUser));
                    break;
                case "KaretkiAdd":
                    CreateView(new NowaKaretkaViewModel(CurrentUser));
                    break;
                case "Koszty UtrzymaniaAdd":
                    CreateView(new NoweKosztyUtrzymaniaViewModel(CurrentUser));
                    break;
                case "Oceny ZespolowAdd":
                    CreateView(new NowaOceanZespoluViewModel(CurrentUser));
                    break;
                case "PlacowkiAdd":
                    CreateView(new NowaPlacowkaViewModel());
                    break;
                case "Pozycje FakturAdd":
                    CreateView(new NowaPozycjaFakturyViewModel(CurrentUser));
                    break;
                case "RoleAdd":
                    CreateView(new NowaRolaPracownikaViewModel());
                    break;
                case "SposobyPlatnosciAdd":
                    CreateView(new NowySposobPlatnosciViewModel());
                    break;
                case "Udzielone PomoceAdd":
                    CreateView(new NowaUdzielonaPomocViewModel(CurrentUser));
                    break;
                case "Skład ZespołówAdd":
                    CreateView(new NowyZespolPracownikViewModel());
                    break;
                case "Zespoly RatunkoweAdd":
                    CreateView(new NowyZespolRatunkowyViewModel());
                    break;
                case "WyjazdyAdd":
                    CreateView(new NoweZlecenieWyjazduViewModel(CurrentUser));
                    break;
                case "KontrahenciShow":
                    ShowAllView<WszyscyKontrahenciViewModel>();
                    break;
                case "KaretkiShow":
                    ShowAllView<WszystkieKaretkiViewModel>();
                    break;
                case "FakturyShow":
                    ShowAllView<WszystkieFakturyViewModel>();
                    break;
                case "PlacowkiShow":
                    ShowAllView<WszystkiePlacowkiViewModel>();
                    break;
                case "ZespolyRatunkoweShow":
                    ShowAllView<WszystkieZespolyRatunkoweViewModel>();
                    break;
                case "PracownicyShow":
                    ShowAllView<WszyscyPracownicyViewModel>();
                    break;
                case "ZleceniaWyjazduShow":
                    ShowAllView<WszystkieZleceniaWyjazduViewModel>();
                    break;
                case "PacjenciShow":
                    ShowAllView<WszyscyPacjenciViewModel>();
                    break;
                case "SposobyPlatnosciShow":
                    ShowAllView<WszystkieSposobyPlatnosciViewModel>();
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}