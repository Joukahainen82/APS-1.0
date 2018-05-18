using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_1.Phonetics
{
    public class VowelCode
    {
        #region Properties

        public int Height { get; set; }
        public int Frontness { get; set; }
        public int Roundness { get; set; }

        #endregion

        #region Methods

        public string GetSymbol(List<VowelModel> models)
        {
            var vowelCode = this.Height.ToString() + this.Frontness.ToString() + this.Roundness.ToString();

            var model = models.Find(x => x.Code.Equals(vowelCode));

            return model.Symbol;
        }

        public static VowelCode CodeFromString(string code)
        {
            var res = new VowelCode();

            if (code.Length == 3)
            {
                res.Height = int.Parse(code[0].ToString());
                res.Frontness = int.Parse(code[1].ToString());
                res.Roundness = int.Parse(code[2].ToString());
            }
            else if (code.Length == 4)
            {
                res.Height = int.Parse(code[0].ToString());
                res.Frontness = int.Parse(code[1].ToString());
                res.Roundness = int.Parse(code[2].ToString() + code[3].ToString());
            }
            else
            {
                throw new NotImplementedException("NIE ZAIMPLEMENTOWANO KONWERSJI KODÓW SAMOGŁOSKOWYCH O DŁUGOŚCI INNEJ NIZ 3 I 4 W KLASIE VowelCode");
            }

            return res;
        }

        public override string ToString()
        {
            return this.Height.ToString() + this.Frontness.ToString() + this.Roundness.ToString();
        }

        #endregion


    }
}
