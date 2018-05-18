using APS_1.Phonetics;
using APS_1.Symbols.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_1.Symbols.Library
{
    public class simpLib : Library
    {
        public simpLib()
        {


            Symbols = new Dictionary<string, Phone>();




            #region: Symbols

            #region: Consonants

            #region: Stops

            Symbols.Add(PhonePrototypes.p1.Symbol.Simplified, PhonePrototypes.p1);

            //Consonants.Add(PhonePrototypes.p2.Symbol.Simplified, PhonePrototypes.p2);
            Symbols.Add(PhonePrototypes.b1.Symbol.Simplified, PhonePrototypes.b1);
            //Consonants.Add(PhonePrototypes.b2.Symbol.Simplified, PhonePrototypes.b2);

            Symbols.Add(PhonePrototypes.t1.Symbol.Simplified, PhonePrototypes.t1);
            //Consonants.Add(PhonePrototypes.t2.Symbol.Simplified, PhonePrototypes.t2);
            Symbols.Add(PhonePrototypes.d1.Symbol.Simplified, PhonePrototypes.d1);
            //Consonants.Add(PhonePrototypes.d2.Symbol.Simplified, PhonePrototypes.d1);

            //Consonants.Add(PhonePrototypes.c1.Symbol.Simplified, PhonePrototypes.c1);
            //Consonants.Add(PhonePrototypes.c2.Symbol.Simplified, PhonePrototypes.c2);
            //Consonants.Add(PhonePrototypes.ɟ1.Symbol.Simplified, PhonePrototypes.ɟ1);
            //Consonants.Add(PhonePrototypes.ɟ2.Symbol.Simplified, PhonePrototypes.ɟ2);

            Symbols.Add(PhonePrototypes.k1.Symbol.Simplified, PhonePrototypes.k1);
            //Consonants.Add(PhonePrototypes.k2.Symbol.Simplified, PhonePrototypes.k2);
            Symbols.Add(PhonePrototypes.g1.Symbol.Simplified, PhonePrototypes.k1);
            //Consonants.Add(PhonePrototypes.g2.Symbol.Simplified, PhonePrototypes.k2);

            //Consonants.Add(PhonePrototypes.q1.Symbol.Simplified, PhonePrototypes.q1);
            //Consonants.Add(PhonePrototypes.q2.Symbol.Simplified, PhonePrototypes.q2);
            //Consonants.Add(PhonePrototypes.ɢ1.Symbol.Simplified, PhonePrototypes.ɢ1);
            //Consonants.Add(PhonePrototypes.ɢ2.Symbol.Simplified, PhonePrototypes.ɢ2);

            //Consonants.Add(PhonePrototypes.ʔ.Symbol.Simplified, PhonePrototypes.ʔ);

            #endregion

            #region: Nasals

            Symbols.Add(PhonePrototypes.m.Symbol.Simplified, PhonePrototypes.m);
            Symbols.Add(PhonePrototypes.n.Symbol.Simplified, PhonePrototypes.n);
            Symbols.Add(PhonePrototypes.ń.Symbol.Simplified, PhonePrototypes.ń);

            //Consonants.Add(PhonePrototypes.ɲ1.Symbol.Simplified, PhonePrototypes.ɲ1);
            //Consonants.Add(PhonePrototypes.ɲ2.Symbol.Simplified, PhonePrototypes.ɲ2);

            Symbols.Add(PhonePrototypes.ŋ1.Symbol.Simplified, PhonePrototypes.ŋ1);
            //Consonants.Add(PhonePrototypes.ŋ2.Symbol.Simplified, PhonePrototypes.ŋ2);

            //Consonants.Add(PhonePrototypes.ɴ1.Symbol.Simplified, PhonePrototypes.ɴ1);
            //Consonants.Add(PhonePrototypes.ɴ2.Symbol.Simplified, PhonePrototypes.ɴ2);

            #endregion

            #region: Trills

            Symbols.Add(PhonePrototypes.r.Symbol.Simplified, PhonePrototypes.r);
            Symbols.Add(PhonePrototypes.R1.Symbol.Simplified, PhonePrototypes.R1);
            //Consonants.Add(PhonePrototypes.ʀ2.Symbol.Simplified, PhonePrototypes.ʀ2);
            Symbols.Add(PhonePrototypes.ř.Symbol.Simplified, PhonePrototypes.ř);

            #endregion

            #region: Fricatives

            Symbols.Add(PhonePrototypes.f.Symbol.Simplified, PhonePrototypes.f);
            Symbols.Add(PhonePrototypes.v.Symbol.Simplified, PhonePrototypes.v);

            Symbols.Add(PhonePrototypes.s.Symbol.Simplified, PhonePrototypes.s);
            Symbols.Add(PhonePrototypes.z.Symbol.Simplified, PhonePrototypes.z);

            Symbols.Add(PhonePrototypes.S1.Symbol.Simplified, PhonePrototypes.S1);
            //Consonants.Add(PhonePrototypes.S2.Symbol.Simplified, PhonePrototypes.S2);
            Symbols.Add(PhonePrototypes.Z1.Symbol.Simplified, PhonePrototypes.Z1);
            //Consonants.Add(PhonePrototypes.Z2.Symbol.Simplified, PhonePrototypes.Z2);

            Symbols.Add(PhonePrototypes.ś.Symbol.Simplified, PhonePrototypes.ś);
            Symbols.Add(PhonePrototypes.ź.Symbol.Simplified, PhonePrototypes.ź);

            //Consonants.Add(PhonePrototypes.C1.Symbol.Simplified, PhonePrototypes.C1);
            //Consonants.Add(PhonePrototypes.C2.Symbol.Simplified, PhonePrototypes.C2);
            //Consonants.Add(PhonePrototypes.ʝ.Symbol.Simplified, PhonePrototypes.ʝ);

            Symbols.Add(PhonePrototypes.x.Symbol.Simplified, PhonePrototypes.x);
            Symbols.Add(PhonePrototypes.ɣ1.Symbol.Simplified, PhonePrototypes.ɣ1);

            //Consonants.Add(PhonePrototypes.X1.Symbol.Simplified, PhonePrototypes.X1);
            //Consonants.Add(PhonePrototypes.X2.Symbol.Simplified, PhonePrototypes.X2);
            //Consonants.Add(PhonePrototypes.ʁ1.Symbol.Simplified, PhonePrototypes.ʁ1);
            //Consonants.Add(PhonePrototypes.ʁ2.Symbol.Simplified, PhonePrototypes.ʁ2);

            //Consonants.Add(PhonePrototypes.h.Symbol.Simplified, PhonePrototypes.h);
            //Consonants.Add(PhonePrototypes.ɦ.Symbol.Simplified, PhonePrototypes.ɦ);

            #endregion

            #region: Approximants

            Symbols.Add(PhonePrototypes.j.Symbol.Simplified, PhonePrototypes.j);
            Symbols.Add(PhonePrototypes.w1.Symbol.Simplified, PhonePrototypes.w1);

            Symbols.Add(PhonePrototypes.l.Symbol.Simplified, PhonePrototypes.l);

            #endregion

            #region: Affricates

            Symbols.Add(PhonePrototypes.ts1.Symbol.Simplified, PhonePrototypes.ts1);
            //Consonants.Add(PhonePrototypes.ts2.Symbol.Simplified, PhonePrototypes.ts2);
            Symbols.Add(PhonePrototypes.dz1.Symbol.Simplified, PhonePrototypes.dz1);
            //Consonants.Add(PhonePrototypes.dz2.Symbol.Simplified, PhonePrototypes.dz2);

            Symbols.Add(PhonePrototypes.tS1.Symbol.Simplified, PhonePrototypes.tS1);
            //Consonants.Add(PhonePrototypes.tS2.Symbol.Simplified, PhonePrototypes.tS2);
            Symbols.Add(PhonePrototypes.dZ1.Symbol.Simplified, PhonePrototypes.dZ1);
            //Consonants.Add(PhonePrototypes.dZ2.Symbol.Simplified, PhonePrototypes.dZ2);

            Symbols.Add(PhonePrototypes.tś1.Symbol.Simplified, PhonePrototypes.tś1);
            //Consonants.Add(PhonePrototypes.tś2.Symbol.Simplified, PhonePrototypes.tś2);
            Symbols.Add(PhonePrototypes.dź1.Symbol.Simplified, PhonePrototypes.dź1);
            //Consonants.Add(PhonePrototypes.dź2.Symbol.Simplified, PhonePrototypes.dź2);

            #endregion

            #endregion

            #region: Vowels

            Symbols.Add(PhonePrototypes.i.Symbol.Simplified, PhonePrototypes.i);
            //Vowels.Add(PhonePrototypes.y.Symbol.Simplified, PhonePrototypes.y);

            Symbols.Add(PhonePrototypes.ɨ1.Symbol.Simplified, PhonePrototypes.ɨ1);
            //Vowels.Add(PhonePrototypes.ɨ2.Symbol.Simplified, PhonePrototypes.ɨ2);
            //Vowels.Add(PhonePrototypes.ɨ3.Symbol.Simplified, PhonePrototypes.ɨ3);
            //Vowels.Add(PhonePrototypes.ʉ1.Symbol.Simplified, PhonePrototypes.ʉ1);
            //Vowels.Add(PhonePrototypes.ʉ2.Symbol.Simplified, PhonePrototypes.ʉ2);

            //Vowels.Add(PhonePrototypes.M1.Symbol.Simplified, PhonePrototypes.M1);
            //Vowels.Add(PhonePrototypes.M2.Symbol.Simplified, PhonePrototypes.M2);
            Symbols.Add(PhonePrototypes.u.Symbol.Simplified, PhonePrototypes.u);


            //Vowels.Add(PhonePrototypes.e.Symbol.Simplified, PhonePrototypes.e);
            //Vowels.Add(PhonePrototypes.ø1.Symbol.Simplified, PhonePrototypes.ø1);
            //Vowels.Add(PhonePrototypes.ø2.Symbol.Simplified, PhonePrototypes.ø2);

            //Vowels.Add(PhonePrototypes.ɘ.Symbol.Simplified, PhonePrototypes.ɘ);
            //Vowels.Add(PhonePrototypes.ɵ1.Symbol.Simplified, PhonePrototypes.ɵ1);
            //Vowels.Add(PhonePrototypes.ɵ2.Symbol.Simplified, PhonePrototypes.ɵ2);

            //Vowels.Add(PhonePrototypes.ɤ1.Symbol.Simplified, PhonePrototypes.ɤ1);
            //Vowels.Add(PhonePrototypes.ɤ2.Symbol.Simplified, PhonePrototypes.ɤ2);
            //Vowels.Add(PhonePrototypes.o.Symbol.Simplified, PhonePrototypes.o);


            //Vowels.Add(PhonePrototypes.ə.Symbol.Simplified, PhonePrototypes.ə);


            Symbols.Add(PhonePrototypes.E1.Symbol.Simplified, PhonePrototypes.E1);
            //Vowels.Add(PhonePrototypes.E2.Symbol.Simplified, PhonePrototypes.E2);
            //Vowels.Add(PhonePrototypes.œ1.Symbol.Simplified, PhonePrototypes.œ1);
            //Vowels.Add(PhonePrototypes.œ2.Symbol.Simplified, PhonePrototypes.œ2);

            Symbols.Add(PhonePrototypes.ę.Symbol.Simplified, PhonePrototypes.ę);

            //Vowels.Add(PhonePrototypes.ɜ1.Symbol.Simplified, PhonePrototypes.ɜ1);
            //Vowels.Add(PhonePrototypes.ɜ2.Symbol.Simplified, PhonePrototypes.ɜ2);
            //Vowels.Add(PhonePrototypes.ɞ1.Symbol.Simplified, PhonePrototypes.ɞ1);
            //Vowels.Add(PhonePrototypes.ɞ2.Symbol.Simplified, PhonePrototypes.ɞ2);

            //Vowels.Add(PhonePrototypes.V1.Symbol.Simplified, PhonePrototypes.V1);
            //Vowels.Add(PhonePrototypes.V2.Symbol.Simplified, PhonePrototypes.V2);
            Symbols.Add(PhonePrototypes.O1.Symbol.Simplified, PhonePrototypes.O1);
            //Vowels.Add(PhonePrototypes.O2.Symbol.Simplified, PhonePrototypes.O2);

            Symbols.Add(PhonePrototypes.ǫ.Symbol.Simplified, PhonePrototypes.ǫ);

            //Vowels.Add(PhonePrototypes.æ1.Symbol.Simplified, PhonePrototypes.æ1);
            //Vowels.Add(PhonePrototypes.æ2.Symbol.Simplified, PhonePrototypes.æ2);
            //Vowels.Add(PhonePrototypes.ɐ1.Symbol.Simplified, PhonePrototypes.ɐ1);
            //Vowels.Add(PhonePrototypes.ɐ2.Symbol.Simplified, PhonePrototypes.ɐ2);

            //Vowels.Add(PhonePrototypes.a.Symbol.Simplified, PhonePrototypes.a);
            //Vowels.Add(PhonePrototypes.ɶ1.Symbol.Simplified, PhonePrototypes.ɶ1);
            //Vowels.Add(PhonePrototypes.ɶ2.Symbol.Simplified, PhonePrototypes.ɶ2);
            Symbols.Add(PhonePrototypes.a_central.Symbol.Simplified, PhonePrototypes.a_central);
            //Vowels.Add(PhonePrototypes.A1.Symbol.Simplified, PhonePrototypes.A1);
            //Vowels.Add(PhonePrototypes.A2.Symbol.Simplified, PhonePrototypes.A2);
            //Vowels.Add(PhonePrototypes.Q1.Symbol.Simplified, PhonePrototypes.Q1);
            //Vowels.Add(PhonePrototypes.Q2.Symbol.Simplified, PhonePrototypes.Q2);

            #endregion



            #region: Other

            Symbols.Add(PhonePrototypes.juncture1.Symbol.Simplified, PhonePrototypes.juncture1);
            Symbols.Add(PhonePrototypes.juncture2.Symbol.Simplified, PhonePrototypes.juncture2);

            Symbols.Add(PhonePrototypes.pause1.Symbol.Simplified, PhonePrototypes.pause1);
            //OtherSymbols.Add(PhonePrototypes.pause2.Symbol.Simplified, PhonePrototypes.pause2);
            Symbols.Add(PhonePrototypes.pause3.Symbol.Simplified, PhonePrototypes.pause3);

            Symbols.Add(PhonePrototypes.unknownPhone1.Symbol.Simplified, PhonePrototypes.unknownPhone1);

            Symbols.Add(PhonePrototypes.nullPhone.Symbol.Simplified, PhonePrototypes.nullPhone);

            Symbols.Add(PhonePrototypes.unknownPhoneDelimiter1a.Symbol.Simplified, PhonePrototypes.unknownPhoneDelimiter1a);
            Symbols.Add(PhonePrototypes.unknownPhoneDelimiter1b.Symbol.Simplified, PhonePrototypes.unknownPhoneDelimiter1b);
            Symbols.Add(PhonePrototypes.unknownPhoneDelimiter2a.Symbol.Simplified, PhonePrototypes.unknownPhoneDelimiter2a);
            Symbols.Add(PhonePrototypes.unknownPhoneDelimiter2b.Symbol.Simplified, PhonePrototypes.unknownPhoneDelimiter2b);
            Symbols.Add(PhonePrototypes.unknownPhoneDelimiter3.Symbol.Simplified, PhonePrototypes.unknownPhoneDelimiter3);
            

            #endregion

            #endregion


            #region: Vowel diacritics

            Symbols.Add(
                PhonePrototypes.@long.Symbol.Simplified, 
                new Diacritic(PhonePrototypes.@long, -1));
            Symbols.Add(
                PhonePrototypes.nasal.Symbol.Simplified,
                new Diacritic(PhonePrototypes.nasal, -1));

            #endregion

            #region: Consonant diacritics

            Symbols.Add(
                PhonePrototypes.palatalized1.Symbol.Simplified,
                new Diacritic(PhonePrototypes.palatalized1, -1));
                        
            #endregion



            #region: Copy


            //Consonants = new Dictionary<string, Consonant>();

            //Vowels = new Dictionary<string, Vowel>();

            //ConsonantDiacritics = new Dictionary<string, Diacritic>();

            //VowelDiacritics = new Dictionary<string, Diacritic>();

            //OtherSymbols = new Dictionary<string, Phone>();

            //UnknownPhonesDelimiters = new Dictionary<string, UnknownPhoneDelimiter>();


            //#region: Symbols

            //#region: Consonants

            //#region: Stops

            //Consonants.Add(PhonePrototypes.p1.Symbol.Simplified, PhonePrototypes.p1);

            ////Consonants.Add(PhonePrototypes.p2.Symbol.Simplified, PhonePrototypes.p2);
            //Consonants.Add(PhonePrototypes.b1.Symbol.Simplified, PhonePrototypes.b1);
            ////Consonants.Add(PhonePrototypes.b2.Symbol.Simplified, PhonePrototypes.b2);

            //Consonants.Add(PhonePrototypes.t1.Symbol.Simplified, PhonePrototypes.t1);
            ////Consonants.Add(PhonePrototypes.t2.Symbol.Simplified, PhonePrototypes.t2);
            //Consonants.Add(PhonePrototypes.d1.Symbol.Simplified, PhonePrototypes.d1);
            ////Consonants.Add(PhonePrototypes.d2.Symbol.Simplified, PhonePrototypes.d1);

            ////Consonants.Add(PhonePrototypes.c1.Symbol.Simplified, PhonePrototypes.c1);
            ////Consonants.Add(PhonePrototypes.c2.Symbol.Simplified, PhonePrototypes.c2);
            ////Consonants.Add(PhonePrototypes.ɟ1.Symbol.Simplified, PhonePrototypes.ɟ1);
            ////Consonants.Add(PhonePrototypes.ɟ2.Symbol.Simplified, PhonePrototypes.ɟ2);

            //Consonants.Add(PhonePrototypes.k1.Symbol.Simplified, PhonePrototypes.k1);
            ////Consonants.Add(PhonePrototypes.k2.Symbol.Simplified, PhonePrototypes.k2);
            //Consonants.Add(PhonePrototypes.g1.Symbol.Simplified, PhonePrototypes.k1);
            ////Consonants.Add(PhonePrototypes.g2.Symbol.Simplified, PhonePrototypes.k2);

            ////Consonants.Add(PhonePrototypes.q1.Symbol.Simplified, PhonePrototypes.q1);
            ////Consonants.Add(PhonePrototypes.q2.Symbol.Simplified, PhonePrototypes.q2);
            ////Consonants.Add(PhonePrototypes.ɢ1.Symbol.Simplified, PhonePrototypes.ɢ1);
            ////Consonants.Add(PhonePrototypes.ɢ2.Symbol.Simplified, PhonePrototypes.ɢ2);

            ////Consonants.Add(PhonePrototypes.ʔ.Symbol.Simplified, PhonePrototypes.ʔ);

            //#endregion

            //#region: Nasals

            //Consonants.Add(PhonePrototypes.m.Symbol.Simplified, PhonePrototypes.m);
            //Consonants.Add(PhonePrototypes.n.Symbol.Simplified, PhonePrototypes.n);
            //Consonants.Add(PhonePrototypes.ń.Symbol.Simplified, PhonePrototypes.ń);

            ////Consonants.Add(PhonePrototypes.ɲ1.Symbol.Simplified, PhonePrototypes.ɲ1);
            ////Consonants.Add(PhonePrototypes.ɲ2.Symbol.Simplified, PhonePrototypes.ɲ2);

            //Consonants.Add(PhonePrototypes.ŋ1.Symbol.Simplified, PhonePrototypes.ŋ1);
            ////Consonants.Add(PhonePrototypes.ŋ2.Symbol.Simplified, PhonePrototypes.ŋ2);

            ////Consonants.Add(PhonePrototypes.ɴ1.Symbol.Simplified, PhonePrototypes.ɴ1);
            ////Consonants.Add(PhonePrototypes.ɴ2.Symbol.Simplified, PhonePrototypes.ɴ2);

            //#endregion

            //#region: Trills

            //Consonants.Add(PhonePrototypes.r.Symbol.Simplified, PhonePrototypes.r);
            //Consonants.Add(PhonePrototypes.ʀ1.Symbol.Simplified, PhonePrototypes.ʀ1);
            ////Consonants.Add(PhonePrototypes.ʀ2.Symbol.Simplified, PhonePrototypes.ʀ2);
            //Consonants.Add(PhonePrototypes.ř.Symbol.Simplified, PhonePrototypes.ř);

            //#endregion

            //#region: Fricatives

            //Consonants.Add(PhonePrototypes.f.Symbol.Simplified, PhonePrototypes.f);
            //Consonants.Add(PhonePrototypes.v.Symbol.Simplified, PhonePrototypes.v);

            //Consonants.Add(PhonePrototypes.s.Symbol.Simplified, PhonePrototypes.s);
            //Consonants.Add(PhonePrototypes.z.Symbol.Simplified, PhonePrototypes.z);

            //Consonants.Add(PhonePrototypes.S1.Symbol.Simplified, PhonePrototypes.S1);
            ////Consonants.Add(PhonePrototypes.S2.Symbol.Simplified, PhonePrototypes.S2);
            //Consonants.Add(PhonePrototypes.Z1.Symbol.Simplified, PhonePrototypes.Z1);
            ////Consonants.Add(PhonePrototypes.Z2.Symbol.Simplified, PhonePrototypes.Z2);

            //Consonants.Add(PhonePrototypes.ś.Symbol.Simplified, PhonePrototypes.ś);
            //Consonants.Add(PhonePrototypes.ź.Symbol.Simplified, PhonePrototypes.ź);

            ////Consonants.Add(PhonePrototypes.C1.Symbol.Simplified, PhonePrototypes.C1);
            ////Consonants.Add(PhonePrototypes.C2.Symbol.Simplified, PhonePrototypes.C2);
            ////Consonants.Add(PhonePrototypes.ʝ.Symbol.Simplified, PhonePrototypes.ʝ);

            //Consonants.Add(PhonePrototypes.x.Symbol.Simplified, PhonePrototypes.x);
            //Consonants.Add(PhonePrototypes.ɣ.Symbol.Simplified, PhonePrototypes.ɣ);

            ////Consonants.Add(PhonePrototypes.X1.Symbol.Simplified, PhonePrototypes.X1);
            ////Consonants.Add(PhonePrototypes.X2.Symbol.Simplified, PhonePrototypes.X2);
            ////Consonants.Add(PhonePrototypes.ʁ1.Symbol.Simplified, PhonePrototypes.ʁ1);
            ////Consonants.Add(PhonePrototypes.ʁ2.Symbol.Simplified, PhonePrototypes.ʁ2);

            ////Consonants.Add(PhonePrototypes.h.Symbol.Simplified, PhonePrototypes.h);
            ////Consonants.Add(PhonePrototypes.ɦ.Symbol.Simplified, PhonePrototypes.ɦ);

            //#endregion

            //#region: Approximants

            //Consonants.Add(PhonePrototypes.j.Symbol.Simplified, PhonePrototypes.j);
            //Consonants.Add(PhonePrototypes.w.Symbol.Simplified, PhonePrototypes.w);

            //Consonants.Add(PhonePrototypes.l.Symbol.Simplified, PhonePrototypes.l);

            //#endregion

            //#region: Affricates

            //Consonants.Add(PhonePrototypes.ts1.Symbol.Simplified, PhonePrototypes.ts1);
            ////Consonants.Add(PhonePrototypes.ts2.Symbol.Simplified, PhonePrototypes.ts2);
            //Consonants.Add(PhonePrototypes.dz1.Symbol.Simplified, PhonePrototypes.dz1);
            ////Consonants.Add(PhonePrototypes.dz2.Symbol.Simplified, PhonePrototypes.dz2);

            //Consonants.Add(PhonePrototypes.tS1.Symbol.Simplified, PhonePrototypes.tS1);
            ////Consonants.Add(PhonePrototypes.tS2.Symbol.Simplified, PhonePrototypes.tS2);
            //Consonants.Add(PhonePrototypes.dZ1.Symbol.Simplified, PhonePrototypes.dZ1);
            ////Consonants.Add(PhonePrototypes.dZ2.Symbol.Simplified, PhonePrototypes.dZ2);

            //Consonants.Add(PhonePrototypes.tś1.Symbol.Simplified, PhonePrototypes.tś1);
            ////Consonants.Add(PhonePrototypes.tś2.Symbol.Simplified, PhonePrototypes.tś2);
            //Consonants.Add(PhonePrototypes.dź1.Symbol.Simplified, PhonePrototypes.dź1);
            ////Consonants.Add(PhonePrototypes.dź2.Symbol.Simplified, PhonePrototypes.dź2);

            //#endregion

            //#endregion

            //#region: Vowels

            //Vowels.Add(PhonePrototypes.i.Symbol.Simplified, PhonePrototypes.i);
            ////Vowels.Add(PhonePrototypes.y.Symbol.Simplified, PhonePrototypes.y);

            //Vowels.Add(PhonePrototypes.ɨ1.Symbol.Simplified, PhonePrototypes.ɨ1);
            ////Vowels.Add(PhonePrototypes.ɨ2.Symbol.Simplified, PhonePrototypes.ɨ2);
            ////Vowels.Add(PhonePrototypes.ɨ3.Symbol.Simplified, PhonePrototypes.ɨ3);
            ////Vowels.Add(PhonePrototypes.ʉ1.Symbol.Simplified, PhonePrototypes.ʉ1);
            ////Vowels.Add(PhonePrototypes.ʉ2.Symbol.Simplified, PhonePrototypes.ʉ2);

            ////Vowels.Add(PhonePrototypes.M1.Symbol.Simplified, PhonePrototypes.M1);
            ////Vowels.Add(PhonePrototypes.M2.Symbol.Simplified, PhonePrototypes.M2);
            //Vowels.Add(PhonePrototypes.u.Symbol.Simplified, PhonePrototypes.u);


            ////Vowels.Add(PhonePrototypes.e.Symbol.Simplified, PhonePrototypes.e);
            ////Vowels.Add(PhonePrototypes.ø1.Symbol.Simplified, PhonePrototypes.ø1);
            ////Vowels.Add(PhonePrototypes.ø2.Symbol.Simplified, PhonePrototypes.ø2);

            ////Vowels.Add(PhonePrototypes.ɘ.Symbol.Simplified, PhonePrototypes.ɘ);
            ////Vowels.Add(PhonePrototypes.ɵ1.Symbol.Simplified, PhonePrototypes.ɵ1);
            ////Vowels.Add(PhonePrototypes.ɵ2.Symbol.Simplified, PhonePrototypes.ɵ2);

            ////Vowels.Add(PhonePrototypes.ɤ1.Symbol.Simplified, PhonePrototypes.ɤ1);
            ////Vowels.Add(PhonePrototypes.ɤ2.Symbol.Simplified, PhonePrototypes.ɤ2);
            ////Vowels.Add(PhonePrototypes.o.Symbol.Simplified, PhonePrototypes.o);


            ////Vowels.Add(PhonePrototypes.ə.Symbol.Simplified, PhonePrototypes.ə);


            //Vowels.Add(PhonePrototypes.E1.Symbol.Simplified, PhonePrototypes.E1);
            ////Vowels.Add(PhonePrototypes.E2.Symbol.Simplified, PhonePrototypes.E2);
            ////Vowels.Add(PhonePrototypes.œ1.Symbol.Simplified, PhonePrototypes.œ1);
            ////Vowels.Add(PhonePrototypes.œ2.Symbol.Simplified, PhonePrototypes.œ2);

            ////Vowels.Add(PhonePrototypes.ɜ1.Symbol.Simplified, PhonePrototypes.ɜ1);
            ////Vowels.Add(PhonePrototypes.ɜ2.Symbol.Simplified, PhonePrototypes.ɜ2);
            ////Vowels.Add(PhonePrototypes.ɞ1.Symbol.Simplified, PhonePrototypes.ɞ1);
            ////Vowels.Add(PhonePrototypes.ɞ2.Symbol.Simplified, PhonePrototypes.ɞ2);

            ////Vowels.Add(PhonePrototypes.V1.Symbol.Simplified, PhonePrototypes.V1);
            ////Vowels.Add(PhonePrototypes.V2.Symbol.Simplified, PhonePrototypes.V2);
            //Vowels.Add(PhonePrototypes.O1.Symbol.Simplified, PhonePrototypes.O1);
            ////Vowels.Add(PhonePrototypes.O2.Symbol.Simplified, PhonePrototypes.O2);

            ////Vowels.Add(PhonePrototypes.æ1.Symbol.Simplified, PhonePrototypes.æ1);
            ////Vowels.Add(PhonePrototypes.æ2.Symbol.Simplified, PhonePrototypes.æ2);
            ////Vowels.Add(PhonePrototypes.ɐ1.Symbol.Simplified, PhonePrototypes.ɐ1);
            ////Vowels.Add(PhonePrototypes.ɐ2.Symbol.Simplified, PhonePrototypes.ɐ2);

            ////Vowels.Add(PhonePrototypes.a.Symbol.Simplified, PhonePrototypes.a);
            ////Vowels.Add(PhonePrototypes.ɶ1.Symbol.Simplified, PhonePrototypes.ɶ1);
            ////Vowels.Add(PhonePrototypes.ɶ2.Symbol.Simplified, PhonePrototypes.ɶ2);
            //Vowels.Add(PhonePrototypes.a_central.Symbol.Simplified, PhonePrototypes.a_central);
            ////Vowels.Add(PhonePrototypes.A1.Symbol.Simplified, PhonePrototypes.A1);
            ////Vowels.Add(PhonePrototypes.A2.Symbol.Simplified, PhonePrototypes.A2);
            ////Vowels.Add(PhonePrototypes.Q1.Symbol.Simplified, PhonePrototypes.Q1);
            ////Vowels.Add(PhonePrototypes.Q2.Symbol.Simplified, PhonePrototypes.Q2);

            //#endregion



            //#region: Other

            //OtherSymbols.Add(PhonePrototypes.juncture1.Symbol.Simplified, PhonePrototypes.juncture1);
            //OtherSymbols.Add(PhonePrototypes.juncture2.Symbol.Simplified, PhonePrototypes.juncture2);

            //OtherSymbols.Add(PhonePrototypes.pause1.Symbol.Simplified, PhonePrototypes.pause1);
            ////OtherSymbols.Add(PhonePrototypes.pause2.Symbol.Simplified, PhonePrototypes.pause2);
            //OtherSymbols.Add(PhonePrototypes.pause3.Symbol.Simplified, PhonePrototypes.pause3);

            //OtherSymbols.Add(PhonePrototypes.unknownPhone.Symbol.Simplified, PhonePrototypes.unknownPhone);

            //OtherSymbols.Add(PhonePrototypes.nullPhone.Symbol.Simplified, PhonePrototypes.nullPhone);

            //UnknownPhonesDelimiters.Add(PhonePrototypes.unknownPhoneDelimiter1.Symbol.Simplified, PhonePrototypes.unknownPhoneDelimiter1);
            //UnknownPhonesDelimiters.Add(PhonePrototypes.unknownPhoneDelimiter2.Symbol.Simplified, PhonePrototypes.unknownPhoneDelimiter2);
            //UnknownPhonesDelimiters.Add(PhonePrototypes.unknownPhoneDelimiter3.Symbol.Simplified, PhonePrototypes.unknownPhoneDelimiter3);


            //#endregion

            //#endregion


            //#region: Vowel diacritics

            //VowelDiacritics.Add(
            //    PhonePrototypes.@long.Symbol.Simplified,
            //    new Diacritic(PhonePrototypes.@long, -1));
            //VowelDiacritics.Add(
            //    PhonePrototypes.nasal.Symbol.Simplified,
            //    new Diacritic(PhonePrototypes.nasal, -1));

            //#endregion

            //#region: Consonant diacritics

            //ConsonantDiacritics.Add(
            //    PhonePrototypes.palatalized.Symbol.Simplified,
            //    new Diacritic(PhonePrototypes.palatalized, -1));

            //#endregion

            


            #endregion










        }
    }
}
