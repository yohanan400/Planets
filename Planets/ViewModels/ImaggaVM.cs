using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planets.Models;
using Planets.Views;
using PlanetsBE;

namespace Planets.ViewModels
{
    class ImaggaVM
    {
        private ImaggaM imaggaM;
        //public string ImageUrl { get; set; } = @"https://firebasestorage.googleapis.com/v0/b/planets-d4e9c.appspot.com/o/Planets%2FVenus.jpg?alt=media&token=7d501038-f3c7-4e57-aeaa-3e9722128ef3";
       
        ObservableCollection<ImaggaObj> imaggaObjs { get; set; }
        public ImaggaVM()
        {
            imaggaM = new ImaggaM();
            imaggaObjs = new ObservableCollection<ImaggaObj>();
        }

        public void GetImagga(string imageUrl)
        {
            imaggaM.GetImagga(imageUrl);
        }

       
    }
}
