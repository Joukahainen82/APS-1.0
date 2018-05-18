using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_1.ApsManager
{
    public class Speaker
    {
        public string RecordingNo { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }

        public string SpeakerNo { get; set; }
        public Education Education { get; set; }
        public Age Age { get; set; }

        public string Place { get; set; }
        public long Population { get; set; }
        public PlaceType PlaceType { get; set; }

        public string County { get; set; }
        public DwellingTime DwellingTime { get; set; }
        public ParentsOrigin ParentsOrigin { get; set; }

        public string AdditionalInfo { get; set; }
        public string Explorer { get; set; }
        public string FileName { get; set; }

        public long FileSize { get; set; }
        /// <summary>
        /// Długość nagrania w sekundach.
        /// </summary>
        public double Length { get; set; }
        public DateTime RecordYear { get; set; }

        public bool RecordYearCertain { get; set; }


    }


    sealed class SpeakerMap : CsvClassMap<Speaker>
    {
        public SpeakerMap()
        {
            Map(m => m.RecordingNo).Index(0);
            Map(m => m.Surname).Index(1);
            Map(m => m.Name).Index(2);

            Map(m => m.SpeakerNo).Index(3);
            Map(m => m.Education).Index(4).TypeConverter(new EducationConverter());
            Map(m => m.Age).Index(5).TypeConverter(new AgeConverter());

            Map(m => m.Place).Index(6);
            Map(m => m.Population).Index(7).TypeConverter(new PopulationConverter());
            Map(m => m.PlaceType).Index(8).TypeConverter(new PlaceTypeConverter());

            Map(m => m.County).Index(9);
            Map(m => m.DwellingTime).Index(10).TypeConverter(new DwellingTimeConverter());
            Map(m => m.ParentsOrigin).Index(11).TypeConverter(new ParentsOriginConverter());

            Map(m => m.AdditionalInfo).Index(12);
            Map(m => m.Explorer).Index(13);
            Map(m => m.FileName).Index(14);

            Map(m => m.FileSize).Index(15).TypeConverter(new FileSizeConverter());
            Map(m => m.Length).Index(16).TypeConverter(new LengthConverter());
            Map(m => m.RecordYear).Index(17).TypeConverter(new YearConverter());

            Map(m => m.RecordYearCertain).Index(17).TypeConverter(new RecordYearCertainConverter());


        }
    }




    sealed class LengthConverter : CsvHelper.TypeConversion.ITypeConverter
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
            double val = Double.Parse(text);

            int h = (int)(val * 24);

            val -= ((h / 24) - 1);

            int m = (int)(val * 24 * 60);

            val -= m / (24 * 60);

            int s = (int)(val * 24 * 60 * 60);

            return (double)(s + (60 * m) + (60 * 60 * h));
        }

        public string ConvertToString(CsvHelper.TypeConversion.TypeConverterOptions options, object value)
        {
            DateTime val = (DateTime)value;

            double res = 0;

            res += val.Hour / 24;

            res += val.Minute / (24 * 60);

            res += val.Second / (24 * 60 * 60);

            return res.ToString();
        }
    }



    sealed class YearConverter : CsvHelper.TypeConversion.ITypeConverter
    {
        public bool CanConvertFrom(Type type)
        {
            return type == typeof(string);
        }

        public bool CanConvertTo(Type type)
        {
            return type == typeof(DateTime);
        }

        public object ConvertFromString(CsvHelper.TypeConversion.TypeConverterOptions options, string text)
        {
            text = text.Replace("(", "");
            text = text.Replace(")", "");
            text = text.Replace("?", "");

            int y = Int32.Parse(text);

            return new DateTime(y, 1, 1);
        }

        public string ConvertToString(CsvHelper.TypeConversion.TypeConverterOptions options, object value)
        {
            return value.ToString();
        }
    }



    sealed class RecordYearCertainConverter : CsvHelper.TypeConversion.ITypeConverter
    {
        public bool CanConvertFrom(Type type)
        {
            return type == typeof(string);
        }

        public bool CanConvertTo(Type type)
        {
            return type == typeof(bool);
        }

        public object ConvertFromString(CsvHelper.TypeConversion.TypeConverterOptions options, string text)
        {
            return (text.IndexOf("?") == -1) ? false : true;
        }

        public string ConvertToString(CsvHelper.TypeConversion.TypeConverterOptions options, object value)
        {
            return (bool)value ? "" : "(?)";
        }
    }



    public sealed class EducationConverter : CsvHelper.TypeConversion.ITypeConverter
    {
        public bool CanConvertFrom(Type type)
        {
            return type == typeof(string);
        }

        public bool CanConvertTo(Type type)
        {
            return type == typeof(Education);
        }

        public object ConvertFromString(CsvHelper.TypeConversion.TypeConverterOptions options, string text)
        {
            switch (text)
            {
                case "wyższe":
                    return Education.higher;
                case "średnie":
                    return Education.secondary;
                case "zawodowe":
                    return Education.vocational;
                case "gimnazjalne":
                    return Education.middle;
                case "podstawowe":
                    return Education.primary;
                default:
                    return Education.noInformation;
            }
        }

        public string ConvertToString(CsvHelper.TypeConversion.TypeConverterOptions options, object value)
        {
            return value.ToString();
        }
    }



    sealed class AgeConverter : CsvHelper.TypeConversion.ITypeConverter
    {
        public bool CanConvertFrom(Type type)
        {
            return type == typeof(string);
        }

        public bool CanConvertTo(Type type)
        {
            return type == typeof(Age);
        }

        public object ConvertFromString(CsvHelper.TypeConversion.TypeConverterOptions options, string text)
        {
            if (text.Equals("brak informacji")) return Age.noInformation;

            int age = Int16.Parse(text);

            if (age >= 60) return Age.old;

            else if (age >= 30) return Age.middleAged;

            else return Age.young;
            
        }

        public string ConvertToString(CsvHelper.TypeConversion.TypeConverterOptions options, object value)
        {
            return value.ToString();
        }
    }



    sealed class PopulationConverter : CsvHelper.TypeConversion.ITypeConverter
    {
        public bool CanConvertFrom(Type type)
        {
            return type == typeof(string);
        }

        public bool CanConvertTo(Type type)
        {
            return type == typeof(long);
        }

        public object ConvertFromString(CsvHelper.TypeConversion.TypeConverterOptions options, string text)
        {
            return Int64.Parse(text);
        }

        public string ConvertToString(CsvHelper.TypeConversion.TypeConverterOptions options, object value)
        {
            return value.ToString();
        }
    }



    sealed class PlaceTypeConverter : CsvHelper.TypeConversion.ITypeConverter
    {
        public bool CanConvertFrom(Type type)
        {
            return type == typeof(string);
        }

        public bool CanConvertTo(Type type)
        {
            return type == typeof(PlaceType);
        }

        public object ConvertFromString(CsvHelper.TypeConversion.TypeConverterOptions options, string text)
        {
            switch (text)
            {
                case "miasto":
                    return PlaceType.town;
                case "wieś":
                    return PlaceType.village;
                default:
                    return PlaceType.noInformation;
            }
        }

        public string ConvertToString(CsvHelper.TypeConversion.TypeConverterOptions options, object value)
        {
            return value.ToString();
        }
    }



    public sealed class DwellingTimeConverter : CsvHelper.TypeConversion.ITypeConverter
    {
        public bool CanConvertFrom(Type type)
        {
            return type == typeof(string);
        }

        public bool CanConvertTo(Type type)
        {
            return type == typeof(DwellingTime);
        }

        public object ConvertFromString(CsvHelper.TypeConversion.TypeConverterOptions options, string text)
        {
            switch (text)
            {
                case "całe życie":
                    return DwellingTime.wholeLife;
                case "całe życie.":
                    return DwellingTime.wholeLife;
                case "część życia":
                    return DwellingTime.partOfLife;
                default:
                    return DwellingTime.noInformation;
            }
        }

        public string ConvertToString(CsvHelper.TypeConversion.TypeConverterOptions options, object value)
        {
            return value.ToString();
        }
    }



    sealed class ParentsOriginConverter : CsvHelper.TypeConversion.ITypeConverter
    {
        public bool CanConvertFrom(Type type)
        {
            return type == typeof(string); 
            //return type == typeof(ParentsOrigin);
        }

        public bool CanConvertTo(Type type)
        {
            return type == typeof(ParentsOrigin);
            //return type == typeof(string);
        }

        public object ConvertFromString(CsvHelper.TypeConversion.TypeConverterOptions options, string text)
        {            
            switch (text)
            {
                case "matka z tej samej miejscowości":
                    return ParentsOrigin.motherFromTheSamePlace;                      
                case "oboje z innej miejscowości lub tylko ojciec z tej samej":
                    return ParentsOrigin.bothFromDifferentPlaceOrOnlyFatherFromTheSame;
                case "oboje z tej samej miejscowości":
                    return ParentsOrigin.bothFromTheSamePlace;
                default: 
                    return ParentsOrigin.noInformation;
            }
        }

        public string ConvertToString(CsvHelper.TypeConversion.TypeConverterOptions options, object value)
        {
            return value.ToString();
        }
    }

    

    sealed class FileSizeConverter : CsvHelper.TypeConversion.ITypeConverter
    {
        public bool CanConvertFrom(Type type)
        {
            return type == typeof(string);
        }

        public bool CanConvertTo(Type type)
        {
            return type == typeof(long);
        }

        public object ConvertFromString(CsvHelper.TypeConversion.TypeConverterOptions options, string text)
        {
            if (text.Equals("")) return (long)0;
            else return Int64.Parse(text);
        }

        public string ConvertToString(CsvHelper.TypeConversion.TypeConverterOptions options, object value)
        {
            return value.ToString();
        }
    }


    
}
