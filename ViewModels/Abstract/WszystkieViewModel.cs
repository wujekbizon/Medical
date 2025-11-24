using Medical.Helper;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Medical.ViewModels.Abstract
{
    /// <summary>
    /// Abstract base class for all "List All" ViewModels
    /// Provides common functionality for displaying collections of entities
    /// </summary>
    /// <typeparam name="T">The type of entity to display</typeparam>
    public abstract class WszystkieViewModel<T> : WorkspaceViewModel
    {
        #region Fields
        private string _searchText;
        #endregion

        #region Constructor
        protected WszystkieViewModel()
        {
            List = new ObservableCollection<T>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Observable collection of items to display
        /// </summary>
        public ObservableCollection<T> List { get; set; }

        /// <summary>
        /// Search text for filtering
        /// </summary>
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged(() => SearchText);
            }
        }
        #endregion

        #region Commands
        private BaseCommand _loadCommand;
        /// <summary>
        /// Command to load/refresh data from database
        /// </summary>
        public ICommand LoadCommand
        {
            get
            {
                if (_loadCommand == null)
                    _loadCommand = new BaseCommand(Load);
                return _loadCommand;
            }
        }

        private BaseCommand _addCommand;
        /// <summary>
        /// Command to open Add New entity view
        /// </summary>
        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                    _addCommand = new BaseCommand(Add);
                return _addCommand;
            }
        }

        private BaseCommand _searchCommand;
        /// <summary>
        /// Command to perform search/filter
        /// </summary>
        public ICommand SearchCommand
        {
            get
            {
                if (_searchCommand == null)
                    _searchCommand = new BaseCommand(Search);
                return _searchCommand;
            }
        }
        #endregion

        #region Abstract Methods
        /// <summary>
        /// Load data from database - must be implemented by derived class
        /// </summary>
        public abstract void Load();

        /// <summary>
        /// Open Add New entity view - must be implemented by derived class
        /// </summary>
        protected abstract void Add();

        /// <summary>
        /// Perform search/filter - can be overridden by derived class
        /// </summary>
        protected virtual void Search()
        {
            Load(); // Default implementation reloads data
        }
        #endregion
    }
}
