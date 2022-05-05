using Planets.Models;
using PlanetsBE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planets.Commands;

namespace Planets.ViewModels
{
    public class MediaVM
    {
        private MediaM mediaM;
        public ObservableCollection<MediaInfo> mediaInfos { get; set; }
        public string subject { get; set; }

        public SelectPlanetCommand selectC { get; set; }


        public MediaVM()
        {
            mediaM = new MediaM();
            mediaInfos = new ObservableCollection<MediaInfo>(mediaM.mediaInfos);
        }

        public void Search(string newSubject)
        {
            subject = newSubject;
            mediaInfos = new ObservableCollection<MediaInfo>(mediaM.SearchMedia(subject));
        }
    }
}
