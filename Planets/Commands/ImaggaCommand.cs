using Planets.ViewModels;
using Planets.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Planets.Commands
{
    public class ImaggaCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public ImaggaCommand()
        {
            
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            new ImaggaV(parameter.ToString()).Show();
        }
    }
}
