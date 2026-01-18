using Medical.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace Medical.Views
{
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();

            this.DataContextChanged += (s, e) =>
            {
                if (e.NewValue is WorkspaceViewModel vm)
                {
                    vm.RequestClose += (sender, args) => this.Close();
                    vm.RequestMinimize += (sender, args) => this.WindowState = WindowState.Minimized;
                }
            };
        }

        private void WindowMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
