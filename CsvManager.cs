using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CsvHelper;
using APS_1.Phonetics;
using System.Globalization;
using APS_1.ApsManager;
using CsvHelper.Configuration;

namespace APS_1.TextManager
{
    public class CsvManager
    {

        //using System.IO;
        //using CsvHelper;

        public static List<myClass> GetRecords<myClass>(
          string path,
          Type myClassMap = null,
          string delimiter = ";")
        {
            var res = new List<myClass>();

            using (TextReader reader = new StreamReader(path, Encoding.Default))
            {
                var csv = new CsvReader(reader);
                
                csv.Configuration.Delimiter = delimiter;

                //if (myClassMap != null) csv.Configuration.RegisterClassMap(myClassMap);
                csv.Configuration.RegisterClassMap(myClassMap);

                csv.Configuration.HasHeaderRecord = true;

                foreach (myClass i in csv.GetRecords<myClass>())
                {
                    res.Add(i);
                }
            }

            return res;
        }







        private static SpeakerType SpeakerConverter(string name)
        {
            switch (name)
            {
                case "Parlator":
                    return SpeakerType.Parlator;
                case "Informator":
                    return SpeakerType.Informator;
                case "Eksplorator":
                    return SpeakerType.Eksplorator;
                default:
                    return SpeakerType.Eksplorator;
            }
        }

    }
}
