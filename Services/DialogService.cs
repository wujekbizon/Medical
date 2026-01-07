using Medical.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Medical.ViewModels.Dialogs;
using Medical.Views.Dialogs;

namespace Medical.Services
{
    public class DialogService : IDialogService
    {
        public Task<string> ShowInputDialogAsync(string title, string prompt, string defaultValue = "")
        {
            var viewModel = new InputDialogViewModel(title, prompt, defaultValue);
            var dialog = new InputDialogView
            {
                DataContext = viewModel,
                Owner = Application.Current.MainWindow
            };

            var result = dialog.ShowDialog();

            return Task.FromResult(result == true ? viewModel.ResponseText : null);
        }

        public void ShowMessage(string message, string title = "Informacja")
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void ShowError(string message, string title = "Błąd")
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public bool ShowConfirmation(string message, string title = "Potwierdzenie")
        {
            var result = MessageBox.Show(message, title, MessageBoxButton.YesNo, MessageBoxImage.Question);
            return result == MessageBoxResult.Yes;
        }
    }
}
