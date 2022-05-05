using Planets.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Planets.Commands
{
    public class SearchCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private MediaVM mediaVM;

        public SearchCommand(MediaVM mediaVM)
        {
            this.mediaVM = mediaVM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            
        }
    }
}
