using APS_2.Phonetics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_2.Symbols
{
    public class UnknownPhoneDelimiter : Phone
    {
        /// <summary>
        /// Symbol oznaczający zakończenie ciągu nierozpoznanego (właściwość "Symbol" jest ciągiem rozpoczynającym). 
        /// </summary>
        //public Symbol EndSymbol { get; set; }


        //public UnknownPhoneDelimiter(Symbol begin, Symbol end)
        //{
        //    this.Symbol = begin;
        //    this.EndSymbol = end;
        //}



        public UnknownPhoneDelimiter(string symbol)
        {
            this.Symbol = new Symbol(symbol);
        }


    }
}
