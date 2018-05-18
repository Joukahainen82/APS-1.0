using APS_1.ApsManager;
using APS_1.Symbols;
using APS_1.Symbols.Enums;
using APS_1.Symbols.Library;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using APS_1.Phonetics.Enums;

namespace APS_1.Phonetics
{
    public class PhoneString
    {
        public List<List<Phone>> PhoneReading { get; set; }


        private static readonly Frequency[] typicalFrequencies = new[] {
            new Frequency(100, 400, 1400, 3000), 
            new Frequency(1000, 2800, 4000, 5000)
        };




        public delegate bool Comparer(Reading reading, List<Reading> readings);


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


                //add info on readings
                AddInfoOnReadings(r);

                //add examples                


                //add contexts

            }




        }





        public static void TagContext2(List<Reading> readings, Comparer method, List<Comparer> exceptions, ContextType contextType)
        {
            foreach (var r in readings)
            {
                
                if (method(r, readings))
                {
                    bool appliable = true;

                    foreach (var e in exceptions)
                    {
                        if (e(r, readings))
                        {
                            appliable = false;
                            break;
                        }
                    }

                    if (appliable)
                    {
                        ApplyContexts(r, contextType);
                    }
                }

            }
        }




        public static void TagContext(List<Reading> readings, Comparer method, ContextType contextType)
        {
            foreach (var r in readings)
            {
                if (method(r, readings)) ApplyContexts(r, contextType);
            }
        }





        /// <summary>
        /// Sprawdza wszystkie fony w każdym odczycie i przypisuje im oznaczenie kontekstu, jeśli tylko dany fon spełnia odpowiednie kryteria. 
        /// </summary>
        /// <param name="readings"></param>
        public static void TagContexts(ref List<Reading> readings)
        {
            foreach (var r in readings)
            {
                if (V_neutral(r, readings)) ApplyContexts(r, ContextType.V_neutral);
                if (Ṽ_(r, readings)) ApplyContexts(r, ContextType.Ṽ_);
                if (Ṽ_S(r, readings)) ApplyContexts(r, ContextType.Ṽ_S);
                if (Ṽ_T(r, readings)) ApplyContexts(r, ContextType.Ṽ_T);
                if (V_ł(r, readings)) ApplyContexts(r, ContextType.V_ł);
                if (V_l(r, readings)) ApplyContexts(r, ContextType.V_l);
                if (V_rz(r, readings)) ApplyContexts(r, ContextType.V_rz);
                if (V_r(r, readings)) ApplyContexts(r, ContextType.V_r);
                if (V_j(r, readings)) ApplyContexts(r, ContextType.V_j);
                if (cz_V(r, readings)) ApplyContexts(r, ContextType.cz_V);
                if (rz_V(r, readings)) ApplyContexts(r, ContextType.rz_V);
                if (ć_V_N(r, readings)) ApplyContexts(r, ContextType.ć_V_N);
                if (V_N(r, readings)) ApplyContexts(r, ContextType.V_N);

                if (r.ContextType.Count == 0) r.ContextType.Add(ContextType.unspecified);
            }

        }




        private static void ApplyContexts(Reading reading, ContextType contextType)
        {
            if (reading.ContextType.Contains(ContextType.unspecified)) reading.ContextType.Remove(ContextType.unspecified);

            reading.ContextType.Add(contextType);

            //Debug.WriteLine("AFTER APPLY CONTEXT THE NUMBER OF CONTEXTS: {0}", reading.ContextType.Count);

            //foreach (var i in reading.PhoneStringA)
            //{
            //    i.Context.ContextType.Add(contextType);
            //}

            //foreach (var i in reading.PhoneStringG)
            //{
            //    i.Context.ContextType.Add(contextType);
            //}

            //foreach (var i in reading.PhoneStringO)
            //{
            //    i.Context.ContextType.Add(contextType);
            //}

            //foreach (var i in reading.PhoneStringS)
            //{
            //    i.Context.ContextType.Add(contextType);
            //}

        }




        #region Contexts checkers


        /// <summary>
        /// Sprawdza obecność kontekstu neutralnego dla samogłoski
        /// </summary>
        /// <returns></returns>
        public static bool V_neutral(Reading reading, List<Reading> readings)
        {
            //warunki
            bool con0 = false, con1 = false, con2 = false, con3 = false, con4 = false, con5 = false, con6 = false, con7 = false, con8 = false, con9 = false;

            //warunek 0: pojedyncza samogłoska w transkrypcji S i A
            con0 = ContainsOnlyVowel(reading, Transcriptions.transcriptionS)
                &&
                ContainsOnlyVowel(reading, Transcriptions.transcriptionA);

            //warunek 1: samogłoska NIE jest w kontekście V_N
            con1 = !V_N(reading, readings);

            //warunek 2: samogłoska NIE jest w kontekście ć_V_V
            con2 = !ć_V_N(reading, readings);

            //warunek 3: samogłoska NIE jest w kontekście V_r
            con3 = !V_r(reading, readings);

            //warunek 4: samogłoska NIE jest w kontekście V_rz
            con4 = !V_rz(reading, readings);

            //warunek 5: samogłoska NIE jest w kontekście V_l
            con5 = !V_l(reading, readings);

            //warunek 6: samogłoska NIE jest w kontekście V_ł
            con6 = !V_ł(reading, readings);

            //warunek 7: samogłoska NIE jest w kontekście V_j
            con7 = !V_j(reading, readings);

            //warunek 8: samogłoska NIE jest w kontekście rz_V
            con8 = !rz_V(reading, readings);

            //warunek 9: samogłoska NIE jest w kontekście cz_V
            con9 = !cz_V(reading, readings);


            //wszystkie warunki muszą być spełnione
            return con0 && con1 && con2 && con3 && con4 && con5 && con6 && con7 && con8 && con9;

        }


        
        /// <summary>
        /// Samogłoska nosowa (transkrypcja S) w wygłosie.
        /// </summary>
        /// <param name="reading"></param>
        /// <param name="readings"></param>
        /// <returns></returns>
        public static bool Ṽ_(Reading reading, List<Reading> readings)
        {
            //warunki
            bool con1 = false, con2 = false, con3 = false, con4 = false;

            //warunek 1: informator
            con1 = reading.SpeakerType == SpeakerType.Parlator || reading.SpeakerType == SpeakerType.Informator;

            //warunek 2: pojedyncza samogłoska w transkypcji A i S
            con2 = ContainsOnlyVowel(reading, Transcriptions.transcriptionA)
                    &&
                    ContainsOnlyVowel(reading, Transcriptions.transcriptionS);

            //warunek 3: junktura/pauza w wygłosie bieżącego odczytu lub w nagłosie następnego
            if (reading.PhoneStringS.Count > 0)
            {
                GetBothContexts(ref readings, ref reading, Transcriptions.transcriptionS);

                if (reading.PhoneStringS[0].Context.Right.Count > 0)
                {
                    int n = reading.PhoneStringS.Count - 1;

                    con3 = reading.PhoneStringS[n].GetType() == typeof(Juncture)
                        ||
                        reading.PhoneStringS[n].GetType() == typeof(Pause)
                        ||
                        reading.PhoneStringS[n].Context.Right[0].GetType() == typeof(Juncture)
                        ||
                        reading.PhoneStringS[n].Context.Right[0].GetType() == typeof(Pause);

                }

                //warunek 4: samogłoska nosowa w transkrypcji S
                con4 = reading.PhoneStringS[0].MannerOfArticulation == MannerOfArticulation.vowel
                        &&
                        reading.PhoneStringS[0].Nasality == Nasality.nasal;

            }


            //wszystkie warunki muszą być spełnione 
            return con1 && con2 && con3 && con4;

        }

        
        
        public static bool Ṽ_S(Reading reading, List<Reading> readings)
        {
            //warunki
            bool con1 = false, con2 = false, con3 = false, con4 = false, con5 = false, con6 = false;

            //warunek 1: informator
            con1 = reading.SpeakerType == SpeakerType.Parlator || reading.SpeakerType == SpeakerType.Informator;

            //warunek 2: pojedyncza samogłoska w transkypcji A i S
            con2 = ContainsOnlyVowel(reading, Transcriptions.transcriptionA)
                    &&
                    ContainsOnlyVowel(reading, Transcriptions.transcriptionS);

            //warunek 3 i 4: spółgłoska trąca, nienosowa w nagłosie następnego segmentu transkrypcji S
            if (reading.PhoneStringS.Count > 0)
            {
                GetBothContexts(ref readings, ref reading, Transcriptions.transcriptionS);

                if (reading.PhoneStringS[0].Context.Right.Count > 0)
                {
                    con3 = reading.PhoneStringS[0].Context.Right[0].MannerOfArticulation == MannerOfArticulation.fricative;

                    con4 = reading.PhoneStringS[0].Context.Right[0].Nasality != Nasality.nasal;
                }

                //warunek 5: samogłoska nosowa w transkrypcji S
                con5 = reading.PhoneStringS[0].MannerOfArticulation == MannerOfArticulation.vowel
                        &&
                        reading.PhoneStringS[0].Nasality == Nasality.nasal;

                //warunek 6: w bieżącym odczycie nie ma pauzy lub junktury
                con6 = !reading.PhoneStringS.Contains(new Juncture())
                    &&
                    !reading.PhoneStringS.Contains(new Pause());
            }


            //wszystkie warunki muszą być spełnione 
            return con1 && con2 && con3 && con4 && con5 && con6;

        }

        

        /// <summary>
        /// Czy po dawnej (transkrypcja S) samogłosce nosowej znajduje się spółgłoska zwarta. 
        /// </summary>
        public static bool Ṽ_T(Reading reading, List<Reading> readings)
        {
            //warunki
            bool con1 = false, con2 = false, con3 = false, con4 = false, con5 = false, con6 = false;

            //warunek 1: informator
            con1 = reading.SpeakerType == SpeakerType.Parlator || reading.SpeakerType == SpeakerType.Informator;

            //warunek 2: pojedyncza samogłoska w transkypcji A i S
            con2 = ContainsOnlyVowel(reading, Transcriptions.transcriptionA)
                    &&
                    ContainsOnlyVowel(reading, Transcriptions.transcriptionS);

            //warunek 3 i 4: spółgłoska zwarta/zwarto-trąca, nienosowa w nagłosie następnego segmentu transkrypcji S
            if (reading.PhoneStringS.Count > 0)
            {
                GetBothContexts(ref readings, ref reading, Transcriptions.transcriptionS);

                if (reading.PhoneStringS[0].Context.Right.Count > 0)
                {
                    con3 = reading.PhoneStringS[0].Context.Right[0].MannerOfArticulation == MannerOfArticulation.stop
                        ||
                        reading.PhoneStringS[0].Context.Right[0].MannerOfArticulation == MannerOfArticulation.affricate;

                    con4 = reading.PhoneStringS[0].Context.Right[0].Nasality != Nasality.nasal;
                }

                //warunek 5: samogłoska nosowa w transkrypcji S
                con5 = reading.PhoneStringS[0].MannerOfArticulation == MannerOfArticulation.vowel
                        &&
                        reading.PhoneStringS[0].Nasality == Nasality.nasal;

                //warunek 6: w bieżącym odczycie nie ma pauzy lub junktury
                con6 = !reading.PhoneStringS.Contains(new Juncture())
                    &&
                    !reading.PhoneStringS.Contains(new Pause());
            }


            //wszystkie warunki muszą być spełnione 
            return con1 && con2 && con3 && con4 && con5 && con6;

        }
        


        public static bool V_ł(Reading reading, List<Reading> readings)
        {
            //warunki
            bool con1 = false, con2 = false, con3 = false, con4 = false, con5 = false, con6 = false;

            //warunek 1: informator
            con1 = reading.SpeakerType == SpeakerType.Informator || reading.SpeakerType == SpeakerType.Parlator;

            //warunek 2: pojedyncza samogłoska w wygłosie
            con2 = ContainsOnlyVowelEnd(reading, Transcriptions.transcriptionA)
                &&
                ContainsOnlyVowelEnd(reading, Transcriptions.transcriptionS);

            //warunek 3, 4, 5, 6: spółgłoska boczna w nagłosie następnego wyrazu
            if (reading.PhoneStringS.Count > 0)
            {
                GetBothContexts(ref readings, ref reading, Transcriptions.transcriptionS);

                if (reading.PhoneStringS[0].Context.Right.Count > 0)
                {
                    con3 = reading.PhoneStringS[0].Context.Right[0].MannerOfArticulation == MannerOfArticulation.semivowel;

                    con4 = reading.PhoneStringS[0].Context.Right[0].Roundness == Roundness.rounded;

                    con5 = reading.PhoneStringS[0].Context.Right[0].Phonation == Phonation.voiced;

                    if (reading.PhoneStringS[0].Context.Right[0].GetType() == typeof(Consonant))
                        con6 = ((Consonant)reading.PhoneStringS[0].Context.Right[0]).PlaceOfArticulation == PlaceOfArticulation.velar;
                }


            }

            //warunek 7: samogłoska nie znajduje się w asymilujących kontekstach lewostronnych
            //con7 = !rz_V(reading, readings) && !cz_V(reading, readings);

            return con1 && con2 && con3 && con4 && con5 && con6;
        }
        


        public static bool V_l(Reading reading, List<Reading> readings)
        {
            //warunki
            bool con1 = false, con2 = false, con3 = false;

            //warunek 1: informator
            con1 = reading.SpeakerType == SpeakerType.Informator || reading.SpeakerType == SpeakerType.Parlator;

            //warunek 2: pojedyncza samogłoska w wygłosie
            con2 = ContainsOnlyVowelEnd(reading, Transcriptions.transcriptionA)
                &&
                ContainsOnlyVowelEnd(reading, Transcriptions.transcriptionS);

            //warunek 3: spółgłoska boczna w nagłosie następnego wyrazu
            if (reading.PhoneStringS.Count > 0)
            {
                GetBothContexts(ref readings, ref reading, Transcriptions.transcriptionS);

                if (reading.PhoneStringS[0].Context.Right.Count > 0)
                {
                    con3 = reading.PhoneStringS[0].Context.Right[0].MannerOfArticulation == MannerOfArticulation.lateral;
                }


            }

            //warunek 4: samogłoska nie znajduje się w asymilujących kontekstach lewostronnych
            //con4 = !rz_V(reading, readings) && !cz_V(reading, readings);

            return con1 && con2 && con3;
        }
        


        public static bool V_rz(Reading reading, List<Reading> readings)
        {
            //warunki
            bool con1 = false, con2 = false, con3 = false;

            //warunek 1: informator
            con1 = reading.SpeakerType == SpeakerType.Informator || reading.SpeakerType == SpeakerType.Parlator;

            //warunek 2: pojedyncza samogłoska w wygłosie
            con2 = ContainsOnlyVowelEnd(reading, Transcriptions.transcriptionA)
                &&
                ContainsOnlyVowelEnd(reading, Transcriptions.transcriptionS);

            //warunek 3: spółgłoska drżąca w nagłosie następnego wyrazu
            if (reading.PhoneStringS.Count > 0)
            {
                GetBothContexts(ref readings, ref reading, Transcriptions.transcriptionS);

                if (reading.PhoneStringS[0].Context.Right.Count > 0)
                {
                    con3 = reading.PhoneStringS[0].Context.Right[0].MannerOfArticulation == MannerOfArticulation.fricativeTrill;
                }


            }

            //warunek 4: samogłoska nie znajduje się w asymilujących kontekstach lewostronnych
            //con4 = !rz_V(reading, readings) && !cz_V(reading, readings);

            return con1 && con2 && con3;
        }
        


        public static bool V_r(Reading reading, List<Reading> readings)
        {
            //warunki
            bool con1 = false, con2 = false, con3 = false;

            //warunek 1: informator
            con1 = reading.SpeakerType == SpeakerType.Informator || reading.SpeakerType == SpeakerType.Parlator;

            //warunek 2: pojedyncza samogłoska w wygłosie
            con2 = ContainsOnlyVowelEnd(reading, Transcriptions.transcriptionA)
                &&
                ContainsOnlyVowelEnd(reading, Transcriptions.transcriptionS);

            //warunek 3: spółgłoska drżąca w nagłosie następnego wyrazu
            if (reading.PhoneStringS.Count > 0)
            {
                GetBothContexts(ref readings, ref reading, Transcriptions.transcriptionS);

                if (reading.PhoneStringS[0].Context.Right.Count > 0)
                {
                    con3 = reading.PhoneStringS[0].Context.Right[0].MannerOfArticulation == MannerOfArticulation.trill;
                }


            }

            //warunek 4: samogłoska nie znajduje się w asymilujących kontekstach lewostronnych
            //con4 = !rz_V(reading, readings) && !cz_V(reading, readings);

            return con1 && con2 && con3;
        }
        


        public static bool V_j(Reading reading, List<Reading> readings)
        {
            //warunki
            bool con1 = false, con2 = false, con3 = false;

            //warunek 1: informator
            con1 = reading.SpeakerType == SpeakerType.Parlator || reading.SpeakerType == SpeakerType.Informator;

            //warunek 2: tylko samogłoska w wygłosie
            con2 = ContainsOnlyVowelEnd(reading, Transcriptions.transcriptionS) &&
                ContainsOnlyVowelEnd(reading, Transcriptions.transcriptionA);

            //warunek 3: półsamogłoska j w nagłosie następnego fonu
            if (reading.PhoneStringS.Count > 0)
            {
                GetBothContexts(ref readings, ref reading, Transcriptions.transcriptionS);

                //reading.PhoneStringS[0].Context = new PhoneContext();
                //reading.PhoneStringS[0].Context.Left = GetLeftContext(readings, reading, reading.PhoneStringA[0], Transcriptions.transcriptionA).ToList();
                //reading.PhoneStringS[0].Context.Right = GetRightContext(readings, reading, reading.PhoneStringA[0], Transcriptions.transcriptionA).ToList();

                if (reading.PhoneStringS[0].Context.Right.Count > 0)
                {
                    if (reading.PhoneStringS[0].Context.Right[0].GetType() == typeof(Consonant))
                    {
                        con3 = reading.PhoneStringS[0].Context.Right[0].MannerOfArticulation == MannerOfArticulation.semivowel
                                &&
                                reading.PhoneStringS[0].Context.Right[0].Phonation == Phonation.voiced
                                &&
                            ((Consonant)reading.PhoneStringS[0].Context.Right[0]).PlaceOfArticulation == PlaceOfArticulation.palatal;
                    }
                }


            }

            //warunek 4: samogłoska nie znajduje się w asymilujących kontekstach lewostronnych
            //con4 = !rz_V(reading, readings) && !cz_V(reading, readings);

            //wszystkie warunku muszą być spełnione
            return con1 && con2 && con3;

        }
        


        public static bool cz_V(Reading reading, List<Reading> readings)
        {
            //warunki
            bool con1 = false, con2 = false, con3 = false;

            //warunek 1: odczyt głoski wykonanej przez informatora
            con1 = reading.SpeakerType == SpeakerType.Parlator || reading.SpeakerType == SpeakerType.Informator;

            //warunek 2: odczyt zawiera wyłącznie samogłoskę
            con2 = ContainsOnlyVowelBeginning(reading, Transcriptions.transcriptionS)
                &&
                ContainsOnlyVowel(reading, Transcriptions.transcriptionA);

            //warunek 3: w prepozycji znajduje się spółgłoska postalweolarna trąca lub zwarto-trąca
            if (reading.PhoneStringS.Count > 0)
            {
                GetBothContexts(ref readings, ref reading, Transcriptions.transcriptionS);

                //reading.PhoneStringS[0].Context = new PhoneContext();
                //reading.PhoneStringS[0].Context.Left = GetLeftContext(readings, reading, reading.PhoneStringS[0], Transcriptions.transcriptionS).ToList();
                //reading.PhoneStringS[0].Context.Right = GetRightContext(readings, reading, reading.PhoneStringS[0], Transcriptions.transcriptionS).ToList();

                if (reading.PhoneStringS[0].Context.Left.Count > 0
                    &&
                    reading.PhoneStringS[0].Context.Left[0].GetType() == typeof(Consonant))
                {
                    con3 = ((Consonant)reading.PhoneStringS[0].Context.Left[0]).PlaceOfArticulation == PlaceOfArticulation.postalveolar
                        &&
                        (reading.PhoneStringS[0].Context.Left[0].MannerOfArticulation == MannerOfArticulation.fricative
                        ||
                        reading.PhoneStringS[0].Context.Left[0].MannerOfArticulation == MannerOfArticulation.affricate);

                }
            }

            //warunek 4: spółgłoska nie znajduje się w prawostronnym kontekście asymilującym
            //con4 = !V_j(reading, readings) &&
            //    !V_l(reading, readings) &&
            //    !V_ł(reading, readings) &&
            //    !V_N(reading, readings) &&
            //    !V_r(reading, readings) &&
            //    !V_rz(reading, readings) &&
            //    !ć_V_N(reading, readings);

            //wszystkie warunki muszą być spełnione
            return con1 && con2 && con3;

        }
        


        public static bool rz_V(Reading reading, List<Reading> readings)
        {
            //warunki
            bool con1 = false, con2 = false, con3 = false, con4 = false;

            //warunek 1: samogłoska musi być wymówiona przez informatora
            con1 = reading.SpeakerType == SpeakerType.Informator || reading.SpeakerType == SpeakerType.Parlator;

            //warunek 2: w odczycie znajduje się tylko jedna samogłoska
            con2 = ContainsOnlyVowelBeginning(reading, Transcriptions.transcriptionA);

            //warunek 3: badana samogłoska jest genetycznie samogłoską (ma odpowiednik w transkrypcji S)
            con3 = ContainsOnlyVowel(reading, Transcriptions.transcriptionS);

            //warunek 4: w następnym segmencie znajduje się dawna spółgłoska r'
            if (reading.PhoneStringS.Count > 0)
            {
                GetBothContexts(ref readings, ref reading, Transcriptions.transcriptionS);

                //reading.PhoneStringS[0].Context = new PhoneContext();
                //reading.PhoneStringS[0].Context.Left = GetLeftContext(readings, reading, reading.PhoneStringS[0], Transcriptions.transcriptionS).ToList();
                //reading.PhoneStringS[0].Context.Right = GetRightContext(readings, reading, reading.PhoneStringS[0], Transcriptions.transcriptionS).ToList();

                if (reading.PhoneStringS[0].Context.Left.Count > 0)
                    con4 = reading.PhoneStringS[0].Context.Left[0].MannerOfArticulation == MannerOfArticulation.fricativeTrill;
            }

            //warunek 5: spółgłoska nie znajduje się w prawostronnym kontekście asymilującym
            //con5 = !V_j(reading, readings) &&
            //    !V_l(reading, readings) &&
            //    !V_ł(reading, readings) &&
            //    !V_N(reading, readings) &&
            //    !V_r(reading, readings) &&
            //    !V_rz(reading, readings) &&
            //    !ć_V_N(reading, readings);

            //wszystkie warunki muszą być spełnione
            return con1 && con2 && con3 && con4;
        }
        


        public static bool ć_V_N(Reading reading, List<Reading> readings)
        {
            //warunki
            bool con1 = false, con2 = false, con3 = false;

            //warunek 1: po samogłosce musi się znajdować spółgłoska nosowa, a w odczycie musi się znajdować pojedyncza samogłoska
            con1 = V_N(reading, readings);

            //warunek 2: przed samogłoską musi się znajdować spółgłoska miękka
            if (reading.PhoneStringS.Count > 0)
            {

                GetBothContexts(ref readings, ref reading, Transcriptions.transcriptionS);

                if (reading.PhoneStringS[0].Context.Left.Count > 0)
                {
                    if (reading.PhoneStringS[0].Context.Left[0].GetType() == typeof(Consonant))
                    {
                        con2 = ((Consonant)reading.PhoneStringS[0].Context.Left[0]).PlaceOfArticulation == PlaceOfArticulation.palatal;
                    }
                }


            }

            //warunek 3: w ciągu fonicznym znajduje się tylko 1 fon wokaliczny
            con3 = ContainsOnlyOneVowel(reading, Transcriptions.transcriptionA);


            //wszystkie warunki muszą być spełnione
            return con1 && con2 && con3;
        }
        


        public static bool V_N(Reading reading, List<Reading> readings)
        {
            //warunki
            bool con1, con2 = false, con3 = false, con4 = false;

            //warunek 1: odczyt musi pochodzić od badanego
            con1 = reading.SpeakerType == SpeakerType.Parlator || reading.SpeakerType == SpeakerType.Informator;

            //warunek 2: odczyt musi zawierać tylko 1 samogłoskę stwierdzoną w badaniu akustycznym
            con2 = ContainsOnlyVowelEnd(reading, Transcriptions.transcriptionA);

            //warunek 3: odczyt musi zawierać tylko 1 samogłoskę w transkrypcji S (genetycznie w tym miejscu powinna być tylko 1 samogłoska)
            con3 = ContainsOnlyVowelEnd(reading, Transcriptions.transcriptionS);

            //warunek 4: kolejny fon jest zwarty i jest nosowy       
            

            if (reading.PhoneStringS.Count > 0)
            {
                GetBothContexts(ref readings, ref reading, Transcriptions.transcriptionS);

                if (reading.PhoneStringS[0].Context.Right.Count > 0)
                {
                    con4 =
                        reading.PhoneStringS[0].Context.Right[0].MannerOfArticulation == MannerOfArticulation.stop
                        &&
                        reading.PhoneStringS[0].Context.Right[0].Nasality == Nasality.nasal;
                }


            }


            //wszystkie warunki muszą być spełnione
            return con1 && con2 && con3 && con4;
        }

        #endregion


        #region Content checkers

        /// <summary>
        /// Czy ciąg foniczny zawiera półsamogłoskę i ewentualnie pauzę i/lub junkturę. 
        /// </summary>
        /// <param name="reading"></param>
        /// <param name="transcription"></param>
        /// <returns></returns>
        public static bool ContainsOnlySemivowel(Reading reading, Transcriptions transcription)
        {

            bool con1 = false, con2 = false, con3 = false, con4 = false;

            switch (transcription)
            {
                case Transcriptions.transcriptionA:

                    //w ciągu fonicznym nie ma samogłosek
                    con1 = reading.PhoneStringA.Count(x => x.GetType() == typeof(Vowel)) == 0;

                    //w ciągu fonicznym jest 1 samogłoska
                    con2 = reading.PhoneStringA.Count(x => x.GetType() == typeof(Consonant)) == 1;

                    //w ciągu fonicznym nie ma nierozpoznanych głosek
                    con3 = reading.PhoneStringA.Count(x => x.GetType() == typeof(UnknownPhone)) == 0;

                    //jedyna rozpoznana spółgłoska jest półsamogłoską
                    foreach (var p in reading.PhoneStringA)
                    {
                        if (p.GetType() == typeof(Consonant) && p.MannerOfArticulation == MannerOfArticulation.semivowel)
                        {
                            con4 = true;
                        }
                    }


                    break;
                case Transcriptions.transcriptionS:

                    //w ciągu fonicznym nie ma samogłosek
                    con1 = reading.PhoneStringS.Count(x => x.GetType() == typeof(Vowel)) == 0;

                    //w ciągu fonicznym jest 1 samogłoska
                    con2 = reading.PhoneStringS.Count(x => x.GetType() == typeof(Consonant)) == 1;

                    //w ciągu fonicznym nie ma nierozpoznanych głosek
                    con3 = reading.PhoneStringS.Count(x => x.GetType() == typeof(UnknownPhone)) == 0;

                    //jedyna rozpoznana spółgłoska jest półsamogłoską
                    foreach (var p in reading.PhoneStringS)
                    {
                        if (p.GetType() == typeof(Consonant) && p.MannerOfArticulation == MannerOfArticulation.semivowel)
                        {
                            con4 = true;
                        }
                    }

                    break;
                case Transcriptions.transcriptionG:

                    //w ciągu fonicznym nie ma samogłosek
                    con1 = reading.PhoneStringG.Count(x => x.GetType() == typeof(Vowel)) == 0;

                    //w ciągu fonicznym jest 1 samogłoska
                    con2 = reading.PhoneStringG.Count(x => x.GetType() == typeof(Consonant)) == 1;

                    //w ciągu fonicznym nie ma nierozpoznanych głosek
                    con3 = reading.PhoneStringG.Count(x => x.GetType() == typeof(UnknownPhone)) == 0;

                    //jedyna rozpoznana spółgłoska jest półsamogłoską
                    foreach (var p in reading.PhoneStringG)
                    {
                        if (p.GetType() == typeof(Consonant) && p.MannerOfArticulation == MannerOfArticulation.semivowel)
                        {
                            con4 = true;
                        }
                    }

                    break;
                case Transcriptions.transcriptionO:

                    //w ciągu fonicznym nie ma samogłosek
                    con1 = reading.PhoneStringO.Count(x => x.GetType() == typeof(Vowel)) == 0;

                    //w ciągu fonicznym jest 1 samogłoska
                    con2 = reading.PhoneStringO.Count(x => x.GetType() == typeof(Consonant)) == 1;

                    //w ciągu fonicznym nie ma nierozpoznanych głosek
                    con3 = reading.PhoneStringO.Count(x => x.GetType() == typeof(UnknownPhone)) == 0;

                    //jedyna rozpoznana spółgłoska jest półsamogłoską
                    foreach (var p in reading.PhoneStringO)
                    {
                        if (p.GetType() == typeof(Consonant) && p.MannerOfArticulation == MannerOfArticulation.semivowel)
                        {
                            con4 = true;
                        }
                    }

                    break;
                default:
                    break;
            }




            //wszystkie 3 warunki muszą być jednocześnie spełnione
            return con1 && con2 && con3 && con4;


        }



        /// <summary>
        /// Czy ciąg foniczny zawiera samogłoskę w wygłosie (w nagłosie może się znajdować pauza i/lub junktura).
        /// </summary>
        /// <param name="reading"></param>
        /// <param name="transcription"></param>
        /// <returns></returns>
        public static bool ContainsOnlyVowelEnd(Reading reading, Transcriptions transcription)
        {
            bool con1 = false, con2 = false, con3 = false;
            int n = -1;

            switch (transcription)
            {
                case Transcriptions.transcriptionA:
                    //w ciągu fonicznym jest tylko jedna samogłoska
                    n = reading.PhoneStringA.Count == 0 ? 0 : reading.PhoneStringA.Count - 1;

                    if (reading.PhoneStringA.Count > 0)
                        con1 = reading.PhoneStringA[n].MannerOfArticulation == MannerOfArticulation.vowel;

                    //w ciągu fonicznym nie ma spółgłosek (wszystkie niesamogłoski są pauzami lub junkturami)
                    int notC = reading.PhoneStringA.Count(x => x.MannerOfArticulation != MannerOfArticulation.vowel);
                    int pauseOrJuncture = reading.PhoneStringA.Count(x => x.GetType() == typeof(Pause) || x.GetType() == typeof(Juncture));
                    con2 = notC == pauseOrJuncture;

                    //w ciągu fonicznym nie ma nierozpoznanych głosek
                    con3 = reading.PhoneStringA.Count(x => x.GetType() == typeof(UnknownPhone)) == 0;
                    break;
                case Transcriptions.transcriptionS:

                    n = reading.PhoneStringS.Count == 0 ? 0 : reading.PhoneStringS.Count - 1;

                    if (reading.PhoneStringS.Count > 0)
                        con1 = reading.PhoneStringS[n].MannerOfArticulation == MannerOfArticulation.vowel;

                    notC = reading.PhoneStringS.Count(x => x.MannerOfArticulation != MannerOfArticulation.vowel);
                    pauseOrJuncture = reading.PhoneStringS.Count(x => x.GetType() == typeof(Pause) || x.GetType() == typeof(Juncture));
                    con2 = notC == pauseOrJuncture;


                    con3 = reading.PhoneStringS.Count(x => x.GetType() == typeof(UnknownPhone)) == 0;
                    break;
                case Transcriptions.transcriptionG:

                    n = reading.PhoneStringG.Count == 0 ? 0 : reading.PhoneStringG.Count - 1;

                    if (reading.PhoneStringG.Count > 0)
                        con1 = reading.PhoneStringG[n].MannerOfArticulation == MannerOfArticulation.vowel;

                    con1 = reading.PhoneStringG.Count(x => x.MannerOfArticulation == MannerOfArticulation.vowel) == 1;


                    notC = reading.PhoneStringG.Count(x => x.MannerOfArticulation != MannerOfArticulation.vowel);
                    pauseOrJuncture = reading.PhoneStringG.Count(x => x.GetType() == typeof(Pause) || x.GetType() == typeof(Juncture));
                    con2 = notC == pauseOrJuncture;


                    con3 = reading.PhoneStringG.Count(x => x.GetType() == typeof(UnknownPhone)) == 0;
                    break;
                case Transcriptions.transcriptionO:

                    n = reading.PhoneStringO.Count == 0 ? 0 : reading.PhoneStringO.Count - 1;

                    if (reading.PhoneStringO.Count > 0)
                        con1 = reading.PhoneStringO[n].MannerOfArticulation == MannerOfArticulation.vowel;

                    con1 = reading.PhoneStringO.Count(x => x.MannerOfArticulation == MannerOfArticulation.vowel) == 1;


                    notC = reading.PhoneStringO.Count(x => x.MannerOfArticulation != MannerOfArticulation.vowel);
                    pauseOrJuncture = reading.PhoneStringO.Count(x => x.GetType() == typeof(Pause) || x.GetType() == typeof(Juncture));
                    con2 = notC == pauseOrJuncture;


                    con3 = reading.PhoneStringO.Count(x => x.GetType() == typeof(UnknownPhone)) == 0;
                    break;
                default:
                    break;
            }




            //wszystkie 3 warunki muszą być jednocześnie spełnione
            return con1 && con2 && con3;
        }



        /// <summary>
        /// Czy ciąg foniczny zawiera samogłoskę w nagłosie (innymi fonami mogą być jedynie pauzy lub junktury).
        /// </summary>
        /// <param name="reading"></param>
        /// <param name="transcription"></param>
        /// <returns></returns>
        public static bool ContainsOnlyVowelBeginning(Reading reading, Transcriptions transcription)
        {
            bool con1 = false, con2 = false, con3 = false;

            switch (transcription)
            {
                case Transcriptions.transcriptionA:
                    //w ciągu fonicznym jest tylko jedna samogłoska
                    if (reading.PhoneStringA.Count > 0)
                        con1 = reading.PhoneStringA[0].MannerOfArticulation == MannerOfArticulation.vowel;

                    //w ciągu fonicznym nie ma spółgłosek (wszystkie niesamogłoski są pauzami lub junkturami)
                    int notC = reading.PhoneStringA.Count(x => x.MannerOfArticulation != MannerOfArticulation.vowel);
                    int pauseOrJuncture = reading.PhoneStringA.Count(x => x.GetType() == typeof(Pause) || x.GetType() == typeof(Juncture));
                    con2 = notC == pauseOrJuncture;

                    //w ciągu fonicznym nie ma nierozpoznanych głosek
                    con3 = reading.PhoneStringA.Count(x => x.GetType() == typeof(UnknownPhone)) == 0;
                    break;
                case Transcriptions.transcriptionS:

                    if (reading.PhoneStringS.Count > 0)
                        con1 = reading.PhoneStringS[0].MannerOfArticulation == MannerOfArticulation.vowel;

                    notC = reading.PhoneStringS.Count(x => x.MannerOfArticulation != MannerOfArticulation.vowel);
                    pauseOrJuncture = reading.PhoneStringS.Count(x => x.GetType() == typeof(Pause) || x.GetType() == typeof(Juncture));
                    con2 = notC == pauseOrJuncture;


                    con3 = reading.PhoneStringS.Count(x => x.GetType() == typeof(UnknownPhone)) == 0;
                    break;
                case Transcriptions.transcriptionG:

                    if (reading.PhoneStringG.Count > 0)
                        con1 = reading.PhoneStringG[0].MannerOfArticulation == MannerOfArticulation.vowel;

                    notC = reading.PhoneStringG.Count(x => x.MannerOfArticulation != MannerOfArticulation.vowel);
                    pauseOrJuncture = reading.PhoneStringG.Count(x => x.GetType() == typeof(Pause) || x.GetType() == typeof(Juncture));
                    con2 = notC == pauseOrJuncture;


                    con3 = reading.PhoneStringG.Count(x => x.GetType() == typeof(UnknownPhone)) == 0;
                    break;
                case Transcriptions.transcriptionO:

                    if (reading.PhoneStringO.Count > 0)
                        con1 = reading.PhoneStringO[0].MannerOfArticulation == MannerOfArticulation.vowel;

                    notC = reading.PhoneStringO.Count(x => x.MannerOfArticulation != MannerOfArticulation.vowel);
                    pauseOrJuncture = reading.PhoneStringO.Count(x => x.GetType() == typeof(Pause) || x.GetType() == typeof(Juncture));
                    con2 = notC == pauseOrJuncture;


                    con3 = reading.PhoneStringO.Count(x => x.GetType() == typeof(UnknownPhone)) == 0;
                    break;
                default:
                    break;
            }




            //wszystkie 3 warunki muszą być jednocześnie spełnione
            return con1 && con2 && con3;
        }



        /// <summary>
        /// Czy ciąg foniczny zawiera tylko jeden fon wokaliczny.
        /// </summary>
        /// <param name="reading"></param>
        /// <param name="transcription"></param>
        /// <returns></returns>
        public static bool ContainsOnlyOneVowel(Reading reading, Transcriptions transcription)
        {
            bool con1 = false, con2 = false, con3 = false;

            switch (transcription)
            {
                case Transcriptions.transcriptionA:
                    //w ciągu fonicznym jest tylko jedna samogłoska
                    con1 = reading.PhoneStringA.Count(x => x.MannerOfArticulation == MannerOfArticulation.vowel) == 1;

                    //w ciągu fonicznym nie ma innych fonów
                    con2 = reading.PhoneStringA.Count == 1;

                    //w ciągu fonicznym nie ma nierozpoznanych głosek
                    con3 = reading.PhoneStringA.Count(x => x.GetType() == typeof(UnknownPhone)) == 0;
                    break;
                case Transcriptions.transcriptionS:

                    con1 = reading.PhoneStringS.Count(x => x.MannerOfArticulation == MannerOfArticulation.vowel) == 1;

                    con2 = reading.PhoneStringS.Count == 1;

                    con3 = reading.PhoneStringS.Count(x => x.GetType() == typeof(UnknownPhone)) == 0;
                    break;
                case Transcriptions.transcriptionG:
                    con1 = reading.PhoneStringG.Count(x => x.MannerOfArticulation == MannerOfArticulation.vowel) == 1;

                    con2 = reading.PhoneStringG.Count == 1;

                    con3 = reading.PhoneStringG.Count(x => x.GetType() == typeof(UnknownPhone)) == 0;
                    break;
                case Transcriptions.transcriptionO:
                    con1 = reading.PhoneStringO.Count(x => x.MannerOfArticulation == MannerOfArticulation.vowel) == 1;

                    con2 = reading.PhoneStringO.Count == 1;

                    con3 = reading.PhoneStringO.Count(x => x.GetType() == typeof(UnknownPhone)) == 0;
                    break;
                default:
                    break;
            }




            //wszystkie 3 warunki muszą być jednocześnie spełnione
            return con1 && con2 && con3;
        }



        /// <summary>
        /// Czy ciąg foniczny zawiera samogłoskę i ewentualnie pauzę i/lub junkturę. 
        /// </summary>
        /// <param name="reading"></param>
        /// <param name="transcription"></param>
        /// <returns></returns>
        public static bool ContainsOnlyVowel(Reading reading, Transcriptions transcription)
        {
            bool con1 = false, con2 = false, con3 = false;

            switch (transcription)
            {
                case Transcriptions.transcriptionA:
                    //w ciągu fonicznym jest tylko jedna samogłoska
                    con1 = reading.PhoneStringA.Count(x => x.MannerOfArticulation == MannerOfArticulation.vowel) == 1;

                    //w ciągu fonicznym nie ma spółgłosek (wszystkie niesamogłoski są pauzami lub junkturami)
                    int notC = reading.PhoneStringA.Count(x => x.MannerOfArticulation != MannerOfArticulation.vowel);
                    int pauseOrJuncture = reading.PhoneStringA.Count(x => x.GetType() == typeof(Pause) || x.GetType() == typeof(Juncture));
                    con2 = notC == pauseOrJuncture;

                    //w ciągu fonicznym nie ma nierozpoznanych głosek
                    con3 = reading.PhoneStringA.Count(x => x.GetType() == typeof(UnknownPhone)) == 0;
                    break;
                case Transcriptions.transcriptionS:

                    con1 = reading.PhoneStringS.Count(x => x.MannerOfArticulation == MannerOfArticulation.vowel) == 1;


                    notC = reading.PhoneStringS.Count(x => x.MannerOfArticulation != MannerOfArticulation.vowel);
                    pauseOrJuncture = reading.PhoneStringS.Count(x => x.GetType() == typeof(Pause) || x.GetType() == typeof(Juncture));
                    con2 = notC == pauseOrJuncture;


                    con3 = reading.PhoneStringS.Count(x => x.GetType() == typeof(UnknownPhone)) == 0;
                    break;
                case Transcriptions.transcriptionG:
                    con1 = reading.PhoneStringG.Count(x => x.MannerOfArticulation == MannerOfArticulation.vowel) == 1;


                    notC = reading.PhoneStringG.Count(x => x.MannerOfArticulation != MannerOfArticulation.vowel);
                    pauseOrJuncture = reading.PhoneStringG.Count(x => x.GetType() == typeof(Pause) || x.GetType() == typeof(Juncture));
                    con2 = notC == pauseOrJuncture;


                    con3 = reading.PhoneStringG.Count(x => x.GetType() == typeof(UnknownPhone)) == 0;
                    break;
                case Transcriptions.transcriptionO:
                    con1 = reading.PhoneStringO.Count(x => x.MannerOfArticulation == MannerOfArticulation.vowel) == 1;


                    notC = reading.PhoneStringO.Count(x => x.MannerOfArticulation != MannerOfArticulation.vowel);
                    pauseOrJuncture = reading.PhoneStringO.Count(x => x.GetType() == typeof(Pause) || x.GetType() == typeof(Juncture));
                    con2 = notC == pauseOrJuncture;


                    con3 = reading.PhoneStringO.Count(x => x.GetType() == typeof(UnknownPhone)) == 0;
                    break;
                default:
                    break;
            }




            //wszystkie 3 warunki muszą być jednocześnie spełnione
            return con1 && con2 && con3;
        }

        #endregion


        public static void TagContinuants(ref List<Reading> readings)
        {
            var vowels = new Dictionary<Phone, OldPolishVowels>();

            vowels.Add(PhonePrototypes.i, OldPolishVowels.i);
            vowels.Add(PhonePrototypes.ɨ1, OldPolishVowels.y);
            vowels.Add(PhonePrototypes.E1, OldPolishVowels.e);
            vowels.Add(PhonePrototypes.E1 + PhonePrototypes.@long, OldPolishVowels.e_long);
            vowels.Add(PhonePrototypes.E1 + PhonePrototypes.nasal, OldPolishVowels.ę);
            vowels.Add(PhonePrototypes.a_central, OldPolishVowels.a);
            vowels.Add(PhonePrototypes.a_central + PhonePrototypes.@long, OldPolishVowels.a_long);
            vowels.Add(PhonePrototypes.O1, OldPolishVowels.o);
            vowels.Add(PhonePrototypes.O1 + PhonePrototypes.@long, OldPolishVowels.o_long);
            vowels.Add(PhonePrototypes.O1 + PhonePrototypes.nasal, OldPolishVowels.ą);
            vowels.Add(PhonePrototypes.u, OldPolishVowels.u);


            foreach (var r in readings)
            {
                foreach (var v in vowels)
                {
                    if (r.F1_Hz > 0)
                    {
                        if (ContainsOnlyVowel(r, Transcriptions.transcriptionS)
                            &&
                            r.Contains(v.Key, Transcriptions.transcriptionS)
                            &&
                            ContainsOnlyVowel(r, Transcriptions.transcriptionA))
                        {
                            r.OldPolishVowel = (OldPolishVowels)v.Value;
                        }


                    }

                }

            }

        }
        


        public static void CountMinMaxFrequencies2(List<Reading> readings)
        {
            //tworzę kolekcję numerów nagrań
            var recNoCOl = readings.Select(x => x.RecordingNo).Distinct();

            //przeglądam tę kolekcję
            foreach (var i in recNoCOl)
            {
                foreach (var j in readings.FindAll(x => x.RecordingNo.Equals(i)))
                {
                    j.f_1_min = readings.Where(x => x.RecordingNo.Equals(i) && x.F1_Hz >= typicalFrequencies[0].F1).Min(x => x.F1_Hz);
                    j.f_2_min = readings.Where(x => x.RecordingNo.Equals(i) && x.F2_Hz >= typicalFrequencies[0].F2).Min(x => x.F2_Hz);
                    j.f_3_min = readings.Where(x => x.RecordingNo.Equals(i) && x.F3_Hz >= typicalFrequencies[0].F3).Min(x => x.F3_Hz);
                    j.f_4_min = readings.Where(x => x.RecordingNo.Equals(i) && x.F4_Hz >= typicalFrequencies[0].F4).Min(x => x.F4_Hz);

                    j.f_1_max = readings.Where(x => x.RecordingNo.Equals(i) && x.F1_Hz <= typicalFrequencies[1].F1).Max(x => x.F1_Hz);
                    j.f_2_max = readings.Where(x => x.RecordingNo.Equals(i) && x.F2_Hz <= typicalFrequencies[1].F2).Max(x => x.F2_Hz);
                    j.f_3_max = readings.Where(x => x.RecordingNo.Equals(i) && x.F3_Hz <= typicalFrequencies[1].F3).Max(x => x.F3_Hz);
                    j.f_4_max = readings.Where(x => x.RecordingNo.Equals(i) && x.F4_Hz <= typicalFrequencies[1].F4).Max(x => x.F4_Hz);

                }

                var subset = readings.FindAll(x => x.RecordingNo.Equals(i));

                double min = subset.Where(x => x.F1_Hz > 0 && x.RecordingNo.Equals(i)).Min(x => x.F1_Hz);



            }



        }



        public static void CountMinMaxFrequencies(List<Reading> readings)
        {
            var recordingNos = readings.Select(x => x.RecordingNo).Distinct();

            foreach (var recNo in recordingNos)
            {
                double minF1 = readings.Average(x => x.F1_Hz), maxF1 = readings.Average(x => x.F1_Hz);
                double minF2 = readings.Average(x => x.F2_Hz), maxF2 = readings.Average(x => x.F2_Hz);
                double minF3 = readings.Average(x => x.F3_Hz), maxF3 = readings.Average(x => x.F3_Hz);
                double minF4 = readings.Average(x => x.F4_Hz), maxF4 = readings.Average(x => x.F4_Hz);

                for (int i = readings.FindIndex(x => x.RecordingNo == recNo); i <= readings.FindLastIndex(x => x.RecordingNo == recNo); i++)
                {
                    //min values
                    if (readings[i].F1_Hz > 0 && IsWithinStandards(readings[i].F1_Hz, 1) && readings[i].F1_Hz < minF1) minF1 = readings[i].F1_Hz;
                    if (readings[i].F2_Hz > 0 && IsWithinStandards(readings[i].F2_Hz, 2) && readings[i].F2_Hz < minF2) minF2 = readings[i].F2_Hz;
                    if (readings[i].F3_Hz > 0 && IsWithinStandards(readings[i].F3_Hz, 3) && readings[i].F3_Hz < minF3) minF3 = readings[i].F3_Hz;
                    if (readings[i].F4_Hz > 0 && IsWithinStandards(readings[i].F4_Hz, 4) && readings[i].F4_Hz < minF4) minF4 = readings[i].F4_Hz;

                    //max values
                    if (readings[i].F1_Hz > 0 && IsWithinStandards(readings[i].F1_Hz, 1) && readings[i].F1_Hz > maxF1) maxF1 = readings[i].F1_Hz;
                    if (readings[i].F2_Hz > 0 && IsWithinStandards(readings[i].F2_Hz, 2) && readings[i].F2_Hz > maxF2) maxF2 = readings[i].F2_Hz;
                    if (readings[i].F3_Hz > 0 && IsWithinStandards(readings[i].F3_Hz, 3) && readings[i].F3_Hz > maxF3) maxF3 = readings[i].F3_Hz;
                    if (readings[i].F4_Hz > 0 && IsWithinStandards(readings[i].F4_Hz, 4) && readings[i].F4_Hz > maxF4) maxF4 = readings[i].F4_Hz;


                }

                for (int i = readings.FindIndex(x => x.RecordingNo == recNo); i <= readings.FindLastIndex(x => x.RecordingNo == recNo); i++)
                {
                    readings[i].f_1_max = maxF1;
                    readings[i].f_2_max = maxF2;
                    readings[i].f_3_max = maxF3;
                    readings[i].f_4_max = maxF4;

                    readings[i].f_1_min = minF1;
                    readings[i].f_2_min = minF2;
                    readings[i].f_3_min = minF3;
                    readings[i].f_4_min = minF4;
                    
                }

                

            }


        }


        private static bool IsWithinStandards(double frequency, int formantNo)
        {
            switch (formantNo)
            {
                case 1: return frequency >= typicalFrequencies[0].F1 && frequency <= typicalFrequencies[1].F1;
                case 2: return frequency >= typicalFrequencies[0].F2 && frequency <= typicalFrequencies[1].F2;
                case 3: return frequency >= typicalFrequencies[0].F3 && frequency <= typicalFrequencies[1].F3;
                case 4: return frequency >= typicalFrequencies[0].F4 && frequency <= typicalFrequencies[1].F4;
                default: return false;
            }
        }



        public static void CountRelativeFrequencies(List<Reading> readings)
        {
            foreach (var r in readings)
            {

                //warunek 1: dostępny jest tag realizacji
                //var c1 = r.OldPolishVowel != null;
                               

                //warunek 2: dostępne są częstotliwości bezwzględne
                var c2 = r.F1_Hz > 0;

                //warunek 3: dostępne są częstotliwości maksymalne i minimalne
                var c3 = r.f_1_min > 0 && r.f_1_max > 0;

                //warunek 4: odczyt zawiera głoskę wymówioną przez parlatora/informatora
                var c4 = r.SpeakerType == SpeakerType.Informator || r.SpeakerType == SpeakerType.Parlator;

                //warunek 5: odczyt zawiera samogłoskę (sposób artykulacji: samogłoska, fonacja: dźwięczna) lub półsamogłoskę (sposób artykulacji: półsamogłoska, fonacja: dźwięczna)
                var c5 = ContainsOnlyVowel(r, Transcriptions.transcriptionA) 
                    || 
                    ContainsOnlySemivowel(r, Transcriptions.transcriptionA);

                if (c2 && c3 && c4 && c5)
                {
                    r.rel_F1 = CheckF(r.F1_Hz, 1) ? (r.F1_Hz - r.f_1_min) / (r.f_1_max - r.f_1_min) : Double.NaN;
                    r.rel_F2 = CheckF(r.F2_Hz, 2) ? (r.F2_Hz - r.f_2_min) / (r.f_2_max - r.f_2_min) : Double.NaN; ;
                    r.rel_F3 = CheckF(r.F3_Hz, 3) ? (r.F3_Hz - r.f_3_min) / (r.f_3_max - r.f_3_min) : Double.NaN; ;
                    r.rel_F4 = CheckF(r.F4_Hz, 4) ? (r.F4_Hz - r.f_4_min) / (r.f_4_max - r.f_4_min) : Double.NaN; ;
                }

            }
        }


        
        public static bool CheckF(double F,  int no)
        {
            switch (no)
            {
                case 1: return F >= typicalFrequencies[0].F1 && F <= typicalFrequencies[1].F1; 
                case 2: return F >= typicalFrequencies[0].F2 && F <= typicalFrequencies[1].F2;
                case 3: return F >= typicalFrequencies[0].F3 && F <= typicalFrequencies[1].F3;
                case 4: return F >= typicalFrequencies[0].F4 && F <= typicalFrequencies[1].F4;
                default: return false; 
            }
        }




        public static void GetBothContexts(ref List<Reading> readings, ref Reading reading, Transcriptions transcription)
        {

            switch (transcription)
            {
                case Transcriptions.transcriptionA:

                    foreach (var i in reading.PhoneStringA)
                    {
                        i.Context = new PhoneContext();
                        i.Context.Left = GetLeftContext(readings, reading, i, Transcriptions.transcriptionA).ToList();
                        i.Context.Right = GetRightContext(readings, reading, i, Transcriptions.transcriptionA).ToList();
                    }

                    break;
                case Transcriptions.transcriptionS:

                    foreach (var i in reading.PhoneStringS)
                    {
                        i.Context = new PhoneContext();
                        i.Context.Left = GetLeftContext(readings, reading, i, Transcriptions.transcriptionS).ToList();
                        i.Context.Right = GetRightContext(readings, reading, i, Transcriptions.transcriptionS).ToList();
                    }

                    break;
                case Transcriptions.transcriptionG:

                    foreach (var i in reading.PhoneStringG)
                    {
                        i.Context = new PhoneContext();
                        i.Context.Left = GetLeftContext(readings, reading, i, Transcriptions.transcriptionG).ToList();
                        i.Context.Right = GetRightContext(readings, reading, i, Transcriptions.transcriptionG).ToList();
                    }

                    break;
                case Transcriptions.transcriptionO:

                    foreach (var i in reading.PhoneStringO)
                    {
                        i.Context = new PhoneContext();
                        i.Context.Left = GetLeftContext(readings, reading, i, Transcriptions.transcriptionO).ToList();
                        i.Context.Right = GetRightContext(readings, reading, i, Transcriptions.transcriptionO).ToList();
                    }

                    break;
                default:
                    break;
            }


        }




        public static Phone[] GetRightContext(List<Reading> readings, Reading reading, Phone phone,
            Transcriptions transcription)
        {
            int readingNo = readings.IndexOf(reading);

            int phoneNo = 0;

            switch (transcription)
            {
                case Transcriptions.transcriptionA:
                    phoneNo = readings[readingNo].PhoneStringA.IndexOf(phone);
                    break;
                case Transcriptions.transcriptionS:
                    phoneNo = readings[readingNo].PhoneStringS.IndexOf(phone);
                    break;
                case Transcriptions.transcriptionG:
                    phoneNo = readings[readingNo].PhoneStringG.IndexOf(phone);
                    break;
                case Transcriptions.transcriptionO:
                    phoneNo = readings[readingNo].PhoneStringO.IndexOf(phone);
                    break;
                default:
                    break;
            }

            var temp = new List<Phone>();

            int i = -1;
            int j = -1;

            for (i = readingNo; i < readings.Count; i++)
            {

                switch (transcription)
                {
                    case Transcriptions.transcriptionA:
                        for (j = j == -1 ? phoneNo : 0; j < readings[i].PhoneStringA.Count; j++)
                        {
                            temp.Add(readings[i].PhoneStringA[j]);
                        }
                        break;
                    case Transcriptions.transcriptionS:
                        for (j = j == -1 ? phoneNo : 0; j < readings[i].PhoneStringS.Count; j++)
                        {
                            temp.Add(readings[i].PhoneStringS[j]);
                        }
                        break;
                    case Transcriptions.transcriptionG:
                        for (j = j == -1 ? phoneNo : 0; j < readings[i].PhoneStringG.Count; j++)
                        {
                            temp.Add(readings[i].PhoneStringG[j]);
                        }
                        break;
                    case Transcriptions.transcriptionO:
                        for (j = j == -1 ? phoneNo : 0; j < readings[i].PhoneStringO.Count; j++)
                        {
                            temp.Add(readings[i].PhoneStringO[j]);
                        }
                        break;
                    default:
                        break;
                }

                //WADLIWY KOD (WARUNEK ZAKOŃCZENIA PĘTLI UZALEŻNIONY TYLKO OD TRANSKRYPCJI A
                //for (j = j == -1 ? phoneNo : 0; j < readings[i].PhoneStringA.Count; j++)
                //{

                //    switch (transcription)
                //    {
                //        case Transcriptions.transcriptionA:
                //            temp.Add(readings[i].PhoneStringA[j]);
                //            break;
                //        case Transcriptions.transcriptionS:
                //            temp.Add(readings[i].PhoneStringS[j]);
                //            break;
                //        case Transcriptions.transcriptionG:
                //            temp.Add(readings[i].PhoneStringG[j]);
                //            break;
                //        case Transcriptions.transcriptionO:
                //            temp.Add(readings[i].PhoneStringO[j]);
                //            break;
                //        default:
                //            break;
                //    }

                //}

                if (temp.Count >= 4) break;
            }

            temp.RemoveAt(0);

            return temp.ToArray();


        }





        public static Phone[] GetLeftContext(List<Reading> readings, Reading reading, Phone phone,
            Transcriptions transcription)
        {
            int readingNo = readings.IndexOf(reading);

            int phoneNo = 0;

            switch (transcription)
            {
                case Transcriptions.transcriptionA:
                    phoneNo = readings[readingNo].PhoneStringA.IndexOf(phone);
                    break;
                case Transcriptions.transcriptionS:
                    phoneNo = readings[readingNo].PhoneStringS.IndexOf(phone);
                    break;
                case Transcriptions.transcriptionG:
                    phoneNo = readings[readingNo].PhoneStringG.IndexOf(phone);
                    break;
                case Transcriptions.transcriptionO:
                    phoneNo = readings[readingNo].PhoneStringO.IndexOf(phone);
                    break;
                default:
                    break;
            }

            var temp = new List<Phone>();

            int i = -2;
            int j = -2;

            int maxPosition = 0;

            for (i = readingNo; i >= 0; i--)
            {
                switch (transcription)
                {
                    case Transcriptions.transcriptionA:
                        maxPosition = readings[i].PhoneStringA.Count - 1;
                        break;
                    case Transcriptions.transcriptionS:
                        maxPosition = readings[i].PhoneStringS.Count - 1;
                        break;
                    case Transcriptions.transcriptionG:
                        maxPosition = readings[i].PhoneStringG.Count - 1;
                        break;
                    case Transcriptions.transcriptionO:
                        maxPosition = readings[i].PhoneStringO.Count - 1;
                        break;
                    default:
                        break;
                }



                for (j = j == -2 ? phoneNo : maxPosition; j >= 0; j--)
                {

                    switch (transcription)
                    {
                        case Transcriptions.transcriptionA:
                            temp.Add(readings[i].PhoneStringA[j]);
                            break;
                        case Transcriptions.transcriptionS:
                            temp.Add(readings[i].PhoneStringS[j]);
                            break;
                        case Transcriptions.transcriptionG:
                            temp.Add(readings[i].PhoneStringG[j]);
                            break;
                        case Transcriptions.transcriptionO:
                            temp.Add(readings[i].PhoneStringO[j]);
                            break;
                        default:
                            break;
                    }

                }

                if (temp.Count >= 4) break;
            }

            temp.RemoveAt(0);

            return temp.ToArray();


        }



        public static void AddContexts7(ref List<Reading> readings)
        {

            foreach (var r in readings)
            {
                foreach (var p in r.PhoneStringA)
                {
                    p.Context = new PhoneContext();

                    p.Context.Left.AddRange(GetLeftContext(readings, r, p, Transcriptions.transcriptionA));
                }

                foreach (var p in r.PhoneStringG)
                {
                    p.Context = new PhoneContext();

                    p.Context.Left.AddRange(GetLeftContext(readings, r, p, Transcriptions.transcriptionG));
                }

                foreach (var p in r.PhoneStringS)
                {
                    p.Context = new PhoneContext();

                    p.Context.Left.AddRange(GetLeftContext(readings, r, p, Transcriptions.transcriptionS));
                }

                foreach (var p in r.PhoneStringO)
                {
                    p.Context = new PhoneContext();

                    p.Context.Left.AddRange(GetLeftContext(readings, r, p, Transcriptions.transcriptionO));
                }

            }


        }















        private static void AddExamples(List<Phone> phones)
        {
            for (int i = 0; i < phones.Count; i++)
            {
                phones[i].Example = new Example();

                int begin = -1;
                int end = -1;

                if (phones[i].GetType() != typeof(Juncture)
                    &&
                    phones[i].GetType() != typeof(Pause))
                {
                    //szukam początku przykładu
                    if (i > 0)
                    {
                        for (int j = i - 1; j >= 0; j--)
                        {
                            if (phones[j].GetType() == typeof(Juncture) || phones[j].GetType() == typeof(Pause) || j == 0)
                            {
                                begin = j;
                                break;
                            }
                        }
                    }

                    //szukam końca przykładu
                    if (i < phones.Count - 1)
                    {
                        for (int j = i + 1; j < phones.Count; j++)
                        {
                            if (phones[j].GetType() == typeof(Juncture) || phones[j].GetType() == typeof(Pause) || j == phones.Count - 1)
                            {
                                end = j;
                                break;
                            }
                        }
                    }

                    //dodaję fony                    
                    for (int j = begin; j <= end; j++)
                    {
                        //phones[i].Example.IPA += phones[i].Symbol.IPA;
                        //phones[i].Example.SPA += phones[i].Symbol.SPA;
                        //phones[i].Example.Simplified += phones[i].Symbol.Simplified;
                        //phones[i].Example.XSampa += phones[i].Symbol.XSampa;
                    }


                }


            }
        }



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


        private static void AddInfoOnReadings(Reading r)
        {

            foreach (var p in r.PhoneStringA)
            {
                p.Reading = r;
            }

            foreach (var p in r.PhoneStringS)
            {
                p.Reading = r;
            }

            foreach (var p in r.PhoneStringG)
            {
                p.Reading = r;
            }

            foreach (var p in r.PhoneStringO)
            {
                p.Reading = r;
            }

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
