using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using APS_2.ApsManager;
using APS_2.Symbols.Library;
using APS_2.Phonetics.Enums;
using APS_1.Symbols.Enums;
using APS_2.Symbols;
using APS_2.ApsManager.Enums;

namespace APS_2.Phonetics
{
    public class PhoneString
    {
        public List<List<Phone>> PhoneReading { get; set; }


        public PhoneString()
        {
            this.PhoneReading = new List<List<Phone>>();
        }





        /// <summary>
        /// Przetwarza listę odczytów: zamienia transkrypcje na ciągi fonów (obiektów klas Phone, Consonant, Vowel i pochodnych), dodaje informacje o mówcy oraz inne informacje. 
        /// </summary>
        /// <param name="readings">Wejściowa lista odczytów.</param>
        /// <param name="speakers">Wejściowa lista mówców.</param>
        /// <returns>Przetwarzona lista odczytów.</returns>
        public static void ProcessReadings(List<Reading> readings, List<Speaker> speakers)
        {
            foreach (var r in readings)
            {
                //find phones in TrA
                r.PhoneStringA = FindAndCorrectPhones(r.Segment, new XsampaLib());

                //find phones in TrS
                r.PhoneStringS = FindAndCorrectPhones(r.TranscriptionS, new simpLib());

                //find phones in TrG
                r.PhoneStringG = FindAndCorrectPhones(r.TranscriptionG, new simpLib());

                //find phones in TrO
                r.PhoneStringO = FindAndCorrectPhones(r.TranscriptionO, new simpLib());


                //add info on speaker
                AddInfoOnSpeakers(r, speakers);


                //add examples                


                //add contexts

            }




        }





        public static void AddContexts7(List<Reading> readings, List<Phone> auxPhones)
        {
            int index = -1;

            foreach (var r in readings)
            {
                foreach (var p in r.PhoneStringA)
                {
                    index += 1;

                    p.Context = new PhoneContext();

                    for (int i = 0, j = index - 1; i < 3 && j >= 0; i++, j--)
                    {
                        p.Context.Left.Add(auxPhones[j]);
                    }

                    for (int i = 0, j = index + 1; i < 3 && j < auxPhones.Count; i++, j++)
                    {
                        p.Context.Right.Add(auxPhones[j]);
                    }

                    var left = p.Context.Left.Count > 0 ? p.Context.Left[0].Symbol.IPA : "#";
                    var right = p.Context.Right.Count > 0 ? p.Context.Right[0].Symbol.IPA : "#";

                    Debug.WriteLine("Phone: [{0}]. Left: [{1}]. Right: [{2}]. LeftSize: {3}. RightSize: {4}", 
                        p.Symbol.IPA, left, right, p.Context.Left.Count, p.Context.Right.Count, "");


                }
            }












            var leftTemp = new List<Phone>();

            var rightTemp = new List<Phone>(auxPhones);

            for (int i = 0; i < auxPhones.Count; i++)
            {
                auxPhones[i].Context = new PhoneContext();


                var temp = new List<Phone>(leftTemp);

                temp.Reverse();

                auxPhones[i].Context.Left.AddRange(temp);

                rightTemp.RemoveAt(0);

                auxPhones[i].Context.Right.AddRange(rightTemp);

                leftTemp.Add(auxPhones[i]);

                var l = auxPhones[i].Context.Left.Count > 0 ? auxPhones[i].Context.Left[0].Symbol.IPA : "#";
                var r = auxPhones[i].Context.Right.Count > 0 ? auxPhones[i].Context.Right[0].Symbol.IPA : "#";

                Debug.WriteLine("Phone: [{0}]. Left: {1}. Right {2}", auxPhones[i].Symbol.IPA, l, r, "");
            }



        }







        public static void AddContexts6(List<Phone> auxPhones)
        {
            var leftTemp = new List<Phone>();

            var rightTemp = new List<Phone>(auxPhones);

            for (int i = 0; i < auxPhones.Count; i++)
            {
                auxPhones[i].Context = new PhoneContext();


                var temp = new List<Phone>(leftTemp);

                temp.Reverse();
                
                auxPhones[i].Context.Left.AddRange(temp);

                rightTemp.RemoveAt(0);

                auxPhones[i].Context.Right.AddRange(rightTemp);

                leftTemp.Add(auxPhones[i]);
                                
                var l = auxPhones[i].Context.Left.Count > 0 ? auxPhones[i].Context.Left[0].Symbol.IPA : "#";
                var r = auxPhones[i].Context.Right.Count > 0 ? auxPhones[i].Context.Right[0].Symbol.IPA : "#";

                Debug.WriteLine("Phone: [{0}]. Left: {1}. Right {2}", auxPhones[i].Symbol.IPA, l, r, "");
            }
                                    
            
                       
        }







        public static void AddContexts5(List<Reading> readings, List<Phone> auxPhones)
        {
            var list = new List<Phone>();

            foreach (var r in readings)
            {
                foreach (var p in r.PhoneStringA)
                {
                    p.Context = new PhoneContext();

                    var temp = list; temp.Reverse();

                    p.Context.Left.AddRange(temp);

                    auxPhones.RemoveAt(0);

                    p.Context.Right.AddRange(auxPhones);

                    list.Add(p);

                }
            }
        }







        public static void AddContexts4(List<Reading> readings, List<Phone> auxPhones)
        {

            foreach (var r in readings)
            {
                foreach (var p in r.PhoneStringA)
                {
                    int currentElementIndex = r.PhoneStringA.IndexOf(p);
                    int currentGroupIndex = readings.IndexOf(r);
                    var alreadyBrowsed = readings.GetRange(0, currentGroupIndex);
                    int sumOfAlreadyBrowsedElements = alreadyBrowsed.Sum(x => x.PhoneStringA.Count());
                    int number = sumOfAlreadyBrowsedElements + currentElementIndex;

                    p.PhoneNo = number;

                    p.Context = new PhoneContext();

                    for (int i = 0, j = number - 3; i < 3 && j >= 0; i++, j++)
                    {
                        p.Context.Left[i] = auxPhones[j];
                    }


                    for (int i = 0, j = number + 1; i < 0 && j < auxPhones.Count; i++, j++)
                    {
                        p.Context.Right[i] = auxPhones[j];
                    }



                }
            }


        }










        public static void AddContexts3(List<Reading> readings, List<Phone> auxPhoneString)
        {
            int index = -1;

            foreach (var r in readings)
            {
                foreach (var p in r.PhoneStringA)
                {
                    index += 1;

                    //Console.WriteLine(p.Symbol.IPA);
                    //Console.Write(auxPhoneString[index].Symbol.IPA);

                    p.Context = new PhoneContext();

                    //Console.Write("\t\t");

                    if (index - 3 >= 0)
                    {
                        p.Context.Left[0] = auxPhoneString[index - 1];
                        p.Context.Left[1] = auxPhoneString[index - 2];
                        p.Context.Left[2] = auxPhoneString[index - 3];

                        //Console.Write("{0} {1} {2}",
                        //    auxPhoneString[index - 1].Symbol.IPA,
                        //    auxPhoneString[index - 2].Symbol.IPA,
                        //    auxPhoneString[index - 3].Symbol.IPA);
                    }

                    //Console.Write("\t||\t");

                    if (index + 3 < auxPhoneString.Count)
                    {
                        p.Context.Right[0] = auxPhoneString[index + 1];
                        p.Context.Right[1] = auxPhoneString[index + 2];
                        p.Context.Right[2] = auxPhoneString[index + 3];

                        //Console.Write("{0} {1} {2}",
                        //    auxPhoneString[index + 1].Symbol.IPA,
                        // auxPhoneString[index + 2].Symbol.IPA,
                        //  auxPhoneString[index + 3].Symbol.IPA);
                    }



                }
            }



        }





        public static void AddContexts2(List<Reading> readings, List<Phone> auxPhoneString)
        {
            int index = -1;

            foreach (var r in readings)
            {
                foreach (var p in r.PhoneStringA)
                {
                    index += 1;

                    p.Context = new PhoneContext();

                    for (int i = 0; i < 3 && i + index + 1 < auxPhoneString.Count; i++)
                    {
                        //p.Context.Right[i] = auxPhoneString[index + i + 1];

                        p.Context.Right[0] = auxPhoneString[index + 1];
                    }


                }
            }




        }




        internal static void AddContexts(List<Reading> readings, List<Phone> auxPhoneStringA)
        {
            var right = new List<Phone[]>();

            for (int i = 0; i < auxPhoneStringA.Count - 3; i++)
            {
                right.Add(new Phone[3]);

                right[i][0] = auxPhoneStringA[i + 1];
                right[i][1] = auxPhoneStringA[i + 2];
                right[i][2] = auxPhoneStringA[i + 3];
            }



















            int index = -1;

            foreach (var r in readings)
            {
                foreach (var p in r.PhoneStringA)
                {
                    index += 1;

                    Debug.WriteLine("!!!INDEX: {0}", index, "");

                    p.Context = new PhoneContext();

                    //for (int i = 0;

                    //    i < p.Context.Right.Length && i + index + 1 < auxPhoneStringA.Count;

                    //    i++)
                    //{

                    //    p.Context.Right[i] = auxPhoneStringA[index + i + 1];


                    //    //p.Context.Right[i].Symbol.IPA = index.ToString();


                    //}


                    //Console.Write("{0}\t{1}\t{2} {3} {4}",
                    //    p.Symbol.IPA, auxPhoneStringA[index].Symbol.IPA,
                    //    auxPhoneStringA[index + 1].Symbol.IPA,
                    //    auxPhoneStringA[index + 2].Symbol.IPA,
                    //    auxPhoneStringA[index + 3].Symbol.IPA);



                    //Console.WriteLine("\t{0} {1} {2} \tGŁOSKA\t{3} {4} {5} ",
                    //    p.Context.Left[2].Symbol.IPA, p.Context.Left[1].Symbol.IPA, p.Context.Left[0].Symbol.IPA,

                    //    p.Context.Right[0].Symbol.IPA, p.Context.Right[1].Symbol.IPA, p.Context.Right[2].Symbol.IPA
                    //    );

                    //Console.WriteLine(); Console.WriteLine();
                }
            }




            //int index = -1;

            //foreach (var r in readings)
            //{
            //    foreach (var p in r.PhoneStringA)
            //    {
            //        index++;

            //        p.Context = new PhoneContext();

            //        for (int i = 0, j = index + 1; 

            //            i < p.Context.Right.Length && j < auxPhoneStringA.Count; 

            //            i++, j++)
            //        {
            //            p.Context.Right[i] = auxPhoneStringA[j];
            //        }


            //        //Console.Write("{0}\t{1}\t{2} {3} {4}",
            //        //    p.Symbol.IPA, auxPhoneStringA[index].Symbol.IPA,
            //        //    auxPhoneStringA[index + 1].Symbol.IPA,
            //        //    auxPhoneStringA[index + 2].Symbol.IPA,
            //        //    auxPhoneStringA[index + 3].Symbol.IPA);



            //        //Console.WriteLine("\t{0} {1} {2} \tGŁOSKA\t{3} {4} {5} ",
            //        //    p.Context.Left[2].Symbol.IPA, p.Context.Left[1].Symbol.IPA, p.Context.Left[0].Symbol.IPA,

            //        //    p.Context.Right[0].Symbol.IPA, p.Context.Right[1].Symbol.IPA, p.Context.Right[2].Symbol.IPA
            //        //    );

            //        //Console.WriteLine(); Console.WriteLine();
            //    }
            //}





            //int index = -1;

            //for (int i = 0; i < readings.Count; i++)
            //{
            //    for (int j = 0; j < readings[i].PhoneStringA.Count; j++)
            //    {
            //        index++;

            //        readings[i].PhoneStringA[j].Context = new PhoneContext();

            //        for (int k = index + 1, l = 0; k < auxPhoneStringA.Count && l < 3; k++, l++)
            //        {
            //            readings[i].PhoneStringA[j].Context.Right[l] = auxPhoneStringA[k];
            //        }

            //        //if (index > 3 && index < auxPhoneStringA.Count - 3)
            //        //{                        

            //        //    readings[i].PhoneStringA[j].Context.Left[0] = auxPhoneStringA[index - 1];
            //        //    readings[i].PhoneStringA[j].Context.Left[1] = auxPhoneStringA[index - 2]; 
            //        //    readings[i].PhoneStringA[j].Context.Left[2] = auxPhoneStringA[index - 3]; 


            //        //    readings[i].PhoneStringA[j].Context.Right[0] = auxPhoneStringA[index + 1]; 
            //        //    readings[i].PhoneStringA[j].Context.Right[1] = auxPhoneStringA[index + 2]; 
            //        //    readings[i].PhoneStringA[j].Context.Right[2] = auxPhoneStringA[index + 3]; 


            //        //}
            //    }
            //}

            index = 0;






        }



















        public static List<Phone> GetAuxPhoneString2(List<Reading> readings, Transcriptions transcription)
        {
            int index = -1;

            var res = new List<Phone>();

            foreach (var r in readings)
            {

                switch (transcription)
                {
                    case Transcriptions.transcriptionA:

                        foreach (var p in r.PhoneStringA)
                        {
                            index++;

                            p.PhoneNo = index;
                            //p.Reading = r;

                            res.Add(p);
                        }

                        break;
                    case Transcriptions.transcriptionS:

                        foreach (var p in r.PhoneStringS)
                        {
                            index++;

                            p.PhoneNo = index;
                            //p.Reading = r;

                            res.Add(p);
                        }

                        break;
                    case Transcriptions.transcriptionG:

                        foreach (var p in r.PhoneStringG)
                        {
                            index++;

                            p.PhoneNo = index;
                            //p.Reading = r;

                            res.Add(p);
                        }

                        break;
                    case Transcriptions.transcriptionO:

                        foreach (var p in r.PhoneStringO)
                        {
                            index++;

                            p.PhoneNo = index;
                            //p.Reading = r;

                            res.Add(p);
                        }

                        break;
                    default:
                        break;
                }
            }

            return res;
        }









        public static List<Phone> GetAuxPhoneString(List<Reading> readings, Transcriptions transcription)
        {
            int index = -1;

            var res = new List<Phone>();

            foreach (var r in readings)
            {

                switch (transcription)
                {
                    case Transcriptions.transcriptionA:

                        foreach (var p in r.PhoneStringA)
                        {
                            index++;

                            p.PhoneNo = index;
                            p.Reading = r;

                            res.Add(p);
                        }

                        break;
                    case Transcriptions.transcriptionS:

                        foreach (var p in r.PhoneStringS)
                        {
                            index++;

                            p.PhoneNo = index;
                            p.Reading = r;

                            res.Add(p);
                        }

                        break;
                    case Transcriptions.transcriptionG:

                        foreach (var p in r.PhoneStringG)
                        {
                            index++;

                            p.PhoneNo = index;
                            p.Reading = r;

                            res.Add(p);
                        }

                        break;
                    case Transcriptions.transcriptionO:

                        foreach (var p in r.PhoneStringO)
                        {
                            index++;

                            p.PhoneNo = index;
                            p.Reading = r;

                            res.Add(p);
                        }

                        break;
                    default:
                        break;
                }
            }

            return res;
        }














        //private static void AddExamplesTA(List<Reading> readings, Reading reading, Phone phone)
        //{
        //    int readingNo = readings.IndexOf(reading);

        //    int phoneNo = reading.PhoneStringA.IndexOf(phone);

        //    int[,] endLimitA = new int[1,1];

        //    List<Symbol> onward = new List<Symbol>();
        //    List<Symbol> backward = new List<Symbol>();

        //    bool breakCondition = false;

        //    for (int i = readingNo; i < readings.Count; i++)
        //    {
        //        if (breakCondition) break;

        //        for (int j = phoneNo; j < readings[i].PhoneStringA.Count; j++)
        //        {
        //            if (j == phoneNo) continue;

        //            if (
        //                readings[i].PhoneStringA[j].GetType() != typeof(Juncture)
        //                &&
        //                readings[i].PhoneStringA[j].GetType() != typeof(Pause)
        //                )
        //            {
        //                onward.Add(readings[i].PhoneStringA[j].Symbol);
        //            }
        //            else
        //            {
        //                breakCondition = true;
        //                break;
        //            }

        //        }
        //    }



        //    breakCondition = false;

        //    for (int i = readingNo; i >= 0; i--)
        //    {
        //        for (int j = i == readingNo ? phoneNo : readings[i].PhoneStringA.Count - 1; j >= 0; j--)
        //        {
        //            if (j == phoneNo) continue;

        //            if (
        //                readings[i].PhoneStringA[j].GetType() != typeof(Juncture)
        //                &&
        //                readings[i].PhoneStringA[j].GetType() != typeof(Pause)
        //                )
        //            {
        //                backward.Add(readings[i].PhoneStringA[j].Symbol);
        //            }
        //            else
        //            {
        //                breakCondition = true;
        //                break;
        //            }
        //        }
        //    }


        //    backward.Reverse();

        //    backward.AddRange(onward);

        //    if (phone.Example == null)
        //        phone.Example = new Example();

        //    phone.Example.TranscriptionA = backward;

        //}





        public static string[] GetTranscription(List<Symbol> symbols)
        {
            var ipa = new StringBuilder();
            var spa = new StringBuilder();
            var simplified = new StringBuilder();
            var xsampa = new StringBuilder();

            foreach (var i in symbols)
            {
                ipa.Append(i.IPA);
                spa.Append(i.SPA);
                simplified.Append(i.Simplified);
                xsampa.Append(i.XSampa);
            }

            var res = new string[4];

            res[0] = ipa.ToString();
            res[1] = spa.ToString();
            res[2] = simplified.ToString();
            res[3] = xsampa.ToString();

            return res;
        }














        //private static void AddExamples(List<Phone> phones)
        //{
        //    for (int i = 0; i < phones.Count; i++)
        //    {
        //        phones[i].Example = new Example();

        //        int begin = -1;
        //        int end = -1;

        //        if (phones[i].GetType() != typeof(Juncture)
        //            &&
        //            phones[i].GetType() != typeof(Pause))
        //        {
        //            //szukam początku przykładu
        //            if (i > 0)
        //            {
        //                for (int j = i - 1; j >= 0; j--)
        //                {
        //                    if (phones[j].GetType() == typeof(Juncture) || phones[j].GetType() == typeof(Pause) || j == 0)
        //                    {
        //                        begin = j;
        //                        break;
        //                    }
        //                }
        //            }

        //            //szukam końca przykładu
        //            if (i < phones.Count - 1)
        //            {
        //                for (int j = i + 1; j < phones.Count; j++)
        //                {
        //                    if (phones[j].GetType() == typeof(Juncture) || phones[j].GetType() == typeof(Pause) || j == phones.Count - 1)
        //                    {
        //                        end = j;
        //                        break;
        //                    }
        //                }
        //            }

        //            //dodaję fony                    
        //            for (int j = begin; j <= end; j++)
        //            {
        //                //phones[i].Example.IPA += phones[i].Symbol.IPA;
        //                //phones[i].Example.SPA += phones[i].Symbol.SPA;
        //                //phones[i].Example.Simplified += phones[i].Symbol.Simplified;
        //                //phones[i].Example.XSampa += phones[i].Symbol.XSampa;
        //            }


        //        }


        //    }
        //}



        private static void AddInfoOnSpeakers(Reading reading, List<Speaker> speakers)
        {
            //searching for the speaker
            int recordingNo = int.Parse(reading.RecordingNo);

            var speaker = speakers.Find(x => int.Parse(x.RecordingNo) == recordingNo);

            reading.Speaker = speaker;

            //adding info
            AddSpeaker(reading.PhoneStringA, speaker, reading.SpeakerType);
            AddSpeaker(reading.PhoneStringS, speaker, reading.SpeakerType);
            AddSpeaker(reading.PhoneStringG, speaker, reading.SpeakerType);
            AddSpeaker(reading.PhoneStringO, speaker, reading.SpeakerType);



        }

        private static void AddSpeaker(List<Phone> phones, Speaker speaker, SpeakerType speakerType)
        {
            for (int i = 0; i < phones.Count; i++)
            {
                phones[i].Speaker = speaker;
                phones[i].SpeakerType = speakerType;
            }

        }





        private static List<Phone> FindAndCorrectPhones(string text, Library library)
        {
            var res = new List<Phone>();

            var sortedLibrary = GetSortedLibrary(library);

            res = FindPhones6(text, sortedLibrary);

            res = CorrectDiacritics5(res);

            //res = CorrectDiacritics5(res);

            res = CorrectUnknownPhones2(res);

            return res;
        }



        /// <summary>
        /// Metoda rozpoznająca fony bez użycia rekurencji
        /// </summary>
        /// <param name="text">Napis wejściowy zawierający symbole fonetyczne.</param>
        /// <param name="library">Posortowana biblioteka symboli fonetycznych.</param>
        /// <returns>Lista fonów.</returns>
        public static List<Phone> FindPhones6(string text, Dictionary<string, Phone> sortedLibrary)
        {
            var res = new List<Phone>();

            StringBuilder unrecognized = new StringBuilder();

            int index = 0;
            int symbolsNo = sortedLibrary.Count;

            while (text.Length > 0)
            {
                index = 0;

                //Debug.WriteLine(">>>TEXT: >{0}<", text, "");

                foreach (var symbol in sortedLibrary)
                {
                    index++;

                    if (symbol.Key.Length > text.Length
                        ||
                        symbol.Key.Length == 0) continue;

                    var subtext = text.Substring(0, symbol.Key.Length);

                    //Debug.WriteLine(">>>SUBTEXT: >{0}<", subtext, "");

                    if (subtext.Equals(symbol.Key))
                    {
                        if (unrecognized.Length > 0)
                        {
                            //Debug.WriteLine(">>>ADDING UNRECOGNIZED: >{0}<", unrecognized.ToString(), "");
                            res.Add(new UnknownPhone(unrecognized.ToString()));

                            unrecognized = unrecognized.Clear();
                        }

                        //Debug.WriteLine(">>>ADDING SYMBOL: >{0}<", symbol.Value.Symbol.XSampa, "");


                        res.Add(symbol.Value);

                        text = text.Substring(symbol.Key.Length);
                        //Debug.WriteLine(">>>NEW TEXT: {0}", text, "");

                        break;
                    }



                    foreach (var item in res)
                    {
                        //Debug.WriteLine("WE HAVE NOW: {0}", item.Symbol.XSampa, "");
                    }



                }

                //No symbol was found
                if (text.Length > 0 && index == symbolsNo)
                {
                    unrecognized.Append(text[0]);
                    text = text.Substring(1);
                }

                //If there's no more characters in 'text'
                if (text.Length == 0 && unrecognized.Length > 0)
                {
                    res.Add(new UnknownPhone(unrecognized.ToString()));
                }

            }


            return res;
        }


        /// <summary>
        /// Nanosi wartość znaków diakrytycznych na odpowiednie symbole, po czym usuwa fony odpowiadające znakom diakrytycznym. 
        /// </summary>
        /// <param name="phones">Modyfikowany ciąg fonów.</param>
        /// <returns>Wyjściowy ciąg fonów.</returns>
        public static List<Phone> CorrectDiacritics5(List<Phone> phones)
        {


            //Przeglądam kolekcję fonów
            for (int i = 0; i < phones.Count; i++)
            {
                if (phones[i].DiacriticImpact == -1
                    &&
                    i - 1 >= 0
                    &&
                    phones[i].GetType() == typeof(Diacritic))
                {

                    if (phones[i - 1].GetType() == typeof(Vowel))
                    {
                        phones[i - 1] = (Vowel)phones[i - 1] + phones[i];
                    }
                    else if (phones[i - 1].GetType() == typeof(Consonant))
                    {
                        phones[i - 1] = (Consonant)phones[i - 1] + phones[i];
                    }

                    phones[i - 1].Symbol = AddSymbol(phones[i - 1], phones[i], phones[i].DiacriticImpact);



                    phones.RemoveAt(i);
                }
                else if (phones[i].DiacriticImpact == 1
                    &&
                    i + 1 < phones.Count
                    &&
                    phones[i].GetType() == typeof(Diacritic))
                {

                    if (phones[i + 1].GetType() == typeof(Vowel))
                    {
                        phones[i + 1] = (Vowel)phones[i + 1] + phones[i];

                    }
                    else if (phones[i + 1].GetType() == typeof(Consonant))
                    {

                        phones[i + 1] = (Consonant)phones[i + 1] + phones[i];
                    }

                    var s = AddSymbol(phones[i + 1], phones[i], phones[i].DiacriticImpact);

                    if (s != null)
                    {
                        phones[i + 1].Symbol = s;
                    }


                    phones.RemoveAt(i);
                }


            }

            return phones;

        }


        /// <summary>
        /// Korekta nierozpoznanych segmentów: fony ograniczone fonami typu UnknownPhoneDelimiter zostają zamienione na fony typu UnknownPhone (symbole fonetyczne zostają zachowane). Zmianie nie podlegają junktury i pauzy. 
        /// </summary>
        /// <param name="phones"></param>
        /// <returns></returns>
        public static List<Phone> CorrectUnknownPhones2(List<Phone> phones)
        {
            int begin = -1;
            int end = -1;

            for (int i = 0; i < phones.Count; i++)
            {
                if (phones[i].GetType() == typeof(UnknownPhoneDelimiter)
                    &&
                    end == -1)
                {
                    begin = i;
                }

                if (phones[i].GetType() == typeof(UnknownPhoneDelimiter)
                    &&
                    begin > -1)
                {
                    end = i;
                }
            }

            if (begin > -1 && begin < end)
            {
                for (int i = begin + 1; i < end; i++)
                {
                    if (phones[i].GetType() == typeof(Consonant)
                        ||
                        phones[i].GetType() == typeof(Vowel))
                    {
                        phones[i] = new UnknownPhone(phones[i].Symbol);
                    }
                }

                phones.RemoveAt(end);
                phones.RemoveAt(begin);
            }

            return phones;
        }




        public static Phone AddPhonesAndSymbols2(Phone phone, Diacritic diacritic, int diacriticImpact)
        {
            if (phone.GetType() == typeof(Consonant))
            {
                return new Consonant((Consonant)AddPhone(phone, diacritic), AddSymbol(phone, diacritic, diacriticImpact));
            }
            else if (phone.GetType() == typeof(Vowel))
            {
                return new Vowel((Vowel)AddPhone(phone, diacritic), AddSymbol(phone, diacritic, diacriticImpact));
            }
            else
            {
                return new Phone((Phone)AddPhone(phone, diacritic), AddSymbol(phone, diacritic, diacriticImpact));
            }
        }


        private static Symbol AddSymbol(Phone phone, Phone diacritic, int diacriticImpact)
        {
            Symbol s = new Symbol("");

            if (phone.Symbol == null && diacritic.Symbol == null) return s;
            else if (phone.Symbol == null && diacritic.Symbol != null) return diacritic.Symbol;
            else if (phone.Symbol != null && diacritic.Symbol == null) return phone.Symbol;
            else
            {

                if (diacriticImpact < 0)
                {
                    s = new Symbol(
                        phone.Symbol.IPA + diacritic.Symbol.IPA,
                        phone.Symbol.Simplified + diacritic.Symbol.Simplified,
                        phone.Symbol.SPA + diacritic.Symbol.SPA,
                        phone.Symbol.XSampa + diacritic.Symbol.XSampa
                        );
                }
                else if (diacriticImpact > 0)
                {
                    s = new Symbol(
                        diacritic.Symbol.IPA + phone.Symbol.IPA,
                        diacritic.Symbol.Simplified + phone.Symbol.Simplified,
                        diacritic.Symbol.SPA + phone.Symbol.SPA,
                        diacritic.Symbol.XSampa + phone.Symbol.XSampa
                        );
                }
                else
                {
                    s = new Symbol(
                        phone.Symbol.IPA,
                        phone.Symbol.Simplified,
                        phone.Symbol.SPA,
                        phone.Symbol.XSampa
                        );
                }
            }

            return s;
        }


        private static Phone AddPhone(Phone phone, Phone diacritic)
        {

            if (phone.GetType() == typeof(Consonant))
            {

                return new Consonant((Consonant)phone + diacritic, new Symbol());

            }
            else if (phone.GetType() == typeof(Vowel))
            {

                return new Vowel((Vowel)phone + diacritic, new Symbol());

            }
            else
            {
                return new Phone(phone);
            }




        }





        public static Phone AddPhonesAndSymbols(Phone phone, Phone diacritic, int diacriticImpact)
        {


            Symbol s = new Symbol("");

            if (diacriticImpact < 0)
            {
                s = new Symbol(
                    phone.Symbol.IPA + diacritic.Symbol.IPA,
                    phone.Symbol.Simplified + diacritic.Symbol.Simplified,
                    phone.Symbol.SPA + diacritic.Symbol.SPA,
                    phone.Symbol.XSampa + diacritic.Symbol.XSampa
                    );
            }
            else if (diacriticImpact > 0)
            {
                s = new Symbol(
                    diacritic.Symbol.IPA + phone.Symbol.IPA,
                    diacritic.Symbol.Simplified + phone.Symbol.Simplified,
                    diacritic.Symbol.SPA + phone.Symbol.SPA,
                    diacritic.Symbol.XSampa + phone.Symbol.XSampa
                    );
            }
            else
            {
                s = new Symbol(
                    phone.Symbol.IPA,
                    phone.Symbol.Simplified,
                    phone.Symbol.SPA,
                    phone.Symbol.XSampa
                    );
            }

            if (phone.GetType() == typeof(Consonant))
            {

                return new Consonant((Consonant)(((Consonant)phone) + diacritic), s);
            }
            else if (phone.GetType() == typeof(Vowel))
            {

                return new Vowel((Vowel)(((Vowel)phone) + diacritic), s);
            }
            else
            {
                //Roundness r = diacritic.Roundness == null ? (Roundness)phone.Roundness : (Roundness)diacritic.Roundness;
                //Phonation ph = diacritic.Phonation == null ? (Phonation)phone.Phonation : (Phonation)diacritic.Phonation;
                //Nasality n = diacritic.Nasality == null ? (Nasality)phone.Nasality : (Nasality)diacritic.Nasality;
                //Length l = diacritic.Length == null ? (Length)phone.Length : (Length)diacritic.Length;

                Debug.WriteLine("!!!TRYING TO ADD PHONE TO PHONE!!!");

                return new Phone(null, null, null, null, new Symbol());
            }

            //else
            //{

            //    return new Phone(
            //        diacritic.Roundness == null ? phone.Roundness : diacritic.Roundness,
            //        diacritic.Phonation == null ? phone.Phonation : diacritic.Phonation,
            //        diacritic.Nasality == null ? phone.Nasality : diacritic.Nasality,
            //        diacritic.Length == null ? phone.Length : diacritic.Length,
            //        s
            //        );
            //}
        }









        public static Dictionary<string, Phone> GetSortedLibrary(Library library)
        {
            var res = new Dictionary<string, Phone>();

            foreach (var i in library.Symbols)
            {
                if (!res.ContainsKey(i.Key)) res.Add(i.Key, i.Value);
            }

            //foreach (var i in library.ConsonantDiacritics)
            //{
            //    if (!res.ContainsKey(i.Key)) res.Add(i.Key, i.Value);
            //}

            //foreach (var i in library.Consonants) { if (!res.ContainsKey(i.Key)) res.Add(i.Key, i.Value); }

            //foreach (var i in library.OtherSymbols) { if (!res.ContainsKey(i.Key)) res.Add(i.Key, i.Value); }

            //foreach (var i in library.UnknownPhonesDelimiters) { if (!res.ContainsKey(i.Key)) res.Add(i.Key, i.Value); }

            //foreach (var i in library.VowelDiacritics) { if (!res.ContainsKey(i.Key)) res.Add(i.Key, i.Value); }

            //foreach (var i in library.Vowels) { if (!res.ContainsKey(i.Key)) res.Add(i.Key, i.Value); }

            res = res.OrderByDescending(x => x.Key.Length).ToDictionary<KeyValuePair<string, Phone>, string, Phone>(x => x.Key, x => x.Value);

            return res;


        }




















        public static void OrderPhones(List<Reading> readings)
        {
            int index = -1;

            foreach (var r in readings)
            {
                foreach (var p in r.PhoneStringA)
                {
                    index += 1;

                    p.PhoneNo = index;

                    //Console.WriteLine("{0}, {1}, {2}", index, p.PhoneNo, p.Symbol.IPA);
                }
            }

            index = -1;

            foreach (var r in readings)
            {
                foreach (var p in r.PhoneStringG)
                {
                    index += 1;

                    p.PhoneNo = index;
                }
            }

            index = -1;

            foreach (var r in readings)
            {
                foreach (var p in r.PhoneStringO)
                {
                    index += 1;

                    p.PhoneNo = index;
                }
            }

            index = -1;

            foreach (var r in readings)
            {
                foreach (var p in r.PhoneStringS)
                {
                    index += 1;

                    p.PhoneNo = index;
                }
            }





        }


    }
}
