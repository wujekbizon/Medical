using System;
using System.Windows.Input;

namespace Medical.Helper
{
    /// <summary>
    /// Static class containing routed commands for menu keyboard shortcuts.
    /// These commands can be bound to menu items and invoked via keyboard shortcuts.
    /// </summary>
    public static class MenuCommands
    {
        // File Menu Commands
        public static readonly RoutedUICommand OpenFileMenu = new RoutedUICommand(
              "Open Help Menu",
              "OpenFileMenu",
              typeof(MenuCommands),
              new InputGestureCollection { new KeyGesture(Key.P, ModifierKeys.Control) });

        public static readonly RoutedUICommand NewRecord = new RoutedUICommand(
            "Nowy rekord",
            "NewRecord",
            typeof(MenuCommands),
            new InputGestureCollection { new KeyGesture(Key.N, ModifierKeys.Control) });

        public static readonly RoutedUICommand OpenFile = new RoutedUICommand(
            "Otwórz",
            "OpenFile",
            typeof(MenuCommands),
            new InputGestureCollection { new KeyGesture(Key.O, ModifierKeys.Control) });

        public static readonly RoutedUICommand Settings = new RoutedUICommand(
            "Ustawienia",
            "Settings",
            typeof(MenuCommands),
            new InputGestureCollection { new KeyGesture(Key.OemComma, ModifierKeys.Control) });

        public static readonly RoutedUICommand Exit = new RoutedUICommand(
            "Wyjście",
            "Exit",
            typeof(MenuCommands),
            new InputGestureCollection { new KeyGesture(Key.Q, ModifierKeys.Control) });

        public static readonly RoutedUICommand OpenPatientsMenu = new RoutedUICommand(
            "Otwórz menu Pacjenci",
            "OpenPatientsMenu",
            typeof(MenuCommands),
            new InputGestureCollection { new KeyGesture(Key.A, ModifierKeys.Control) });

        public static readonly RoutedUICommand AllPatients = new RoutedUICommand(
            "Wszyscy Pacjenci",
            "AllPatients",
            typeof(MenuCommands),
            new InputGestureCollection { new KeyGesture(Key.A, ModifierKeys.Control | ModifierKeys.Shift) });

        public static readonly RoutedUICommand NewPatient = new RoutedUICommand(
            "Nowy Pacjent",
            "NewPatient",
            typeof(MenuCommands),
            new InputGestureCollection { new KeyGesture(Key.P, ModifierKeys.Control | ModifierKeys.Shift) });

        // Teams Menu Commands
        public static readonly RoutedUICommand OpenTeamsMenu = new RoutedUICommand(
            "Otwórz menu Zespoły",
            "OpenTeamsMenu",
            typeof(MenuCommands),
            new InputGestureCollection { new KeyGesture(Key.Z, ModifierKeys.Control) });

        public static readonly RoutedUICommand EmergencyTeams = new RoutedUICommand(
            "Zespoły Ratunkowe",
            "EmergencyTeams",
            typeof(MenuCommands),
            new InputGestureCollection { new KeyGesture(Key.T, ModifierKeys.Control | ModifierKeys.Shift) });

        public static readonly RoutedUICommand Employees = new RoutedUICommand(
            "Pracownicy",
            "Employees",
            typeof(MenuCommands),
            new InputGestureCollection { new KeyGesture(Key.E, ModifierKeys.Control | ModifierKeys.Shift) });

        // Help Menu Commands
        public static readonly RoutedUICommand OpenHelpMenu = new RoutedUICommand(
            "Otwórz menu Pomoc",
            "OpenHelpMenu",
            typeof(MenuCommands),
            new InputGestureCollection { new KeyGesture(Key.H, ModifierKeys.Control) });

        public static readonly RoutedUICommand ShowDocumentation = new RoutedUICommand(
            "Dokumentacja",
            "ShowDocumentation",
            typeof(MenuCommands),
            new InputGestureCollection { new KeyGesture(Key.F1) });

        public static readonly RoutedUICommand ShowAbout = new RoutedUICommand(
            "O programie",
            "ShowAbout",
            typeof(MenuCommands),
            new InputGestureCollection { new KeyGesture(Key.F1, ModifierKeys.Shift) });

        // General Commands
        public static readonly RoutedUICommand Refresh = new RoutedUICommand(
            "Odśwież",
            "Refresh",
            typeof(MenuCommands),
            new InputGestureCollection { new KeyGesture(Key.F5) });

        public static readonly RoutedUICommand Print = new RoutedUICommand(
            "Drukuj",
            "Print",
            typeof(MenuCommands),
            new InputGestureCollection { new KeyGesture(Key.P, ModifierKeys.Control | ModifierKeys.Shift) });

        public static readonly RoutedUICommand Search = new RoutedUICommand(
            "Wyszukaj",
            "Search",
            typeof(MenuCommands),
            new InputGestureCollection { new KeyGesture(Key.F, ModifierKeys.Control) });

        public static readonly RoutedUICommand Export = new RoutedUICommand(
            "Eksport",
            "Export",
            typeof(MenuCommands),
            new InputGestureCollection { new KeyGesture(Key.E, ModifierKeys.Control) });

        // Dispatch Command
        public static readonly RoutedUICommand NewDispatch = new RoutedUICommand(
            "Nowe Zlecenie Wyjazdu",
            "NewDispatch",
            typeof(MenuCommands),
            new InputGestureCollection { new KeyGesture(Key.D, ModifierKeys.Control | ModifierKeys.Shift) });
    }
}