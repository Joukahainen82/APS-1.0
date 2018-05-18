using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_1.ApsManager
{
    public static class ExtensionMethods
    {
        public static BiasedIndex[] IndexOf(this string text, string substring)
        {
            //int n = text.Count(x => x.Equals(substring));
            //int m = text.Split(substring, StringSplitOptions.None);



            return new[] { new BiasedIndex()};
        }




    }

    /// <summary>
    /// Specjalny typ indeksu zawierający dodatkowe informacje
    /// </summary>
    public class BiasedIndex
    {
        /// <summary>
        /// Położenie szukanego ciągu znaków. 
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// Obecność innego ciągu po ciągu o danym indeksie. 
        /// </summary>
        public bool Bias { get; set; }
        /// <summary>
        /// Obecność innego ciągu na początku przeszukiwanego napisu. 
        /// </summary>
        public bool ExtraBias { get; set; }
    }

}
