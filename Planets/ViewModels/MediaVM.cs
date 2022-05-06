using Planets.Models;
using PlanetsBE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planets.Commands;
using System.ComponentModel;

namespace Planets.ViewModels
{
    public class MediaVM 
    {
        private MediaM mediaM;
        
        private ObservableCollection<MediaInfo> mediaInfos;

        public event PropertyChangedEventHandler OnNotifyPropertyChanged;

        public ObservableCollection<MediaInfo> MediaInfos
        {
            get { return mediaInfos; }
            set { mediaInfos = value;
                
                    OnNotifyPropertyChanged(this, new PropertyChangedEventArgs("MediaInfos"));
            }
        }

        public ImaggaCommand ImaggaCommand { get; set; }


        public string subject { get; set; }

        public MediaVM()
        {
            mediaM = new MediaM();
            subject = mediaM.subject;
            mediaInfos = new ObservableCollection<MediaInfo>(mediaM.mediaInfos);
            ImaggaCommand = new ImaggaCommand();
        }


        public void Search(string newSubject)
        {
            subject = newSubject;
            
            mediaInfos = new ObservableCollection<MediaInfo>(mediaM.SearchMedia(subject));
        }
    }
}
