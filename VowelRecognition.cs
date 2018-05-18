using APS_1.Phonetics;
using APS_1.Phonetics.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APS_1.ApsManager
{
    public class VowelRecognition : Recognition
    {
        public OldPolishVowels OldPolishVowel { get; set; }

        public Frequency ConditionalMedian { get; set; }

        public string IpaSymbol { get; set; }

        public VowelRecognition(OldPolishVowels oldPolishVowel, Frequency conditionalMedian, int counter, List<string> examples, int continuants, int contexts, VowelCode vowelCode, VowelModel recognition, string ipaSymbol)
        {
            this.OldPolishVowel = oldPolishVowel;
            this.ConditionalMedian = conditionalMedian;
            this.Counter = counter;
            this.Examples = examples;
            this.PercentageOnContexts = (double)counter / contexts;
            this.PercentageOnContinuants = (double)counter / continuants;
            this.VowelCode = vowelCode;
            this.IpaSymbol = ipaSymbol;

        }


    }
}
