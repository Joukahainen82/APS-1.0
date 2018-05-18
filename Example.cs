using APS_1.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APS_1.ApsManager
{
    public class Example
    {
        //public int ReadingNo { get; set; }

        //public int SampleNo { get; set; }

        //public int RecordNo { get; set; }

        public List<Symbol> TranscriptionA { get; set; }
        public List<Symbol> TranscriptionS { get; set; }
        public List<Symbol> TranscriptionG { get; set; }
        public List<Symbol> TranscriptionO { get; set; }


        public Example()
        {

            this.TranscriptionA = new List<Symbol>();
            this.TranscriptionS = new List<Symbol>();
            this.TranscriptionG = new List<Symbol>();
            this.TranscriptionO = new List<Symbol>();

        }


    }
}
