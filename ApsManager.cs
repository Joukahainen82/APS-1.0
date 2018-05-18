using APS_2.Phonetics;
using APS_2.TextManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_2.ApsManager
{
    public class ApsManager
    {

        /// <summary>
        /// Pobiera odczyty z pliku wskazanego ścieżką. 
        /// </summary>
        /// <param name="path">Ścieżka pliku .txt (.csv) z odczytami.</param>
        /// <returns></returns>
        public static List<Reading> GetReadings(string path)
        {
            return CsvManager.GetRecords<Reading>(path, typeof(ReadingClassMap));
        }




        /// <summary>
        /// Pobiera dane informatorów z pliku wskazanego ścieżką. 
        /// </summary>
        /// <param name="path">Ścieżka pliku .txt (.csv) z danymi.</param>
        /// <returns></returns>
        public static List<Speaker> GetSpeakers(string path)
        {
            var res = new List<Speaker>();

            res = TextManager.CsvManager.GetRecords<Speaker>(path, typeof(SpeakerMap));

            //res = Corrections.CorrectionOnSpeakers.Do(res);

            return res;
        }













    }
}
