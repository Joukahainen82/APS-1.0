using APS_1.Phonetics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_1.Symbols.Library
{
    public abstract class Library
    {

        //Przy tych właściwościach następuje przepełnienie stosu
        //public Dictionary<string, Consonant> Consonants { get; set; }

        //public Dictionary<string, Vowel> Vowels { get; set; }
        

        //public Dictionary<string, Diacritic> ConsonantDiacritics { get; set; }

        //public Dictionary<string, Diacritic> VowelDiacritics { get; set; }
        

        //public Dictionary<string, Phone> OtherSymbols { get; set; }
                                

        //public Dictionary<string, UnknownPhoneDelimiter> UnknownPhonesDelimiters { get; set; }




        //Nowa właściwość
        public Dictionary<string, Phone> Symbols { get; set; }


    }
}
