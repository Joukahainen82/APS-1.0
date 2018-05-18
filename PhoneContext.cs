using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_2.Phonetics.Enums
{
    public enum ContextType
    {
        neutral,
        _N, Ć_N,
        _R, _rz,
        _ł, _l,
        _j,
        rz_, cz_,
        _T, _S, Wy
    }

    public class PhoneContext
    {
        public ContextType ContextType { get; set; }


        public List<Phone> Left { get; set; }

        public List<Phone> Right { get; set; }


        public PhoneContext()
        {
            Left = new List<Phone>();
            Right = new List<Phone>();

        }

    }



}
