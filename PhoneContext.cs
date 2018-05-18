using APS_1.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_1.Phonetics.Enums
{
    public enum ContextType
    {
        unspecified, 
        V_neutral,
        Ṽ_, Ṽ_S, Ṽ_T,
        V_ł, V_l,
        V_rz, V_r,
        V_j,
        cz_V, rz_V,
        ć_V_N, V_N
    }


    public class PhoneContext
    {
        //public List<ContextType> ContextType { get; set; }


        public List<Phone> Left { get; set; }

        public List<Phone> Right { get; set; }


        public PhoneContext()
        {
            Left = new List<Phone>();
            Right = new List<Phone>();

            //ContextType = new List<ContextType>(); 
        }

    }
}
