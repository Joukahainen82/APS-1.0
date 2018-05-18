using APS_1.Phonetics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APS_1.TextManager;
using APS_1.Phonetics.Enums;
using APS_1.ApsManager.Enums;

namespace APS_1.ApsManager
{

    public class ApsManager
    {
        private static string[] _names = new[] { "Parlator", "Informator" };


        //odwrotności średnich odchyleń standardowych w wymówieniach fonetyków
        //private static readonly double[] weights = new[]{
        //    12.78981185,
        //    14.88339828,
        //    6.244879995,
        //    5.179870062        
        //};

        //odwrotności średnich wariancji w wymówieniach fonetyków
        private static readonly double[] weights = new[]{
            125.2055928,
            176.824207,
            34.38832733,
            22.50366091        
        };

        //wagi neutralne
        //private static readonly double[] weights = new[]{
        //    (double)1,
        //    (double)1,
        //    (double)1,
        //    (double)1      
        //};		




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

            res = Corrections.CorrectionOnSpeakers.Do(res);

            return res;
        }



        public static List<VowelModel> GetModels(string path)
        {
            return TextManager.CsvManager.GetRecords<VowelModel>(path, typeof(VowelModelMap));

        }



        /// <summary>
        /// Sprawdza, czy dany fon został wymówiony przez badanego.
        /// </summary>
        /// <param name="phone">Badany fon.</param>
        /// <returns>Wartość "true", jeśli w opisie fonu zaznaczono, że jest wymówiony przez badanego.</returns>
        public static bool IsSpeaker(Phone phone)
        {
            return phone.SpeakerType == SpeakerType.Informator
                ||
                phone.SpeakerType == SpeakerType.Parlator;
        }



        public static void ShowDataV_jMC(List<Reading> Readings, List<VowelModel> Models, bool use4thFormant = false)
        {

            Console.WriteLine("Śląskie kontynuanty staropolskich samogłosek przed spółgłoską [j] (rzeczowniki)");
            ApsInterface.PresentData2(ApsInterface.V_j, 5, Readings, Models, MorphCategory.n, use4thFormant);

            Console.WriteLine();

            Console.WriteLine("Śląskie kontynuanty staropolskich samogłosek przed spółgłoską [j] (czasowniki)");
            ApsInterface.PresentData2(ApsInterface.V_j, 5, Readings, Models, MorphCategory.v, use4thFormant);

            Console.WriteLine();

            Console.WriteLine("Śląskie kontynuanty staropolskich samogłosek przed spółgłoską [j] (zakończenie czasowników typu Vje)");
            ApsInterface.PresentData2(ApsInterface.V_j, 5, Readings, Models, MorphCategory.v_Vje, use4thFormant);

            Console.WriteLine();

            Console.WriteLine("Śląskie kontynuanty staropolskich samogłosek przed spółgłoską [j] (przymiotniki i przysłówki)");
            ApsInterface.PresentData2(ApsInterface.V_j, 5, Readings, Models, MorphCategory.a, use4thFormant);

            Console.WriteLine();

            Console.WriteLine("Śląskie kontynuanty staropolskich samogłosek przed spółgłoską [j] (przedrostek naj-)");
            ApsInterface.PresentData2(ApsInterface.V_j, 5, Readings, Models, MorphCategory.a_naj, use4thFormant);

            Console.WriteLine();

            Console.WriteLine("Śląskie kontynuanty staropolskich samogłosek przed spółgłoską [j] (zakończenia -ejszy, -ej)");
            ApsInterface.PresentData2(ApsInterface.V_j, 5, Readings, Models, MorphCategory.a_ejsz, use4thFormant);

            Console.WriteLine();

            Console.WriteLine("Śląskie kontynuanty staropolskich samogłosek przed spółgłoską [j] (zaimki)");
            ApsInterface.PresentData2(ApsInterface.V_j, 5, Readings, Models, MorphCategory.p, use4thFormant);

            Console.WriteLine();

        }


        public static void ShowData(List<Reading> Readings, List<VowelModel> Models, bool use4thFormant = false)
        {


            Console.WriteLine("Samogłoski śląskie w kontekstach neutralnych bez uwzględnienia cech demograficznych.");
            Console.WriteLine("Parametry: wagi - odwrotności średnich wariancji; bez F4");

            //bool use4thFormant = false;

            ApsInterface.PresentData(ApsInterface.VowelsInNeutralContext, 5, Readings, Models, use4thFormant);

            Console.WriteLine();

            Console.WriteLine("Śląskie kontynuanty staropolskich samogłosek nosowych w wygłosie.");
            ApsInterface.PresentData(ApsInterface.VowelsInṼ_Context, 5, Readings, Models, use4thFormant);

            Console.WriteLine();

            Console.WriteLine("Śląskie kontynuanty staropolskich samogłosek nosowych przed spółgłoskami trącymi.");
            ApsInterface.PresentData(ApsInterface.VowelsInṼ_SContext, 5, Readings, Models, use4thFormant);

            Console.WriteLine();

            Console.WriteLine("Śląskie kontynuanty staropolskich samogłosek nosowych przed spółgłoskami zwartymi.");
            ApsInterface.PresentData(ApsInterface.VowelsInṼ_TContext, 5, Readings, Models, use4thFormant);

            Console.WriteLine();

            Console.WriteLine("Śląskie kontynuanty staropolskich samogłosek przed spółgłoską [ł].");
            ApsInterface.PresentData(ApsInterface.VowelsInV_łContext, 5, Readings, Models, use4thFormant);

            Console.WriteLine();

            Console.WriteLine("Śląskie kontynuanty staropolskich samogłosek przed spółgłoską [l].");
            ApsInterface.PresentData(ApsInterface.VowelsInV_lContext, 5, Readings, Models, use4thFormant);

            Console.WriteLine();

            Console.WriteLine("Śląskie kontynuanty staropolskich samogłosek przed kontynuantem dawnego [r'].");
            ApsInterface.PresentData(ApsInterface.VowelsInV_rzContext, 5, Readings, Models, use4thFormant);

            Console.WriteLine();

            Console.WriteLine("Śląskie kontynuanty staropolskich samogłosek przed spółgłoską [r].");
            ApsInterface.PresentData(ApsInterface.VowelsInV_rContext, 5, Readings, Models, use4thFormant);

            Console.WriteLine();





            Console.WriteLine("Śląskie kontynuanty staropolskich samogłosek przed spółgłoską [j].");
            ApsInterface.PresentData(ApsInterface.VowelsInV_jContext, 5, Readings, Models, use4thFormant);
            
            Console.WriteLine();

 




            Console.WriteLine("Śląskie kontynuanty staropolskich samogłosek po spółgłoskach stwardniałych (sz, ż, cz, dż).");
            ApsInterface.PresentData(ApsInterface.VowelsIncz_VContext, 5, Readings, Models, use4thFormant);

            Console.WriteLine();

            Console.WriteLine("Śląskie kontynuanty staropolskich samogłosek po spółgłoskach stwardniałych (rz).");
            ApsInterface.PresentData(ApsInterface.VowelsInrz_VContext, 5, Readings, Models, use4thFormant);

            Console.WriteLine();

            Console.WriteLine("Śląskie kontynuanty staropolskich samogłosek po spółgłoskach miękkich, a przed nosowymi.");
            ApsInterface.PresentData(ApsInterface.VowelsInć_V_NContext, 5, Readings, Models, use4thFormant);

            Console.WriteLine();

            Console.WriteLine("Śląskie kontynuanty staropolskich samogłosek przed nosowymi.");
            ApsInterface.PresentData(ApsInterface.VowelsInV_NContext, 5, Readings, Models, use4thFormant);

            Console.WriteLine();


            Console.WriteLine();

            Console.WriteLine("Śląskie samogłoski w kontekstach neutralnych; początek nagrania.");
            ApsInterface.PresentData(ApsInterface.VowelsNeutralBeginning, 5, Readings, Models, use4thFormant);

            Console.WriteLine();

            Console.WriteLine("Śląskie samogłoski w kontekstach neutralnych; koniec nagrania.");
            ApsInterface.PresentData(ApsInterface.VowelsNeutralEnd, 5, Readings, Models, use4thFormant);


            Console.WriteLine();

            Console.WriteLine();


            //WYMOWA OSÓB W RÓŻNYM WIEKU 

            Console.WriteLine("Śląskie samogłoski w kontekstach neutralnych; osoby młode.");
            ApsInterface.PresentData(ApsInterface.VowelsNeutralAgeYoung, 5, Readings, Models, use4thFormant);

            Console.WriteLine();

            Console.WriteLine("Śląskie samogłoski w kontekstach neutralnych; osoby w średnim wieku.");
            ApsInterface.PresentData(ApsInterface.VowelsNeutralAgeMiddle, 5, Readings, Models, use4thFormant);

            Console.WriteLine();

            Console.WriteLine("Śląskie samogłoski w kontekstach neutralnych; osoby starsze.");
            ApsInterface.PresentData(ApsInterface.VowelsNeutralAgeOld, 5, Readings, Models, use4thFormant);





            Console.WriteLine();

            Console.WriteLine("Śląskie samogłoski w kontekstach neutralnych; osoby z wykształceniem podstawowym.");
            ApsInterface.PresentData(ApsInterface.VowelsNeutralEducationPrimary, 5, Readings, Models, use4thFormant);

            Console.WriteLine();

            Console.WriteLine("Śląskie samogłoski w kontekstach neutralnych; osoby z wykształceniem gimnazjalnym.");
            ApsInterface.PresentData(ApsInterface.VowelsNeutralEducationMiddle, 5, Readings, Models, use4thFormant);

            Console.WriteLine();

            Console.WriteLine("Śląskie samogłoski w kontekstach neutralnych; osoby z wykształceniem średnim.");
            ApsInterface.PresentData(ApsInterface.VowelsNeutralEducationSecondary, 5, Readings, Models, use4thFormant);

            Console.WriteLine();

            Console.WriteLine("Śląskie samogłoski w kontekstach neutralnych; osoby z wykształceniem zawodowym.");
            ApsInterface.PresentData(ApsInterface.VowelsNeutralEducationVocational, 5, Readings, Models, use4thFormant);

            Console.WriteLine();

            Console.WriteLine("Śląskie samogłoski w kontekstach neutralnych; osoby z wykształceniem wyższym.");
            ApsInterface.PresentData(ApsInterface.VowelsNeutralEducationHigher, 5, Readings, Models, use4thFormant);


            Console.WriteLine();

            Console.WriteLine("Śląskie samogłoski w kontekstach neutralnych; osoby mieszkające na wsi.");
            ApsInterface.PresentData(ApsInterface.VowelsNeutralPlaceVillage, 5, Readings, Models, use4thFormant);

            Console.WriteLine();

            Console.WriteLine("Śląskie samogłoski w kontekstach neutralnych; osoby mieszkające w małym mieście.");
            ApsInterface.PresentData(ApsInterface.VowelsNeutralPlaceTown, 5, Readings, Models, use4thFormant);

            Console.WriteLine();

            Console.WriteLine("Śląskie samogłoski w kontekstach neutralnych; osoby mieszkające w dużym mieście.");
            ApsInterface.PresentData(ApsInterface.VowelsNeutralPlaceCity, 5, Readings, Models, use4thFormant);


            Console.WriteLine();

            Console.WriteLine("Śląskie samogłoski w kontekstach neutralnych; osoby mieszkające w swoim miejscu zamieszkania całe życie.");
            ApsInterface.PresentData(ApsInterface.VowelsNeutralDwellingTimeWholeLife, 5, Readings, Models, use4thFormant);

            Console.WriteLine();

            Console.WriteLine("Śląskie samogłoski w kontekstach neutralnych; osoby mieszkające w swoim miejscu zamieszkania część życia.");
            ApsInterface.PresentData(ApsInterface.VowelsNeutralDwellingTimePartOfLive, 5, Readings, Models, use4thFormant);


            Console.WriteLine();

            Console.WriteLine("Śląskie samogłoski w kontekstach neutralnych; osoby, których rodzice pochodzili z tej samej miejscowości co badany.");
            ApsInterface.PresentData(ApsInterface.VowelsNeutralParentsOriginBoth, 5, Readings, Models, use4thFormant);

            Console.WriteLine();

            Console.WriteLine("Śląskie samogłoski w kontekstach neutralnych; osoby, których matka pochodziła z tej samej miejscowości co badany.");
            ApsInterface.PresentData(ApsInterface.VowelsNeutralParentsOriginMother, 5, Readings, Models, use4thFormant);

            Console.WriteLine();

            Console.WriteLine("Śląskie samogłoski w kontekstach neutralnych; osoby, których rodzice pochodzili z innej miejscowości co badany.");
            ApsInterface.PresentData(ApsInterface.VowelsNeutralParentsOriginDifferent, 5, Readings, Models, use4thFormant);


        }







        public static void GetExamples3(string location, List<Reading> readings, int span = 5)
        {
            var recNo = location.Split('/')[0];
            var excNo = location.Split('/')[1];
            var linNo = location.Split('/')[2];

            var reading = readings.Find(x => x.RecordingNo.Equals(recNo) && x.ExcerptNo.Equals(excNo) && x.LineNo.Equals(linNo));
            int readingNo = readings.IndexOf(reading);

            int recNoStart = readingNo - span >= 0 ? readingNo - span : 0;
            int recNoEnd = readingNo + span <= readings.Count ? readingNo + span : readings.Count;

            Console.WriteLine("{0}\t{1}\t{2}", location, reading.OldPolishVowel, reading.VowelModel.Symbol);


            Console.Write("Transkrypcja A: ");

            for (int i = recNoStart; i < recNoEnd; i++)
            {
                if (readings[i].Equals(reading))
                {
                    foreach (var s in readings[i].PhoneStringA)
                    {
                        if (s.GetType() == typeof(Vowel))
                        {
                            var color = Console.ForegroundColor;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("|");
                            Console.Write(readings[i].VowelModel.Symbol);
                            Console.Write("|");
                            Console.ForegroundColor = color;                        
                        }
                        else
                        {
                            Console.Write(s.Symbol.IPA);
                        }
                    }
                }
                else
                {
                    foreach (var s in readings[i].PhoneStringA)
                    {
                        Console.Write(s.Symbol.IPA);
                    }
                }

            }

            Console.WriteLine();


            Console.Write("Transkrypcja S: ");

            for (int i = recNoStart; i < recNoEnd; i++)
            {                

                foreach (var s in readings[i].PhoneStringS)
                {
                    Console.Write(s.Symbol.SPA);
                }
            }

            Console.WriteLine();

            Console.Write("Transkrypcja G: ");

            for (int i = recNoStart; i < recNoEnd; i++)
            {

                foreach (var s in readings[i].PhoneStringG)
                {
                    Console.Write(s.Symbol.Simplified);
                }
            }

            Console.WriteLine();

            Console.Write("Transkrypcja O: ");

            for (int i = recNoStart; i < recNoEnd; i++)
            {

                foreach (var s in readings[i].PhoneStringO)
                {
                    Console.Write(s.Symbol.Simplified);
                }
            }

            Console.WriteLine();
            Console.WriteLine();
        }




        public static void GetExamples2(string location, List<Reading> readings)
        {
            var recNo = location.Split('/')[0];
            var excNo = location.Split('/')[1];
            var linNo = location.Split('/')[2];

            var reading = readings.Find(x => x.RecordingNo.Equals(recNo) && x.ExcerptNo.Equals(excNo) && x.LineNo.Equals(linNo));

            int recNoStart = -1;
            int phoneNoStart = -1;

            int recNoEnd = -1;
            int phoneNoEnd = -1;


            //wstecz
            for (int i = readings.IndexOf(reading); i <= 0; i--)
            {
                for (int j = 0; j < readings[i].PhoneStringA.Count; j++)
                {
                    if (readings[i].PhoneStringA[i].GetType() == typeof(Juncture))
                    {
                        recNoStart = i;
                        phoneNoStart = j;
                        break;
                    }
                }

                if (recNoStart != -1) break;
            }

            //w przód
            for (int i = readings.IndexOf(reading); i < readings.Count; i++)
            {
                for (int j = 0; j < readings[i].PhoneStringA.Count; j++)
                {
                    if (readings[i].PhoneStringA.GetType() == typeof(Juncture))
                    {
                        recNoEnd = i;
                        phoneNoEnd = j;
                        break;
                    }
                }

                if (recNoEnd != -1) break;
            }





        }




        public static List<Reading> GetExamples(string location, List<Reading> readings, out Reading reading, int span = 5)
        {
            var res = new List<Reading>();

            var readingNo = location.Split('/')[0];
            var excerptNo = location.Split('/')[1];
            var lineNo = location.Split('/')[2];

            reading = readings.Find(x => x.RecordingNo.Equals(readingNo) && x.ExcerptNo.Equals(excerptNo) && x.LineNo.Equals(lineNo));

            int begin = int.Parse(readingNo) - span;
            if (begin < 0) begin = 0;

            int end = int.Parse(readingNo) + span;
            if (end > readings.Count) end = readings.Count;

            for (int i = begin; i < end; i++)
            {
                res.Add(readings[i]);
            }

            return res;
        }





        public static bool IsEmpty(Reading reading)
        {
            var c1 = reading.rel_F1 == 0;
            var c2 = reading.rel_F2 == 0;
            var c3 = reading.rel_F3 == 0;
            var c4 = reading.rel_F4 == 0;

            return c1 && c2 && c3 && c4;
        }



        /// <summary>
        /// Uśrednia względne częstotliwości formantowe tych odczytów, które zawierają segmenty należące do wskazanego kontekstu. 
        /// </summary>
        /// <param name="phoneString">Ciąg segmentów. </param>
        /// <param name="conditions">Warunki, jakie dany segment musi spełniać, by został uwzględniony w obliczeniach. </param>
        /// <param name="phone">Fon - warunek uwzględnienia odczytu w uśrednieniu. </param>
        /// <returns></returns>
        public static Frequency ConditionalMedian(List<Reading> readings, Condition conditions)
        {
            //uwaga na zerowe wartości f_n (sprawdzić najpierw, czy jest wartość)

            var list = new List<Frequency>();

            foreach (var r in readings)
            {
                if (ConditionChecker(r, conditions) && !IsEmpty(r))
                    list.Add(new Frequency(r.rel_F1, r.rel_F2, r.rel_F3, r.rel_F4));
            }

            var res = new Frequency();

            res.F1 = Median(list.Select(x => x.F1).ToList());
            res.F2 = Median(list.Select(x => x.F2).ToList());
            res.F3 = Median(list.Select(x => x.F3).ToList());
            res.F4 = Median(list.Select(x => x.F4).ToList());


            return res;
        }



        public static Frequency ConditionalMean(List<Reading> readings, Condition conditions)
        {
            //uwaga na zerowe wartości f_n (sprawdzić najpierw, czy jest wartość)

            var list = new List<Frequency>();

            foreach (var r in readings)
            {
                if (ConditionChecker(r, conditions) && !IsEmpty(r))
                    list.Add(new Frequency(r.rel_F1, r.rel_F2, r.rel_F3, r.rel_F4));
            }

            var res = new Frequency();

            res.F1 = list.Average(x => x.F1);
            res.F2 = list.Average(x => x.F2);
            res.F3 = list.Average(x => x.F3);
            res.F4 = list.Average(x => x.F4);


            return res;
        }



        public static int ConditionalCount(List<Reading> readings, Condition conditions)
        {
            int res = 0;

            foreach (var r in readings)
            {
                if (ConditionChecker(r, conditions)) res++;
            }


            return res;

        }




        public static List<string> GetExamples(List<Reading> readings, Condition conditions)
        {
            var res = new List<string>();

            foreach (var r in readings)
            {
                if (ConditionChecker(r, conditions))
                {
                    res.Add(r.RecordingNo.ToString() + "/" + r.ExcerptNo.ToString() + "/" + r.LineNo.ToString());
                }
            }


            return res;

        }






        /// <summary>
        /// Sprawdza, czy podany odczyt spełnia łącznie wszystkie podane warunki. Niepodanie warunku (wartość null określonej właściwości) przyjmowana jest jako spełnianie warunku. 
        /// </summary>
        /// <param name="reading">Badany odczyt.</param>
        /// <param name="condition">Zestaw warunków.</param>
        /// <returns></returns>
        public static bool ConditionChecker(Reading reading, Condition condition)
        {
            var con0 = reading.SpeakerType == SpeakerType.Parlator || reading.SpeakerType == SpeakerType.Informator;

            var con1 = condition.OldPolishVowel == OldPolishVowels.allVowels ?
                true :
                reading.OldPolishVowel == condition.OldPolishVowel;

            var con2 = ContextChecker(reading, condition.ContextType);

            var con3 = condition.ExcerptNo != ExcerptNo.bothExcerpts ? int.Parse(reading.ExcerptNo) == (int)condition.ExcerptNo : true;


            var con4 = condition.Age == Age.noInformation ? true : condition.Age == reading.Speaker.Age;
            var con5 = condition.Education == Education.noInformation ? true : condition.Education == reading.Speaker.Education;
            var con6 = condition.PlaceType == PlaceType.noInformation ? true : condition.PlaceType == reading.Speaker.PlaceType;
            var con7 = condition.DwellingTime == DwellingTime.noInformation ? true : condition.DwellingTime == reading.Speaker.DwellingTime;
            var con8 = condition.ParentOrigin == ParentsOrigin.noInformation ? true : condition.ParentOrigin == reading.Speaker.ParentsOrigin;

            var con9 = condition.MorphCategory == MorphCategory.inne ? true : condition.MorphCategory == reading.MorphCategory;

            return con0 && con1 && con2 && con3 && con4 && con5 && con6 && con7 && con8 && con9;
        }



        public static bool ContextChecker(Reading reading, ContextType contextType)
        {
            if (contextType == ContextType.unspecified) return true;

            foreach (var c in reading.ContextType)
            {
                if (c == contextType) return true;
            }

            return false;
        }



        /// <summary>
        /// Sprawdza, czy dana osoba jest parlatorem/informatorem, a więc czy powinna być brana pod uwagę.
        /// </summary>
        /// <param name="name">Nazwa parlatora/informatora.</param>
        /// <param name="properNames">Nazwy brane pod uwagę. Domyślnie "Parlator" i "Informator"</param>
        /// <returns></returns>
        public static bool IsSpeaker(string name, string[] properNames = null)
        {
            if (properNames == null) properNames = _names;

            foreach (var n in properNames)
            {
                if (name.Equals(n)) return true;
            }

            return false;
        }




        /// <summary>
        /// Przypisuje każdemu odczytowi najbardziej pasujący (najbliższy) model. 
        /// </summary>
        /// <param name="vowel"></param>
        /// <param name="models"></param>
        /// <returns></returns>
        public static void AppendModels(List<Reading> Readings, List<VowelModel> models, bool use4thFormant)
        {
            foreach (Reading reading in Readings)
            {
                reading.VowelModel = FindModel(reading, models, use4thFormant);
            }

        }





        public static VowelModel FindModel(Reading reading, List<VowelModel> models, bool use4thFormant)
        {
            var distances = new List<double>();

            foreach (var model in models)
            {
                distances.Add(CountDistance(reading, model, use4thFormant));
            }

            var minDistance = distances.Min();

            var position = distances.IndexOf(minDistance);

            return models[position];

        }





        public static double CountDistance(Reading reading, VowelModel model, bool use4thFormant)
        {
            double d1 = reading.rel_F1 - model.f1;
            double d2 = reading.rel_F2 - model.f2;
            double d3 = reading.rel_F3 - model.f3;
            double d4 = 0;
            if (use4thFormant) d4 = reading.rel_F4 - model.f4;

            d1 = Math.Pow(d1, 2);
            d2 = Math.Pow(d2, 2);
            d3 = Math.Pow(d3, 2);
            if (use4thFormant) d4 = Math.Pow(d4, 2);

            //dodaję wagi
            d1 = d1 * weights[0];
            d2 = d2 * weights[1];
            d3 = d3 * weights[2];
            if (use4thFormant) d4 = d4 * weights[3];


            return Math.Pow(d1 + d2 + d3 + d4, 0.5);
        }





        public static double Median(List<double> list)
        {
            //usunięcie pustych miejsc z lokalnej kopii listy
            //for (int i = 0; i < list.Count; i++)
            //{
            //    if (Double.IsNaN(list[i]) || list[i].Equals("")) list.Remove(i);
            //}

            int n = (list.Count / 2);

            list = list.OrderBy(x => x).ToList();

            if (list.Count == 0)
            {
                return double.NaN;
            }
            else if ((list.Count % 2) == 0)
            {
                return (list[n - 1] + list[n]) / 2;
            }
            else
            {
                return list[n];
            }
        }







        /// <summary>
        /// Zwraca liczbę całkowitą oznaczającą nasycenie próbki gwaryzmami fonetycznymi 
        /// </summary>
        /// <param name="readings">Lista odczytów.</param>
        /// <param name="condition">Warunek.</param>
        /// <returns>LIczba gwaryzmów.</returns>
        public static int N(List<Reading> readings, Condition condition)
        {
            int res = 0;

            foreach (var i in readings)
            {
                if (i.PhoneStringG.Count == i.PhoneStringS.Count 
                    && 
                    i.PhoneStringG.Count == i.PhoneStringO.Count
                    &&
                    ApsManager.ConditionChecker(i, condition)
                    )
                {
                    for (int j = 0; j < i.PhoneStringG.Count; j++)
                    {
                        if (!i.PhoneStringG[j].Equals(i.PhoneStringS[j]) 
                            ||
                            !i.PhoneStringG[j].Equals(i.PhoneStringO[j])
                            )
                        {
                            res++;
                        } 
                    }
                }
            }

            return res;

        }

        
        /// <summary>
        /// Zwraca liczbę wyrazów tekstowych, zliczając liczbę symboli końca wyrazu. 
        /// </summary>
        /// <param name="readings">Lista odczytów.</param>
        /// <param name="condition">Warunek.</param>
        /// <returns>Liczba wyrazów tekstowych.</returns>
        public static int W(List<Reading> readings, Condition condition)
        {
            int res = 0;

            foreach (var i in readings)
            {
                if (ApsManager.ConditionChecker(i, condition))
                {
                    res += i.PhoneStringA.Count(x => x.Symbol.IPA.Contains('#'));
                }
            }

            return res;
        }


        /// <summary>
        /// Zwraca sumę różnic artykulacyjnych między dwiema próbkami
        /// </summary>
        /// <param name="readings"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static int R(List<Reading> readings, Condition conditionA, Condition conditionB, bool use4thFormant = false)
        {

            var resA = new List<VowelRecognition>();
            var resB = new List<VowelRecognition>();

            int contextsA = ApsManager.ConditionalCount(readings, conditionA);
            int contextsB = ApsManager.ConditionalCount(readings, conditionB);

            foreach (var i in ApsInterface.oldPolishVowels)
            {
                int continuantsA = ApsManager.ConditionalCount(readings, new Condition(i));
                int continuantsB = ApsManager.ConditionalCount(readings, new Condition(i));

                var medianA = ApsManager.ConditionalMedian(readings, conditionA);
                var medianB = ApsManager.ConditionalMedian(readings, conditionB);


                var counterA = ApsManager.ConditionalCount(readings, conditionA);
                var counterB = ApsManager.ConditionalCount(readings, conditionB);

                var examplesA = ApsManager.GetExamples(readings, conditionA);
                var examplesB = ApsManager.GetExamples(readings, conditionB);

                var recognitionA = ApsManager.FindModel(new Reading(medianA), Program.Models, use4thFormant);
                var recognitionB = ApsManager.FindModel(new Reading(medianB), Program.Models, use4thFormant);

                var vowelCodeA = VowelCode.CodeFromString(recognitionA.Code);
                var vowelCodeB = VowelCode.CodeFromString(recognitionB.Code);

                var ipaSymbolA = recognitionA.Symbol;
                var ipaSymbolB = recognitionB.Symbol;


                resA.Add(new VowelRecognition(i, medianA, counterA, examplesA, continuantsA, contextsA, vowelCodeA, recognitionA, ipaSymbolA));
                resB.Add(new VowelRecognition(i, medianB, counterB, examplesB, continuantsB, contextsB, vowelCodeB, recognitionB, ipaSymbolB));
            }
            

            return R(resA, resB);

        }


        private static int R(List<VowelRecognition> recognitionA, List<VowelRecognition> recognitionB)
        {
            int r = 0; 

            if (recognitionA.Count == recognitionB.Count)
            {
                for (int i = 0; i < recognitionA.Count; i++)
                {
                    r += Math.Abs(recognitionA[i].VowelCode.Frontness - recognitionB[i].VowelCode.Frontness);
                    r += Math.Abs(recognitionA[i].VowelCode.Height - recognitionB[i].VowelCode.Height);
                    r += Math.Abs(recognitionA[i].VowelCode.Roundness - recognitionB[i].VowelCode.Roundness);
                }

                return r;
            }
            else return r;
        }










        /// <summary>
        /// Zwraca tablicę [n, m, o, p] - n - liczba przypadków mazurzenia, m - liczba przypadków mazurzenia niepoprawnego, o - liczba kontekstów prawidłowego mazurzenia, p - liczba kontekstów nieprawidłowego mazurzenia
        /// </summary>
        /// <param name="readings"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static int[] mazurzenie(List<Reading> readings, Condition condition)
        {
            var res = new int[4];
            res[0] = res[1] = res[2] = res[3] = 0; 

            foreach (var i in readings)
            {
                if (ConditionChecker(i, condition))
                {
                    foreach (var j in i.PhoneStringS)
                    {
                        if (j.SpeakerType == SpeakerType.Informator || j.SpeakerType == SpeakerType.Parlator)
                        {
                            if (j.GetType() == typeof(Consonant))                                
                            {
                                if (((Consonant)j).PlaceOfArticulation == PlaceOfArticulation.postalveolar &&
                                    (((Consonant)j).MannerOfArticulation == MannerOfArticulation.fricative || 
                                    ((Consonant)j).MannerOfArticulation == MannerOfArticulation.affricate)
                                    )
                                {
                                    res[1]++;

                                    var n = i.PhoneStringS.IndexOf(j);

                                    if (i.PhoneStringG.Count > n)
                                    {
                                        if (i.PhoneStringG[n].GetType() == typeof(Consonant))
                                        {
                                            if (((Consonant)i.PhoneStringG[n]).PlaceOfArticulation == PlaceOfArticulation.alveolar)
                                            {
                                                res[0]++;
                                            }
                                        }
                                    }

                                }
                                else if (((Consonant)j).PlaceOfArticulation == PlaceOfArticulation.postalveolar && 
                                    j.MannerOfArticulation == MannerOfArticulation.fricativeTrill)
                                {
                                    res[3]++;

                                    var n = i.PhoneStringS.IndexOf(j); 

                                    if (i.PhoneStringG.Count > n)
                                    {
                                        if (i.PhoneStringG[n].GetType() == typeof(Consonant))
                                        {
                                            if (((Consonant)i.PhoneStringG[n]).PlaceOfArticulation == PlaceOfArticulation.alveolar)
                                            {
                                                res[2]++; 
                                            }
                                        }
                                    }
                                }

                            }

                        }
                    }


                }


            }

            return res; 
        }






    }
}
