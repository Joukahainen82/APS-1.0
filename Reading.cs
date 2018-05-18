using APS_1.ApsManager;
using APS_1.ApsManager.Enums;
using APS_1.Phonetics.Enums;
using APS_1.Symbols.Enums;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_1.Phonetics
{
    public class Reading
    {
        #region Original properties

        public string RecordingNo { get; set; }
        public string ExcerptNo { get; set; }
        public string LineNo { get; set; }
        public SpeakerType SpeakerType { get; set; }

        public string Segment { get; set; }
        public string TranscriptionS { get; set; }
        public string TranscriptionG { get; set; }
        public string TranscriptionO { get; set; }

        public string Notes { get; set; }

        public double F1_Hz { get; set; }
        public double F2_Hz { get; set; }
        public double F3_Hz { get; set; }
        public double F4_Hz { get; set; }

        public double f_1_min { get; set; }
        public double f_2_min { get; set; }
        public double f_3_min { get; set; }
        public double f_4_min { get; set; }

        public double f_1_max { get; set; }
        public double f_2_max { get; set; }
        public double f_3_max { get; set; }
        public double f_4_max { get; set; }

        public double rel_F1 { get; set; }
        public double rel_F2 { get; set; }
        public double rel_F3 { get; set; }
        public double rel_F4 { get; set; }

        #endregion

        #region: Additional properties

        public List<Phone> PhoneStringA { get; set; }
        public List<Phone> PhoneStringS { get; set; }
        public List<Phone> PhoneStringG { get; set; }
        public List<Phone> PhoneStringO { get; set; }

        public Speaker Speaker { get; set; }

        public OldPolishVowels OldPolishVowel { get; set; }


        public List<ContextType> ContextType { get; set; }

        public VowelModel VowelModel { get; set; }


        public MorphCategory MorphCategory { get; set; }


        #endregion



        public Reading()
        {
            this.PhoneStringA = new List<Phone>();
            this.PhoneStringG = new List<Phone>();
            this.PhoneStringS = new List<Phone>();
            this.PhoneStringO = new List<Phone>();

            this.ContextType = new List<ContextType>(); 

            this.Speaker = new Speaker();
        }

        public Reading(Frequency frequency)
        {
            this.rel_F1 = frequency.F1;
            this.rel_F2 = frequency.F2;
            this.rel_F3 = frequency.F3;
            this.rel_F4 = frequency.F4;
        }


        public bool Contains(Phone phone, Nullable<Transcriptions> transcription = null)
        {
            switch (transcription)
            {
                case Transcriptions.transcriptionA:
                    foreach (var p in this.PhoneStringA)
                    {
                        if (p.Equals(phone)) return true;
                    }
                    return false;
                case Transcriptions.transcriptionS:
                    foreach (var p in this.PhoneStringS)
                    {
                        if (p.Equals(phone)) return true;
                    }
                    return false;
                case Transcriptions.transcriptionG:
                    foreach (var p in this.PhoneStringG)
                    {
                        if (p.Equals(phone)) return true;
                    }
                    return false;
                case Transcriptions.transcriptionO:
                    foreach (var p in this.PhoneStringO)
                    {
                        if (p.Equals(phone)) return true;
                    }
                    return false;
                default:
                    bool c1 = false, c2 = false, c3 = false, c4 = false;
                    foreach (var p in this.PhoneStringA) if (p.Equals(phone)) c1 = true;
                    foreach (var p in this.PhoneStringS) if (p.Equals(phone)) c2 = true;
                    foreach (var p in this.PhoneStringG) if (p.Equals(phone)) c3 = true;
                    foreach (var p in this.PhoneStringO) if (p.Equals(phone)) c4 = true;
                    return c1 || c2 || c3 || c4;
            }
        }
    
    
    }



    public sealed class ReadingClassMap : CsvClassMap<Reading>
    {
        public ReadingClassMap()
        {
            //[F1_Hz];[F2_Hz];[F3_Hz];[F4_Hz];f_1_min;f_2_min;f_3_min;f_4_min;f_1_max;f_2_max;f_3_max;f_4_max

            Map(m => m.RecordingNo).Name("RecordingNo");
            Map(m => m.ExcerptNo).Name("ExcerptNo");
            Map(m => m.LineNo).Name("LineNo");

            Map(m => m.SpeakerType).Name("Person").TypeConverter(new StringToSpeakerTypeConverter());

            Map(m => m.Segment).Name("Segment");
            Map(m => m.TranscriptionS).Name("TranscriptionS");
            Map(m => m.TranscriptionG).Name("TranscriptionG");
            Map(m => m.TranscriptionO).Name("TranscriptionO");

            Map(m => m.Notes).Name("Notes");

            Map(m => m.F1_Hz).Name("[F1_Hz]").TypeConverter(new StringToDoubleTypeConverter());
            Map(m => m.F2_Hz).Name("[F2_Hz]").TypeConverter(new StringToDoubleTypeConverter());
            Map(m => m.F3_Hz).Name("[F3_Hz]").TypeConverter(new StringToDoubleTypeConverter());
            Map(m => m.F4_Hz).Name("[F4_Hz]").TypeConverter(new StringToDoubleTypeConverter());

            Map(m => m.f_1_min).Name("f_1_min").TypeConverter(new StringToDoubleTypeConverter());
            Map(m => m.f_2_min).Name("f_2_min").TypeConverter(new StringToDoubleTypeConverter());
            Map(m => m.f_3_min).Name("f_3_min").TypeConverter(new StringToDoubleTypeConverter());
            Map(m => m.f_4_min).Name("f_4_min").TypeConverter(new StringToDoubleTypeConverter());

            Map(m => m.f_1_max).Name("f_1_max").TypeConverter(new StringToDoubleTypeConverter());
            Map(m => m.f_2_max).Name("f_2_max").TypeConverter(new StringToDoubleTypeConverter());
            Map(m => m.f_3_max).Name("f_3_max").TypeConverter(new StringToDoubleTypeConverter());
            Map(m => m.f_4_max).Name("f_4_max").TypeConverter(new StringToDoubleTypeConverter());


        }


    }

    public sealed class StringToDoubleTypeConverter : CsvHelper.TypeConversion.ITypeConverter
    {

        public bool CanConvertFrom(Type type)
        {
            return type == typeof(string);
        }

        public bool CanConvertTo(Type type)
        {
            return type == typeof(double);
        }

        public object ConvertFromString(CsvHelper.TypeConversion.TypeConverterOptions options, string text)
        {

            double output;

            bool done = double.TryParse(text, System.Globalization.NumberStyles.Number, CultureInfo.CurrentCulture, out output);

            return output;
        }

        public string ConvertToString(CsvHelper.TypeConversion.TypeConverterOptions options, object value)
        {
            return value.ToString();
        }
    }



    public sealed class StringToSpeakerTypeConverter : CsvHelper.TypeConversion.ITypeConverter
    {
        public bool CanConvertFrom(Type type)
        {
            return type == typeof(string);
        }

        public bool CanConvertTo(Type type)
        {
            return type == typeof(SpeakerType);
        }

        public object ConvertFromString(CsvHelper.TypeConversion.TypeConverterOptions options, string text)
        {
            if (text.Equals("Parlator") ||
                text.Equals("Informator") ||
                text.Equals("Eksplorator")) return Enum.Parse(typeof(SpeakerType), text);
            else return SpeakerType.Eksplorator;
        }

        public string ConvertToString(CsvHelper.TypeConversion.TypeConverterOptions options, object value)
        {
            return value.ToString();
        }

    }


}
