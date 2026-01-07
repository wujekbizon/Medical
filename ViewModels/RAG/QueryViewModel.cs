using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Medical.Helper;
using Medical.Models.RAG;
using Medical.Services.Interfaces;

namespace Medical.ViewModels.RAG
{
    public class QueryViewModel : BaseViewModel
    {
        #region Serwisy
        private readonly IRAGService _ragService;
        private readonly IDialogService _dialogService;

        #endregion

        #region Konstruktor

        public QueryViewModel(IRAGService ragService, IDialogService dialogService)
        {
            _ragService = ragService;
            _dialogService = dialogService;
            Citations = new ObservableCollection<Citation>();
        }

        #endregion

        #region Właściwości - Pola

        private string _QueryText;
        public string QueryText
        {
            get => _QueryText;
            set
            {
                if (_QueryText != value)
                {
                    _QueryText = value;
                    OnPropertyChanged(() => QueryText);
                    OnPropertyChanged(() => CzyMoznaWykonacQuery);
                }
            }
        }

        private string _SelectedStoreId;
        public string SelectedStoreId
        {
            get => _SelectedStoreId;
            set
            {
                if (_SelectedStoreId != value)
                {
                    _SelectedStoreId = value;
                    OnPropertyChanged(() => SelectedStoreId);
                    OnPropertyChanged(() => CzyMoznaWykonacQuery);
                }
            }
        }

        private bool _IsQuerying;
        public bool IsQuerying
        {
            get => _IsQuerying;
            set
            {
                if (_IsQuerying != value)
                {
                    _IsQuerying = value;
                    OnPropertyChanged(() => IsQuerying);
                }
            }
        }

        private RAGResponse _CurrentResponse;
        public RAGResponse CurrentResponse
        {
            get => _CurrentResponse;
            set
            {
                if (_CurrentResponse != value)
                {
                    _CurrentResponse = value;
                    OnPropertyChanged(() => CurrentResponse);
                    OnPropertyChanged(() => CzyJestOdpowiedz);
                }
            }
        }

        #endregion

        #region Właściwości - Wyniki

        private ObservableCollection<Citation> _Citations;
        public ObservableCollection<Citation> Citations
        {
            get => _Citations;
            set
            {
                if (_Citations != value)
                {
                    _Citations = value;
                    OnPropertyChanged(() => Citations);
                }
            }
        }

        public bool CzyJestOdpowiedz
        {
            get { return CurrentResponse != null; }
        }

        public bool CzyMoznaWykonacQuery
        {
            get
            {
                return !string.IsNullOrWhiteSpace(QueryText) &&
                       !string.IsNullOrWhiteSpace(SelectedStoreId);
            }
        }

        #endregion

        #region Komendy

        private BaseCommand _ExecuteQueryCommand;
        public ICommand ExecuteQueryCommand
        {
            get
            {
                if (_ExecuteQueryCommand == null)
                {
                    _ExecuteQueryCommand = new BaseCommand(() => ExecuteQueryClick());
                }
                return _ExecuteQueryCommand;
            }
        }

        private BaseCommand _ClearQueryCommand;
        public ICommand ClearQueryCommand
        {
            get
            {
                if (_ClearQueryCommand == null)
                {
                    _ClearQueryCommand = new BaseCommand(() => ClearQuery());
                }
                return _ClearQueryCommand;
            }
        }

        #endregion

        #region Metody - Obsługa Komend

        private void ExecuteQueryClick()
        {
            if (!CzyMoznaWykonacQuery)
            {
                _dialogService.ShowMessage("Wpisz pytanie i wybierz store.");
                return;
            }

            _ = ExecuteQueryAsync();
        }

        private void ClearQuery()
        {
            QueryText = string.Empty;
            CurrentResponse = null;
            Citations.Clear();
        }

        #endregion

        #region Metody - Asynchroniczne Operacje

        private async Task ExecuteQueryAsync()
        {
            IsQuerying = true;
            Citations.Clear();
            CurrentResponse = null;

            try
            {
                var query = new RAGQuery
                {
                    QueryText = QueryText,
                    StoreId = SelectedStoreId
                };

                var response = await _ragService.QueryAsync(query);

                CurrentResponse = response;

                Citations.Clear();
                foreach (var citation in response.Citations)
                {
                    Citations.Add(citation);
                }
            }
            catch (Exception ex)
            {
                _dialogService.ShowError($"Wystąpił błąd podczas wykonywania zapytania: {ex.Message}");
            }
            finally
            {
                IsQuerying = false;
            }
        }

        #endregion
    }
}