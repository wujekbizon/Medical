using Medical.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Medical.ViewModels
{
    public abstract class WorkspaceViewModel : BaseViewModel
    {
        #region Fields
        private BaseCommand _CloseCommand;
        private BaseCommand _MinimizeCommand;
        #endregion 

        #region Constructor
        public WorkspaceViewModel()
        {
        }
        #endregion 

        #region Commands
        public ICommand CloseCommand
        {
            get
            {
                if (_CloseCommand == null)
                    _CloseCommand = new BaseCommand(() => this.OnRequestClose());
                return _CloseCommand;
            }
        }

        public ICommand MinimizeCommand
        {
            get
            {
                if (_MinimizeCommand == null)
                    _MinimizeCommand = new BaseCommand(() => this.OnRequestMinimize());
                return _MinimizeCommand;
            }
        }

        #endregion

        #region RequestMinimize [event]
        public event EventHandler RequestMinimize;
        protected void OnRequestMinimize()
        {
            EventHandler handler = this.RequestMinimize;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        #endregion

        #region RequestClose [event]
        public event EventHandler RequestClose;
        protected void OnRequestClose()
        {
            EventHandler handler = this.RequestClose;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        #endregion 
    }
}
