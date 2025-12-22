using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.ViewModels
{
    public class LoginViewModel : WorkspaceViewModel
    {
        public LoginViewModel()
        {
        }

        private void ExecuteLogin()
        {
            var mainWin = new Medical.Views.MainWindow();
            mainWin.DataContext = new Medical.ViewModels.MainWindowViewModel();
            mainWin.Show();

            this.OnRequestClose();
        }
    }
}
