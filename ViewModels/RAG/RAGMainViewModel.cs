using Medical.Helper;
using Medical.Models.RAG;
using Medical.Services;
using Medical.Services.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;


namespace Medical.ViewModels.RAG
{
    public class RAGMainViewModel : WorkspaceViewModel
    {
        #region Serwisy

        private readonly IRAGService _ragService;
        private readonly IDialogService _dialogService;

        #endregion

        #region Konstruktor

        public RAGMainViewModel()
        {
            base.DisplayName = "RAG - AI Assistant";

            try
            {
                var configService = new ConfigurationService();
                var apiKey = configService.GetGeminiApiKey();
                _ragService = new GeminiRAGService(apiKey);
                _dialogService = new DialogService();

                Stores = new ObservableCollection<FileSearchStore>();

                QueryViewModel = new QueryViewModel(_ragService, _dialogService);

                _ = LoadStoresAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Initialization error: {ex.Message}";
                _dialogService?.ShowError(ex.Message, "RAG Service Error");
            }
        }

        #endregion

        #region Właściwości - Pola

        private FileSearchStore _SelectedStore;
        public FileSearchStore SelectedStore
        {
            get => _SelectedStore;
            set
            {
                if (_SelectedStore != value)
                {
                    _SelectedStore = value;
                    OnPropertyChanged(() => SelectedStore);
                    QueryViewModel.SelectedStoreId = value?.StoreId;
                    OnPropertyChanged(() => CzyMoznaUploadowac);
                    OnPropertyChanged(() => CzyMoznaUsunac);
                }
            }
        }

        private QueryViewModel _QueryViewModel;
        public QueryViewModel QueryViewModel
        {
            get => _QueryViewModel;
            set
            {
                if (_QueryViewModel != value)
                {
                    _QueryViewModel = value;
                    OnPropertyChanged(() => QueryViewModel);
                }
            }
        }

        private bool _IsLoading;
        public bool IsLoading
        {
            get => _IsLoading;
            set
            {
                if (_IsLoading != value)
                {
                    _IsLoading = value;
                    OnPropertyChanged(() => IsLoading);
                }
            }
        }

        private string _StatusMessage;
        public string StatusMessage
        {
            get => _StatusMessage;
            set
            {
                if (_StatusMessage != value)
                {
                    _StatusMessage = value;
                    OnPropertyChanged(() => StatusMessage);
                }
            }
        }

        #endregion

        #region Właściwości - Wyniki

        private ObservableCollection<FileSearchStore> _Stores;
        public ObservableCollection<FileSearchStore> Stores
        {
            get => _Stores;
            set
            {
                if (_Stores != value)
                {
                    _Stores = value;
                    OnPropertyChanged(() => Stores);
                    OnPropertyChanged(() => BrakDanych);
                }
            }
        }

        public bool BrakDanych
        {
            get { return Stores == null || Stores.Count == 0; }
        }

        public bool CzyMoznaUploadowac
        {
            get { return SelectedStore != null; }
        }

        public bool CzyMoznaUsunac
        {
            get { return SelectedStore != null; }
        }

        #endregion

        #region Komendy

        private BaseCommand _CreateStoreCommand;
        public ICommand CreateStoreCommand
        {
            get
            {
                if (_CreateStoreCommand == null)
                {
                    _CreateStoreCommand = new BaseCommand(() => CreateStoreClick());
                }
                return _CreateStoreCommand;
            }
        }

        private BaseCommand _RefreshStoresCommand;
        public ICommand RefreshStoresCommand
        {
            get
            {
                if (_RefreshStoresCommand == null)
                {
                    _RefreshStoresCommand = new BaseCommand(() => RefreshStoresClick());
                }
                return _RefreshStoresCommand;
            }
        }

        private BaseCommand _UploadDocumentCommand;
        public ICommand UploadDocumentCommand
        {
            get
            {
                if (_UploadDocumentCommand == null)
                {
                    _UploadDocumentCommand = new BaseCommand(() => UploadDocumentClick());
                }
                return _UploadDocumentCommand;
            }
        }

        private BaseCommand _DeleteStoreCommand;
        public ICommand DeleteStoreCommand
        {
            get
            {
                if (_DeleteStoreCommand == null)
                {
                    _DeleteStoreCommand = new BaseCommand(() => DeleteStoreClick());
                }
                return _DeleteStoreCommand;
            }
        }

        #endregion

        #region Metody - Obsługa Komend

        private void CreateStoreClick()
        {
            _ = CreateStoreAsync();
        }

        private void RefreshStoresClick()
        {
            _ = LoadStoresAsync();
        }

        private void UploadDocumentClick()
        {
            if (!CzyMoznaUploadowac)
            {
                _dialogService.ShowMessage("Najpierw wybierz store z listy.");
                return;
            }

            _ = UploadDocumentAsync();
        }

        private void DeleteStoreClick()
        {
            if (!CzyMoznaUsunac)
            {
                _dialogService.ShowMessage("Najpierw wybierz store z listy.");
                return;
            }

            _ = DeleteStoreAsync();
        }

        #endregion

        #region Metody - Asynchroniczne Operacje

        private async Task LoadStoresAsync()
        {
            IsLoading = true;
            StatusMessage = "Ładowanie stores...";

            try
            {
                var stores = await _ragService.GetAllStoresAsync();

                Stores.Clear();
                foreach (var store in stores)
                {
                    Stores.Add(store);
                }

                StatusMessage = $"Załadowano {stores.Count} store(s)";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Błąd ładowania stores: {ex.Message}";
                _dialogService.ShowError($"Wystąpił błąd podczas ładowania stores: {ex.Message}");
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task CreateStoreAsync()
        {
            var storeName = await _dialogService.ShowInputDialogAsync(
                "Utwórz File Search Store",
                "Podaj nazwę:");

            if (!string.IsNullOrWhiteSpace(storeName))
            {
                IsLoading = true;
                StatusMessage = "Tworzenie store...";

                try
                {
                    var store = await _ragService.CreateStoreAsync(storeName);
                    Stores.Add(store);
                    SelectedStore = store;
                    StatusMessage = $"Store '{store.DisplayName}' utworzony pomyślnie";

                    _dialogService.ShowMessage($"Store '{store.DisplayName}' został utworzony pomyślnie.", "Sukces");
                }
                catch (Exception ex)
                {
                    StatusMessage = $"Błąd tworzenia store: {ex.Message}";
                    _dialogService.ShowError($"Wystąpił błąd podczas tworzenia store: {ex.Message}");
                }
                finally
                {
                    IsLoading = false;
                }
            }
        }

        private async Task UploadDocumentAsync()
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Documents (*.md;*.txt;*.pdf)|*.md;*.txt;*.pdf|All files (*.*)|*.*",
                Title = "Wybierz dokument do przesłania"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                IsLoading = true;
                StatusMessage = "Przesyłanie i indeksowanie dokumentu...";

                try
                {
                    var metadata = await _ragService.UploadDocumentAsync(
                        openFileDialog.FileName,
                        SelectedStore.StoreId
                    );
                    SelectedStore.TotalDocuments++;

                    StatusMessage = $"Dokument '{metadata.FileName}' przesłany i zaindeksowany pomyślnie";

                    _dialogService.ShowMessage($"Dokument '{metadata.FileName}' został przesłany i zaindeksowany pomyślnie.", "Sukces");
                }
                catch (Exception ex)
                {
                    StatusMessage = $"Błąd przesyłania dokumentu: {ex.Message}";
                    _dialogService.ShowError($"Wystąpił błąd podczas przesyłania dokumentu: {ex.Message}");
                }
                finally
                {
                    IsLoading = false;
                }
            }
        }

        private async Task DeleteStoreAsync()
        {
            var confirmed = _dialogService.ShowConfirmation(
                $"Czy na pewno chcesz usunąć store '{SelectedStore.DisplayName}'?",
                "Potwierdź usunięcie");

            if (confirmed)
            {
                IsLoading = true;
                StatusMessage = "Usuwanie store...";

                try
                {
                    await _ragService.DeleteStoreAsync(SelectedStore.StoreId);
                    Stores.Remove(SelectedStore);
                    SelectedStore = null;
                    StatusMessage = "Store usunięty pomyślnie";

                    _dialogService.ShowMessage("Store został usunięty pomyślnie.", "Sukces");
                }
                catch (Exception ex)
                {
                    StatusMessage = $"Błąd usuwania store: {ex.Message}";
                    _dialogService.ShowError($"Wystąpił błąd podczas usuwania store: {ex.Message}");
                }
                finally
                {
                    IsLoading = false;
                }
            }
        }
        #endregion
    }
}