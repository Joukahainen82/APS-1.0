using APS_2.ApsManager;
using APS_2.ApsManager.Enums;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_2.Phonetics
{
    public class Reading
    {
        #region Original properties

        public string RecordingNo { get; set; }
        public string ExcerptNo { get; set; }
        public string TableS { get; set; }
        public string TableF { get; set; }
        public string LineNo { get; set; }
        public SpeakerType SpeakerType { get; set; }
        public double T_min { get; set; }
        public double T_max { get; set; }
        public string Segment { get; set; }

        public string TranscriptionS { get; set; }
        public string TranscriptionG { get; set; }
        public string TranscriptionO { get; set; }

        #endregion

        #region: Additional properties

        public List<Phone> PhoneStringA { get; set; }
        public List<Phone> PhoneStringS { get; set; }
        public List<Phone> PhoneStringG { get; set; }
        public List<Phone> PhoneStringO { get; set; }

        public Speaker Speaker { get; set; }

        #endregion


        public Reading()
        {
            this.PhoneStringA = new List<Phone>();
            this.PhoneStringG = new List<Phone>();
            this.PhoneStringS = new List<Phone>();
            this.PhoneStringO = new List<Phone>();

            this.Speaker = new Speaker();
        }

    }



    public sealed class ReadingClassMap : CsvClassMap<Reading>
    {
        public ReadingClassMap()
        {
            Map(m => m.RecordingNo).Name("RecordingNo");
            Map(m => m.ExcerptNo).Name("ExcerptNo");
            Map(m => m.TableS).Name("TableS");

            Map(m => m.TableF).Name("TableF");
            Map(m => m.LineNo).Name("LineNo");
            Map(m => m.SpeakerType).Name("Person").TypeConverter(new StringToSpeakerTypeConverter());

            Map(m => m.T_min).Name("T_min");
            Map(m => m.T_max).Name("T_max");
            Map(m => m.Segment).Name("Segment");

            Map(m => m.TranscriptionS).Name("TranscriptionS");
            Map(m => m.TranscriptionG).Name("TranscriptionG");
            Map(m => m.TranscriptionO).Name("TranscriptionO");
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
