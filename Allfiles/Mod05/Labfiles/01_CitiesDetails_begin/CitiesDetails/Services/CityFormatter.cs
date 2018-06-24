﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiesDetails.Services
{
    public class CityFormatter
    {
        public string GetFormattedPopulation(int population)
        {
            return string.Format("{0:n0}", population);
        }
    }
}
