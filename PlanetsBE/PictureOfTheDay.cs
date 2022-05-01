using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetsBE
{
    public class PictureOfTheDay
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Explanation { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Url { get; set; }
    }
}
