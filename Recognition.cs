using APS_1.Phonetics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APS_1.ApsManager
{
    public class Recognition
    {
        public long Counter { get; set; }

        public double PercentageOnContinuants { get; set; }

        public double PercentageOnContexts { get; set; }

        public VowelCode VowelCode { get; set; }

        public List<string> Examples { get; set; }


        

    }



}
