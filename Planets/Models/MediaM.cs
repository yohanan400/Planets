using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanetsBE;
using PlanetsBL;

namespace Planets.Models
{
    public class MediaM
    {
        public PlanetsBL.PlanetsBl blReference;
        public List<MediaInfo> mediaInfos;
        public string subject;

        public MediaM()
        {
            subject = "Earth";
            blReference = new PlanetsBl();
            mediaInfos = new List<MediaInfo>(blReference.GetMediaInfos(subject));
        }

        public List<MediaInfo> SearchMedia(string newSubject)
        {
            subject = newSubject;
            mediaInfos = blReference.GetMediaInfos(subject);
            
            return mediaInfos;
        }
    }
}
