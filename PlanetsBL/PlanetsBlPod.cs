﻿using PlanetsBE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetsBL
{
    public partial class PlanetsBl
    {
        public PictureOfTheDay GetPODByDate(DateTime date)
        {
            return DalReference.GetPictureOfTheDayByDate(date);
        }
    }
}
