using Medical.Helper;
using Medical.Models;
using System;
using System.Windows;
using System.Windows.Input;

namespace Medical.ViewModels.Abstract
{
    /// <summary>
    /// Abstract base class for all "Add/Edit One" ViewModels
    /// Provides common functionality for adding/editing single entities
    /// </summary>
    /// <typeparam name="T">The type of entity to add/edit</typeparam>
    public abstract class JedenViewModel<T> : WorkspaceViewModel where T : class, new()
    {
        #region Fields
        protected readonly MedicalEntities _medicalEntities;
        #endregion

        #region Constructor
        public JedenViewModel()
        {
            _medicalEntities = new MedicalEntities();
            Item = new T();
        }
        #endregion

        #region Properties
        /// <summary>
        /// The entity being added/edited
        /// </summary>
        public T Item { get; set; }
        #endregion

        #region Commands
        private BaseCommand _saveCommand;
        /// <summary>
        /// Command to save changes without closing
        /// </summary>
        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                    _saveCommand = new BaseCommand(Save);
                return _saveCommand;
            }
        }

        private BaseCommand _saveAndCloseCommand;
        /// <summary>
        /// Command to save changes and close the view
        /// </summary>
        public ICommand SaveAndCloseCommand
        {
            get
            {
                if (_saveAndCloseCommand == null)
                    _saveAndCloseCommand = new BaseCommand(SaveAndClose);
                return _saveAndCloseCommand;
            }
        }

        private BaseCommand _cancelCommand;
        /// <summary>
        /// Command to cancel changes and close the view
        /// </summary>
        public ICommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null)
                    _cancelCommand = new BaseCommand(Cancel);
                return _cancelCommand;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Save changes to database
        /// </summary>
        protected virtual void Save()
        {
            try
            {
                _medicalEntities.SaveChanges();
                MessageBox.Show("Zmiany zostały zapisane pomyślnie.",
                    "Sukces",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas zapisywania: {ex.Message}",
                    "Błąd",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Save changes and close the view
        /// </summary>
        private void SaveAndClose()
        {
            Save();
            OnRequestClose();
        }

        /// <summary>
        /// Cancel changes and close the view
        /// </summary>
        private void Cancel()
        {
            OnRequestClose();
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
