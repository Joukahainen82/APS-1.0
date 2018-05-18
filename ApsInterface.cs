using APS_1.Phonetics;
using APS_1.Phonetics.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APS_1.ExtensionMethods;
using APS_1.ApsManager.Enums;

namespace APS_1.ApsManager
{
    /// <summary>
    /// Fasada gromadząca dane przy użyciu funkcji (metod). 
    /// </summary>
    class ApsInterface
    {
        //VowelsInNeutralContext(Readings, Models, false)
        public delegate List<VowelRecognition> ApsFunction(List<Reading> readings, List<VowelModel> models, bool use4thFormant);
        public delegate List<VowelRecognition> ApsFunction2(List<Reading> readings, List<VowelModel> models, MorphCategory morphCategory, bool use4thFormant);

        public static readonly OldPolishVowels[] oldPolishVowels = new OldPolishVowels[]
        {
            OldPolishVowels.i, 
            OldPolishVowels.y, 
            OldPolishVowels.e, OldPolishVowels.e_long, 
            OldPolishVowels.a, OldPolishVowels.a_long, 
            OldPolishVowels.o, OldPolishVowels.o_long, 
            OldPolishVowels.u, 
            OldPolishVowels.ę, OldPolishVowels.ą
        };



        public static void PresentData2(ApsFunction2 function, int examples, List<Reading> readings, List<VowelModel> models, MorphCategory morphCategory, bool use4thFormant)
        {
            var res = function(readings, models, morphCategory, use4thFormant);

            Console.WriteLine("{0,10}{1,10}{2,10}\t{3:P}\t{4:P}\t{5:P}\t{6,-10:P}\t{7}/{8:P2}/{9,-10:p2}{10,-50}",
                                "Smg. stp.",
                                "Smg. śl.", "Kod",
                                "F1'",
                                "F2'",
                                "F3'",
                                "F4'",
                                "n",
                                "%*",
                                "%**",
                                "Przykłady: (nagranie/fragment/odczyt)."
                                );

            foreach (var i in res)
            {
                Console.WriteLine("{0,10}{1,10}{2,10}\t{3:P}\t{4:P}\t{5:P}\t{6,-10:P}\t{7}/{8:P2}/{9,-10:p2}{10,-50}",
                    i.OldPolishVowel,
                    i.IpaSymbol, i.VowelCode.ToString(),
                    i.ConditionalMedian.F1,
                    i.ConditionalMedian.F2,
                    i.ConditionalMedian.F3,
                    i.ConditionalMedian.F4,
                    i.Counter, i.PercentageOnContinuants, i.PercentageOnContexts,
                    i.Examples.GetExamples(examples)
                    );
            }

            Console.WriteLine("*) Procent rozpoznań w odniesieniu do liczby odpowiedników samogłoski staropolskiej");
            Console.WriteLine("**) Procent rozpoznań w odniesieniu do liczby kontekstów");

        }




        public static void PresentData(ApsFunction function, int examples, List<Reading> readings, List<VowelModel> models, bool use4thFormant)
        {
            var res = function(readings, models, use4thFormant);

            Console.WriteLine("{0,10}{1,10}{2,10}\t{3:P}\t{4:P}\t{5:P}\t{6,-10:P}\t{7}/{8:P2}/{9,-10:p2}{10,-50}",
                                "Smg. stp.",
                                "Smg. śl.", "Kod",
                                "F1'",
                                "F2'",
                                "F3'",
                                "F4'",
                                "n",
                                "%*",
                                "%**",
                                "Przykłady: (nagranie/fragment/odczyt)."
                                );

            foreach (var i in res)
            {
                Console.WriteLine("{0,10}{1,10}{2,10}\t{3:P}\t{4:P}\t{5:P}\t{6,-10:P}\t{7}/{8:P2}/{9,-10:p2}{10,-50}",
                    i.OldPolishVowel,
                    i.IpaSymbol, i.VowelCode.ToString(),
                    i.ConditionalMedian.F1,
                    i.ConditionalMedian.F2,
                    i.ConditionalMedian.F3,
                    i.ConditionalMedian.F4,
                    i.Counter, i.PercentageOnContinuants, i.PercentageOnContexts,
                    i.Examples.GetExamples(examples)
                    );
            }

            Console.WriteLine("*) Procent rozpoznań w odniesieniu do liczby odpowiedników samogłoski staropolskiej");
            Console.WriteLine("**) Procent rozpoznań w odniesieniu do liczby kontekstów");

        }


        public static void PresentData(List<VowelRecognition> vowelRecognitions, int examples)
        {
            var res = vowelRecognitions;

            Console.WriteLine("{0,10}{1,10}{2,10}\t{3:P}\t{4:P}\t{5:P}\t{6,-10:P}\t{7}/{8:P2}/{9,-10:p2}{10,-50}",
                                "Smg. stp.",
                                "Smg. śl.", "Kod",
                                "F1'",
                                "F2'",
                                "F3'",
                                "F4'",
                                "n",
                                "%*",
                                "%**",
                                "Przykłady: (nagranie/fragment/odczyt)."
                                );

            foreach (var i in res)
            {
                Console.WriteLine("{0,10}{1,10}{2,10}\t{3:P}\t{4:P}\t{5:P}\t{6,-10:P}\t{7}/{8:P2}/{9,-10:p2}{10,-50}",
                    i.OldPolishVowel,
                    i.IpaSymbol, i.VowelCode.ToString(),
                    i.ConditionalMedian.F1,
                    i.ConditionalMedian.F2,
                    i.ConditionalMedian.F3,
                    i.ConditionalMedian.F4,
                    i.Counter, i.PercentageOnContinuants, i.PercentageOnContexts,
                    i.Examples.GetExamples(examples)
                    );
            }

            Console.WriteLine("*) Procent rozpoznań w odniesieniu do liczby odpowiedników samogłoski staropolskiej");
            Console.WriteLine("**) Procent rozpoznań w odniesieniu do liczby kontekstów");

        }



        public static void PresentData(List<Reading> readings, Condition[] condition, string[] conditionNames, string comparisonName)
        {
            if (condition.Count() != conditionNames.Count())
            {
                throw new Exception("Liczba warunków nie jest zgodna z liczbą nazw warunków. Zob. ApsInterface.PresentData()");
            }

            Console.WriteLine();

            Console.WriteLine(comparisonName);

            Console.WriteLine();

            for (int i = 0; i < condition.Count(); i++)
            {
                Console.WriteLine("{0}: {1} na {2} = {3:P}",
                    conditionNames[i],
                    ApsManager.N(readings, condition[i]),
                    ApsManager.W(readings, condition[i]),
                    Convert.ToDouble(ApsManager.N(readings, condition[i])) / Convert.ToDouble(ApsManager.W(readings, condition[i]))
                    );
            }

            Console.WriteLine();

        }


        public static void PresentDataVs(List<Reading> readings, Condition[] conditions, List<VowelModel> models, string[] comparisonNames, string comparisonName, bool use4Formant = false, bool presentData = false, int howManyExamples = 5)
        {
            if (comparisonNames.Count() != conditions.Count())
            {
                throw new Exception("Liczba nazw porównań jest różna od liczby warunków. Zob. ApsInterface.PresentData()");
            }

            Console.WriteLine();

            Console.WriteLine(comparisonName);

            if (presentData)
            {
                foreach (var c in conditions)
                {
                    Console.WriteLine();
                    PresentData(GetVowelRecognition(readings, c, models, use4Formant), howManyExamples);
                }

                Console.WriteLine();
            }

            for (int i = 0; i < conditions.Count(); i++)
            {
                for (int j = i + 1; j < conditions.Count(); j++)
                {
                    Console.WriteLine("{0} vs. {1}: {2}",
                        comparisonNames[i],
                        comparisonNames[j],
                        ApsManager.R(readings, conditions[i], conditions[j]));
                }
            }

            Console.WriteLine();
        }


        public static void PresentData(List<Reading> readings, Condition[] conditions, Condition[] variants, string[] conditionNames, string[] variantNames, string comparisonName)
        {
            if (conditions.Count() != conditionNames.Count() || variants.Count() != variantNames.Count())
            {
                throw new Exception("Liczba warunków nie jest zgodna z liczbą nazw warunków. Zob. ApsInterface.PresentData()");
            }

            Console.WriteLine();

            Console.WriteLine(comparisonName);

            Console.WriteLine();


            Condition[][] con = new Condition[conditions.Count()][];

            for (int i = 0; i < con.Count(); i++)
            {
                con[i] = new Condition[variants.Count()];

                for (int j = 0; j < variants.Count(); j++)
                {
                    con[i][j] = conditions[i] + variants[j];
                }
            }


            foreach (var i in variantNames)
            {
                Console.Write("{0}\t", i);
            }

            Console.WriteLine();

            for (int i = 0; i < con.Count(); i++)
            {
                Console.Write("{0}\t", conditionNames[i]);

                for (int j = 0; j < con[i].Count(); j++)
                {
                    Console.Write("{0} na {1} = {2:P}\t",
                        ApsManager.N(readings, con[i][j]),
                        ApsManager.W(readings, con[i][j]),
                        Convert.ToDouble(ApsManager.N(readings, con[i][j])) / Convert.ToDouble(ApsManager.W(readings, con[i][j])));
                };

                Console.WriteLine();
            }


            //for (int i = 0; i < conditions.Count(); i++)
            //{
            //    for (int j = 0; j < 2; j++)
            //    {
            //        Console.WriteLine("{0}: {1} na {2} = {3:P}\t{4} na {5} = {6:P}",
            //            conditionNames[i],

            //            ApsManager.N(readings, conditionA[i]),
            //            ApsManager.W(readings, conditionA[i]),
            //            Convert.ToDouble(ApsManager.N(readings, conditionA[i])) / Convert.ToDouble(ApsManager.W(readings, conditionA[i])),

            //            ApsManager.N(readings, conditionB[i]),
            //            ApsManager.W(readings, conditionB[i]),
            //            Convert.ToDouble(ApsManager.N(readings, conditionB[i])) / Convert.ToDouble(ApsManager.W(readings, conditionB[i]))
            //            );
            //    }
            //}

            Console.WriteLine();
        }


        public static void PresentDataVs(List<Reading> readings, Condition[] conditions, Condition[] variants, List<VowelModel> models, string[] conditionNames, string[] variantNames, string comparisonName, bool use4Formant = false, bool presentData = false, int howManyExamples = 5)
        {

            if (conditions.Count() != conditionNames.Count() || variants.Count() != variantNames.Count())
            {
                throw new Exception("Liczba warunków nie jest zgodna z liczbą nazw warunków. Zob. ApsInterface.PresentData()");
            }

            Console.WriteLine();

            Console.WriteLine(comparisonName);

            Console.WriteLine();


            Condition[][] con = new Condition[conditions.Count()][];

            for (int i = 0; i < con.Count(); i++)
            {
                con[i] = new Condition[variants.Count()];

                for (int j = 0; j < variants.Count(); j++)
                {
                    con[i][j] = conditions[i] + variants[j];
                }
            }


            foreach (var i in variantNames)
            {
                Console.Write("{0}\t", i);
            }

            Console.WriteLine();

            for (int i = 0; i < con.GetLength(1); i++)
            {
                Console.Write("{0}", conditionNames[i]);
            }

            Console.WriteLine();

            //for (int i = 0; i < con.Count(); i++)
            //{               

            //    for (int j = 0; j < con[i].Count(); j++)
            //    {
            //        Console.Write("{0} vs. {1}: {2:P}\t",
            //            comparisonName[i], 


            //            ApsManager.N(readings, con[i][j]),
            //            ApsManager.W(readings, con[i][j]),
            //            Convert.ToDouble(ApsManager.N(readings, con[i][j])) / Convert.ToDouble(ApsManager.W(readings, con[i][j])));
            //    };

            //    Console.WriteLine();                             



            for (int i = 0; i < conditions.Count(); i++)
            {
                for (int j = i + 1; j < conditions.Count(); j++)
                {
                    Console.Write("{0} vs. {1}\t",
                        conditionNames[i],
                        conditionNames[j],
                        ApsManager.R(readings, conditions[i], conditions[j]));

                    for (int k = 0; k < variants.Count(); k++)
                    {
                        Console.Write("{0}", ApsManager.R(readings, con[i][k], con[i][k]));
                    }

                    Console.WriteLine();

                }
            }

            Console.WriteLine();
        }










        public static void PresentDataOnSaturation(List<Reading> readings, Condition[] condition, string[] conditionNames, string comparisonName)
        {
            if (condition.Count() != conditionNames.Count())
            {
                throw new Exception("Liczba warunków nie jest zgodna z liczbą nazw warunków. Zob. ApsInterface.PresentData()");
            }

            Console.WriteLine();

            Console.WriteLine(comparisonName);

            Console.WriteLine();

            for (int i = 0; i < condition.Count(); i++)
            {
                Console.WriteLine("{0}: {1} na {2} = {3:P}",
                    conditionNames[i],
                    ApsManager.N(readings, condition[i]),
                    ApsManager.W(readings, condition[i]),
                    Convert.ToDouble(ApsManager.N(readings, condition[i])) / Convert.ToDouble(ApsManager.W(readings, condition[i]))
                    );
            }

            Console.WriteLine();

        }


        public static void PresentDataOnSaturationComparison(List<Reading> readings, Condition[] conditions, Condition[] variants, string[] conditionNames, string[] variantNames, string comparisonName)
        {
            if (conditions.Count() != conditionNames.Count() || variants.Count() != variantNames.Count())
            {
                throw new Exception("Liczba warunków nie jest zgodna z liczbą nazw warunków. Zob. ApsInterface.PresentData()");
            }

            Console.WriteLine();

            Console.WriteLine(comparisonName);

            Console.WriteLine();


            Condition[][] con = new Condition[conditions.Count()][];

            for (int i = 0; i < con.Count(); i++)
            {
                con[i] = new Condition[variants.Count()];

                for (int j = 0; j < variants.Count(); j++)
                {
                    con[i][j] = conditions[i] + variants[j];
                }
            }


            foreach (var i in variantNames)
            {
                Console.Write("\t{0}", i);
            }

            Console.WriteLine();

            for (int i = 0; i < con.Count(); i++)
            {
                Console.Write("{0}\t", conditionNames[i]);

                for (int j = 0; j < con[i].Count(); j++)
                {
                    Console.Write("{0} na {1} = {2:P}\t",
                        ApsManager.N(readings, con[i][j]),
                        ApsManager.W(readings, con[i][j]),
                        Convert.ToDouble(ApsManager.N(readings, con[i][j])) / Convert.ToDouble(ApsManager.W(readings, con[i][j])));
                };

                Console.WriteLine();
            }

            Console.WriteLine();
        }




        public static void PresentDataOnDifferences(List<Reading> readings, Condition[] conditions, List<VowelModel> models, string[] comparisonNames, string comparisonName, bool use4Formant = false, bool presentData = false, int howManyExamples = 5)
        {
            if (comparisonNames.Count() != conditions.Count())
            {
                throw new Exception("Liczba nazw porównań jest różna od liczby warunków. Zob. ApsInterface.PresentData()");
            }

            Console.WriteLine();

            Console.WriteLine(comparisonName);

            if (presentData)
            {
                for (int i = 0; i < conditions.Count(); i++)
                {
                    Console.WriteLine(comparisonNames[i]);
                    PresentData(GetVowelRecognition(readings, conditions[i], models, use4Formant), howManyExamples);
                }

                //foreach (var c in conditions)
                //{
                //    Console.WriteLine();
                //    PresentData(GetVowelRecognition(readings, c, models, use4Formant), howManyExamples);
                //}

                Console.WriteLine();
            }

            for (int i = 0; i < conditions.Count(); i++)
            {
                for (int j = i + 1; j < conditions.Count(); j++)
                {
                    Console.WriteLine("{0} vs. {1}: {2}",
                        comparisonNames[i],
                        comparisonNames[j],
                        ApsManager.R(readings, conditions[i], conditions[j]));
                }
            }

            Console.WriteLine();
        }


        //(Readings, age_c, variants, Models, age_n, variantNames, age, use4thformant, showData, numberOfExamples)
        public static void PresentDataOnDifferencesComparison(List<Reading> readings, Condition[] conditions, Condition[] variants, List<VowelModel> models, string[] conditionNames, string[] variantNames, string comparisonName, bool use4Formant = false, bool presentData = false, int howManyExamples = 5)
        {
            if (conditionNames.Count() != conditions.Count())
            {
                throw new Exception("Liczba nazw porównań jest różna od liczby warunków. Zob. ApsInterface.PresentData()");
            }


            Condition[][] con = new Condition[conditions.Count()][];

            for (int i = 0; i < con.Count(); i++)
            {
                con[i] = new Condition[variants.Count()];

                for (int j = 0; j < variants.Count(); j++)
                {
                    con[i][j] = conditions[i] + variants[j];
                }
            }



            Console.WriteLine();

            Console.WriteLine(comparisonName);

            if (presentData)
            {
                for (int i = 0; i < variants.Count(); i++)
                {
                    Console.WriteLine(variantNames[i]);

                    for (int j = 0; j < conditions.Count(); j++)
                    {
                        Console.WriteLine(conditionNames[j]);
                        PresentData(GetVowelRecognition(readings, con[j][i], models, use4Formant), howManyExamples);

                    }                   
                    
                }

                //foreach (var c in conditions)
                //{
                //    Console.WriteLine();
                //    PresentData(GetVowelRecognition(readings, c, models, use4Formant), howManyExamples);
                //}

                Console.WriteLine();
            }

            Console.WriteLine();



            foreach (var i in variantNames)
            {
                Console.Write("\t{0}", i);
            }

            Console.WriteLine();



            for (int i = 0; i < con.Count(); i++)
            {
                for (int j = i + 1; j < con.Count(); j++)
                {
                    Console.Write("{0} vs. {1}:\t", conditionNames[i], conditionNames[j]);

                    for (int k = 0; k < con[i].Count(); k++)
                    {
                        Console.Write("{0}\t", ApsManager.R(readings, con[i][k], con[j][k]));
                    }

                    Console.WriteLine();
                }
            }

            Console.WriteLine();
        }







        






        public static List<VowelRecognition> GetVowelRecognition(
            List<Reading> readings,
            Condition condition,
            List<VowelModel> vowelModels,
            bool use4thFormant)
        {

            var res = new List<VowelRecognition>();

            int contexts = ApsManager.ConditionalCount(readings, new Condition(null, ContextType.V_neutral));

            foreach (var i in oldPolishVowels)
            {

                int continuants = ApsManager.ConditionalCount(readings, new Condition(i));

                condition.OldPolishVowel = i;

                var median = ApsManager.ConditionalMedian(readings, condition);
                //var median = ApsManager.ConditionalMean(readings, condition);

                var counter = ApsManager.ConditionalCount(readings, condition);

                var examples = ApsManager.GetExamples(readings, condition);

                var recognition = ApsManager.FindModel(new Reading(median), vowelModels, use4thFormant);

                var vowelCode = VowelCode.CodeFromString(recognition.Code);

                var ipaSymbol = recognition.Symbol;


                res.Add(new VowelRecognition(i, median, counter, examples, continuants, contexts, vowelCode, recognition, ipaSymbol));



            }


            return res;


        }



        #region: Without demographic features

        public static List<VowelRecognition> VowelsInNeutralContext(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
        {
            var res = new List<VowelRecognition>();

            int contexts = ApsManager.ConditionalCount(readings, new Condition(null, ContextType.V_neutral));

            foreach (var i in oldPolishVowels)
            {
                int continuants = ApsManager.ConditionalCount(readings, new Condition(i));

                var condition = new Condition(i, ContextType.V_neutral);

                var median = ApsManager.ConditionalMedian(readings, condition);
                //var median = ApsManager.ConditionalMean(readings, condition);

                var counter = ApsManager.ConditionalCount(readings, condition);

                var examples = ApsManager.GetExamples(readings, condition);

                var recognition = ApsManager.FindModel(new Reading(median), vowelModels, use4thFormant);

                var vowelCode = VowelCode.CodeFromString(recognition.Code);

                var ipaSymbol = recognition.Symbol;


                res.Add(new VowelRecognition(i, median, counter, examples, continuants, contexts, vowelCode, recognition, ipaSymbol));


            }


            return res;

        }



        public static List<VowelRecognition> VowelsInṼ_Context(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
        {
            var res = new List<VowelRecognition>();

            int contexts = ApsManager.ConditionalCount(readings, new Condition(null, ContextType.Ṽ_));

            foreach (var i in oldPolishVowels)
            {
                int continuants = ApsManager.ConditionalCount(readings, new Condition(i));

                var condition = new Condition(i, ContextType.Ṽ_);

                var median = ApsManager.ConditionalMedian(readings, condition);
                //var median = ApsManager.ConditionalMean(readings, condition);

                var counter = ApsManager.ConditionalCount(readings, condition);

                var examples = ApsManager.GetExamples(readings, condition);

                var recognition = ApsManager.FindModel(new Reading(median), vowelModels, use4thFormant);

                var vowelCode = VowelCode.CodeFromString(recognition.Code);

                var ipaSymbol = recognition.Symbol;


                res.Add(new VowelRecognition(i, median, counter, examples, continuants, contexts, vowelCode, recognition, ipaSymbol));


            }


            return res;

        }



        public static List<VowelRecognition> VowelsInṼ_SContext(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
        {
            var res = new List<VowelRecognition>();

            int contexts = ApsManager.ConditionalCount(readings, new Condition(null, ContextType.Ṽ_S));

            foreach (var i in oldPolishVowels)
            {
                int continuants = ApsManager.ConditionalCount(readings, new Condition(i));

                var condition = new Condition(i, ContextType.Ṽ_S);

                var median = ApsManager.ConditionalMedian(readings, condition);
                //var median = ApsManager.ConditionalMean(readings, condition);

                var counter = ApsManager.ConditionalCount(readings, condition);

                var examples = ApsManager.GetExamples(readings, condition);

                var recognition = ApsManager.FindModel(new Reading(median), vowelModels, use4thFormant);

                var vowelCode = VowelCode.CodeFromString(recognition.Code);

                var ipaSymbol = recognition.Symbol;


                res.Add(new VowelRecognition(i, median, counter, examples, continuants, contexts, vowelCode, recognition, ipaSymbol));


            }


            return res;

        }



        public static List<VowelRecognition> VowelsInṼ_TContext(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
        {
            var res = new List<VowelRecognition>();

            int contexts = ApsManager.ConditionalCount(readings, new Condition(null, ContextType.Ṽ_T));

            foreach (var i in oldPolishVowels)
            {
                int continuants = ApsManager.ConditionalCount(readings, new Condition(i));

                var condition = new Condition(i, ContextType.Ṽ_T);

                var median = ApsManager.ConditionalMedian(readings, condition);
                //var median = ApsManager.ConditionalMean(readings, condition);

                var counter = ApsManager.ConditionalCount(readings, condition);

                var examples = ApsManager.GetExamples(readings, condition);

                var recognition = ApsManager.FindModel(new Reading(median), vowelModels, use4thFormant);

                var vowelCode = VowelCode.CodeFromString(recognition.Code);

                var ipaSymbol = recognition.Symbol;


                res.Add(new VowelRecognition(i, median, counter, examples, continuants, contexts, vowelCode, recognition, ipaSymbol));


            }


            return res;

        }



        public static List<VowelRecognition> VowelsInV_łContext(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
        {
            var res = new List<VowelRecognition>();

            int contexts = ApsManager.ConditionalCount(readings, new Condition(null, ContextType.V_ł));

            foreach (var i in oldPolishVowels)
            {
                int continuants = ApsManager.ConditionalCount(readings, new Condition(i));

                var condition = new Condition(i, ContextType.V_ł);

                var median = ApsManager.ConditionalMedian(readings, condition);
                //var median = ApsManager.ConditionalMean(readings, condition);

                var counter = ApsManager.ConditionalCount(readings, condition);

                var examples = ApsManager.GetExamples(readings, condition);

                var recognition = ApsManager.FindModel(new Reading(median), vowelModels, use4thFormant);

                var vowelCode = VowelCode.CodeFromString(recognition.Code);

                var ipaSymbol = recognition.Symbol;


                res.Add(new VowelRecognition(i, median, counter, examples, continuants, contexts, vowelCode, recognition, ipaSymbol));


            }


            return res;

        }



        public static List<VowelRecognition> VowelsInV_lContext(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
        {
            var res = new List<VowelRecognition>();

            int contexts = ApsManager.ConditionalCount(readings, new Condition(null, ContextType.V_l));

            foreach (var i in oldPolishVowels)
            {
                int continuants = ApsManager.ConditionalCount(readings, new Condition(i));

                var condition = new Condition(i, ContextType.V_l);

                var median = ApsManager.ConditionalMedian(readings, condition);
                //var median = ApsManager.ConditionalMean(readings, condition);

                var counter = ApsManager.ConditionalCount(readings, condition);

                var examples = ApsManager.GetExamples(readings, condition);

                var recognition = ApsManager.FindModel(new Reading(median), vowelModels, use4thFormant);

                var vowelCode = VowelCode.CodeFromString(recognition.Code);

                var ipaSymbol = recognition.Symbol;


                res.Add(new VowelRecognition(i, median, counter, examples, continuants, contexts, vowelCode, recognition, ipaSymbol));


            }


            return res;

        }



        public static List<VowelRecognition> VowelsInV_rzContext(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
        {
            var res = new List<VowelRecognition>();

            int contexts = ApsManager.ConditionalCount(readings, new Condition(null, ContextType.V_rz));

            foreach (var i in oldPolishVowels)
            {
                int continuants = ApsManager.ConditionalCount(readings, new Condition(i));

                var condition = new Condition(i, ContextType.V_rz);

                var median = ApsManager.ConditionalMedian(readings, condition);
                //var median = ApsManager.ConditionalMean(readings, condition);

                var counter = ApsManager.ConditionalCount(readings, condition);

                var examples = ApsManager.GetExamples(readings, condition);

                var recognition = ApsManager.FindModel(new Reading(median), vowelModels, use4thFormant);

                var vowelCode = VowelCode.CodeFromString(recognition.Code);

                var ipaSymbol = recognition.Symbol;


                res.Add(new VowelRecognition(i, median, counter, examples, continuants, contexts, vowelCode, recognition, ipaSymbol));


            }


            return res;

        }



        public static List<VowelRecognition> VowelsInV_rContext(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
        {
            var res = new List<VowelRecognition>();

            int contexts = ApsManager.ConditionalCount(readings, new Condition(null, ContextType.V_r));

            foreach (var i in oldPolishVowels)
            {
                int continuants = ApsManager.ConditionalCount(readings, new Condition(i));

                var condition = new Condition(i, ContextType.V_r);

                var median = ApsManager.ConditionalMedian(readings, condition);
                //var median = ApsManager.ConditionalMean(readings, condition);

                var counter = ApsManager.ConditionalCount(readings, condition);

                var examples = ApsManager.GetExamples(readings, condition);

                var recognition = ApsManager.FindModel(new Reading(median), vowelModels, use4thFormant);

                var vowelCode = VowelCode.CodeFromString(recognition.Code);

                var ipaSymbol = recognition.Symbol;


                res.Add(new VowelRecognition(i, median, counter, examples, continuants, contexts, vowelCode, recognition, ipaSymbol));


            }


            return res;

        }



        public static List<VowelRecognition> VowelsInV_jContext(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
        {
            var res = new List<VowelRecognition>();

            int contexts = ApsManager.ConditionalCount(readings, new Condition(null, ContextType.V_j));

            foreach (var i in oldPolishVowels)
            {
                int continuants = ApsManager.ConditionalCount(readings, new Condition(i));

                var condition = new Condition(i, ContextType.V_j);

                var median = ApsManager.ConditionalMedian(readings, condition);
                //var median = ApsManager.ConditionalMean(readings, condition);

                var counter = ApsManager.ConditionalCount(readings, condition);

                var examples = ApsManager.GetExamples(readings, condition);

                var recognition = ApsManager.FindModel(new Reading(median), vowelModels, use4thFormant);

                var vowelCode = VowelCode.CodeFromString(recognition.Code);

                var ipaSymbol = recognition.Symbol;


                res.Add(new VowelRecognition(i, median, counter, examples, continuants, contexts, vowelCode, recognition, ipaSymbol));


            }


            return res;

        }



        public static List<VowelRecognition> VowelsIncz_VContext(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
        {
            var res = new List<VowelRecognition>();

            int contexts = ApsManager.ConditionalCount(readings, new Condition(null, ContextType.cz_V));

            foreach (var i in oldPolishVowels)
            {
                int continuants = ApsManager.ConditionalCount(readings, new Condition(i));

                var condition = new Condition(i, ContextType.cz_V);

                var median = ApsManager.ConditionalMedian(readings, condition);
                //var median = ApsManager.ConditionalMean(readings, condition);

                var counter = ApsManager.ConditionalCount(readings, condition);

                var examples = ApsManager.GetExamples(readings, condition);

                var recognition = ApsManager.FindModel(new Reading(median), vowelModels, use4thFormant);

                var vowelCode = VowelCode.CodeFromString(recognition.Code);

                var ipaSymbol = recognition.Symbol;


                res.Add(new VowelRecognition(i, median, counter, examples, continuants, contexts, vowelCode, recognition, ipaSymbol));


            }


            return res;

        }



        public static List<VowelRecognition> VowelsInrz_VContext(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
        {
            var res = new List<VowelRecognition>();

            int contexts = ApsManager.ConditionalCount(readings, new Condition(null, ContextType.rz_V));

            foreach (var i in oldPolishVowels)
            {
                int continuants = ApsManager.ConditionalCount(readings, new Condition(i));

                var condition = new Condition(i, ContextType.rz_V);

                var median = ApsManager.ConditionalMedian(readings, condition);
                //var median = ApsManager.ConditionalMean(readings, condition);

                var counter = ApsManager.ConditionalCount(readings, condition);

                var examples = ApsManager.GetExamples(readings, condition);

                var recognition = ApsManager.FindModel(new Reading(median), vowelModels, use4thFormant);

                var vowelCode = VowelCode.CodeFromString(recognition.Code);

                var ipaSymbol = recognition.Symbol;


                res.Add(new VowelRecognition(i, median, counter, examples, continuants, contexts, vowelCode, recognition, ipaSymbol));


            }


            return res;

        }



        public static List<VowelRecognition> VowelsInć_V_NContext(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
        {
            var res = new List<VowelRecognition>();

            int contexts = ApsManager.ConditionalCount(readings, new Condition(null, ContextType.ć_V_N));

            foreach (var i in oldPolishVowels)
            {
                int continuants = ApsManager.ConditionalCount(readings, new Condition(i));

                var condition = new Condition(i, ContextType.ć_V_N);

                var median = ApsManager.ConditionalMedian(readings, condition);
                //var median = ApsManager.ConditionalMean(readings, condition);

                var counter = ApsManager.ConditionalCount(readings, condition);

                var examples = ApsManager.GetExamples(readings, condition);

                var recognition = ApsManager.FindModel(new Reading(median), vowelModels, use4thFormant);

                var vowelCode = VowelCode.CodeFromString(recognition.Code);

                var ipaSymbol = recognition.Symbol;


                res.Add(new VowelRecognition(i, median, counter, examples, continuants, contexts, vowelCode, recognition, ipaSymbol));


            }


            return res;

        }



        public static List<VowelRecognition> VowelsInV_NContext(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
        {
            var res = new List<VowelRecognition>();

            int contexts = ApsManager.ConditionalCount(readings, new Condition(null, ContextType.V_N));

            foreach (var i in oldPolishVowels)
            {
                int continuants = ApsManager.ConditionalCount(readings, new Condition(i));

                var condition = new Condition(i, ContextType.V_N);

                var median = ApsManager.ConditionalMedian(readings, condition);
                //var median = ApsManager.ConditionalMean(readings, condition);

                var counter = ApsManager.ConditionalCount(readings, condition);

                var examples = ApsManager.GetExamples(readings, condition);

                var recognition = ApsManager.FindModel(new Reading(median), vowelModels, use4thFormant);

                var vowelCode = VowelCode.CodeFromString(recognition.Code);

                var ipaSymbol = recognition.Symbol;


                res.Add(new VowelRecognition(i, median, counter, examples, continuants, contexts, vowelCode, recognition, ipaSymbol));


            }


            return res;

        }

        #endregion

        #region With demographic features

        public static List<VowelRecognition> VowelsNeutralAgeYoung(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
        {
            var res = new List<VowelRecognition>();

            int contexts = ApsManager.ConditionalCount(readings, new Condition(null, ContextType.V_neutral));

            foreach (var i in oldPolishVowels)
            {
                int continuants = ApsManager.ConditionalCount(readings, new Condition(i));

                var condition = new Condition(i, ContextType.V_neutral, null, Age.young);

                var median = ApsManager.ConditionalMedian(readings, condition);
                //var median = ApsManager.ConditionalMean(readings, condition);

                var counter = ApsManager.ConditionalCount(readings, condition);

                var examples = ApsManager.GetExamples(readings, condition);

                var recognition = ApsManager.FindModel(new Reading(median), vowelModels, use4thFormant);

                var vowelCode = VowelCode.CodeFromString(recognition.Code);

                var ipaSymbol = recognition.Symbol;


                res.Add(new VowelRecognition(i, median, counter, examples, continuants, contexts, vowelCode, recognition, ipaSymbol));


            }


            return res;

        }

        public static List<VowelRecognition> VowelsNeutralAgeMiddle(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
        {
            var res = new List<VowelRecognition>();

            int contexts = ApsManager.ConditionalCount(readings, new Condition(null, ContextType.V_neutral));

            foreach (var i in oldPolishVowels)
            {
                int continuants = ApsManager.ConditionalCount(readings, new Condition(i));

                var condition = new Condition(i, ContextType.V_neutral, null, Age.middleAged);

                var median = ApsManager.ConditionalMedian(readings, condition);
                //var median = ApsManager.ConditionalMean(readings, condition);

                var counter = ApsManager.ConditionalCount(readings, condition);

                var examples = ApsManager.GetExamples(readings, condition);

                var recognition = ApsManager.FindModel(new Reading(median), vowelModels, use4thFormant);

                var vowelCode = VowelCode.CodeFromString(recognition.Code);

                var ipaSymbol = recognition.Symbol;


                res.Add(new VowelRecognition(i, median, counter, examples, continuants, contexts, vowelCode, recognition, ipaSymbol));


            }


            return res;

        }

        public static List<VowelRecognition> VowelsNeutralAgeOld(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
        {
            var res = new List<VowelRecognition>();

            int contexts = ApsManager.ConditionalCount(readings, new Condition(null, ContextType.V_neutral));

            foreach (var i in oldPolishVowels)
            {
                int continuants = ApsManager.ConditionalCount(readings, new Condition(i));

                var condition = new Condition(i, ContextType.V_neutral, null, Age.old);

                var median = ApsManager.ConditionalMedian(readings, condition);
                //var median = ApsManager.ConditionalMean(readings, condition);

                var counter = ApsManager.ConditionalCount(readings, condition);

                var examples = ApsManager.GetExamples(readings, condition);

                var recognition = ApsManager.FindModel(new Reading(median), vowelModels, use4thFormant);

                var vowelCode = VowelCode.CodeFromString(recognition.Code);

                var ipaSymbol = recognition.Symbol;


                res.Add(new VowelRecognition(i, median, counter, examples, continuants, contexts, vowelCode, recognition, ipaSymbol));


            }


            return res;

        }


        public static List<VowelRecognition> VowelsNeutralEducationPrimary(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
        {
            var res = new List<VowelRecognition>();

            int contexts = ApsManager.ConditionalCount(readings, new Condition(null, ContextType.V_neutral));

            foreach (var i in oldPolishVowels)
            {
                int continuants = ApsManager.ConditionalCount(readings, new Condition(i));

                var condition = new Condition(i, ContextType.V_neutral, null, null, Education.primary);

                var median = ApsManager.ConditionalMedian(readings, condition);
                //var median = ApsManager.ConditionalMean(readings, condition);

                var counter = ApsManager.ConditionalCount(readings, condition);

                var examples = ApsManager.GetExamples(readings, condition);

                var recognition = ApsManager.FindModel(new Reading(median), vowelModels, use4thFormant);

                var vowelCode = VowelCode.CodeFromString(recognition.Code);

                var ipaSymbol = recognition.Symbol;


                res.Add(new VowelRecognition(i, median, counter, examples, continuants, contexts, vowelCode, recognition, ipaSymbol));


            }


            return res;

        }

        public static List<VowelRecognition> VowelsNeutralEducationMiddle(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
        {
            var res = new List<VowelRecognition>();

            int contexts = ApsManager.ConditionalCount(readings, new Condition(null, ContextType.V_neutral));

            foreach (var i in oldPolishVowels)
            {
                int continuants = ApsManager.ConditionalCount(readings, new Condition(i));

                var condition = new Condition(i, ContextType.V_neutral, null, null, Education.middle);

                var median = ApsManager.ConditionalMedian(readings, condition);
                //var median = ApsManager.ConditionalMean(readings, condition);

                var counter = ApsManager.ConditionalCount(readings, condition);

                var examples = ApsManager.GetExamples(readings, condition);

                var recognition = ApsManager.FindModel(new Reading(median), vowelModels, use4thFormant);

                var vowelCode = VowelCode.CodeFromString(recognition.Code);

                var ipaSymbol = recognition.Symbol;


                res.Add(new VowelRecognition(i, median, counter, examples, continuants, contexts, vowelCode, recognition, ipaSymbol));


            }


            return res;

        }

        public static List<VowelRecognition> VowelsNeutralEducationSecondary(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
        {
            var res = new List<VowelRecognition>();

            int contexts = ApsManager.ConditionalCount(readings, new Condition(null, ContextType.V_neutral));

            foreach (var i in oldPolishVowels)
            {
                int continuants = ApsManager.ConditionalCount(readings, new Condition(i));

                var condition = new Condition(i, ContextType.V_neutral, null, null, Education.secondary);

                var median = ApsManager.ConditionalMedian(readings, condition);
                //var median = ApsManager.ConditionalMean(readings, condition);

                var counter = ApsManager.ConditionalCount(readings, condition);

                var examples = ApsManager.GetExamples(readings, condition);

                var recognition = ApsManager.FindModel(new Reading(median), vowelModels, use4thFormant);

                var vowelCode = VowelCode.CodeFromString(recognition.Code);

                var ipaSymbol = recognition.Symbol;


                res.Add(new VowelRecognition(i, median, counter, examples, continuants, contexts, vowelCode, recognition, ipaSymbol));


            }


            return res;

        }

        public static List<VowelRecognition> VowelsNeutralEducationVocational(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
        {
            var res = new List<VowelRecognition>();

            int contexts = ApsManager.ConditionalCount(readings, new Condition(null, ContextType.V_neutral));

            foreach (var i in oldPolishVowels)
            {
                int continuants = ApsManager.ConditionalCount(readings, new Condition(i));

                var condition = new Condition(i, ContextType.V_neutral, null, null, Education.vocational);

                var median = ApsManager.ConditionalMedian(readings, condition);
                //var median = ApsManager.ConditionalMean(readings, condition);

                var counter = ApsManager.ConditionalCount(readings, condition);

                var examples = ApsManager.GetExamples(readings, condition);

                var recognition = ApsManager.FindModel(new Reading(median), vowelModels, use4thFormant);

                var vowelCode = VowelCode.CodeFromString(recognition.Code);

                var ipaSymbol = recognition.Symbol;


                res.Add(new VowelRecognition(i, median, counter, examples, continuants, contexts, vowelCode, recognition, ipaSymbol));


            }


            return res;

        }

        public static List<VowelRecognition> VowelsNeutralEducationHigher(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
        {
            var res = new List<VowelRecognition>();

            int contexts = ApsManager.ConditionalCount(readings, new Condition(null, ContextType.V_neutral));

            foreach (var i in oldPolishVowels)
            {
                int continuants = ApsManager.ConditionalCount(readings, new Condition(i));

                var condition = new Condition(i, ContextType.V_neutral, null, null, Education.higher);

                var median = ApsManager.ConditionalMedian(readings, condition);
                //var median = ApsManager.ConditionalMean(readings, condition);

                var counter = ApsManager.ConditionalCount(readings, condition);

                var examples = ApsManager.GetExamples(readings, condition);

                var recognition = ApsManager.FindModel(new Reading(median), vowelModels, use4thFormant);

                var vowelCode = VowelCode.CodeFromString(recognition.Code);

                var ipaSymbol = recognition.Symbol;


                res.Add(new VowelRecognition(i, median, counter, examples, continuants, contexts, vowelCode, recognition, ipaSymbol));


            }


            return res;

        }


        public static List<VowelRecognition> VowelsNeutralPlaceVillage(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
        {
            var res = new List<VowelRecognition>();

            int contexts = ApsManager.ConditionalCount(readings, new Condition(null, ContextType.V_neutral));

            foreach (var i in oldPolishVowels)
            {
                int continuants = ApsManager.ConditionalCount(readings, new Condition(i));

                var condition = new Condition(i, ContextType.V_neutral, null, null, null, PlaceType.village);

                var median = ApsManager.ConditionalMedian(readings, condition);
                //var median = ApsManager.ConditionalMean(readings, condition);

                var counter = ApsManager.ConditionalCount(readings, condition);

                var examples = ApsManager.GetExamples(readings, condition);

                var recognition = ApsManager.FindModel(new Reading(median), vowelModels, use4thFormant);

                var vowelCode = VowelCode.CodeFromString(recognition.Code);

                var ipaSymbol = recognition.Symbol;


                res.Add(new VowelRecognition(i, median, counter, examples, continuants, contexts, vowelCode, recognition, ipaSymbol));


            }


            return res;

        }

        public static List<VowelRecognition> VowelsNeutralPlaceTown(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
        {
            var res = new List<VowelRecognition>();

            int contexts = ApsManager.ConditionalCount(readings, new Condition(null, ContextType.V_neutral));

            foreach (var i in oldPolishVowels)
            {
                int continuants = ApsManager.ConditionalCount(readings, new Condition(i));

                var condition = new Condition(i, ContextType.V_neutral, null, null, null, PlaceType.town);

                var median = ApsManager.ConditionalMedian(readings, condition);
                //var median = ApsManager.ConditionalMean(readings, condition);

                var counter = ApsManager.ConditionalCount(readings, condition);

                var examples = ApsManager.GetExamples(readings, condition);

                var recognition = ApsManager.FindModel(new Reading(median), vowelModels, use4thFormant);

                var vowelCode = VowelCode.CodeFromString(recognition.Code);

                var ipaSymbol = recognition.Symbol;


                res.Add(new VowelRecognition(i, median, counter, examples, continuants, contexts, vowelCode, recognition, ipaSymbol));


            }


            return res;

        }

        public static List<VowelRecognition> VowelsNeutralPlaceCity(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
        {
            var res = new List<VowelRecognition>();

            int contexts = ApsManager.ConditionalCount(readings, new Condition(null, ContextType.V_neutral));

            foreach (var i in oldPolishVowels)
            {
                int continuants = ApsManager.ConditionalCount(readings, new Condition(i));

                var condition = new Condition(i, ContextType.V_neutral, null, null, null, PlaceType.city);

                var median = ApsManager.ConditionalMedian(readings, condition);
                //var median = ApsManager.ConditionalMean(readings, condition);

                var counter = ApsManager.ConditionalCount(readings, condition);

                var examples = ApsManager.GetExamples(readings, condition);

                var recognition = ApsManager.FindModel(new Reading(median), vowelModels, use4thFormant);

                var vowelCode = VowelCode.CodeFromString(recognition.Code);

                var ipaSymbol = recognition.Symbol;


                res.Add(new VowelRecognition(i, median, counter, examples, continuants, contexts, vowelCode, recognition, ipaSymbol));


            }


            return res;

        }


        public static List<VowelRecognition> VowelsNeutralDwellingTimePartOfLive(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
        {
            var res = new List<VowelRecognition>();

            int contexts = ApsManager.ConditionalCount(readings, new Condition(null, ContextType.V_neutral));

            foreach (var i in oldPolishVowels)
            {
                int continuants = ApsManager.ConditionalCount(readings, new Condition(i));

                var condition = new Condition(i, ContextType.V_neutral, null, null, null, null, DwellingTime.partOfLife);

                var median = ApsManager.ConditionalMedian(readings, condition);
                //var median = ApsManager.ConditionalMean(readings, condition);

                var counter = ApsManager.ConditionalCount(readings, condition);

                var examples = ApsManager.GetExamples(readings, condition);

                var recognition = ApsManager.FindModel(new Reading(median), vowelModels, use4thFormant);

                var vowelCode = VowelCode.CodeFromString(recognition.Code);

                var ipaSymbol = recognition.Symbol;


                res.Add(new VowelRecognition(i, median, counter, examples, continuants, contexts, vowelCode, recognition, ipaSymbol));


            }


            return res;

        }

        public static List<VowelRecognition> VowelsNeutralDwellingTimeWholeLife(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
        {
            var res = new List<VowelRecognition>();

            int contexts = ApsManager.ConditionalCount(readings, new Condition(null, ContextType.V_neutral));

            foreach (var i in oldPolishVowels)
            {
                int continuants = ApsManager.ConditionalCount(readings, new Condition(i));

                var condition = new Condition(i, ContextType.V_neutral, null, null, null, null, DwellingTime.wholeLife);

                var median = ApsManager.ConditionalMedian(readings, condition);
                //var median = ApsManager.ConditionalMean(readings, condition);

                var counter = ApsManager.ConditionalCount(readings, condition);

                var examples = ApsManager.GetExamples(readings, condition);

                var recognition = ApsManager.FindModel(new Reading(median), vowelModels, use4thFormant);

                var vowelCode = VowelCode.CodeFromString(recognition.Code);

                var ipaSymbol = recognition.Symbol;


                res.Add(new VowelRecognition(i, median, counter, examples, continuants, contexts, vowelCode, recognition, ipaSymbol));


            }


            return res;

        }


        public static List<VowelRecognition> VowelsNeutralParentsOriginBoth(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
        {
            var res = new List<VowelRecognition>();

            int contexts = ApsManager.ConditionalCount(readings, new Condition(null, ContextType.V_neutral));

            foreach (var i in oldPolishVowels)
            {
                int continuants = ApsManager.ConditionalCount(readings, new Condition(i));

                var condition = new Condition(i, ContextType.V_neutral, null, null, null, null, null, ParentsOrigin.bothFromTheSamePlace);

                var median = ApsManager.ConditionalMedian(readings, condition);
                //var median = ApsManager.ConditionalMean(readings, condition);

                var counter = ApsManager.ConditionalCount(readings, condition);

                var examples = ApsManager.GetExamples(readings, condition);

                var recognition = ApsManager.FindModel(new Reading(median), vowelModels, use4thFormant);

                var vowelCode = VowelCode.CodeFromString(recognition.Code);

                var ipaSymbol = recognition.Symbol;


                res.Add(new VowelRecognition(i, median, counter, examples, continuants, contexts, vowelCode, recognition, ipaSymbol));


            }


            return res;

        }

        public static List<VowelRecognition> VowelsNeutralParentsOriginMother(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
        {
            var res = new List<VowelRecognition>();

            int contexts = ApsManager.ConditionalCount(readings, new Condition(null, ContextType.V_neutral));

            foreach (var i in oldPolishVowels)
            {
                int continuants = ApsManager.ConditionalCount(readings, new Condition(i));

                var condition = new Condition(i, ContextType.V_neutral, null, null, null, null, null, ParentsOrigin.motherFromTheSamePlace);

                var median = ApsManager.ConditionalMedian(readings, condition);
                //var median = ApsManager.ConditionalMean(readings, condition);

                var counter = ApsManager.ConditionalCount(readings, condition);

                var examples = ApsManager.GetExamples(readings, condition);

                var recognition = ApsManager.FindModel(new Reading(median), vowelModels, use4thFormant);

                var vowelCode = VowelCode.CodeFromString(recognition.Code);

                var ipaSymbol = recognition.Symbol;


                res.Add(new VowelRecognition(i, median, counter, examples, continuants, contexts, vowelCode, recognition, ipaSymbol));


            }


            return res;

        }

        public static List<VowelRecognition> VowelsNeutralParentsOriginDifferent(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
        {
            var res = new List<VowelRecognition>();

            int contexts = ApsManager.ConditionalCount(readings, new Condition(null, ContextType.V_neutral));

            foreach (var i in oldPolishVowels)
            {
                int continuants = ApsManager.ConditionalCount(readings, new Condition(i));

                var condition = new Condition(i, ContextType.V_neutral, null, null, null, null, null, ParentsOrigin.bothFromDifferentPlaceOrOnlyFatherFromTheSame);

                var median = ApsManager.ConditionalMedian(readings, condition);
                //var median = ApsManager.ConditionalMean(readings, condition);

                var counter = ApsManager.ConditionalCount(readings, condition);

                var examples = ApsManager.GetExamples(readings, condition);

                var recognition = ApsManager.FindModel(new Reading(median), vowelModels, use4thFormant);

                var vowelCode = VowelCode.CodeFromString(recognition.Code);

                var ipaSymbol = recognition.Symbol;


                res.Add(new VowelRecognition(i, median, counter, examples, continuants, contexts, vowelCode, recognition, ipaSymbol));


            }


            return res;

        }


        public static List<VowelRecognition> VowelsNeutralBeginning(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
        {
            var res = new List<VowelRecognition>();

            int contexts = ApsManager.ConditionalCount(readings, new Condition(null, ContextType.V_neutral));

            foreach (var i in oldPolishVowels)
            {
                int continuants = ApsManager.ConditionalCount(readings, new Condition(i));

                var condition = new Condition(i, ContextType.V_neutral, ExcerptNo.beginning);

                var median = ApsManager.ConditionalMedian(readings, condition);
                //var median = ApsManager.ConditionalMean(readings, condition);

                var counter = ApsManager.ConditionalCount(readings, condition);

                var examples = ApsManager.GetExamples(readings, condition);

                var recognition = ApsManager.FindModel(new Reading(median), vowelModels, use4thFormant);

                var vowelCode = VowelCode.CodeFromString(recognition.Code);

                var ipaSymbol = recognition.Symbol;


                res.Add(new VowelRecognition(i, median, counter, examples, continuants, contexts, vowelCode, recognition, ipaSymbol));


            }


            return res;

        }

        public static List<VowelRecognition> VowelsNeutralEnd(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
        {
            var res = new List<VowelRecognition>();

            int contexts = ApsManager.ConditionalCount(readings, new Condition(null, ContextType.V_neutral));

            foreach (var i in oldPolishVowels)
            {
                int continuants = ApsManager.ConditionalCount(readings, new Condition(i));

                var condition = new Condition(i, ContextType.V_neutral, ExcerptNo.end);

                var median = ApsManager.ConditionalMedian(readings, condition);
                //var median = ApsManager.ConditionalMean(readings, condition);

                var counter = ApsManager.ConditionalCount(readings, condition);

                var examples = ApsManager.GetExamples(readings, condition);

                var recognition = ApsManager.FindModel(new Reading(median), vowelModels, use4thFormant);

                var vowelCode = VowelCode.CodeFromString(recognition.Code);

                var ipaSymbol = recognition.Symbol;


                res.Add(new VowelRecognition(i, median, counter, examples, continuants, contexts, vowelCode, recognition, ipaSymbol));


            }


            return res;

        }




        #endregion


        #region: With morphology categories

        public static List<VowelRecognition> V_j(List<Reading> readings, List<VowelModel> vowelModels, MorphCategory morphCategory, bool use4thFormant)
        {
            var res = new List<VowelRecognition>();

            int contexts = ApsManager.ConditionalCount(readings, new Condition(null, ContextType.V_neutral));

            foreach (var i in oldPolishVowels)
            {
                int continuants = ApsManager.ConditionalCount(readings, new Condition(i));

                //var condition = new Condition(i, ContextType.V_neutral, null, Age.young);
                var condition = new Condition(oldPolishVowel: i, contextType: ContextType.V_j, morphCategory: morphCategory);

                var median = ApsManager.ConditionalMedian(readings, condition);
                //var median = ApsManager.ConditionalMean(readings, condition);

                var counter = ApsManager.ConditionalCount(readings, condition);

                var examples = ApsManager.GetExamples(readings, condition);

                var recognition = ApsManager.FindModel(new Reading(median), vowelModels, use4thFormant);

                var vowelCode = VowelCode.CodeFromString(recognition.Code);

                var ipaSymbol = recognition.Symbol;


                res.Add(new VowelRecognition(i, median, counter, examples, continuants, contexts, vowelCode, recognition, ipaSymbol));


            }


            return res;

        }


        #endregion


        public static VowelRecognition RozpoznanieSamogłoski(
            Phone odpowiednikStaropolski,
            //ContextType kontekst,
            Education wykształcenie,
            Age wiek,
            PlaceTypeConverter miejscowość,
            DwellingTime okresZamieszkania,
            ParentsOrigin pochodzenieRodziców,
            Accented pozycjaAkcentowana,
            ExcerptNo pozycjaWNagraniu)
        {
            throw new NotImplementedException();
        }

        public static Recognition MiejsceAkcentu(
            StressPlace pozycjaAkcentu)
        {
            throw new NotImplementedException();
        }

        public static Recognition Mazurzenie(
            MazurzenieType typMazurzenia)
        {
            throw new NotImplementedException();
        }

        public static Recognition CzwartaPalatalizacja()
        {
            throw new NotImplementedException();
        }

        public static Recognition iPoDawnymMiękkimR()
        {
            throw new NotImplementedException();
        }

        public static Recognition FonetykaMiędzywyrazowa(SandhiType typFonetykiMiędzywyrazowej)
        {
            throw new NotImplementedException();
        }

        public static Recognition RozłożenieNosówki(NasalVowelContType typKontynuancji)
        {
            throw new NotImplementedException();
        }







    }




}
