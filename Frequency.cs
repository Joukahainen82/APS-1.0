using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_1.Phonetics
{
    public class Frequency
    {
        public double F1 { get; set; }
        public double F2 { get; set; }
        public double F3 { get; set; }
        public double F4 { get; set; }


        public Frequency() { }

        public Frequency(double F1, double F2, double F3, double F4)
        {
            this.F1 = F1;
            this.F2 = F2;
            this.F3 = F3;
            this.F4 = F4; 
        }

        
    }
}
