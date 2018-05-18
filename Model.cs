using APS_1.Symbols;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_1.Phonetics
{
    public class VowelModel
    {
        public string Code { get; set; }
        public string Symbol { get; set; }

        public double f1 { get; set; }
        public double f2 { get; set; }
        public double f3 { get; set; }
        public double f4 { get; set; }
        
        
        public VowelCode GetCode()
        {
            var code = new VowelCode();

            if (this.Code.Length == 3)
            {
                code.Height = int.Parse(this.Code[0].ToString());
                code.Frontness = int.Parse(this.Code[1].ToString());
                code.Roundness = int.Parse(this.Code[2].ToString());
            }
            else if (this.Code.Length == 4)
            {
                code.Height = int.Parse(this.Code[0].ToString());
                code.Frontness = int.Parse(this.Code[1].ToString());
                code.Roundness = int.Parse(this.Code[2].ToString() + this.Code[3].ToString());
            }
            else
            {
                var n = this.Code.Length.ToString();

                throw new NotImplementedException("NIE PRZEWIDZIANO KODÓW SAMOGŁOSKOWYCH O DŁUGOŚCI " 
                    + n
                    + ". UZUPEŁNIĆ METODĘ GetCode W KLASIE MODEL.");
            }

            return code;
        }



    }




    public class VowelModelMap : CsvClassMap<VowelModel>
    {
        public VowelModelMap()
        {
            //Code;Symbol;f1;f2;f3;f4
            Map(x => x.Code).Name("Code");
            Map(x => x.Symbol).Name("Symbol");

            Map(x => x.f1).Name("f1").TypeConverter(new StringToDoubleTypeConverter());
            Map(x => x.f2).Name("f2").TypeConverter(new StringToDoubleTypeConverter());
            Map(x => x.f3).Name("f3").TypeConverter(new StringToDoubleTypeConverter());
            Map(x => x.f4).Name("f4").TypeConverter(new StringToDoubleTypeConverter());


        }
    }








}
