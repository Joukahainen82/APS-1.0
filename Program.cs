using APS_1.Symbols.Enums;
using APS_2.Phonetics;
using APS_2.Phonetics.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.Unicode;


            //---------------------------------------------------------------
            //POBRANIE DANYCH Z ANALIZ AKUSTYCZNYCH
            Console.WriteLine("Pobieram dane z analiz akustycznych.");

            string path = @"D:\Projekty\APS\APS_2\Data\Readings.csv";

            var readings = ApsManager.ApsManager.GetReadings(path);
            //---------------------------------------------------------------


            //---------------------------------------------------------------
            //POBRANIE INFORMACJI O BADANYCH
            Console.WriteLine("Pobieram dane na temat badanych.");

            path = @"D:\Projekty\APS\APS_2\Data\Speakers.csv";

            var speakers = ApsManager.ApsManager.GetSpeakers(path);
            //---------------------------------------------------------------


            //---------------------------------------------------------------
            //ANALIZA TRANSKRYPCJI, DODANIE INFORMACJI O BADANYCH
            Console.WriteLine("Analizuję transkrypcje fonetyczne i dodaję informacje o badanych");

            PhoneString.ProcessReadings(readings, speakers);
            //---------------------------------------------------------------


            //---------------------------------------------------------------
            //TWORZĘ POMOCNICZE CIĄGI SEGMENTÓW
            Console.WriteLine("Tworzę pomocnicze ciągi segmentów");

            var auxPhoneStringA = PhoneString.GetAuxPhoneString2(readings, Transcriptions.transcriptionA);
            //---------------------------------------------------------------



            //---------------------------------------------------------------
            //ANALIZUJĘ KONTEKSTY KAŻDEGO SEGMENTU
            Console.WriteLine("Analizuję konteksty każdego segmentu");

            PhoneString.AddContexts7(readings, auxPhoneStringA);

            //---------------------------------------------------------------


            foreach (var r in readings)
            {
                foreach (var p in r.PhoneStringA)
                {

                    Console.Write("{0}\t\t\t", p.Symbol.IPA);

                    foreach (var i in p.Context.Left)
                    {
                        Console.Write("{0} ", i.Symbol.IPA);
                    }

                    Console.Write("\t||\t");

                    foreach (var i in p.Context.Right)
                    {
                        Console.Write("{0} ", i.Symbol.IPA);
                    }

                    Console.WriteLine(); Console.WriteLine();

                }
            }
























            //int index = -1;

            //foreach (var r in readings)
            //{
            //    Console.WriteLine("{0}, {1}, {2}", r.RecordingNo, r.ExcerptNo, r.LineNo);

            //    foreach (var p in r.PhoneStringA)
            //    {
            //        index++;


            //        //Console.Write("{0}\t{1}\t{2} {3} {4}",
            //        //    p.Symbol.IPA, auxPhoneStringA[index].Symbol.IPA,
            //        //    auxPhoneStringA[index + 1].Symbol.IPA,
            //        //    auxPhoneStringA[index + 2].Symbol.IPA,
            //        //    auxPhoneStringA[index + 3].Symbol.IPA);


            //        Console.Write("{0}\t{1}\t{2}\t{3}\t",
            //            index, p.Symbol.IPA, "", auxPhoneStringA[index].Symbol.IPA);


            //        Console.WriteLine("\t{0} {1} {2} \tGŁOSKA\t{3} {4} {5} ",
            //            p.Context.Left[2].Symbol.IPA, p.Context.Left[1].Symbol.IPA, p.Context.Left[0].Symbol.IPA,

            //            p.Context.Right[0].Symbol.IPA, p.Context.Right[1].Symbol.IPA, p.Context.Right[2].Symbol.IPA
            //            );
            //    }
            //}







            //int index = -1;

            //for (int i = 0; i < readings.Count; i++)
            //{
            //    for (int j = 0; j < readings[i].PhoneStringA.Count; j++)
            //    {
            //        index++;

            //        if (index >= 3 && index < auxPhoneStringA.Count - 3)
            //        {



            //            if (index >= 3 && index < auxPhoneStringA.Count - 3)
            //                Console.WriteLine("{0}\t{1}\t\t\tl: {2}{3}{4}\t\t\tp: {5}{6}{7}",
            //                    readings[i].PhoneStringA[j].Symbol.IPA,                                 
            //                    auxPhoneStringA[index].Symbol.IPA,

            //                    auxPhoneStringA[index - 3].Symbol.IPA, auxPhoneStringA[index - 2].Symbol.IPA, auxPhoneStringA[index - 1].Symbol.IPA,

            //                    auxPhoneStringA[index + 1].Symbol.IPA, auxPhoneStringA[index + 2].Symbol.IPA, auxPhoneStringA[index + 3].Symbol.IPA
            //                );

            //            Console.WriteLine();



            //        }
            //    }
            //}




            //int index = -1;

            //foreach (var r in readings)
            //{
            //    foreach (var p in r.PhoneStringA)
            //    {
            //        index++;

            //        if (index >= 3 && index < auxPhoneStringA.Count - 3)
            //            Console.WriteLine("{0}\t{1}\t\t\tl: {2}{3}{4}\t\t\tp: {5}{6}{7}",
            //                p.Symbol.IPA,
            //                auxPhoneStringA[index].Symbol.IPA,

            //                auxPhoneStringA[index - 3].Symbol.IPA, auxPhoneStringA[index - 2].Symbol.IPA, auxPhoneStringA[index - 1].Symbol.IPA,

            //                auxPhoneStringA[index + 1].Symbol.IPA, auxPhoneStringA[index + 2].Symbol.IPA, auxPhoneStringA[index + 3].Symbol.IPA
            //            );

            //        Console.WriteLine();

            //    }
            //}





            //int index = -1;
            //foreach (var r in readings)
            //{
            //    Console.WriteLine("Transkrypcja A: [{0}]", r.Segment);

            //    foreach (var p in r.PhoneStringA)
            //    {
            //        //index++;

            //        Console.WriteLine("Transkrypcja A po analizie (IPA): [{0}]", p.Symbol.IPA);

            //        //Console.WriteLine("Element ciągu fonicznego: {0}", auxPhoneStringA[index].Symbol.IPA);

            //        Console.Write("Kontekst: ");

            //        Console.Write("\t");

            //        foreach (var i in p.Context.Left)
            //        {
            //            Console.Write("{0} ", i.Symbol.IPA);
            //        }

            //        Console.Write("\tGŁOSKA\t");

            //        foreach (var i in p.Context.Right)
            //        {
            //            Console.Write("{0} ", i.Symbol.IPA);
            //        }

            //        Console.WriteLine();
            //    }

            //    Console.WriteLine(); Console.WriteLine();
            //}












            //var library = new simpLib();
            //var library = new XsampaLib();

            //var sortedLibrary = PhoneString.GetSortedLibrary(library);

            //foreach (var reading in readings)
            //{
            //    var phones = PhoneString.FindPhones6(reading.Segment, sortedLibrary);

            //    phones = PhoneString.CorrectDiacritics5(phones);

            //    phones = PhoneString.CorrectUnknownPhones2(phones);



            //    Console.WriteLine("Record no.: {0}, excerpt no.: {1}, segment no.: {2}",
            //            reading.RecordingNo,
            //            reading.ExcerptNo,
            //            reading.LineNo);

            //    Console.WriteLine("[{0}]", reading.Segment);

            //    foreach (var i in phones)
            //    {
            //        if (i.GetType() == typeof(Vowel))
            //        {
            //            Console.WriteLine("[{0}]\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}",
            //                i.Symbol.IPA,
            //                i.GetType(),
            //                ((Vowel)i).Height,
            //                ((Vowel)i).Frontness,
            //                ((Vowel)i).MannerOfArticulation,
            //                ((Vowel)i).Nasality,
            //                ((Vowel)i).Length,
            //                ((Vowel)i).Roundness,
            //                ((Vowel)i).Stress.HasValue);
            //        }
            //        else if (i.GetType() == typeof(Consonant))
            //        {
            //            Console.WriteLine("[{0}]\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}",
            //                i.Symbol.IPA,
            //                i.GetType(),
            //                ((Consonant)i).PlaceOfArticulation,
            //                ((Consonant)i).MannerOfArticulation,
            //                ((Consonant)i).Phonation,
            //                ((Consonant)i).Nasality,
            //                ((Consonant)i).Palatalization.HasValue,
            //                ((Consonant)i).Roundness);
            //        }
            //        else
            //        {
            //            Console.WriteLine("[{0}]\t{1}", i.Symbol.IPA, i.GetType());
            //        }
            //    }

            //    Console.WriteLine(); Console.WriteLine();














            //if (phones.Exists(x => x.GetType() == typeof(UnknownPhone)))
            //{
            //    Console.WriteLine("Reading no: {0}, excerpt no: {1}, line: {2}",
            //        reading.RecordingNo,
            //        reading.ExcerptNo,
            //        reading.LineNo);

            //    Console.WriteLine("Transcription S: [{0}]", reading.TranscriptionS);
            //    Console.WriteLine("Transcription G: [{0}]", reading.TranscriptionG);
            //    Console.WriteLine("Transcription O: [{0}]", reading.TranscriptionO);

            //    foreach (var phone in phones)
            //    {
            //        Console.WriteLine("{0}\t{1}\t{2}\t{3}", phone.Symbol.SPA, phone.GetType(), phone.Phonation, phone.Nasality);
            //    }

            //    Console.WriteLine(); Console.WriteLine();
            //}


            //Console.WriteLine("Reading no: {0}, excerpt no: {1}, line: {2}",
            //    reading.RecordingNo,
            //    reading.ExcerptNo,
            //    reading.LineNo);

            //Console.WriteLine("Transcription S: [{0}]", reading.TranscriptionS);
            //Console.WriteLine("Transcription G: [{0}]", reading.TranscriptionG);
            //Console.WriteLine("Transcription O: [{0}]", reading.TranscriptionO);

            //foreach (var phone in phones)
            //{
            //    Console.WriteLine("{0}\t{1}\t{2}\t{3}", phone.Symbol.SPA, phone.GetType(), phone.Phonation, phone.Nasality);
            //}

            //Console.WriteLine(); Console.WriteLine();



            //}





            //Vowel o = PhonePrototypes.o;

            //var o2 = o + PhonePrototypes.primaryStress1;

            //Diacritic d = new Diacritic(o2, 1);

            ////Vowel res = (Vowel)PhoneString.AddPhonesAndSymbols2(o, d, 1);

            //Console.WriteLine(d.Stress);

            //Console.WriteLine(((Vowel)(o + d)).Stress);
            ////phones[i - 1] = (((Vowel)(phones[i - 1])) + phones[i]);
            //Console.WriteLine((o + d).Stress);

            ////Console.WriteLine(res.Stress);






            //var phones = PhoneString.FindPhones4(xsampa, sortedLibrary);

            //ParameterizedThreadStart foo = new ParameterizedThreadStart(PhoneString.CorrectDiacritics3);

            //Thread thread = new Thread(foo, 1200000000 / 1);

            //thread.Start(phones);

            //phones = PhoneString.CorrectDiacritics4(phones);

            //foreach (var i in phones)
            //{
            //    Console.WriteLine("{0}\t{1}\t{2}", i.Symbol.IPA, i.GetType(), i.DiacriticImpact);
            //}







            //WYDRUK WSZYSTKICH SEGMENTÓW TRANSKRYPCJI A
            //foreach (var i in readings)
            //{
            //    //i.PhoneStringA = new List<Phone>();

            //    //i.PhoneStringA.Add(PhoneString.FindPhones(i.Segment, new SampaLib()));
            //    i.PhoneStringA = PhoneString.FindPhones(i.Segment, new SampaLib());
            //}
            //Console.WriteLine();

            //foreach (var i in readings)
            //{
            //    Console.WriteLine("Segment: [{0}]", i.Segment);

            //    foreach (var j in i.PhoneStringA)
            //    {
            //        Console.Write(j.Symbol.XSampa);
            //    }

            //    Console.WriteLine();
            //    Console.WriteLine();
            //}






            //NIE KASOWAĆ: LICZBA NIEROZPOZNANYCH SYMBOLI: 
            //var no = ps.PhoneReading.Select(x => x.Count(y => y.Symbol.IPA.Equals("*"))).Sum();

            //Console.WriteLine(no);


















        }
    }
}
