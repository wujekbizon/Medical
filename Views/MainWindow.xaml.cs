using Medical.Helper;
using Medical.Views.Controls;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Medical.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Action Commands

        private void Exit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var result = MessageBox.Show(
                "Czy na pewno chcesz zamknąć aplikację?",
                "Potwierdzenie",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        #endregion

        #region Helper Methods

        public void ShowLoading(string message = "Ładowanie...")
        {
            LoadingOverlay.SetStatus(message);
            LoadingOverlay.Show();
        }

        public void HideLoading()
        {
            LoadingOverlay.Hide();
        }

        #endregion
    }
}