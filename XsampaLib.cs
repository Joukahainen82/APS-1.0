using APS_2.Phonetics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_2.Symbols.Library
{
    public class XsampaLib : Library
    {
        public XsampaLib()
        {

            Symbols = new Dictionary<string, Phone>();

            //var type = typeof(PhonePrototypes);

            //System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(type.TypeHandle);
            //System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(type.TypeHandle);

            #region: Symbols

            #region: Consonants

            #region: Stops

            Symbols.Add(PhonePrototypes.p1.Symbol.XSampa, PhonePrototypes.p1);

            //Symbols.Add(PhonePrototypes.p2.Symbol.XSampa, PhonePrototypes.p2);
            Symbols.Add(PhonePrototypes.b1.Symbol.XSampa, PhonePrototypes.b1);
            //Symbols.Add(PhonePrototypes.b2.Symbol.XSampa, PhonePrototypes.b2);

            Symbols.Add(PhonePrototypes.t1.Symbol.XSampa, PhonePrototypes.t1);
            //Symbols.Add(PhonePrototypes.t2.Symbol.XSampa, PhonePrototypes.t2);
            Symbols.Add(PhonePrototypes.d1.Symbol.XSampa, PhonePrototypes.d1);
            //Symbols.Add(PhonePrototypes.d2.Symbol.XSampa, PhonePrototypes.d1);

            Symbols.Add(PhonePrototypes.ti.Symbol.XSampa, PhonePrototypes.ti);
            Symbols.Add(PhonePrototypes.di.Symbol.XSampa, PhonePrototypes.di);


            Symbols.Add(PhonePrototypes.c1.Symbol.XSampa, PhonePrototypes.c1);
            //Symbols.Add(PhonePrototypes.c2.Symbol.XSampa, PhonePrototypes.c2);
            Symbols.Add(PhonePrototypes.ɟ1.Symbol.XSampa, PhonePrototypes.ɟ1);
            //Symbols.Add(PhonePrototypes.ɟ2.Symbol.XSampa, PhonePrototypes.ɟ2);
            Symbols.Add(PhonePrototypes.ɟ3.Symbol.XSampa, PhonePrototypes.ɟ3);

            Symbols.Add(PhonePrototypes.k1.Symbol.XSampa, PhonePrototypes.k1);
            //Symbols.Add(PhonePrototypes.k2.Symbol.XSampa, PhonePrototypes.k2);
            Symbols.Add(PhonePrototypes.g1.Symbol.XSampa, PhonePrototypes.g1);
            //Symbols.Add(PhonePrototypes.g2.Symbol.XSampa, PhonePrototypes.k2);

            Symbols.Add(PhonePrototypes.q1.Symbol.XSampa, PhonePrototypes.q1);
            //Symbols.Add(PhonePrototypes.q2.Symbol.XSampa, PhonePrototypes.q2);
            Symbols.Add(PhonePrototypes.ɢ1.Symbol.XSampa, PhonePrototypes.ɢ1);
            //Symbols.Add(PhonePrototypes.ɢ2.Symbol.XSampa, PhonePrototypes.ɢ2);
            Symbols.Add(PhonePrototypes.ɢ3.Symbol.XSampa, PhonePrototypes.ɢ3);

            Symbols.Add(PhonePrototypes.ʔ.Symbol.XSampa, PhonePrototypes.ʔ);

            #endregion

            #region: Nasals

            Symbols.Add(PhonePrototypes.m.Symbol.XSampa, PhonePrototypes.m);
            Symbols.Add(PhonePrototypes.F.Symbol.XSampa, PhonePrototypes.F);

            Symbols.Add(PhonePrototypes.n.Symbol.XSampa, PhonePrototypes.n);
            Symbols.Add(PhonePrototypes.ń.Symbol.XSampa, PhonePrototypes.ń);

            Symbols.Add(PhonePrototypes.ɲ1.Symbol.XSampa, PhonePrototypes.ɲ1);
            Symbols.Add(PhonePrototypes.ɲ2.Symbol.XSampa, PhonePrototypes.ɲ2);

            Symbols.Add(PhonePrototypes.ŋ1.Symbol.XSampa, PhonePrototypes.ŋ1);
            Symbols.Add(PhonePrototypes.ŋ2.Symbol.XSampa, PhonePrototypes.ŋ2);

            Symbols.Add(PhonePrototypes.ɴ1.Symbol.XSampa, PhonePrototypes.ɴ1);
            Symbols.Add(PhonePrototypes.ɴ2.Symbol.XSampa, PhonePrototypes.ɴ2);

            #endregion

            #region: Trills and flaps

            Symbols.Add(PhonePrototypes.r.Symbol.XSampa, PhonePrototypes.r);
            Symbols.Add(PhonePrototypes.r_0.Symbol.XSampa, PhonePrototypes.r_0);
            Symbols.Add(PhonePrototypes.R1.Symbol.XSampa, PhonePrototypes.R1);
            Symbols.Add(PhonePrototypes.R2.Symbol.XSampa, PhonePrototypes.R2);
            Symbols.Add(PhonePrototypes.ř.Symbol.XSampa, PhonePrototypes.ř);
            Symbols.Add(PhonePrototypes.B1.Symbol.XSampa, PhonePrototypes.B1);
            Symbols.Add(PhonePrototypes.B2.Symbol.XSampa, PhonePrototypes.B2);

            Symbols.Add(PhonePrototypes._4_1.Symbol.XSampa, PhonePrototypes._4_1);
            Symbols.Add(PhonePrototypes._4_2.Symbol.XSampa, PhonePrototypes._4_2);

            #endregion

            #region: Fricatives

            Symbols.Add(PhonePrototypes.ɸ.Symbol.XSampa, PhonePrototypes.ɸ);
            Symbols.Add(PhonePrototypes.β.Symbol.XSampa, PhonePrototypes.β);

            Symbols.Add(PhonePrototypes.f.Symbol.XSampa, PhonePrototypes.f);
            Symbols.Add(PhonePrototypes.v.Symbol.XSampa, PhonePrototypes.v);

            Symbols.Add(PhonePrototypes.s.Symbol.XSampa, PhonePrototypes.s);
            Symbols.Add(PhonePrototypes.z.Symbol.XSampa, PhonePrototypes.z);

            Symbols.Add(PhonePrototypes.S1.Symbol.XSampa, PhonePrototypes.S1);
            Symbols.Add(PhonePrototypes.S2.Symbol.XSampa, PhonePrototypes.S2);
            Symbols.Add(PhonePrototypes.Z1.Symbol.XSampa, PhonePrototypes.Z1);
            Symbols.Add(PhonePrototypes.Z2.Symbol.XSampa, PhonePrototypes.Z2);

            Symbols.Add(PhonePrototypes.ś.Symbol.XSampa, PhonePrototypes.ś);
            Symbols.Add(PhonePrototypes.ź.Symbol.XSampa, PhonePrototypes.ź);

            Symbols.Add(PhonePrototypes.C1.Symbol.XSampa, PhonePrototypes.C1);
            Symbols.Add(PhonePrototypes.C2.Symbol.XSampa, PhonePrototypes.C2);
            Symbols.Add(PhonePrototypes.ʝ.Symbol.XSampa, PhonePrototypes.ʝ);

            Symbols.Add(PhonePrototypes.x.Symbol.XSampa, PhonePrototypes.x);
            Symbols.Add(PhonePrototypes.ɣ1.Symbol.XSampa, PhonePrototypes.ɣ1);
            Symbols.Add(PhonePrototypes.ɣ2.Symbol.XSampa, PhonePrototypes.ɣ2);

            Symbols.Add(PhonePrototypes.X1.Symbol.XSampa, PhonePrototypes.X1);
            Symbols.Add(PhonePrototypes.X2.Symbol.XSampa, PhonePrototypes.X2);
            Symbols.Add(PhonePrototypes.ʁ1.Symbol.XSampa, PhonePrototypes.ʁ1);
            Symbols.Add(PhonePrototypes.ʁ2.Symbol.XSampa, PhonePrototypes.ʁ2);

            Symbols.Add(PhonePrototypes.h.Symbol.XSampa, PhonePrototypes.h);
            Symbols.Add(PhonePrototypes.ɦ.Symbol.XSampa, PhonePrototypes.ɦ);

            #endregion

            #region: Approximants

            Symbols.Add(PhonePrototypes.j.Symbol.XSampa, PhonePrototypes.j);
            Symbols.Add(PhonePrototypes.w1.Symbol.XSampa, PhonePrototypes.w1);
            Symbols.Add(PhonePrototypes.w2.Symbol.XSampa, PhonePrototypes.w2);

            Symbols.Add(PhonePrototypes.P1.Symbol.XSampa, PhonePrototypes.P1);
            Symbols.Add(PhonePrototypes.P2.Symbol.XSampa, PhonePrototypes.P2);

            Symbols.Add(PhonePrototypes.l.Symbol.XSampa, PhonePrototypes.l);
            Symbols.Add(PhonePrototypes.li.Symbol.XSampa, PhonePrototypes.li);
            Symbols.Add(PhonePrototypes.L1.Symbol.XSampa, PhonePrototypes.L1);
            Symbols.Add(PhonePrototypes.L2.Symbol.XSampa, PhonePrototypes.L2);

            Symbols.Add(PhonePrototypes.ɹ.Symbol.XSampa, PhonePrototypes.ɹ);

            #endregion

            #region: Affricates

            //Symbols.Add(PhonePrototypes.ts1.Symbol.XSampa, PhonePrototypes.ts1);
            //Symbols.Add(PhonePrototypes.ts2.Symbol.XSampa, PhonePrototypes.ts2);
            //Symbols.Add(PhonePrototypes.dz1.Symbol.XSampa, PhonePrototypes.dz1);
            //Symbols.Add(PhonePrototypes.dz2.Symbol.XSampa, PhonePrototypes.dz2);

            //Symbols.Add(PhonePrototypes.tS1.Symbol.XSampa, PhonePrototypes.tS1);
            //Symbols.Add(PhonePrototypes.tS2.Symbol.XSampa, PhonePrototypes.tS2);
            //Symbols.Add(PhonePrototypes.dZ1.Symbol.XSampa, PhonePrototypes.dZ1);
            //Symbols.Add(PhonePrototypes.dZ2.Symbol.XSampa, PhonePrototypes.dZ2);

            //Symbols.Add(PhonePrototypes.tś1.Symbol.XSampa, PhonePrototypes.tś1);
            //Symbols.Add(PhonePrototypes.tś2.Symbol.XSampa, PhonePrototypes.tś2);
            //Symbols.Add(PhonePrototypes.dź1.Symbol.XSampa, PhonePrototypes.dź1);
            //Symbols.Add(PhonePrototypes.dź2.Symbol.XSampa, PhonePrototypes.dź2);

            #endregion

            #region: Releases

            Symbols.Add(PhonePrototypes.s_release1.Symbol.XSampa, PhonePrototypes.s_release1);
            //Symbols.Add(PhonePrototypes.s_release2.Symbol.XSampa, PhonePrototypes.s_release2);

            Symbols.Add(PhonePrototypes.z_release1.Symbol.XSampa, PhonePrototypes.z_release1);
            //Symbols.Add(PhonePrototypes.z_release2.Symbol.XSampa, PhonePrototypes.z_release2);

            Symbols.Add(PhonePrototypes.S_release1.Symbol.XSampa, PhonePrototypes.S_release1);
            //Symbols.Add(PhonePrototypes.S_release2.Symbol.XSampa, PhonePrototypes.S_release2);
            Symbols.Add(PhonePrototypes.S_release3.Symbol.XSampa, PhonePrototypes.S_release3);

            Symbols.Add(PhonePrototypes.Z_release1.Symbol.XSampa, PhonePrototypes.Z_release1);
            //Symbols.Add(PhonePrototypes.Z_release2.Symbol.XSampa, PhonePrototypes.Z_release2);
            Symbols.Add(PhonePrototypes.Z_release3.Symbol.XSampa, PhonePrototypes.Z_release3);

            Symbols.Add(PhonePrototypes.ś_release1.Symbol.XSampa, PhonePrototypes.ś_release1);
            //Symbols.Add(PhonePrototypes.ś_release2.Symbol.XSampa, PhonePrototypes.ś_release2);
            Symbols.Add(PhonePrototypes.ś_release3.Symbol.XSampa, PhonePrototypes.ś_release3);
            Symbols.Add(PhonePrototypes.ś_release4.Symbol.XSampa, PhonePrototypes.ś_release4);


            Symbols.Add(PhonePrototypes.ź_release1.Symbol.XSampa, PhonePrototypes.ź_release1);
            //Symbols.Add(PhonePrototypes.ź_release2.Symbol.XSampa, PhonePrototypes.ź_release2);
            Symbols.Add(PhonePrototypes.ź_release3.Symbol.XSampa, PhonePrototypes.ź_release3);
            Symbols.Add(PhonePrototypes.ź_release4.Symbol.XSampa, PhonePrototypes.ź_release4);


            Symbols.Add(PhonePrototypes.x_release.Symbol.XSampa, PhonePrototypes.x_release);
            Symbols.Add(PhonePrototypes.ɣ_release1.Symbol.XSampa, PhonePrototypes.ɣ_release1);
            Symbols.Add(PhonePrototypes.ɣ_release2.Symbol.XSampa, PhonePrototypes.ɣ_release2);

            Symbols.Add(PhonePrototypes.h_release1.Symbol.XSampa, PhonePrototypes.h_release1);
            Symbols.Add(PhonePrototypes.h_release2.Symbol.XSampa, PhonePrototypes.h_release2);

            Symbols.Add(PhonePrototypes.h_voiced_release1.Symbol.XSampa, PhonePrototypes.h_voiced_release1);
            Symbols.Add(PhonePrototypes.h_voiced_release2.Symbol.XSampa, PhonePrototypes.h_voiced_release2);


            Symbols.Add(PhonePrototypes.y_release.Symbol.XSampa, PhonePrototypes.y_release);
            Symbols.Add(PhonePrototypes.a_release.Symbol.XSampa, PhonePrototypes.a_release);
            Symbols.Add(PhonePrototypes.U_release1.Symbol.XSampa, PhonePrototypes.U_release1);
            Symbols.Add(PhonePrototypes.U_release2.Symbol.XSampa, PhonePrototypes.U_release2);

            Symbols.Add(PhonePrototypes.u_release.Symbol.XSampa, PhonePrototypes.u_release);
            Symbols.Add(PhonePrototypes.A_release1.Symbol.XSampa, PhonePrototypes.A_release1);
            Symbols.Add(PhonePrototypes.A_release2.Symbol.XSampa, PhonePrototypes.A_release2);

            Symbols.Add(PhonePrototypes.e_release.Symbol.XSampa, PhonePrototypes.e_release);
            Symbols.Add(PhonePrototypes.o_release.Symbol.XSampa, PhonePrototypes.o_release);

            Symbols.Add(PhonePrototypes.V_release1.Symbol.XSampa, PhonePrototypes.o_release);
            Symbols.Add(PhonePrototypes.V_release2.Symbol.XSampa, PhonePrototypes.V_release2);

            Symbols.Add(PhonePrototypes.E_release1.Symbol.XSampa, PhonePrototypes.E_release1);
            Symbols.Add(PhonePrototypes.E_release2.Symbol.XSampa, PhonePrototypes.E_release2);

            Symbols.Add(PhonePrototypes.O_release1.Symbol.XSampa, PhonePrototypes.O_release1);
            Symbols.Add(PhonePrototypes.O_release2.Symbol.XSampa, PhonePrototypes.O_release2);
            Symbols.Add(PhonePrototypes.Q_release1.Symbol.XSampa, PhonePrototypes.Q_release1);
            Symbols.Add(PhonePrototypes.Q_release2.Symbol.XSampa, PhonePrototypes.Q_release2);

            Symbols.Add(PhonePrototypes.ɐ1_release1.Symbol.XSampa, PhonePrototypes.ɐ1_release1);
            Symbols.Add(PhonePrototypes.ɐ1_release2.Symbol.XSampa, PhonePrototypes.ɐ1_release2);

            Symbols.Add(PhonePrototypes.ə_release.Symbol.XSampa, PhonePrototypes.ə_release);

            Symbols.Add(PhonePrototypes.ɨ_release1.Symbol.XSampa, PhonePrototypes.ɨ_release1);
            Symbols.Add(PhonePrototypes.ɨ_release2.Symbol.XSampa, PhonePrototypes.ɨ_release2);

            Symbols.Add(PhonePrototypes.ɜ_release1.Symbol.XSampa, PhonePrototypes.ɜ_release1);
            Symbols.Add(PhonePrototypes.ɜ_release2.Symbol.XSampa, PhonePrototypes.ɜ_release2);

            Symbols.Add(PhonePrototypes.ʉ_release1.Symbol.XSampa, PhonePrototypes.ʉ_release1);
            Symbols.Add(PhonePrototypes.ʉ_release2.Symbol.XSampa, PhonePrototypes.ʉ_release2);

            Symbols.Add(PhonePrototypes.ɵ_release1.Symbol.XSampa, PhonePrototypes.ɵ_release1);
            Symbols.Add(PhonePrototypes.ɵ_release2.Symbol.XSampa, PhonePrototypes.ɵ_release2);




            #endregion


            #endregion

            #region: Vowels

            Symbols.Add(PhonePrototypes.i.Symbol.XSampa, PhonePrototypes.i);
            Symbols.Add(PhonePrototypes.y.Symbol.XSampa, PhonePrototypes.y);

            Symbols.Add(PhonePrototypes.I1.Symbol.XSampa, PhonePrototypes.I1);
            Symbols.Add(PhonePrototypes.I2.Symbol.XSampa, PhonePrototypes.I2);

            Symbols.Add(PhonePrototypes.ɨ1.Symbol.XSampa, PhonePrototypes.ɨ1);
            Symbols.Add(PhonePrototypes.ɨ2.Symbol.XSampa, PhonePrototypes.ɨ2);
            Symbols.Add(PhonePrototypes.ɨ3.Symbol.XSampa, PhonePrototypes.ɨ3);
            Symbols.Add(PhonePrototypes.ʉ1.Symbol.XSampa, PhonePrototypes.ʉ1);
            Symbols.Add(PhonePrototypes.ʉ2.Symbol.XSampa, PhonePrototypes.ʉ2);

            Symbols.Add(PhonePrototypes.M1.Symbol.XSampa, PhonePrototypes.M1);
            Symbols.Add(PhonePrototypes.M2.Symbol.XSampa, PhonePrototypes.M2);
            Symbols.Add(PhonePrototypes.u.Symbol.XSampa, PhonePrototypes.u);


            Symbols.Add(PhonePrototypes.e.Symbol.XSampa, PhonePrototypes.e);
            Symbols.Add(PhonePrototypes.ø1.Symbol.XSampa, PhonePrototypes.ø1);
            Symbols.Add(PhonePrototypes.ø2.Symbol.XSampa, PhonePrototypes.ø2);

            Symbols.Add(PhonePrototypes.ɘ.Symbol.XSampa, PhonePrototypes.ɘ);
            Symbols.Add(PhonePrototypes.ɵ1.Symbol.XSampa, PhonePrototypes.ɵ1);
            Symbols.Add(PhonePrototypes.ɵ2.Symbol.XSampa, PhonePrototypes.ɵ2);

            Symbols.Add(PhonePrototypes.ɤ1.Symbol.XSampa, PhonePrototypes.ɤ1);
            Symbols.Add(PhonePrototypes.ɤ2.Symbol.XSampa, PhonePrototypes.ɤ2);
            Symbols.Add(PhonePrototypes.o.Symbol.XSampa, PhonePrototypes.o);


            Symbols.Add(PhonePrototypes.ə.Symbol.XSampa, PhonePrototypes.ə);


            Symbols.Add(PhonePrototypes.E1.Symbol.XSampa, PhonePrototypes.E1);
            Symbols.Add(PhonePrototypes.E2.Symbol.XSampa, PhonePrototypes.E2);
            Symbols.Add(PhonePrototypes.œ1.Symbol.XSampa, PhonePrototypes.œ1);
            Symbols.Add(PhonePrototypes.œ2.Symbol.XSampa, PhonePrototypes.œ2);

            Symbols.Add(PhonePrototypes.ɜ1.Symbol.XSampa, PhonePrototypes.ɜ1);
            Symbols.Add(PhonePrototypes.ɜ2.Symbol.XSampa, PhonePrototypes.ɜ2);
            Symbols.Add(PhonePrototypes.ɞ1.Symbol.XSampa, PhonePrototypes.ɞ1);
            Symbols.Add(PhonePrototypes.ɞ2.Symbol.XSampa, PhonePrototypes.ɞ2);

            Symbols.Add(PhonePrototypes.V1.Symbol.XSampa, PhonePrototypes.V1);
            Symbols.Add(PhonePrototypes.V2.Symbol.XSampa, PhonePrototypes.V2);
            Symbols.Add(PhonePrototypes.O1.Symbol.XSampa, PhonePrototypes.O1);
            Symbols.Add(PhonePrototypes.O2.Symbol.XSampa, PhonePrototypes.O2);

            Symbols.Add(PhonePrototypes.æ1.Symbol.XSampa, PhonePrototypes.æ1);
            Symbols.Add(PhonePrototypes.æ2.Symbol.XSampa, PhonePrototypes.æ2);
            Symbols.Add(PhonePrototypes.ɐ1.Symbol.XSampa, PhonePrototypes.ɐ1);
            Symbols.Add(PhonePrototypes.ɐ2.Symbol.XSampa, PhonePrototypes.ɐ2);

            Symbols.Add(PhonePrototypes.a.Symbol.XSampa, PhonePrototypes.a);
            //AllSymbols.Add(PhonePrototypes.ɶ1.Symbol.XSampa, PhonePrototypes.ɶ1);
            Symbols.Add(PhonePrototypes.ɶ2.Symbol.XSampa, PhonePrototypes.ɶ2);
            //AllSymbols.Add(PhonePrototypes.a_central.Symbol.XSampa, PhonePrototypes.a_central);
            Symbols.Add(PhonePrototypes.A1.Symbol.XSampa, PhonePrototypes.A1);
            Symbols.Add(PhonePrototypes.A2.Symbol.XSampa, PhonePrototypes.A2);
            Symbols.Add(PhonePrototypes.Q1.Symbol.XSampa, PhonePrototypes.Q1);
            Symbols.Add(PhonePrototypes.Q2.Symbol.XSampa, PhonePrototypes.Q2);

            #endregion

            #region: Other

            Symbols.Add(PhonePrototypes.juncture1.Symbol.XSampa, PhonePrototypes.juncture1);
            Symbols.Add(PhonePrototypes.juncture2.Symbol.XSampa, PhonePrototypes.juncture2);

            Symbols.Add(PhonePrototypes.pause1.Symbol.XSampa, PhonePrototypes.pause1);
            Symbols.Add(PhonePrototypes.pause2.Symbol.XSampa, PhonePrototypes.pause2);
            Symbols.Add(PhonePrototypes.pause3.Symbol.XSampa, PhonePrototypes.pause3);

            Symbols.Add(PhonePrototypes.unknownPhone1.Symbol.XSampa, PhonePrototypes.unknownPhone1);
            Symbols.Add(PhonePrototypes.unknownPhone2.Symbol.XSampa, PhonePrototypes.unknownPhone2);
            Symbols.Add(PhonePrototypes.unknownPhone3.Symbol.XSampa, PhonePrototypes.unknownPhone3);
            Symbols.Add(PhonePrototypes.unknownPhone4.Symbol.XSampa, PhonePrototypes.unknownPhone4);


            Symbols.Add(PhonePrototypes.nullPhone.Symbol.XSampa, PhonePrototypes.nullPhone);

            Symbols.Add(PhonePrototypes.unknownPhoneDelimiter1a.Symbol.XSampa, PhonePrototypes.unknownPhoneDelimiter1a);
            Symbols.Add(PhonePrototypes.unknownPhoneDelimiter1b.Symbol.XSampa, PhonePrototypes.unknownPhoneDelimiter1b);
            Symbols.Add(PhonePrototypes.unknownPhoneDelimiter2a.Symbol.XSampa, PhonePrototypes.unknownPhoneDelimiter2a);
            Symbols.Add(PhonePrototypes.unknownPhoneDelimiter2b.Symbol.XSampa, PhonePrototypes.unknownPhoneDelimiter2b);
            Symbols.Add(PhonePrototypes.unknownPhoneDelimiter3.Symbol.XSampa, PhonePrototypes.unknownPhoneDelimiter3);

            #endregion

            #endregion


            #region: Diacritics

            #region: Vowel diacritics

            Symbols.Add(PhonePrototypes.voiceless.Symbol.XSampa,
                new Diacritic(PhonePrototypes.voiceless, -1));
            Symbols.Add(PhonePrototypes.voiced.Symbol.XSampa,
                new Diacritic(PhonePrototypes.voiced, -1));

            Symbols.Add(PhonePrototypes.breathy.Symbol.XSampa,
                new Diacritic(PhonePrototypes.breathy, -1));
            Symbols.Add(PhonePrototypes.creak.Symbol.XSampa,
                new Diacritic(PhonePrototypes.creak, -1));


            Symbols.Add(PhonePrototypes.extraShort.Symbol.XSampa,
                new Diacritic(PhonePrototypes.extraShort, -1));
            Symbols.Add(PhonePrototypes.@long.Symbol.XSampa,
                new Diacritic(PhonePrototypes.@long, -1));

            Symbols.Add(PhonePrototypes.primaryStress1.Symbol.XSampa,
                new Diacritic(PhonePrototypes.primaryStress1, 1));
            Symbols.Add(PhonePrototypes.primiaryStress2.Symbol.XSampa,
                new Diacritic(PhonePrototypes.primiaryStress2, 1));

            Symbols.Add(PhonePrototypes.nasal.Symbol.XSampa,
                new Diacritic(PhonePrototypes.nasal, -1));

            Symbols.Add(PhonePrototypes.retroflexion.Symbol.XSampa,
                new Diacritic(PhonePrototypes.retroflexion, -1));

            #endregion


            #region: Consonant diacritics

            Symbols.Add(PhonePrototypes.rounded1.Symbol.XSampa,
            new Diacritic(PhonePrototypes.rounded1, -1));
            Symbols.Add(PhonePrototypes.rounded2.Symbol.XSampa,
            new Diacritic(PhonePrototypes.rounded1, -1));

            //AllSymbols.Add(PhonePrototypes.creak.Symbol.XSampa,
            //new Diacritic(PhonePrototypes.creak, -1));
            //AllSymbols.Add(PhonePrototypes.breathy.Symbol.XSampa,
            //new Diacritic(PhonePrototypes.breathy, -1));


            Symbols.Add(
                PhonePrototypes.palatalized1.Symbol.XSampa,
                new Diacritic(PhonePrototypes.palatalized1, -1));
            //Symbols.Add(
            //    PhonePrototypes.palatalized2.Symbol.XSampa,
            //    new Diacritic(PhonePrototypes.palatalized2, -1));


            #endregion


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

            //Consonants.Add(PhonePrototypes.p1.Symbol.XSampa, PhonePrototypes.p1);

            //Consonants.Add(PhonePrototypes.p2.Symbol.XSampa, PhonePrototypes.p2);
            //Consonants.Add(PhonePrototypes.b1.Symbol.XSampa, PhonePrototypes.b1);
            //Consonants.Add(PhonePrototypes.b2.Symbol.XSampa, PhonePrototypes.b2);

            //Consonants.Add(PhonePrototypes.t1.Symbol.XSampa, PhonePrototypes.t1);
            //Consonants.Add(PhonePrototypes.t2.Symbol.XSampa, PhonePrototypes.t2);
            //Consonants.Add(PhonePrototypes.d1.Symbol.XSampa, PhonePrototypes.d1);
            //Consonants.Add(PhonePrototypes.d2.Symbol.XSampa, PhonePrototypes.d1);

            //Consonants.Add(PhonePrototypes.c1.Symbol.XSampa, PhonePrototypes.c1);
            //Consonants.Add(PhonePrototypes.c2.Symbol.XSampa, PhonePrototypes.c2);
            //Consonants.Add(PhonePrototypes.ɟ1.Symbol.XSampa, PhonePrototypes.ɟ1);
            //Consonants.Add(PhonePrototypes.ɟ2.Symbol.XSampa, PhonePrototypes.ɟ2);

            //Consonants.Add(PhonePrototypes.k1.Symbol.XSampa, PhonePrototypes.k1);
            //Consonants.Add(PhonePrototypes.k2.Symbol.XSampa, PhonePrototypes.k2);
            //Consonants.Add(PhonePrototypes.g1.Symbol.XSampa, PhonePrototypes.k1);
            //Consonants.Add(PhonePrototypes.g2.Symbol.XSampa, PhonePrototypes.k2);

            //Consonants.Add(PhonePrototypes.q1.Symbol.XSampa, PhonePrototypes.q1);
            //Consonants.Add(PhonePrototypes.q2.Symbol.XSampa, PhonePrototypes.q2);
            //Consonants.Add(PhonePrototypes.ɢ1.Symbol.XSampa, PhonePrototypes.ɢ1);
            //Consonants.Add(PhonePrototypes.ɢ2.Symbol.XSampa, PhonePrototypes.ɢ2);

            //Consonants.Add(PhonePrototypes.ʔ.Symbol.XSampa, PhonePrototypes.ʔ);

            //#endregion

            //#region: Nasals

            //Consonants.Add(PhonePrototypes.m.Symbol.XSampa, PhonePrototypes.m);
            //Consonants.Add(PhonePrototypes.n.Symbol.XSampa, PhonePrototypes.n);
            //Consonants.Add(PhonePrototypes.ń.Symbol.XSampa, PhonePrototypes.ń);

            //Consonants.Add(PhonePrototypes.ɲ1.Symbol.XSampa, PhonePrototypes.ɲ1);
            //Consonants.Add(PhonePrototypes.ɲ2.Symbol.XSampa, PhonePrototypes.ɲ2);

            //Consonants.Add(PhonePrototypes.ŋ1.Symbol.XSampa, PhonePrototypes.ŋ1);
            //Consonants.Add(PhonePrototypes.ŋ2.Symbol.XSampa, PhonePrototypes.ŋ2);

            //Consonants.Add(PhonePrototypes.ɴ1.Symbol.XSampa, PhonePrototypes.ɴ1);
            //Consonants.Add(PhonePrototypes.ɴ2.Symbol.XSampa, PhonePrototypes.ɴ2);

            //#endregion

            //#region: Trills

            //Consonants.Add(PhonePrototypes.r.Symbol.XSampa, PhonePrototypes.r);
            //Consonants.Add(PhonePrototypes.ʀ1.Symbol.XSampa, PhonePrototypes.ʀ1);
            //Consonants.Add(PhonePrototypes.ʀ2.Symbol.XSampa, PhonePrototypes.ʀ2);
            //Consonants.Add(PhonePrototypes.ř.Symbol.XSampa, PhonePrototypes.ř);

            //#endregion

            //#region: Fricatives

            //Consonants.Add(PhonePrototypes.f.Symbol.XSampa, PhonePrototypes.f);
            //Consonants.Add(PhonePrototypes.v.Symbol.XSampa, PhonePrototypes.v);

            //Consonants.Add(PhonePrototypes.s.Symbol.XSampa, PhonePrototypes.s);
            //Consonants.Add(PhonePrototypes.z.Symbol.XSampa, PhonePrototypes.z);

            //Consonants.Add(PhonePrototypes.S1.Symbol.XSampa, PhonePrototypes.S1);
            //Consonants.Add(PhonePrototypes.S2.Symbol.XSampa, PhonePrototypes.S2);
            //Consonants.Add(PhonePrototypes.Z1.Symbol.XSampa, PhonePrototypes.Z1);
            //Consonants.Add(PhonePrototypes.Z2.Symbol.XSampa, PhonePrototypes.Z2);

            //Consonants.Add(PhonePrototypes.ś.Symbol.XSampa, PhonePrototypes.ś);
            //Consonants.Add(PhonePrototypes.ź.Symbol.XSampa, PhonePrototypes.ź);

            //Consonants.Add(PhonePrototypes.C1.Symbol.XSampa, PhonePrototypes.C1);
            //Consonants.Add(PhonePrototypes.C2.Symbol.XSampa, PhonePrototypes.C2);
            //Consonants.Add(PhonePrototypes.ʝ.Symbol.XSampa, PhonePrototypes.ʝ);

            //Consonants.Add(PhonePrototypes.x.Symbol.XSampa, PhonePrototypes.x);
            //Consonants.Add(PhonePrototypes.ɣ.Symbol.XSampa, PhonePrototypes.ɣ);

            //Consonants.Add(PhonePrototypes.X1.Symbol.XSampa, PhonePrototypes.X1);
            //Consonants.Add(PhonePrototypes.X2.Symbol.XSampa, PhonePrototypes.X2);
            //Consonants.Add(PhonePrototypes.ʁ1.Symbol.XSampa, PhonePrototypes.ʁ1);
            //Consonants.Add(PhonePrototypes.ʁ2.Symbol.XSampa, PhonePrototypes.ʁ2);

            //Consonants.Add(PhonePrototypes.h.Symbol.XSampa, PhonePrototypes.h);
            //Consonants.Add(PhonePrototypes.ɦ.Symbol.XSampa, PhonePrototypes.ɦ);

            //#endregion

            //#region: Approximants

            //Consonants.Add(PhonePrototypes.j.Symbol.XSampa, PhonePrototypes.j);
            //Consonants.Add(PhonePrototypes.w.Symbol.XSampa, PhonePrototypes.w);

            //Consonants.Add(PhonePrototypes.l.Symbol.XSampa, PhonePrototypes.l);

            //#endregion

            //#region: Affricates

            //Consonants.Add(PhonePrototypes.ts1.Symbol.XSampa, PhonePrototypes.ts1);
            //Consonants.Add(PhonePrototypes.ts2.Symbol.XSampa, PhonePrototypes.ts2);
            //Consonants.Add(PhonePrototypes.dz1.Symbol.XSampa, PhonePrototypes.dz1);
            //Consonants.Add(PhonePrototypes.dz2.Symbol.XSampa, PhonePrototypes.dz2);

            //Consonants.Add(PhonePrototypes.tS1.Symbol.XSampa, PhonePrototypes.tS1);
            //Consonants.Add(PhonePrototypes.tS2.Symbol.XSampa, PhonePrototypes.tS2);
            //Consonants.Add(PhonePrototypes.dZ1.Symbol.XSampa, PhonePrototypes.dZ1);
            //Consonants.Add(PhonePrototypes.dZ2.Symbol.XSampa, PhonePrototypes.dZ2);

            //Consonants.Add(PhonePrototypes.tś1.Symbol.XSampa, PhonePrototypes.tś1);
            //Consonants.Add(PhonePrototypes.tś2.Symbol.XSampa, PhonePrototypes.tś2);
            //Consonants.Add(PhonePrototypes.dź1.Symbol.XSampa, PhonePrototypes.dź1);
            //Consonants.Add(PhonePrototypes.dź2.Symbol.XSampa, PhonePrototypes.dź2);

            //#endregion

            //#endregion

            //#region: Vowels

            //Vowels.Add(PhonePrototypes.i.Symbol.XSampa, PhonePrototypes.i);
            //Vowels.Add(PhonePrototypes.y.Symbol.XSampa, PhonePrototypes.y);

            //Vowels.Add(PhonePrototypes.ɨ1.Symbol.XSampa, PhonePrototypes.ɨ1);
            //Vowels.Add(PhonePrototypes.ɨ2.Symbol.XSampa, PhonePrototypes.ɨ2);
            //Vowels.Add(PhonePrototypes.ɨ3.Symbol.XSampa, PhonePrototypes.ɨ3);
            //Vowels.Add(PhonePrototypes.ʉ1.Symbol.XSampa, PhonePrototypes.ʉ1);
            //Vowels.Add(PhonePrototypes.ʉ2.Symbol.XSampa, PhonePrototypes.ʉ2);

            //Vowels.Add(PhonePrototypes.M1.Symbol.XSampa, PhonePrototypes.M1);
            //Vowels.Add(PhonePrototypes.M2.Symbol.XSampa, PhonePrototypes.M2);
            //Vowels.Add(PhonePrototypes.u.Symbol.XSampa, PhonePrototypes.u);


            //Vowels.Add(PhonePrototypes.e.Symbol.XSampa, PhonePrototypes.e);
            //Vowels.Add(PhonePrototypes.ø1.Symbol.XSampa, PhonePrototypes.ø1);
            //Vowels.Add(PhonePrototypes.ø2.Symbol.XSampa, PhonePrototypes.ø2);

            //Vowels.Add(PhonePrototypes.ɘ.Symbol.XSampa, PhonePrototypes.ɘ);
            //Vowels.Add(PhonePrototypes.ɵ1.Symbol.XSampa, PhonePrototypes.ɵ1);
            //Vowels.Add(PhonePrototypes.ɵ2.Symbol.XSampa, PhonePrototypes.ɵ2);

            //Vowels.Add(PhonePrototypes.ɤ1.Symbol.XSampa, PhonePrototypes.ɤ1);
            //Vowels.Add(PhonePrototypes.ɤ2.Symbol.XSampa, PhonePrototypes.ɤ2);
            //Vowels.Add(PhonePrototypes.o.Symbol.XSampa, PhonePrototypes.o);


            //Vowels.Add(PhonePrototypes.ə.Symbol.XSampa, PhonePrototypes.ə);


            //Vowels.Add(PhonePrototypes.E1.Symbol.XSampa, PhonePrototypes.E1);
            //Vowels.Add(PhonePrototypes.E2.Symbol.XSampa, PhonePrototypes.E2);
            //Vowels.Add(PhonePrototypes.œ1.Symbol.XSampa, PhonePrototypes.œ1);
            //Vowels.Add(PhonePrototypes.œ2.Symbol.XSampa, PhonePrototypes.œ2);

            //Vowels.Add(PhonePrototypes.ɜ1.Symbol.XSampa, PhonePrototypes.ɜ1);
            //Vowels.Add(PhonePrototypes.ɜ2.Symbol.XSampa, PhonePrototypes.ɜ2);
            //Vowels.Add(PhonePrototypes.ɞ1.Symbol.XSampa, PhonePrototypes.ɞ1);
            //Vowels.Add(PhonePrototypes.ɞ2.Symbol.XSampa, PhonePrototypes.ɞ2);

            //Vowels.Add(PhonePrototypes.V1.Symbol.XSampa, PhonePrototypes.V1);
            //Vowels.Add(PhonePrototypes.V2.Symbol.XSampa, PhonePrototypes.V2);
            //Vowels.Add(PhonePrototypes.O1.Symbol.XSampa, PhonePrototypes.O1);
            //Vowels.Add(PhonePrototypes.O2.Symbol.XSampa, PhonePrototypes.O2);

            //Vowels.Add(PhonePrototypes.æ1.Symbol.XSampa, PhonePrototypes.æ1);
            //Vowels.Add(PhonePrototypes.æ2.Symbol.XSampa, PhonePrototypes.æ2);
            //Vowels.Add(PhonePrototypes.ɐ1.Symbol.XSampa, PhonePrototypes.ɐ1);
            //Vowels.Add(PhonePrototypes.ɐ2.Symbol.XSampa, PhonePrototypes.ɐ2);

            //Vowels.Add(PhonePrototypes.a.Symbol.XSampa, PhonePrototypes.a);
            ////Vowels.Add(PhonePrototypes.ɶ1.Symbol.XSampa, PhonePrototypes.ɶ1);
            //Vowels.Add(PhonePrototypes.ɶ2.Symbol.XSampa, PhonePrototypes.ɶ2);
            ////Vowels.Add(PhonePrototypes.a_central.Symbol.XSampa, PhonePrototypes.a_central);
            //Vowels.Add(PhonePrototypes.A1.Symbol.XSampa, PhonePrototypes.A1);
            //Vowels.Add(PhonePrototypes.A2.Symbol.XSampa, PhonePrototypes.A2);
            //Vowels.Add(PhonePrototypes.Q1.Symbol.XSampa, PhonePrototypes.Q1);
            //Vowels.Add(PhonePrototypes.Q2.Symbol.XSampa, PhonePrototypes.Q2);

            //#endregion

            //#region: Other

            //OtherSymbols.Add(PhonePrototypes.juncture1.Symbol.XSampa, PhonePrototypes.juncture1);
            //OtherSymbols.Add(PhonePrototypes.juncture2.Symbol.XSampa, PhonePrototypes.juncture2);

            //OtherSymbols.Add(PhonePrototypes.pause1.Symbol.XSampa, PhonePrototypes.pause1);
            //OtherSymbols.Add(PhonePrototypes.pause2.Symbol.XSampa, PhonePrototypes.pause2);
            //OtherSymbols.Add(PhonePrototypes.pause3.Symbol.XSampa, PhonePrototypes.pause3);

            //OtherSymbols.Add(PhonePrototypes.unknownPhone.Symbol.XSampa, PhonePrototypes.unknownPhone);

            //OtherSymbols.Add(PhonePrototypes.nullPhone.Symbol.XSampa, PhonePrototypes.nullPhone);

            //UnknownPhonesDelimiters.Add(PhonePrototypes.unknownPhoneDelimiter1.Symbol.XSampa, PhonePrototypes.unknownPhoneDelimiter1);
            //UnknownPhonesDelimiters.Add(PhonePrototypes.unknownPhoneDelimiter2.Symbol.XSampa, PhonePrototypes.unknownPhoneDelimiter2);
            //UnknownPhonesDelimiters.Add(PhonePrototypes.unknownPhoneDelimiter3.Symbol.XSampa, PhonePrototypes.unknownPhoneDelimiter3);

            //#endregion

            //#endregion


            //#region: Diacritics

            //#region: Vowel diacritics

            //VowelDiacritics.Add(PhonePrototypes.voiceless.Symbol.XSampa,
            //    new Diacritic(PhonePrototypes.voiceless, -1));
            //VowelDiacritics.Add(PhonePrototypes.voiced.Symbol.XSampa,
            //    new Diacritic(PhonePrototypes.voiced, -1));

            //VowelDiacritics.Add(PhonePrototypes.breathy.Symbol.XSampa,
            //    new Diacritic(PhonePrototypes.breathy, -1));
            //VowelDiacritics.Add(PhonePrototypes.creak.Symbol.XSampa,
            //    new Diacritic(PhonePrototypes.creak, -1));

            //VowelDiacritics.Add(PhonePrototypes.@long.Symbol.XSampa,
            //    new Diacritic(PhonePrototypes.@long, -1));

            //VowelDiacritics.Add(PhonePrototypes.primiaryStress.Symbol.XSampa,
            //    new Diacritic(PhonePrototypes.primiaryStress, 1));

            //VowelDiacritics.Add(PhonePrototypes.nasal.Symbol.XSampa,
            //    new Diacritic(PhonePrototypes.nasal, -1));



            //#endregion


            //#region: Consonant diacritics

            //ConsonantDiacritics.Add(PhonePrototypes.rounded.Symbol.XSampa,
            //    new Diacritic(PhonePrototypes.rounded, -1));

            //ConsonantDiacritics.Add(PhonePrototypes.creak.Symbol.XSampa,
            //    new Diacritic(PhonePrototypes.creak, -1));
            //ConsonantDiacritics.Add(PhonePrototypes.breathy.Symbol.XSampa,
            //    new Diacritic(PhonePrototypes.breathy, -1));



            //#endregion


            //#endregion


            #endregion




        }


    }
}
