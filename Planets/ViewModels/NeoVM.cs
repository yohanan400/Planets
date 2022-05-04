using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planets.ViewModels
{
    public class NeoVM
    {
        private Models.NeoM neoModel;

        public ObservableCollection<PlanetsBE.Neo> neos { get; set; }

        public NeoVM()
        {
            neoModel = new Models.NeoM();
            neos = new ObservableCollection<PlanetsBE.Neo>(neoModel.neos);
        }
    }
}
