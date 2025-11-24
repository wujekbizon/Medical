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
        private ReadOnlyCollection<CommandViewModel> _Commands;
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        #endregion

        #region Commands
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_Commands == null)
                {
                    List<CommandViewModel> cmds = this.CreateCommands();
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _Commands;
            }
        }
        private List<CommandViewModel> CreateCommands()
        {
            return new List<CommandViewModel>
            {
               new CommandViewModel(
                   "Karetki",
                   new BaseCommand(() => this.ShowAllView<WszystkieKaretkiViewModel>())),
               new CommandViewModel(
                   "Faktury",
                   new BaseCommand(() => this.ShowAllView<WszystkieFakturyViewModel>())),
               new CommandViewModel(
                   "Kontrahenci",
                   new BaseCommand(() => this.ShowAllView<WszyscyKontrahenciViewModel>())),
               new CommandViewModel(
                   "Pacjenci",
                   new BaseCommand(() => this.ShowAllView<WszyscyPacjenciViewModel>())),
               new CommandViewModel(
                   "Pracownicy",
                   new BaseCommand(() => this.ShowAllView<WszystkieHistorieNaprawViewModel>())),
               new CommandViewModel(
                   "Historie Napraw",
                   new BaseCommand(() => this.ShowAllView<WszystkieKosztyUtrzymaniaViewModel>())),
               new CommandViewModel(
                   "Koszty Utrzymania",
                   new BaseCommand(() => this.ShowAllView<WszystkieOcenyZespoluViewModel>())),
               new CommandViewModel(
                   "Oceny Zespolow",
                   new BaseCommand(() => this.ShowAllView<WszystkiePlacowkiViewModel>())),
               new CommandViewModel(
                   "Placowki",
                   new BaseCommand(() => this.ShowAllView<WszystkiePozycjeFakturyViewModel>())),
               new CommandViewModel(
                   "Pozycje Faktur",
                   new BaseCommand(() => this.ShowAllView<WszystkieRolePracownikaViewModel>())),
               new CommandViewModel(
                   "Role",
                   new BaseCommand(() => this.ShowAllView<WszystkieSposobyPlatnosciViewModel>())),
               new CommandViewModel(
                   "SposobyPlatnosci",
                   new BaseCommand(() => this.ShowAllView<WszystkieUdzielonePomoceViewModel>())),
               new CommandViewModel(
                   "Udzielone Pomoce",
                   new BaseCommand(() => this.ShowAllView<WszystkieZespolPracownikViewModel>())),
               new CommandViewModel(
                   "Zespoly-Pracownicy",
                   new BaseCommand(() => this.ShowAllView<WszystkieZespolyRatunkoweViewModel>())),
               new CommandViewModel(
                   "Zespoly Ratunkowe",
                   new BaseCommand(() => this.ShowAllView<WszystkieZleceniaWyjazduViewModel>())),
               new CommandViewModel(
                   "Wyjazdy",
                   new BaseCommand(() => this.ShowAllView<WszystkieFakturyViewModel>())),
               new CommandViewModel(
                   "Karetka",
                   new BaseCommand(() => this.CreateView(new NowaKaretkaViewModel()))),
               new CommandViewModel(
                   "Faktura",
                   new BaseCommand(() => this.CreateView(new NowaFakturaViewModel()))),
               new CommandViewModel(
                   "Historia Napraw",
                   new BaseCommand(() => this.CreateView(new NowaHistoriaNaprawViewModel()))),
               new CommandViewModel(
                   "Ocena Zespolu",
                   new BaseCommand(() => this.CreateView(new NowaPlacowkaViewModel()))),
               new CommandViewModel(
                   "Placowka",
                   new BaseCommand(() => this.CreateView(new NowaPozycjaFakturyViewModel()))),
               new CommandViewModel(
                   "Pozycja Faktury",
                   new BaseCommand(() => this.CreateView(new NowaRolaPracownikaViewModel()))),
               new CommandViewModel(
                   "Rola",
                   new BaseCommand(() => this.CreateView(new NowaUdzielonaPomocViewModel()))),
               new CommandViewModel(
                   "Udzielona Pomoc",
                   new BaseCommand(() => this.CreateView(new NoweKosztyUtrzymaniaViewModel()))),
               new CommandViewModel(
                   "Koszt Utrzymania",
                   new BaseCommand(() => this.CreateView(new NoweZlecenieWyjazduViewModel()))),
               new CommandViewModel(
                   "Zlecenie Wyjazdu",
                   new BaseCommand(() => this.CreateView(new NowaOceanZespoluViewModel()))),
               new CommandViewModel(
                   "Kontrahent",
                   new BaseCommand(() => this.CreateView(new NowyKontrahentViewModel()))),
               new CommandViewModel(
                   "Pacjent",
                   new BaseCommand(() => this.CreateView(new NowyPacjentViewModel()))),
               new CommandViewModel(
                   "Placowka",
                   new BaseCommand(() => this.CreateView(new NowaPlacowkaViewModel()))),
               new CommandViewModel(
                   "Sposob Platnosci",
                   new BaseCommand(() => this.CreateView(new NowySposbobPlatnosciViewModel()))),
               new CommandViewModel(
                   "Zespol-Pracownik",
                   new BaseCommand(() => this.CreateView(new NowyZespolPracownikViewModel()))),
               new CommandViewModel(
                   "Zespol Ratunkowy",
                   new BaseCommand(() => this.CreateView(new NowyZespolRatunkowyViewModel()))),
     
            };
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
