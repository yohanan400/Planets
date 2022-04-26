using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetsBE
{
    public class Picture
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string PictureName { get; set; }
        public int PlanetId { get; set; }
    }
}
