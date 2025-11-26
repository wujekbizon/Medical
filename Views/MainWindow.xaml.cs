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

            // Subscribe to keyboard events for additional handling if needed
            this.PreviewKeyDown += MainWindow_PreviewKeyDown;
        }

        #region Menu Opening Commands (Ctrl+Letter)

        /// <summary>
        /// Opens the Plik (File) menu when Ctrl+P is pressed.
        /// </summary>
        private void OpenFileMenu_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MenuPlik.IsSubmenuOpen = true;
            MenuPlik.Focus();
        }

        /// <summary>
        /// Opens the Pacjenci (Patients) menu when Ctrl+A is pressed.
        /// </summary>
        private void OpenPatientsMenu_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MenuPacjenci.IsSubmenuOpen = true;
            MenuPacjenci.Focus();
        }

        /// <summary>
        /// Opens the Zespoły (Teams) menu when Ctrl+Z is pressed.
        /// </summary>
        private void OpenTeamsMenu_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MenuZespoly.IsSubmenuOpen = true;
            MenuZespoly.Focus();
        }

        /// <summary>
        /// Opens the Pomoc (Help) menu when Ctrl+H is pressed.
        /// </summary>
        private void OpenHelpMenu_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MenuPomoc.IsSubmenuOpen = true;
            MenuPomoc.Focus();
        }

        #endregion

        #region Action Commands

        /// <summary>
        /// Exits the application.
        /// </summary>
        private void Exit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // Ask for confirmation before closing
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

        /// <summary>
        /// Refreshes the current view.
        /// </summary>
        private void Refresh_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // TODO: Implement refresh logic based on current workspace
            ShowStatusMessage("Odświeżanie...");
        }

        /// <summary>
        /// Opens the search functionality.
        /// </summary>
        private void Search_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // TODO: Implement search dialog or focus search box
            ShowStatusMessage("Wyszukiwanie...");
        }

        /// <summary>
        /// Shows the documentation.
        /// </summary>
        private void ShowDocumentation_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // TODO: Open actual documentation window or help file
            ShowStatusMessage("Otwieranie dokumentacji...");
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Shows a temporary status message in the status bar.
        /// </summary>
        private void ShowStatusMessage(string message)
        {
            // This can be extended to update a status bar text binding
            System.Diagnostics.Debug.WriteLine($"Status: {message}");
        }

        /// <summary>
        /// Shows the loading overlay with a custom message.
        /// </summary>
        public void ShowLoading(string message = "Ładowanie...")
        {
            LoadingOverlay.SetStatus(message);
            LoadingOverlay.Show();
        }

        /// <summary>
        /// Hides the loading overlay.
        /// </summary>
        public void HideLoading()
        {
            LoadingOverlay.Hide();
        }

        /// <summary>
        /// Handles additional keyboard shortcuts not covered by InputBindings.
        /// </summary>
        private void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Alt+letter combinations for traditional menu access
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
                    case Key.O: // Alt+O for pOmoc
                        MenuPomoc.IsSubmenuOpen = true;
                        e.Handled = true;
                        break;
                }
            }
        }

        #endregion
    }
}