using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator
{
    public static class Costs
    {
        public static Dictionary<int, int> Petrol = new Dictionary<int, int>()
        {
            { 0, 0 },
            { 50, 10 },
            { 75, 25 },
            { 90, 105 },
            { 100, 125 },
            { 110, 145 },
            { 130, 165 },
            { 150, 205 },
            { 170, 515 },
            { 190, 830 },
            { 225, 1240 },
            { 255, 1760 }
        };

        public static Dictionary<int, int> Diesel = new Dictionary<int, int>()
        {
            { 0,   0 },
            { 50,  25 },
            { 75,  105 },
            { 90,  125 },
            { 100, 145 },
            { 110, 165 },
            { 130, 205 },
            { 150, 515 },
            { 170, 830 },
            { 190, 1240 },
            { 225, 1760 },
            { 255, 2070 }
        };

        public static Dictionary<int, int> AlternateFuel = new Dictionary<int, int>()
        {
            { 0,   0 },
            { 50,  0 },
            { 75,  15 },
            { 90,  95  },
            { 100, 115 },
            { 110, 135 },
            { 130, 155 },
            { 150, 195 },
            { 170, 505 },
            { 190, 820 },
            { 225, 1230 },
            { 255, 1750 }
        };

        public static Dictionary<string, int> FirstYearAgeCosts = new Dictionary<string, int>()
        {
            { "Petrol",  140 },
            { "Diesel",  140 },
            { "Electric",  0 },
            { "AlternativeFuel",  130 },
        };

        public static Dictionary<string, int> Over40kCosts = new Dictionary<string, int>()
        {
            { "Petrol",  450 },
            { "Diesel",  450 },
            { "Electric",  310 },
            { "AlternativeFuel",  440 },
        };



    }
}
