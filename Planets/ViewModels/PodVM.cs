using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planets.Models;
using PlanetsBE;

namespace Planets.ViewModels
{
    public class PodVM 
    {
        private PodM podM;

        public ObservableCollection<PictureOfTheDay> Pods { get; set; }

        public PodVM()
        {
            podM = new PodM();
            Pods = new ObservableCollection<PictureOfTheDay>(podM.Pods);
        }


    }
}
