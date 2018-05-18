using APS_1.ApsManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_1.Corrections
{
    public class CorrectionOnSpeakers
    {
        public static List<Speaker> Do(List<Speaker> list)
        {
            foreach (var i in list)
            {
                if (i.PlaceType == PlaceType.town && i.Population > 100000)
                {
                    i.PlaceType = PlaceType.city;
                }
            }

            return list;
        }
    }
}
