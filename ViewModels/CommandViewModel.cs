using Material.Icons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Medical.ViewModels
{
    public class CommandViewModel : BaseViewModel
    {
        #region Properties
        public ICommand Command { get; private set; }
        public MaterialIconKind IconKind { get; private set; }
    
        #endregion


        #region Constructor
        public CommandViewModel(string displayName, ICommand command, MaterialIconKind iconKind = MaterialIconKind.Circle)
        {
            if (command == null)
                throw new ArgumentNullException("command");
            this.DisplayName = displayName;
            this.Command = command;
            this.IconKind = iconKind;
        }
        #endregion

    }
}
