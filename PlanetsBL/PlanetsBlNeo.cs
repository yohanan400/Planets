using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetsBL
{
    public partial class PlanetsBl
    {
        public List<PlanetsBE.Neo> GetNeosList()
        {
            return DalReference.GetNeosList();
        }
    }
}
