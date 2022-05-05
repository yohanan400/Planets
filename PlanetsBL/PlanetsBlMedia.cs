using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanetsBE;

namespace PlanetsBL
{
    public partial class PlanetsBl
    {
        public List<MediaInfo> GetMediaInfos(string subject)
        {
            return DalReference.GetMediaFromNasa(subject);
        }
    }
}
