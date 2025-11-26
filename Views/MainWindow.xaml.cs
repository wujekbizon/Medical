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
            this.PreviewKeyDown += MainWindow_PreviewKeyDown;
        }

        #region Theme Toggle Logic

        private void ThemeToggle_Checked(object sender, RoutedEventArgs e)
        {
            ThemeHelper.SetTheme(isDark: true);
        }

        private void ThemeToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            ThemeHelper.SetTheme(isDark: false);
        }

        #endregion

        #region Menu Opening Commands (Ctrl+Letter)

        private void OpenFileMenu_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MenuPlik.IsSubmenuOpen = true;
            MenuPlik.Focus();
        }

        private void OpenPatientsMenu_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MenuPacjenci.IsSubmenuOpen = true;
            MenuPacjenci.Focus();
        }

        private void OpenTeamsMenu_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MenuZespoly.IsSubmenuOpen = true;
            MenuZespoly.Focus();
        }

        private void OpenHelpMenu_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MenuPomoc.IsSubmenuOpen = true;
            MenuPomoc.Focus();
        }

        #endregion

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

        private void Refresh_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ShowStatusMessage("Odświeżanie...");
        }

        private void Search_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ShowStatusMessage("Wyszukiwanie...");
        }

        private void ShowDocumentation_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ShowStatusMessage("Otwieranie dokumentacji...");
        }

        #endregion

        #region Helper Methods

        private void ShowStatusMessage(string message)
        {
            System.Diagnostics.Debug.WriteLine($"Status: {message}");
        }

        public void ShowLoading(string message = "Ładowanie...")
        {
            LoadingOverlay.SetStatus(message);
            LoadingOverlay.Show();
        }

        public void HideLoading()
        {
            LoadingOverlay.Hide();
        }

        private void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Alt)
            {
                switch (e.SystemKey)
                {
                    case Key.P:
                        MenuPlik.IsSubmenuOpen = true;
                        e.Handled = true;
                        break;
                    case Key.A:
                        MenuPacjenci.IsSubmenuOpen = true;
                        e.Handled = true;
                        break;
                    case Key.Z:
                        MenuZespoly.IsSubmenuOpen = true;
                        e.Handled = true;
                        break;
                    case Key.O:
                        MenuPomoc.IsSubmenuOpen = true;
                        e.Handled = true;
                        break;
                }
            }
        }

        #endregion
    }
}