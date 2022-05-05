using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Planets.Commands
{
    public class SelectPlanetCommand : ICommand
    {
        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
            }

        string name;
        ViewModels.PlanetVM planetVM;

        public SelectPlanetCommand(ViewModels.PlanetVM planetVM)
        {
            this.planetVM = planetVM;
            this.name = planetVM.name;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            planetVM.currentPlanet = planetVM.Planets.FirstOrDefault(x => x.Name == name);
        }
    }
}
