using PlanetsBE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planets.Commands;
using System.ComponentModel;
using Planets.Models;

namespace Planets.ViewModels
{
    public class PlanetVM : INotifyPropertyChanged
    {
        private PlanetM planetM;
        public string name;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Planet> Planets { get; set; }

        public Planet currentPlanet
        {
            get { return planetM.currentPlanet; }
            set
            {
                planetM.currentPlanet = value;
                if (null != PropertyChanged)
                    PropertyChanged(this, new PropertyChangedEventArgs("currentPlanet"));
            }
        }

        public SelectPlanetCommand SelectPlanetCommand { get; set; }

        public PlanetVM()
        {
            SelectPlanetCommand = new Commands.SelectPlanetCommand(this);
            planetM = new Models.PlanetM();
            Planets = new ObservableCollection<Planet>(planetM.planets);
            currentPlanet = Planets[0];
        }

    }
}
