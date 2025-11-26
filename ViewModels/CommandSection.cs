using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.ViewModels
{
    public class CommandSection
    {
        public string SectionName { get; set; }
        public bool ShowSectionHeader { get; set; }
        public List<CommandViewModel> Commands { get; set; }

        public CommandSection()
        {
            Commands = new List<CommandViewModel>();
        }
    }
}
