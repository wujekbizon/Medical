using System.Security;
using System.Windows;
using System.Windows.Controls;


namespace Medical.Views.Controls
{
    public partial class BindablePasswordBox : UserControl
    {
        public static readonly DependencyProperty PasswordProperty =
             DependencyProperty.Register("Password", typeof(SecureString), typeof(BindablePasswordBox), new PropertyMetadata(null));

        public SecureString Password 
        {
            get { return (SecureString)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }
        public BindablePasswordBox()
        {
            InitializeComponent();
            PasswordInput.PasswordChanged += OnPasswordChanged;
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            Password = PasswordInput.SecurePassword;
        }
    }
}
