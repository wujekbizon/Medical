using System.Windows;
using System.Windows.Input;
using Medical.Helper;

namespace Medical.ViewModels.Dialogs
{
    public class InputDialogViewModel : BaseViewModel
    {
        #region Właściwości - Pola

        private string _Title;
        public string Title
        {
            get => _Title;
            set
            {
                if (_Title != value)
                {
                    _Title = value;
                    OnPropertyChanged(() => Title);
                }
            }
        }

        private string _Prompt;
        public string Prompt
        {
            get => _Prompt;
            set
            {
                if (_Prompt != value)
                {
                    _Prompt = value;
                    OnPropertyChanged(() => Prompt);
                }
            }
        }

        private string _ResponseText;
        public string ResponseText
        {
            get => _ResponseText;
            set
            {
                if (_ResponseText != value)
                {
                    _ResponseText = value;
                    OnPropertyChanged(() => ResponseText);
                    OnPropertyChanged(() => CzyMoznaZatwierdzic);
                }
            }
        }

        public bool CzyMoznaZatwierdzic
        {
            get { return !string.IsNullOrWhiteSpace(ResponseText); }
        }

        #endregion

        #region Właściwości - Dialog Result

        public bool? DialogResult { get; private set; }

        #endregion

        #region Konstruktor

        public InputDialogViewModel(string title, string prompt, string defaultValue = "")
        {
            Title = title;
            Prompt = prompt;
            ResponseText = defaultValue;
        }

        #endregion

        #region Komendy

        private BaseCommand _OkCommand;
        public ICommand OkCommand
        {
            get
            {
                if (_OkCommand == null)
                {
                    _OkCommand = new BaseCommand(() => OkClick());
                }
                return _OkCommand;
            }
        }

        private BaseCommand _CancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                if (_CancelCommand == null)
                {
                    _CancelCommand = new BaseCommand(() => CancelClick());
                }
                return _CancelCommand;
            }
        }

        #endregion

        #region Metody - Obsługa Komend

        private void OkClick()
        {
            if (!CzyMoznaZatwierdzic)
            {
                return;
            }

            DialogResult = true;
            RequestClose?.Invoke(this, System.EventArgs.Empty);
        }

        private void CancelClick()
        {
            DialogResult = false;
            RequestClose?.Invoke(this, System.EventArgs.Empty);
        }

        #endregion

        #region Events

        public event System.EventHandler RequestClose;

        #endregion
    }
}