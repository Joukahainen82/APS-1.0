using APS_1.Phonetics;
using APS_1.TextManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APS_1.ApsManager;
using APS_1.Symbols.Library;
using System.Threading;
using APS_1.Symbols;
using APS_1.Symbols.Enums;
using APS_1.Phonetics.Enums;
using APS_1.ApsManager.Enums;

namespace APS_1
{
    class Program
    {
        public static List<VowelModel> Models { get; set; }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;


            //---------------------------------------------------------------
            //POBRANIE DANYCH Z ANALIZ AKUSTYCZNYCH
            Console.WriteLine("Pobieram dane z analiz akustycznych.");

            string path = @"D:\Projekty\C#\APS\APS_1\Data\Readings.csv";

            var Readings = ApsManager.ApsManager.GetReadings(path);
            //---------------------------------------------------------------


            //---------------------------------------------------------------
            //POBRANIE INFORMACJI O BADANYCH
            Console.WriteLine("Pobieram dane na temat badanych.");

            path = @"D:\Projekty\C#\APS\APS_1\Data\Speakers.csv";

            var speakers = ApsManager.ApsManager.GetSpeakers(path);
            //---------------------------------------------------------------


            //---------------------------------------------------------------
            //ANALIZA TRANSKRYPCJI, DODANIE INFORMACJI O BADANYCH
            Console.WriteLine("Analizuję transkrypcje fonetyczne i dodaję informacje o badanych.");

            PhoneString.ProcessReadings(Readings, speakers);
            //---------------------------------------------------------------


            //---------------------------------------------------------------
            //ANALIZUJĘ KONTEKSTY KAŻDEGO SEGMENTU I PRZYPISUJĘ SEGMENTOM OZNACZENIA KONTEKSTÓW
            Console.WriteLine("Analizuję konteksty każdego segmentu.");
            
            PhoneString.AddContexts7(ref Readings);
            
            //Console.WriteLine("Przypisuję segmentom oznaczenia kontekstów.");
            //PhoneString.TagContexts(ref Readings);

            Console.WriteLine("Kontekst neutralny.");
            PhoneString.TagContext(Readings, PhoneString.V_neutral, ContextType.V_neutral);
            
            Console.WriteLine("Kontekst typu Ṽ_ (samogłoska nosowa w wygłosie).");
            PhoneString.TagContext(Readings, PhoneString.Ṽ_, ContextType.Ṽ_);
            
            Console.WriteLine("Kontekst typu Ṽ_S (samogłoska nosowa przed spółgłoską trącą).");
            PhoneString.TagContext(Readings, PhoneString.Ṽ_S, ContextType.Ṽ_S);
            
            Console.WriteLine("Kontekst typu Ṽ_T (samogłoska nosowa przed spółgłoską zwartą).");
            PhoneString.TagContext(Readings, PhoneString.Ṽ_T, ContextType.Ṽ_T);
            
            Console.WriteLine("Kontekst typu V_ł (samogłoska ustna przed półsamogłoską labio-welarną).");
            //PhoneString.TagContext(Readings, PhoneString.V_ł, ContextType.V_ł);
            PhoneString.TagContext2(Readings, PhoneString.V_ł, new List<PhoneString.Comparer>() { PhoneString.rz_V, PhoneString.cz_V }, ContextType.V_ł);

            Console.WriteLine("Kontekst typu V_l (samogłoska ustna przed spółgłoską boczną).");
            //PhoneString.TagContext(Readings, PhoneString.V_l, ContextType.V_l);
            PhoneString.TagContext2(Readings, PhoneString.V_l, new List<PhoneString.Comparer>() { PhoneString.rz_V, PhoneString.cz_V }, ContextType.V_l);

            Console.WriteLine("Kontekst typu V_rz (samogłoska ustna przed dawnym r').");
            //PhoneString.TagContext(Readings, PhoneString.V_rz, ContextType.V_rz);
            PhoneString.TagContext2(Readings, PhoneString.V_rz, new List<PhoneString.Comparer>() { PhoneString.rz_V, PhoneString.cz_V }, ContextType.V_rz);

            Console.WriteLine("Kontekst typu V_r (samogłoska ustna przed r).");
            //PhoneString.TagContext(Readings, PhoneString.V_r, ContextType.V_r);
            PhoneString.TagContext2(Readings, PhoneString.V_r, new List<PhoneString.Comparer>() { PhoneString.rz_V, PhoneString.cz_V }, ContextType.V_r);

            Console.WriteLine("Kontekst typu V_j (samogłoska ustna przed półsamogłoską palatalną).");
            //PhoneString.TagContext(Readings, PhoneString.V_j, ContextType.V_j);
            PhoneString.TagContext2(Readings, PhoneString.V_j, new List<PhoneString.Comparer>() { PhoneString.rz_V, PhoneString.cz_V }, ContextType.V_j);
            
            Console.WriteLine("Kontekst typu cz_V (samogłoska ustna po spółgłosce dziąsłowej, trącej lub zwarto-trącej).");
            //PhoneString.TagContext(Readings, PhoneString.cz_V, ContextType.cz_V);            
            PhoneString.TagContext2(Readings, PhoneString.cz_V,
                new List<PhoneString.Comparer> { PhoneString.V_ł, PhoneString.V_l, PhoneString.V_r, PhoneString.V_rz, PhoneString.ć_V_N, PhoneString.V_N, PhoneString.V_j }, ContextType.cz_V);

            Console.WriteLine("Kontekst typu rz_V (samogłoska ustna po dawnym r').");
            //PhoneString.TagContext(Readings, PhoneString.rz_V, ContextType.rz_V);
            PhoneString.TagContext2(Readings, PhoneString.rz_V,
                new List<PhoneString.Comparer> { PhoneString.V_ł, PhoneString.V_l, PhoneString.V_r, PhoneString.V_rz, PhoneString.ć_V_N, PhoneString.V_N, PhoneString.V_j }, ContextType.rz_V);

            Console.WriteLine("Kontekst typu ć_V_N (samogłoska ustna po spółgłosce miękkiej i przed spółgłoską nosową).");
            PhoneString.TagContext(Readings, PhoneString.ć_V_N, ContextType.ć_V_N);
            
            Console.WriteLine("Kontekst typu V_N (samogłoska ustna przed spółgłoską nosową).");
            //PhoneString.TagContext(Readings, PhoneString.V_N, ContextType.V_N);
            PhoneString.TagContext2(Readings, PhoneString.V_N, new List<PhoneString.Comparer>() { PhoneString.rz_V, PhoneString.cz_V }, ContextType.V_N);
            //---------------------------------------------------------------


            //---------------------------------------------------------------
            //OZNACZENIA KONTYNUANTÓW
            Console.WriteLine("Przypisuję samogłoskom oznaczenia kontynuantów (jaką samogłoskę staropolską kontynuuje dany segment).");

            PhoneString.TagContinuants(ref Readings);

            PhoneString.CountRelativeFrequencies(Readings);
            //---------------------------------------------------------------


            //---------------------------------------------------------------
            //MODELE SAMOGŁOSEK
            Console.WriteLine("Pobieram dane modeli samogłosek.");

            path = @"D:\Projekty\C#\APS\APS_1\Data\Models.csv";

            //var Models = ApsManager.ApsManager.GetModels(path);
            Models = ApsManager.ApsManager.GetModels(path);
            
            //---------------------------------------------------------------


            //---------------------------------------------------------------
            //MAKSIMA I MINIMA
            Console.WriteLine("Obliczam skrajne wartości bezwzględnych częstotliwości formantowych.");

            PhoneString.CountMinMaxFrequencies2(Readings);
            //---------------------------------------------------------------


            //---------------------------------------------------------------
            //PRZYPISYWANIE MODELI
            Console.WriteLine("Rozpoznaję samogłoski - przypisuję najbardziej podobne modele.");
            
            ApsManager.ApsManager.AppendModels(Readings, Models, true);
            Console.WriteLine("\n\n");
            //---------------------------------------------------------------




            
            //var n = Readings.Count(x => !x.VowelModel.Code.Equals(""));
            var n = Readings.Count(x => x.F1_Hz > 0);

            Console.WriteLine("LICZBA SAMOGŁOSEK");
            Console.WriteLine(n);

            n = Readings.Count;
            Console.WriteLine("LICZBA SEGMENTÓW");
            Console.WriteLine(n);




            

            //---------------------------------------------------------------
            //ROZPOZNANIA: kontekst neutralny, bez uwzględnienia cech demograficznych
            ApsManager.ApsManager.ShowData(Readings, Models, false);



            #region: Przykłady

            
            //---------------------------------------------------------------
            //PRZYKŁADY

            //samogłoski ustne, konteksty neutralne
            string[][] adresy = {
                new[] {"1/1/14", "1/1/120", "1/1/212", "1/1/223", "1/1/329"}, 
                new[] {"1/1/19", "1/1/136", "1/1/192", "1/1/198", "1/1/285"}, 
                new[] {"1/1/16", "1/1/93", "1/1/110", "1/1/130", "1/1/140"}, 
                new[] {"1/1/337", "1/1/444", "1/1/455", "2/2/69", "2/2/80"}, 
                new[] {"1/1/35", "1/1/44", "1/1/60", "1/1/72", "1/1/105"}, 
                new[] {"1/1/49", "1/1/51", "1/1/81", "1/1/216", "1/1/219"}, 
                new[] {"1/1/8", "1/1/23", "1/1/26", "1/1/38", "1/1/55"}, 
                new[] {"1/2/454", "1/2/471", "1/2/480", "4/2/437", "10/1/350"}, 
                new[] {"1/1/33", "1/1/42", "1/1/79", "1/1/178", "1/1/368"}, 
                
                };

            //samogłoski nosowe, konteksty neutralne
            //string[][] adresy = {
            //    new[] {"1/1/47", "1/1/75", "1/1/379", "1/1/493", "1/2/12"}, 
            //    new[] {"1/1/156", "1/1/162", "1/1/232", "1/1/242", "1/1/257"}
            //                    };

            //samogłoski nosowe, kontekst przed trącą
            //string[][] adresy = {
            //                        new[] {"2/1/208", "3/1/118", "15/1/228", "15/2/59", "17/2/128"}, 
            //                        new[] {"1/1/29", "2/1/103", "4/1/89", "4/1/127", "13/2/58"}, 
            //                    };

            //samogłoski nosowe, kontekst przed zwartą 
            //string[][] adresy = {
            //                        new[] {"1/1/503", "1/2/116", "1/2/189", "1/2/199", "1/2/325"}, 
            //                        new[] {"1/1/100", "1/1/184", "1/1/291", "1/1/441", "2/1/34"}                                     
            //                    };


            //samogłoski ustne, przed ł
            //Console.WriteLine("Samogłoski ustne przed [ł]");
            //string[][] adresy = {
            //                        new[] {"1/1/275", "1/2/464", "4/2/156", "4/2/279", "16/2/19"},
            //                        new[] {"1/1/115", "1/1/400", "1/2/155", "1/2/407", "1/2/432"},
            //                        new[] {"14/1/138", "18/1/268", "24/2/531"},
            //                        new[] {"1/1/134", "1/1/376", "1/2/249", "1/2/516", "2/2/170"},
            //                        new[] {"2/2/75", "2/2/95", "2/2/112", "2/2/154", "2/2/241"},
            //                        new[] {"4/2/296", "4/2/369", "12/2/65", "12/2/112", "12/2/265"},
            //                        new[] {"3/1/320", "4/2/26", "10/1/145", "10/1/180"},
            //                        new[] {"4/2/130", "20/1/204"}
            //                    };

            //samogłoski ustne, przed l
            //Console.WriteLine("Samogłoski ustne przed [l]");
            //string[][] adresy = {
            //                        new[] {"1/1/252", "1/1/263", "4/1/460", "4/1/483", "10/1/38"},
            //                        new[] {"12/2/25", "12/2/160", "15/2/195", "15/2/466", "19/2/192"},
            //                        new[] {"1/1/12", "1/1/125", "1/2/260", "2/1/298", "2/1/451"},
            //                        new[] {"1/1/221", "1/1/312", "1/1/429", "1/1/464", "1/2/71"},
            //                        new[] {"2/2/86", "15/2/328", "122/1/271"},
            //                        new[] {"1/1/235", "1/2/498", "2/2/142", "2/2/180", "2/2/230"},
            //                        new[] {"14/1/71"},
            //                        new[] {"3/1/267", "28/2/399"}                            
            //                    };

            //samogłoski ustne, przed r
            //Console.WriteLine("Samogłoski ustne przed [r]");
            //string[][] adresy = {
            //                        new[] {"1/1/484", "2/1/67", "4/1/385", "15/2/151", "16/2/291"}, 
            //                        new[] {"1/1/4", "16/1/28", "19/2/444"}, 
            //                        new[] {"1/2/358", "2/1/361", "2/2/217", "2/2/327", "3/1/275"}, 
            //                        new[] {"4/1/201"}, 
            //                        new[] {"1/1/214", "1/2/107", "2/1/183", "2/1/346", "3/1/242"}, 
            //                        new[] {"3/2/77", "24/2/185", "24/2/202", "24/2/385", "28/2/350"}, 
            //                        new[] {"1/1/194", "1/1/281", "1/1/289", "1/1/356", "1/2/127"}, 
            //                        new[] {"2/2/84", "15/2/326", "15/2/445", "17/2/200", "19/1/204"}, 
            //                        new[] {"2/1/172", "2/1/187", "4/1/62", "16/1/276", "20/2/114"} 
            //                    };

            //samogłoski ustne, przed j
            //Console.WriteLine("Samogłoski ustne przed [j]");
            //string[][] adresy = {
            //                        new[] {"2/2/188", "14/2/86"},
            //                        new[] {"1/2/491", "1/2/507", "2/1/215", "2/1/245", "16/2/246"},
            //                        new[] {"1/1/153", "1/2/242", "3/2/86", "3/2/211", "3/2/421"},
            //                        new[] {"28/1/118", "28/1/155", "28/2/358"},
            //                        new[] {"1/1/122", "1/1/150", "1/2/272", "2/1/53", "2/1/310"},
            //                        new[] {"1/1/147", "1/1/249", "1/2/104", "1/2/196", "1/2/322"},
            //                        new[] {"2/1/72", "3/2/61", "4/1/243", "4/2/198", "10/1/224"},
            //                        new[] {"3/1/39", "4/2/482"},
            //                        new[] {"1/1/91", "1/2/49", "14/2/305", "16/1/89", "24/2/137"}
            //                    };




            //samogłoski ustne, przed j
            //Console.WriteLine("Samogłoski ustne przed [j] (rzeczowniki)");
            //string[][] adresy = {
            //                        new[] {"1/2/491", "1/2/507", "16/2/246", "23/2/152"}, 
            //                        new[] {"1/2/242", "18/2/390", "28/2/17"}, 
            //                        new[] {"1/1/122", "1/2/272", "2/2/118", "2/2/161", "4/2/502"}, 
            //                        new[] {"122/1/303"}, 
            //                        new[] {"10/1/224", "10/2/18", "10/2/101", "10/2/199", "10/2/251"}, 
            //                        new[] {"4/2/482"}
            //                    };

            //samogłoski ustne, przed j
            //Console.WriteLine("Samogłoski ustne przed [j] (Na i Śr czasowników)");
            //string[][] adresy = {
            //                        new[] {"2/2/188"},
            //                        new[] {"2/1/215", "2/1/245"},
            //                        new[] {"3/2/86", "3/2/211", "12/2/239"},
            //                        new[] {"3/2/61", "23/2/243", "23/2/275"}
            //                    };

            //samogłoski ustne, przed j
            //Console.WriteLine("Samogłoski ustne przed [j] (Wy czasowników)");
            //string[][] adresy = {
            //                        new[] {"14/2/16", "30/1/382"},
            //                        new[] {"13/2/197", "14/2/26", "14/2/50", "17/1/71", "24/2/53"},
            //                        new[] {"1/1/91", "1/2/49", "14/2/305", "16/1/89", "24/2/137"}
            //                    };


            //samogłoski ustne, przed j
            //Console.WriteLine("Samogłoski ustne przed [j] (przysłówki i przymiotniki)");
            //string[][] adresy = {
            //                        new[] {"23/2/33", "30/1/182"},
            //                        new[] {"28/1/155"},
            //                        new[] {"2/2/205", "3/1/413", "3/2/284", "4/1/263", "4/2/332"},
            //                        new[] {"16/1/300"}
            //                    };

            //Console.WriteLine("Samogłoski ustne przed [j] (przedrostek naj-)");
            //string[][] adresy = {
            //                        new[] {"1/1/147", "1/1/150", "1/1/249", "1/2/104", "1/2/196"}
            //                    };

            //Console.WriteLine("Samogłoski ustne po spółgłoskach stwardniałych [sz, ż, cz, dż].");
            //string[][] adresy = {
            //                        new[] {"1/1/239", "1/1/387", "1/1/488", "1/2/60", "1/2/283"},
            //                        new[] {"1/1/21", "1/1/107", "1/1/113", "1/1/246", "1/1/255"},
            //                        new[] {"16/2/404"},
            //                        new[] {"1/1/309", "1/1/409", "1/2/222", "1/2/331", "3/2/23"},
            //                        new[] {"1/1/462", "2/1/70", "3/1/235", "10/1/41", "10/1/206"},
            //                        new[] {"3/1/135", "3/1/374", "10/1/102", "10/2/240", "10/2/333"},
            //                        new[] {"1/1/452"},
            //                        new[] {"13/1/53", "15/2/274"},
            //                        new[] {"1/1/493", "2/1/208", "3/1/20", "10/1/334", "15/1/145"},
            //                        new[] {"1/1/156", "1/1/162", "2/1/34", "23/1/299", "24/1/336"}
            //                    };

            //Console.WriteLine("Samogłoski ustne po spółgłoskach stwardniałych [rz].");
            //string[][] adresy = {
            //                        new[] {"1/1/85", "1/1/170", "1/2/419", "2/1/59", "2/1/201"},
            //                        new[] {"1/1/160", "1/1/343", "1/1/382", "1/2/56", "2/2/303"},
            //                        new[] {"24/1/326", "24/2/135"},
            //                        new[] {"2/2/369", "2/2/374", "20/2/78"},
            //                        new[] {"2/1/322", "4/1/108"},
            //                        new[] {"3/2/6", "4/2/2", "4/2/84", "4/2/90"}
            //                    };

            //Console.WriteLine("Samogłoski ustne przed spółgłoskami nosowymi.");
            //string[][] adresy = {
            //                        new[] {"2/2/305", "3/1/228", "3/1/326", "3/1/389", "3/2/174"}, 
            //                        new[] {"1/1/138", "1/1/269", "1/1/352", "1/1/391", "1/1/395"}, 
            //                        new[] {"1/1/67", "2/1/261", "2/1/339", "3/1/147", "3/1/177"}, 
            //                        new[] {"1/1/470", "1/2/268", "2/1/257", "2/1/273", "2/1/334"}, 
            //                        new[] {"1/1/40", "1/1/176", "1/1/302", "1/1/360", "1/2/114"}, 
            //                        new[] {"1/1/57", "1/2/94", "1/2/119", "1/2/382", "1/2/468"}, 
            //                        new[] {"1/2/183", "1/2/307", "1/2/542", "2/2/5", "2/2/136"}, 
            //                        new[] {"15/1/239"}, 
            //                        new[] {"1/2/185", "1/2/309", "3/1/192", "4/1/195", "4/1/199"}
            //                    };


            //Console.WriteLine("Samogłoski ustne przed spółgłoskami nosowymi, a po spółgłoskach miękkich.");
            //string[][] adresy = {
            //                        new[] {"3/2/213", "10/1/319", "23/1/380", "30/1/433"}, 
            //                        new[] {"28/1/181"}, 
            //                        new[] {"18/2/393"}, 
            //                        new[] {"4/1/195"}
            //                    };



            foreach (var i in adresy)
            {
                foreach (var j in i)
                {

                    ApsManager.ApsManager.GetExamples3(j, Readings, 10);

                }
            }




            #endregion 


            #region: Nasycenie gwaryzmami i różnice artykulacyjne 

            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine("Nasycenie gwaryzmami i różnice artykulacyjne ");
            //Console.WriteLine();

            //var use4thformant = false;
            //var numberOfExamples = 5;
            //var showData = true;





            //var variantNames = new[] { "początek", "koniec" };
            //var variants = new[] { new Condition(null, null, ExcerptNo.beginning), new Condition(null, null, ExcerptNo.end) };


            ////WIEK

            //var age_c = new[] 
            //{
            //    new Condition(null, ContextType.V_neutral, null, Age.young), 
            //    new Condition(null, ContextType.V_neutral, null, Age.middleAged), 
            //    new Condition(null, ContextType.V_neutral, null, Age.old)
            //};

            //var age_n = new[] { "osoby młode", "osoby w średnim wieku", "osoby starsze" };



            //var age = "Nasycenie gwaryzmami wypowiedzi osób w danym wieku.";

            //ApsInterface.PresentDataOnSaturation(Readings, age_c, age_n, age);

            //age = "Nasycenie gwaryzmami NA POCZĄTKU wypowiedzi osób w danym wieku."; 
                                    
            //ApsInterface.PresentDataOnSaturationComparison(Readings, age_c, variants, age_n, variantNames, age); 



            //age = "Różnice artykulacyjne między wypowiedziami osób w danym wieku.";

            //ApsInterface.PresentDataOnDifferences(Readings, age_c, Models, age_n, age, use4thformant, showData, numberOfExamples);

            //age = "Różnice artykulacyjne między wypowiedziami osób w danym wieku i POCZĄTKIEM a KOŃCEM nagrania.";

            //ApsInterface.PresentDataOnDifferencesComparison(Readings, age_c, variants, Models, age_n, variantNames, age, use4thformant, showData, numberOfExamples); 

            //Console.WriteLine();




            ////WYKSZTAŁCENIE

            //var education_c = new[]
            //    {
            //        new Condition(null, ContextType.V_neutral, null, null, Education.primary), 
            //        new Condition(null, ContextType.V_neutral, null, null, Education.middle), 
            //        new Condition(null, ContextType.V_neutral, null, null, Education.vocational), 
            //        new Condition(null, ContextType.V_neutral, null, null, Education.secondary), 
            //        new Condition(null, ContextType.V_neutral, null, null, Education.higher) 
            //    };

            //var education_n = new[]
            //    {
            //        "osoby z wykształceniem podstawowym", 
            //        "osoby z wykształceniem gimnazjalnym", 
            //        "osoby z wykształceniem zawowodym", 
            //        "osoby z wykształceniem średnim", 
            //        "osoby z wykształceniem wyższym"
            //    };

            //var education = "Nasycenie gwaryzmami wypowiedzi osób o określonym wykształceniu.";


            //ApsInterface.PresentDataOnSaturation(Readings, education_c, education_n, education);

            //education = "Nasycenie gwaryzmami NA POCZĄTKU wypowiedzi osób z danym wykształceniem.";

            //ApsInterface.PresentDataOnSaturationComparison(Readings, education_c, variants, education_n, variantNames, education);



            //education = "Różnice artykulacyjne między wypowiedziami osób z danym wykształceniem.";

            //ApsInterface.PresentDataOnDifferences(Readings, education_c, Models, education_n, education, use4thformant, showData, numberOfExamples);

            //education = "Różnice artykulacyjne między wypowiedziami osób z danym wykształceniem i POCZĄTKIEM a KOŃCEM nagrania.";

            //ApsInterface.PresentDataOnDifferencesComparison(Readings, education_c, variants, Models, education_n, variantNames, education, use4thformant, showData, numberOfExamples);

            //Console.WriteLine();




            ////MIEJSCE ZAMIESZKANIA

            //var place_c = new[]
            //    {
            //        new Condition(null, ContextType.V_neutral, null, null, null, PlaceType.village), 
            //        new Condition(null, ContextType.V_neutral, null, null, null, PlaceType.town), 
            //        new Condition(null, ContextType.V_neutral, null, null, null, PlaceType.city) 
                    
            //    };

            //var place_n = new[]
            //    {
            //        "wieś", "małe miasto", "duże miasto"
            //    };

            //var place = "Nasycenie gwaryzmami wypowiedzi osób zależnie od miejsca zamieszkania.";



            //ApsInterface.PresentDataOnSaturation(Readings, place_c, place_n, place);

            //place = "Nasycenie gwaryzmami NA POCZĄTKU wypowiedzi osób o danym miejscu zamieszkania.";

            //ApsInterface.PresentDataOnSaturationComparison(Readings, place_c, variants, place_n, variantNames, place);



            //place = "Różnice artykulacyjne między wypowiedziami osób o danym miejscu zamieszkania.";

            //ApsInterface.PresentDataOnDifferences(Readings, place_c, Models, place_n, place, use4thformant, showData, numberOfExamples);

            //place = "Różnice artykulacyjne między wypowiedziami osób o danym miejscu zamieszkania i POCZĄTKIEM a KOŃCEM nagrania.";

            //ApsInterface.PresentDataOnDifferencesComparison(Readings, place_c, variants, Models, place_n, variantNames, place, use4thformant, showData, numberOfExamples);

            //Console.WriteLine();
            






            ////CZAS ZAMIESZKANIA

            //var dwellingTime_c = new[]
            //    {
            //        new Condition(null, ContextType.V_neutral, null, null, null, null, DwellingTime.partOfLife), 
            //        new Condition(null, ContextType.V_neutral, null, null, null, null, DwellingTime.wholeLife)
            //    };

            //var dwellingTime_n = new[]
            //    {
            //        "część życia", "całe życie"
            //    };

            //var dwellingTime = "Nasycenie gwaryzmami wypowiedzi osób zależnie od czasu zamieszkania w danej miejscowości.";



            //ApsInterface.PresentDataOnSaturation(Readings, dwellingTime_c, dwellingTime_n, dwellingTime);

            //dwellingTime = "Nasycenie gwaryzmami NA POCZĄTKU wypowiedzi osób w danym wieku.";

            //ApsInterface.PresentDataOnSaturationComparison(Readings, dwellingTime_c, variants, dwellingTime_n, variantNames, dwellingTime);



            //dwellingTime = "Różnice artykulacyjne między wypowiedziami osób w danym wieku.";

            //ApsInterface.PresentDataOnDifferences(Readings, dwellingTime_c, Models, dwellingTime_n, dwellingTime, use4thformant, showData, numberOfExamples);

            //dwellingTime = "Różnice artykulacyjne między wypowiedziami osób w danym wieku i POCZĄTKIEM a KOŃCEM nagrania.";

            //ApsInterface.PresentDataOnDifferencesComparison(Readings, dwellingTime_c, variants, Models, dwellingTime_n, variantNames, dwellingTime, use4thformant, showData, numberOfExamples);

            //Console.WriteLine();






            ////POCHODZENIE RODZICÓW

            //var parentsOrigin_c = new[]
            //    {
            //        new Condition(null, ContextType.V_neutral, null, null, null, null, null, ParentsOrigin.bothFromTheSamePlace), 
            //        new Condition(null, ContextType.V_neutral, null, null, null, null, null, ParentsOrigin.motherFromTheSamePlace), 
            //        new Condition(null, ContextType.V_neutral, null, null, null, null, null, ParentsOrigin.bothFromDifferentPlaceOrOnlyFatherFromTheSame) 
            //    };

            //var parentsOrigin_n = new[]
            //    {
            //        "oboje z tej samej miejscowości", 
            //        "tylko matka z tej samej miejscowości", 
            //        "oboje z innej lub tylko ojciec z tej samej miejscowości"
            //    };

            //var parentsOrigin = "Nasycenie gwaryzmami wypowiedzi osób zależnie od pochodzenia rodziców.";


            //ApsInterface.PresentDataOnSaturation(Readings, parentsOrigin_c, parentsOrigin_n, parentsOrigin);

            //parentsOrigin = "Nasycenie gwaryzmami NA POCZĄTKU wypowiedzi osób w danym wieku.";

            //ApsInterface.PresentDataOnSaturationComparison(Readings, parentsOrigin_c, variants, parentsOrigin_n, variantNames, parentsOrigin);



            //parentsOrigin = "Różnice artykulacyjne między wypowiedziami osób w danym wieku.";

            //ApsInterface.PresentDataOnDifferences(Readings, parentsOrigin_c, Models, parentsOrigin_n, parentsOrigin, use4thformant, showData, numberOfExamples);

            //parentsOrigin = "Różnice artykulacyjne między wypowiedziami osób w danym wieku i POCZĄTKIEM a KOŃCEM nagrania.";

            //ApsInterface.PresentDataOnDifferencesComparison(Readings, parentsOrigin_c, variants, Models, parentsOrigin_n, variantNames, parentsOrigin, use4thformant, showData, numberOfExamples);

            //Console.WriteLine();





            


            #endregion


            






            #region: analiza kontekstu Vj

            //wypisanie adresów wszystkich fonów zawierających kontynuant stp. samogłoski ustnej w kontekście +j
            //var n = Readings.FindAll(x => x.ContextType.Contains(ContextType.V_j)).Count;

            var subset = Readings.FindAll(x => x.ContextType.Contains(ContextType.V_j));

            //var list = new List<string>();

            //foreach (var i in subset)
            //{
            //    list.Add(
            //        i.RecordingNo + @"/" +
            //        i.ExcerptNo + @"/" +
            //        i.LineNo
            //        );
            //}

            //foreach (var i in list)
            //{
            //    ApsManager.ApsManager.GetExamples3(i, Readings);
            //}
            

            //Tablica z kategoriami
            MorphCategory[] categories = 
            {
                MorphCategory.v_Vje, 
                MorphCategory.n, 

                MorphCategory.a_naj, 
                MorphCategory.a_naj, 
                MorphCategory.a_ejsz, 
                MorphCategory.a_naj, 
                MorphCategory.v_Vje, 

                MorphCategory.a_naj, 
                MorphCategory.a_naj, 
                MorphCategory.n, 
                MorphCategory.n, 
                MorphCategory.a_naj, 
                MorphCategory.n, 

                MorphCategory.n, 
                MorphCategory.inne, 
                MorphCategory.p, 
                MorphCategory.v, 
                MorphCategory.v, 

                MorphCategory.p, 
                MorphCategory.p, 
                MorphCategory.n, 
                MorphCategory.n, 
                MorphCategory.v, 
                MorphCategory.a, 

                MorphCategory.p, 
                MorphCategory.a, 
                MorphCategory.v, 
                MorphCategory.v, 
                MorphCategory.v, 

                MorphCategory.a, 
                MorphCategory.p, 
                MorphCategory.p, 
                MorphCategory.a, 
                MorphCategory.a_naj, 
                MorphCategory.a_naj, 

                MorphCategory.inne, 
                MorphCategory.a, 
                MorphCategory.n, 
                MorphCategory.n, 
                MorphCategory.n, 

                MorphCategory.inne, 
                MorphCategory.inne, 
                MorphCategory.n, 
                MorphCategory.n, 
                MorphCategory.n, 
                MorphCategory.n, 

                MorphCategory.n, 
                MorphCategory.p, 
                MorphCategory.v, 
                MorphCategory.v_Vje, 
                MorphCategory.v_Vje, 

                MorphCategory.v_Vje, 
                MorphCategory.v_Vje, 
                MorphCategory.inne, 
                MorphCategory.a, 
                MorphCategory.v_Vje, 
                MorphCategory.inne, 

                MorphCategory.p, 
                MorphCategory.v_Vje, 
                MorphCategory.a, 
                MorphCategory.a, 
                MorphCategory.p, 

                MorphCategory.n, 
                MorphCategory.a_naj, 
                MorphCategory.v_Vje, 
                MorphCategory.inne, 
                MorphCategory.a, 
                MorphCategory.n, 

                MorphCategory.a_naj, 
                MorphCategory.a_naj, 
                MorphCategory.p, 
                MorphCategory.p, 
                MorphCategory.inne, 

                MorphCategory.n, 
                MorphCategory.p, 
                MorphCategory.a, 
                MorphCategory.a_naj, 
                MorphCategory.a, 
                MorphCategory.a_naj, 

                MorphCategory.n, 
                MorphCategory.n, 
                MorphCategory.v, 
                MorphCategory.v, 
                MorphCategory.a_naj, 

                MorphCategory.n, 
                MorphCategory.a_naj, 
                MorphCategory.a_naj, 
                MorphCategory.a_naj, 
                MorphCategory.a_naj, 
                MorphCategory.a_ejsz, 

                MorphCategory.v_Vje,
                MorphCategory.n, 
                MorphCategory.v_Vje, 
                MorphCategory.n, 
                MorphCategory.v_Vje,
 
                MorphCategory.n, 
                MorphCategory.inne, 
                MorphCategory.a, 
                MorphCategory.n, 
                MorphCategory.n, 
                MorphCategory.n, 

                MorphCategory.n, 
                MorphCategory.n, 
                MorphCategory.a, 
                MorphCategory.n, 
                MorphCategory.n, 

                MorphCategory.p, 
                MorphCategory.p, 
                MorphCategory.a, 
                MorphCategory.a, 
                MorphCategory.v_Vje, 
                MorphCategory.inne, 

                MorphCategory.a, 
                MorphCategory.v_Vje, 
                MorphCategory.v_Vje, 
                MorphCategory.v_Vje, 
                MorphCategory.v_Vje, 

                MorphCategory.v_Vje, 
                MorphCategory.p, 
                MorphCategory.n, 
                MorphCategory.inne, 
                MorphCategory.a_naj, 

                MorphCategory.a_ejsz, 
                MorphCategory.a_ejsz, 
                MorphCategory.v_Vje
                                
            };

            //przypisuję kategorie 
            for (int i = 0; i < categories.Length; i++)
            {
                subset[i].MorphCategory = categories[i];
            }


            //ApsManager.ApsManager.ShowDataV_jMC(subset, Models, false); 




            #endregion









            //LICZBA NIEROZPOZNANYCH SYMBOLI: 
            //var no = ps.PhoneReading.Select(x => x.Count(y => y.Symbol.IPA.Equals("*"))).Sum();

            //Console.WriteLine(no);




            //NASYCENIE GWARYZMAMI I RÓŻNICE ARTYKULACYJNE BEZ WZGLĘDU NA KATEGORIE DEMOGRAFICZNE 

            var con_p = new Condition(null, ContextType.V_neutral, ExcerptNo.beginning);
            var con_k = new Condition(null, ContextType.V_neutral, ExcerptNo.end);

            Console.WriteLine("Nasycenie gwaryzmami próbek z początku i z końca wypowiedzi");

            var p_n = ApsManager.ApsManager.N(Readings, con_p);
            var p_w = ApsManager.ApsManager.W(Readings, con_p);

            var k_n = ApsManager.ApsManager.N(Readings, con_k);
            var k_w = ApsManager.ApsManager.W(Readings, con_k);


            Console.WriteLine("Początek: {0} na {1} wyrazów = {2:P}", p_n, p_w, Convert.ToDouble(p_n) / Convert.ToDouble(p_w));

            Console.WriteLine("Koniec: {0} na {1} wyrazów = {2:P}", k_n, k_w, Convert.ToDouble(k_n) / Convert.ToDouble(k_w));

            Console.WriteLine();
            Console.WriteLine("Różnice artykulacyjne między próbkami z początku i z końca wypowiedzi");

            var r = ApsManager.ApsManager.R(Readings, con_p, con_k);

            Console.WriteLine("R = {0}", r);

            Console.WriteLine("POCZĄTKOWE FRAGMENTY - SAMOGŁOSKI USTNE W KONTEKSTACH NEUTRALNYCH");

            ApsInterface.PresentData(ApsInterface.GetVowelRecognition(Readings, con_p, Models, false), 5);

            Console.WriteLine("KOŃCOWE FRAGMENTY - SAMOGŁOSKI USTNE W KONTEKSTACH NEUTRALNYCH");

            ApsInterface.PresentData(ApsInterface.GetVowelRecognition(Readings, con_k, Models, false), 5); 







            #region: Analiza spółgłosek










            #endregion







            //bool warunek = true;
            //int wartość = 10; 

            //for (int i = 0; i < wartość; i++)
            //{
            //    //operacje
            //}

            //do
            //{
            //    //operacje
            //} while (warunek);


            //while (warunek)
            //{
            //    //operacje
            //}























        }
    }
}
