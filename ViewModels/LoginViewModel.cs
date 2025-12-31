using Medical.Helper;
using Medical.Models;
using Medical.Models.BusinessLogic;
using Medical.Views;
using System;
using System.Net;
using System.Security;
using System.Windows.Input;

namespace Medical.ViewModels
{
    public class LoginViewModel : WorkspaceViewModel
    {

        #region Baza Danych
        private readonly MedicalEntities medicalEntities;
        private readonly UserRepository userRepository;
        #endregion

        #region Konstruktor
        public LoginViewModel()
        {
            //base.DisplayName = "Logowanie";
            IsViewVisible = true;
            medicalEntities = new MedicalEntities();
            userRepository = new UserRepository(medicalEntities);
        }
        #endregion

        #region Wlasciowsci - Pola
        private string _Username;
        public string Username
        {
            get { return _Username; }
            set
            {
                if (_Username != value)
                {
                    _Username = value;
                    OnPropertyChanged(() => Username);
                    _LoginCommand?.RaiseCanExecuteChanged();
                }
            }
        }

        private SecureString _Password;
        public SecureString Password
        {
            get { return _Password; }
            set
            {
                if (_Password != value)
                {
                    _Password = value;
                    OnPropertyChanged(() => Password);
                    _LoginCommand?.RaiseCanExecuteChanged();
                }
            }
        }

        private string _ErrorMessage;
        public string ErrorMessage
        {
            get { return _ErrorMessage; }
            set
            {
                if (_ErrorMessage != value)
                {
                    _ErrorMessage = value;
                    OnPropertyChanged(() => ErrorMessage);
                }
            }
        }

        private bool _IsViewVisible;
        public bool IsViewVisible
        {
            get { return _IsViewVisible; }
            set
            {
                if (_IsViewVisible != value)
                {
                    _IsViewVisible = value;
                    OnPropertyChanged(() => IsViewVisible);
                }
            }
        }
        #endregion
        #region Komendy
        private BaseCommand _LoginCommand;
        public ICommand LoginCommand
        {
            get
            {
                if (_LoginCommand == null)
                {
                    _LoginCommand = new BaseCommand(ExecuteLogin, CanExecuteLoginCommand);
                    //_RecoverPasswordCommand = new BaseCommand(() => ExecuteRecoverPassword("",""));
                }
                return _LoginCommand;
            }
        }

        private void ExecuteLogin()
        {
            try
            {
                var credential = new NetworkCredential(Username, Password);

                if (userRepository.AuthenticateUser(credential))
                {
                    ErrorMessage = string.Empty;

                    var currentUser = userRepository.GetUserByUsername(Username);

                    var mainViewModel = new MainWindowViewModel
                    {
                        CurrentUser = currentUser
                    };

                    var mainWin = new MainWindow
                    {
                        DataContext = mainViewModel
                    };
                    mainWin.Show();

                    this.OnRequestClose();
                }
                else
                {
                    ErrorMessage = "Nieprawidłowa nazwa użytkownika lub hasło.";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Błąd logowania: {ex.Message}";
            }
        }

        private bool CanExecuteLoginCommand()
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 || Password == null || Password.Length < 3)
                validData = false;
            else
                validData = true;
            return validData;
        }

        private BaseCommand _RecoverPasswordCommand;
        public ICommand RecoverPasswordCommand
        {
            get
            {
                if (_RecoverPasswordCommand == null)
                {
                    _RecoverPasswordCommand = new BaseCommand(() => ExecuteRecoverPassword("",""));
                }
                return _RecoverPasswordCommand;
            }
        }

        private void ExecuteRecoverPassword(string Username, string Email)
        {
            System.Windows.MessageBox.Show(
                       "Email z odzyskiwaniem hasła wysłany.",
                       "Informacja",
                       System.Windows.MessageBoxButton.OK,
                       System.Windows.MessageBoxImage.Information);
        }
        #endregion

    }
}
