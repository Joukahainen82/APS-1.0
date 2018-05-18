using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_2.Symbols
{
    public class Symbol
    {
        public string IPA { get; set; }

        public string SPA { get; set; }

        public string Simplified { get; set; }

        public string XSampa { get; set; }


        public Symbol() { }

        public Symbol(string ipa, string spa, string simplified, string xsampa)
        {
            this.IPA = ipa;
            this.SPA = spa;
            this.Simplified = simplified;
            this.XSampa = xsampa;
        }

        public Symbol(string symbol)
        {
            this.IPA = symbol;
            this.SPA = symbol;
            this.Simplified = symbol;
            this.XSampa = symbol;
        }





        public static Symbol operator +(Symbol s1, Symbol s2)
        {
            return new Symbol(
                s1.IPA += s2.IPA,
                s1.Simplified += s2.Simplified,
                s1.SPA += s2.SPA,
                s1.XSampa += s2.XSampa
                );
        }




    }
}
