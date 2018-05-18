using APS_1.Phonetics.Enums;
using APS_1.Symbols;
using APS_1.Symbols.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_1.Phonetics
{
    public static class PhonePrototypes
    {



        #region: Diacritics

        public static readonly Phone voiceless = new Phone(
            Phonation.voiceless,
            new Symbol("\u0325", "", "", "_0"),
            -1);
        public static readonly Phone voiced = new Phone(
            Phonation.voiced,
            new Symbol("\u023D", "", "", "_v"),
            -1);

        public static readonly Phone nasal = new Phone(
            Nasality.nasal,
            new Symbol("\u0303", "\u0303", "~", "~"),
            -1);
        public static readonly Phone oral = new Phone(
            Nasality.oral,
            new Symbol("", "", "", ""),
            0);

        public static readonly Phone extraShort = new Phone(
            Length.extraShort,
            new Symbol("\u0306", "", "", "_X"),
            -1);
        public static readonly Phone @short = new Phone(
            Length.@short,
            new Symbol("", "", "", ""),
            0);
        public static readonly Phone @long = new Phone(
            Length.@long,
            new Symbol("\u02D0", "\u0304", ":", ":"),
            1);


        public static readonly Consonant palatalized1 = new Consonant(
            Palatalization.palatalized,
            new Symbol("\u02B2", "'", "'", "_j"),
            -1);
        //public static readonly Consonant palatalized2 = new Consonant(
        //    Palatalization.palatalized,
        //    new Symbol("\u02B2", "'", "'", "j)"),
        //    -1);
        public static readonly Consonant unpalatalized = new Consonant(
            Palatalization.unpalatalized,
            null,
            0);

        public static readonly Phone creak = new Phone(
            Phonation.creaky,
            new Symbol("\u0330", "", "", "_k"),
            -1);
        public static readonly Phone breathy = new Phone(
            Phonation.breathy,
            new Symbol("\u0324", "", "", "_t"),
            -1);

        public static readonly Phone rounded1 = new Phone(
            Roundness.rounded,
            new Symbol("\u02B7", "", "", "_w"),
            -1);
        public static readonly Phone rounded2 = new Phone(
    Roundness.rounded,
    new Symbol("\u02B7", "", "", "^w"),
    -1);
        public static readonly Phone unrounded = new Phone(
            Roundness.unrounded,
            new Symbol("", "", "", ""),
            0);

        public static readonly Vowel primaryStress1 = new Vowel(
            Stress.stressed,
            new Symbol("\u02C8", "\u0027", "\u0027", "\u0022"),
            1);
        public static readonly Vowel primiaryStress2 = new Vowel(
            Stress.stressed,
            new Symbol("\u02C8", "\u0027", "\u0027", "'"),
            1);

        public static readonly Phone retroflexion = new Phone(
            Rhoticity.rhotic,
            new Symbol("˞", "", "", "`"),
            -1);


        #endregion

        #region: Place of articulation

        private static readonly Consonant bilabial = new Consonant(PlaceOfArticulation.bilabial);
        private static readonly Consonant labiodental = new Consonant(PlaceOfArticulation.labiodental);
        private static readonly Consonant dental = new Consonant(PlaceOfArticulation.dental);
        private static readonly Consonant alveolar = new Consonant(PlaceOfArticulation.alveolar);
        private static readonly Consonant postalveolar = new Consonant(PlaceOfArticulation.postalveolar);
        private static readonly Consonant alveopalatal = new Consonant(PlaceOfArticulation.alveopalatal);
        private static readonly Consonant palatal = new Consonant(PlaceOfArticulation.palatal);
        private static readonly Consonant velar = new Consonant(PlaceOfArticulation.velar);
        private static readonly Consonant uvular = new Consonant(PlaceOfArticulation.uvular);
        private static readonly Consonant glottal = new Consonant(PlaceOfArticulation.glottal);

        #endregion

        #region: Manner of articulation

        private static readonly Consonant stop = new Consonant(MannerOfArticulation.stop);
        private static readonly Consonant fricative = new Consonant(MannerOfArticulation.fricative);
        private static readonly Consonant affricate = new Consonant(MannerOfArticulation.affricate);
        private static readonly Consonant lateral = new Consonant(MannerOfArticulation.lateral);
        private static readonly Consonant trill = new Consonant(MannerOfArticulation.trill);
        private static readonly Consonant flap = new Consonant(MannerOfArticulation.flap);
        private static readonly Consonant semivowel = new Consonant(MannerOfArticulation.semivowel);
        private static readonly Consonant fricativeTrill = new Consonant(MannerOfArticulation.fricativeTrill);

        private static readonly Phone release = new Phone() { MannerOfArticulation = Enums.MannerOfArticulation.vowel };

        private static readonly Vowel vowel = new Vowel() { MannerOfArticulation = Enums.MannerOfArticulation.vowel };

        #endregion

        #region: Releases

        public static readonly Phone releaseVoiced = new Phone(MannerOfArticulation.releaseVoiced, new Symbol(), 0);
        public static readonly Phone releaseVoiceless = new Phone(MannerOfArticulation.releaseVoiceless, new Symbol(), 0);

        //public static readonly Vowel releaseVowel = new Vowel(MannerOfArticulation.releaseVowel);

        public static readonly Phone releaseFricativeVoiced = new Phone(MannerOfArticulation.releaseFricativeVoiced, new Symbol(), 0);
        public static readonly Phone releaseFricativeVoiceless = new Phone(MannerOfArticulation.releaseFricativeVoiceless, new Symbol(), 0);



        //public static readonly Consonant f_release = new Consonant(PlaceOfArticulation.labiodental, MannerOfArticulation.releaseFricativeVoiceless, null, Nasality.oral, new Symbol("ᶠ", "", "", "^f"), Roundness.unrounded, 0);
        //public static readonly Consonant v_release = new Consonant(PlaceOfArticulation.labiodental, MannerOfArticulation.releaseFricativeVoiceless, null, Nasality.oral, new Symbol("ᵛ", "", "", "^v"), Roundness.unrounded, 0);

        public static readonly Consonant s_release1 = new Consonant(PlaceOfArticulation.alveolar, MannerOfArticulation.releaseFricativeVoiceless, null, Nasality.oral, new Symbol("ˢ", "", "", "^s"), Roundness.unrounded, 0);
        //public static readonly Consonant s_release2 = new Consonant
        //    (s_release1, new Symbol("ˢ", "", "", "s)"), 0);
        public static readonly Consonant z_release1 = new Consonant(s_release1 + releaseFricativeVoiced, new Symbol("ᶻ", "", "", "^z"), 0);
        //public static readonly Consonant z_release2 = new Consonant
        //    (z_release1, new Symbol("ˢ", "", "", "z)"), 0);

        public static readonly Consonant S_release1 = new Consonant(s_release1 + postalveolar, new Symbol("ᶴ", "", "", "^S"), 0);
        //public static readonly Consonant S_release2 = new Consonant(S_release1, new Symbol("ᶴ", "", "", "S)"), 0);
        public static readonly Consonant S_release3 = new Consonant(S_release1, new Symbol("ᶴ", "", "", "^|S"), 0);

        public static readonly Consonant Z_release1 = new Consonant(S_release1 + releaseFricativeVoiced + voiced, new Symbol("ᶾ", "", "", "^Z"), 0);
        //public static readonly Consonant Z_release2 = new Consonant(Z_release1, new Symbol("ᶾ", "", "", "Z)"), 0);
        public static readonly Consonant Z_release3 = new Consonant(Z_release1, new Symbol("ᶾ", "", "", "^|Z"), 0);

        public static readonly Consonant ś_release1 = new Consonant(s_release1 + alveopalatal, new Symbol("ᶝ", "", "", @"^s\"), 0);
        //public static readonly Consonant ś_release2 = new Consonant(ś_release1, new Symbol("ᶝ", "", "", @"s\)"), 0);
        public static readonly Consonant ś_release3 = new Consonant(ś_release1, new Symbol("ᶝ", "", "", "^C"));
        public static readonly Consonant ś_release4 = new Consonant(ś_release1, new Symbol("ᶝ", "", "", "^|C"));

        public static readonly Consonant ź_release1 = new Consonant(ś_release1 + releaseFricativeVoiced + voiced, new Symbol("ᶽ", "", "", @"^z\"), 0);
        //public static readonly Consonant ź_release2 = new Consonant(ź_release1, new Symbol("ᶽ", "", "", @"z\)"), 0);
        public static readonly Consonant ź_release3 = new Consonant(ź_release1, new Symbol("ᶽ", "", "", @"^j\"), 0);
        public static readonly Consonant ź_release4 = new Consonant(ź_release1, new Symbol("ᶽ", "", "", @"^|j\"), 0);

                
        public static readonly Consonant x_release = new Consonant(s_release1 + velar, new Symbol("ˣ", "", "", @"^x"), 0);
        public static readonly Consonant ɣ_release1 = new Consonant(z_release1 + velar, new Symbol("ˠ", "", "", @"^G"), 0);
        public static readonly Consonant ɣ_release2 = new Consonant(z_release1 + velar, new Symbol("ˠ", "", "", @"^|G"), 0);

        public static readonly Consonant h_release1 = new Consonant(s_release1 + glottal + releaseVoiceless, new Symbol("ʰ", "", "", @"^h"), 0);
        public static readonly Consonant h_release2 = new Consonant(h_release1, new Symbol("ʰ", "", "", @"h)"), 0);

        public static readonly Consonant h_voiced_release1 = new Consonant(h_release1 + releaseVoiced + voiced, new Symbol("ʱ", "", "", @"^h\"), 0);
        public static readonly Consonant h_voiced_release2 = new Consonant(h_voiced_release1, new Symbol("ʱ", "", "", @"h\)"), 0);



        public static readonly Consonant y_release = new Consonant(h_voiced_release1, new Symbol("ʸ", "", "", @"^y"), 0);
        public static readonly Consonant a_release = new Consonant(h_voiced_release1, new Symbol("ᵃ", "", "", @"^a"), 0);
        public static readonly Consonant U_release1 = new Consonant(h_voiced_release1, new Symbol("ᶷ", "", "", @"^U"), 0);
        public static readonly Consonant U_release2 = new Consonant(h_voiced_release1, new Symbol("ᶷ", "", "", @"^|U"), 0);
        public static readonly Consonant u_release = new Consonant(h_voiced_release1, new Symbol("ᵘ", "", "", @"^u"), 0);
        public static readonly Consonant A_release1 = new Consonant(h_voiced_release1, new Symbol("ᵅ", "", "", @"^A"), 0);
        public static readonly Consonant A_release2 = new Consonant(h_voiced_release1, new Symbol("ᵅ", "", "", @"^|A"), 0);
        public static readonly Consonant e_release = new Consonant(h_voiced_release1, new Symbol("ᵉ", "", "", @"^e"), 0);
        public static readonly Consonant o_release = new Consonant(h_voiced_release1, new Symbol("ᵒ", "", "", @"^o"), 0);
        public static readonly Consonant V_release1 = new Consonant(h_voiced_release1, new Symbol("ᶺ", "", "", @"^V"), 0);
        public static readonly Consonant V_release2 = new Consonant(h_voiced_release1, new Symbol("ᶺ", "", "", @"^|V"), 0);
        public static readonly Consonant E_release1 = new Consonant(h_voiced_release1, new Symbol("ᵋ", "", "", @"^E"), 0);
        public static readonly Consonant E_release2 = new Consonant(h_voiced_release1, new Symbol("ᵋ", "", "", @"^|E"), 0);

        public static readonly Consonant O_release1 = new Consonant(h_voiced_release1, new Symbol("ᵓ", "", "", @"^O"), 0);
        public static readonly Consonant O_release2 = new Consonant(h_voiced_release1, new Symbol("ᵓ", "", "", @"^|O"), 0);
        public static readonly Consonant Q_release1 = new Consonant(h_voiced_release1, new Symbol("ᶛ", "", "", @"^Q"), 0);
        public static readonly Consonant Q_release2 = new Consonant(h_voiced_release1, new Symbol("ᶛ", "", "", @"^|Q"), 0);

        public static readonly Consonant ɐ1_release1 = new Consonant(h_voiced_release1, new Symbol("ᵄ", "", "", @"^6"), 0);
        public static readonly Consonant ɐ1_release2 = new Consonant(h_voiced_release1, new Symbol("ᵄ", "", "", @"^|6"), 0);

        public static readonly Consonant ə_release = new Consonant(h_voiced_release1, new Symbol("ᵊ", "", "", @"^@"), 0);

        public static readonly Consonant ɨ_release1 = new Consonant(h_voiced_release1, new Symbol("ᶤ", "", "", @"^1"), 0);
        public static readonly Consonant ɨ_release2 = new Consonant(h_voiced_release1, new Symbol("ᶤ", "", "", @"^|1"), 0);

        public static readonly Consonant ɜ_release1 = new Consonant(h_voiced_release1, new Symbol("ᵌ", "", "", @"^3"), 0);
        public static readonly Consonant ɜ_release2 = new Consonant(h_voiced_release1, new Symbol("ᵌ", "", "", @"^|3"), 0);

        public static readonly Consonant ʉ_release1 = new Consonant(h_voiced_release1, new Symbol("ᶶ", "", "", @"^}"), 0);
        public static readonly Consonant ʉ_release2 = new Consonant(h_voiced_release1, new Symbol("ᶶ", "", "", @"^u\"), 0);

        public static readonly Consonant ɵ_release1 = new Consonant(h_voiced_release1, new Symbol("ᶱ", "", "", @"^8"), 0);
        public static readonly Consonant ɵ_release2 = new Consonant(h_voiced_release1, new Symbol("ᶱ", "", "", @"^|8"), 0);





        //public static readonly Vowel y_release = new Vowel(y + releaseVowel, new Symbol("ʸ", "", "", @"^y"), -1);
        //public static readonly Vowel a_release = new Vowel(a + releaseVowel, new Symbol("ᵃ", "", "", @"^a"), -1);
        //public static readonly Vowel U_release1 = new Vowel(u + releaseVowel + nearBack + nearClose, new Symbol("ᶷ", "", "", @"^U"), -1);
        //public static readonly Vowel U_release2 = new Vowel(u + releaseVowel + nearBack + nearClose, new Symbol("ᶷ", "", "", @"^|U"), -1);
        //public static readonly Vowel u_release = new Vowel(u + releaseVowel, new Symbol("ᵘ", "", "", @"^u"), -1);
        //public static readonly Vowel A_release1 = new Vowel(A1 + releaseVowel, new Symbol("ᵅ", "", "", @"^A"), -1);
        //public static readonly Vowel A_release2 = new Vowel(A1 + releaseVowel, new Symbol("ᵅ", "", "", @"^|A"), -1);
        //public static readonly Vowel e_release = new Vowel(e + releaseVowel, new Symbol("ᵉ", "", "", @"^e"), -1);
        //public static readonly Vowel o_release = new Vowel(o + releaseVowel, new Symbol("ᵒ", "", "", @"^o"), -1);
        //public static readonly Vowel V_release1 = new Vowel(V1 + releaseVowel, new Symbol("ᶺ", "", "", @"^V"), -1);
        //public static readonly Vowel V_release2 = new Vowel(V1 + releaseVowel, new Symbol("ᶺ", "", "", @"^|V"), -1);
        //public static readonly Vowel E_release1 = new Vowel(E1 + releaseVowel, new Symbol("ᵋ", "", "", @"^E"), -1);
        //public static readonly Vowel E_release2 = new Vowel(E1 + releaseVowel, new Symbol("ᵋ", "", "", @"^|E"), -1);

        //public static readonly Vowel O_release1 = new Vowel(O1 + releaseVowel, new Symbol("ᵓ", "", "", @"^O"), -1);
        //public static readonly Vowel O_release2 = new Vowel(O1 + releaseVowel, new Symbol("ᵓ", "", "", @"^|O"), -1);
        //public static readonly Vowel Q_release1 = new Vowel(Q1 + releaseVowel, new Symbol("ᶛ", "", "", @"^Q"), -1);
        //public static readonly Vowel Q_release2 = new Vowel(Q1 + releaseVowel, new Symbol("ᶛ", "", "", @"^|Q"), -1);

        //public static readonly Vowel ɐ1_release1 = new Vowel(ɐ1 + releaseVowel, new Symbol("ᵄ", "", "", @"^6"), -1);
        //public static readonly Vowel ɐ1_release2 = new Vowel(ɐ1 + releaseVowel, new Symbol("ᵄ", "", "", @"^|6"), -1);

        //public static readonly Vowel ə_release = new Vowel(ə + releaseVowel, new Symbol("ᵊ", "", "", @"^@"), -1);

        //public static readonly Vowel ɨ_release1 = new Vowel(ɨ1 + releaseVowel, new Symbol("ᶤ", "", "", @"^1"), -1);
        //public static readonly Vowel ɨ_release2 = new Vowel(ɨ1 + releaseVowel, new Symbol("ᶤ", "", "", @"^|1"), -1);

        //public static readonly Vowel ɜ_release1 = new Vowel(ɜ1 + releaseVowel, new Symbol("ᵌ", "", "", @"^3"), -1);
        //public static readonly Vowel ɜ_release2 = new Vowel(ɜ1 + releaseVowel, new Symbol("ᵌ", "", "", @"^|3"), -1);

        //public static readonly Vowel ʉ_release1 = new Vowel(ʉ1 + releaseVowel, new Symbol("ᶶ", "", "", @"^}"), -1);
        //public static readonly Vowel ʉ_release2 = new Vowel(ʉ1 + releaseVowel, new Symbol("ᶶ", "", "", @"^u\"), -1);

        //public static readonly Vowel ɵ_release1 = new Vowel(ɵ1 + releaseVowel, new Symbol("ᶱ", "", "", @"^8"), -1);
        //public static readonly Vowel ɵ_release2 = new Vowel(ɵ1 + releaseVowel, new Symbol("ᶱ", "", "", @"^|8"), -1);



        #endregion

        #region: Vowel features

        public static readonly Vowel front = new Vowel(Frontness.front);
        public static readonly Vowel nearFront = new Vowel(Frontness.nearFront);
        public static readonly Vowel central = new Vowel(Frontness.central);
        public static readonly Vowel nearBack = new Vowel(Frontness.nearBack);
        public static readonly Vowel back = new Vowel(Frontness.back);

        public static readonly Vowel close = new Vowel(Height.close);
        public static readonly Vowel nearClose = new Vowel(Height.nearClose);
        public static readonly Vowel closeMid = new Vowel(Height.closeMid);
        public static readonly Vowel mid = new Vowel(Height.mid);
        public static readonly Vowel midOpen = new Vowel(Height.openMid);
        public static readonly Vowel nearOpen = new Vowel(Height.nearOpen);
        public static readonly Vowel open = new Vowel(Height.open);
        
        #endregion

        #region: Symbols

        #region: Consonants

        #region: Stops


        public readonly static Consonant p1 = new Consonant(PlaceOfArticulation.bilabial, MannerOfArticulation.stop, Phonation.voiceless, Nasality.oral,
            new Symbol("p", "p", "p", "p"), Roundness.unrounded);



        //public static readonly Consonant p2 = new Consonant(p1, new Symbol("p", "p", "p", "p^h"));
        public readonly static Consonant b1 = new Consonant((Consonant)p1 + voiced, new Symbol("b", "b", "b", "b"));
        //public static readonly Consonant b2 = new Consonant(b1, new Symbol("b", "b", "b", @"b^h\"));

        public static readonly Consonant t1 = new Consonant((Consonant)p1 + alveolar, new Symbol("t", "t", "t", "t"));
        //public static readonly Consonant t2 = new Consonant(p1 + alveolar, new Symbol("t", "t", "t", "t^h"));
        public static readonly Consonant d1 = new Consonant(t1 + voiced, new Symbol("d", "d", "d", "d"));
        //public static readonly Consonant d2 = new Consonant(t1 + voiced, new Symbol("d", "d", "d", @"d^h\"));

        public static readonly Consonant ti = new Consonant(t1 + alveopalatal, new Symbol("ȶ", "t'", "t'", @"t\"));
        public static readonly Consonant di = new Consonant(d1 + alveopalatal, new Symbol("ȡ", "d'", "d'", @"d\"));

        public static readonly Consonant c1 = new Consonant(t1 + palatal, new Symbol("c", "*", "*", "c"));
        //public static readonly Consonant c2 = new Consonant(t1 + palatal, new Symbol("c", "*", "*", "c^h"));
        public static readonly Consonant ɟ1 = new Consonant(c1 + voiced, new Symbol("ɟ", "*", "*", @"J\"));
        //public static readonly Consonant ɟ2 = new Consonant(c1 + voiced, new Symbol("ɟ", "*", "*", @"J\^h\"));
        public static readonly Consonant ɟ3 = new Consonant(c1 + voiced, new Symbol("ɟ", "*", "*", @"|J\"));


        public static readonly Consonant k1 = new Consonant(t1 + velar, new Symbol("k", "k", "k", "k"));
        //public static readonly Consonant k2 = new Consonant(t1 + velar, new Symbol("k", "k", "k", "k^h"));
        public static readonly Consonant g1 = new Consonant(k1 + voiced, new Symbol("ɡ", "g", "g", "g"));
        //public static readonly Consonant g2 = new Consonant(k1 + voiced, new Symbol("ɡ", "g", "g", @"g^h\"));

        public static readonly Consonant q1 = new Consonant(k1 + uvular, new Symbol("q", "*", "*", "q"));
        //public static readonly Consonant q2 = new Consonant(k1 + uvular, new Symbol("q", "*", "*", "q^h"));
        public static readonly Consonant ɢ1 = new Consonant(q1 + voiced, new Symbol("ɢ", "*", "*", @"G\"));
        //public static readonly Consonant ɢ2 = new Consonant(q1 + voiced, new Symbol("ɢ", "*", "*", @"G\^h\"));
        public static readonly Consonant ɢ3 = new Consonant(q1 + voiced, new Symbol("ɢ", "*", "*", @"|G\"));


        public static readonly Consonant ʔ = new Consonant(PlaceOfArticulation.glottal, MannerOfArticulation.stop, null, null,
            new Symbol("ʔ", "*", "*", @"?"), Roundness.unrounded);

        #endregion

        #region: Nasals

        public static readonly Consonant m = new Consonant(b1 + nasal, new Symbol("m"));
        public static readonly Consonant n = new Consonant(m + alveolar, new Symbol("n"));
        public static readonly Consonant ń = new Consonant(n + alveopalatal, new Symbol("ȵ", "ń", "ń", @"n\"));

        public static readonly Consonant F = new Consonant(m + labiodental, new Symbol("ɱ", "", "", "F"));

        public static readonly Consonant ɲ1 = new Consonant(n + palatal, new Symbol("ɲ", "*", "*", "J"));
        public static readonly Consonant ɲ2 = new Consonant(n + palatal, new Symbol("ɲ", "*", "*", "|J"));

        public static readonly Consonant ŋ1 = new Consonant(n + velar, new Symbol("ŋ", "ŋ", "N", "N"));
        public static readonly Consonant ŋ2 = new Consonant(n + velar, new Symbol("ŋ", "ŋ", "N", "|N"));

        public static readonly Consonant ɴ1 = new Consonant(n + uvular, new Symbol("ɴ", "*", "*", @"N\"));
        public static readonly Consonant ɴ2 = new Consonant(n + uvular, new Symbol("ɴ", "*", "*", @"|N\"));

        #endregion

        #region: Trills and flaps

        public static readonly Consonant r = new Consonant(d1 + trill, new Symbol("r"));
        public static readonly Consonant r_0 = new Consonant(r + voiceless, new Symbol("r" + "\u0325", "r" + "\u0326", "r", "r_0"));
        public static readonly Consonant R1 = new Consonant(r + uvular, new Symbol("ʀ", "R", "R", @"R\"));
        public static readonly Consonant R2 = new Consonant(r + uvular, new Symbol("ʀ", "R", "R", @"|R\"));
        public static readonly Consonant ř = new Consonant(r + fricativeTrill, new Symbol("r̝", "ř", "rz", "r_r"));

        public static readonly Consonant B1 = new Consonant(r + bilabial, new Symbol("ʙ", "", "", @"B\"));
        public static readonly Consonant B2 = new Consonant(r + bilabial, new Symbol("ʙ", "", "", @"|B\"));

        public static readonly Consonant _4_1 = new Consonant(r + flap, new Symbol("ɾ", "", "", "4"));
        public static readonly Consonant _4_2 = new Consonant(r + flap, new Symbol("ɾ", "", "", "|4"));

        #endregion

        #region: Fricatives

        public static readonly Consonant f = new Consonant((Consonant)p1 + fricative + labiodental, new Symbol("f"));
        public static readonly Consonant v = new Consonant(f + voiced, new Symbol("v", "v", "w", "v"));

        public static readonly Consonant ɸ = new Consonant(f + bilabial, new Symbol("ɸ", "", "", @"p\"));
        public static readonly Consonant β = new Consonant(v + bilabial, new Symbol("β", "", "", @"B"));

        public static readonly Consonant s = new Consonant(f + alveolar, new Symbol("s"));
        public static readonly Consonant z = new Consonant(s + voiced, new Symbol("z"));

        public static readonly Consonant S1 = new Consonant(s + postalveolar, new Symbol("ʃ", "š", "sz", "S"));
        public static readonly Consonant S2 = new Consonant(s + postalveolar, new Symbol("ʃ", "š", "sz", "|S"));
        public static readonly Consonant Z1 = new Consonant(S1 + voiced, new Symbol("ʒ", "ž", "ż", "Z"));
        public static readonly Consonant Z2 = new Consonant(S1 + voiced, new Symbol("ʒ", "ž", "ż", "|Z"));

        public static readonly Consonant ś = new Consonant(s + alveopalatal, new Symbol("ɕ", "ś", "ś", @"s\"));
        public static readonly Consonant ź = new Consonant(ś + voiced, new Symbol("ʑ", "ź", "ź", @"z\"));

        public static readonly Consonant C1 = new Consonant(s + palatal, new Symbol("ç", "*", "*", "C"));
        public static readonly Consonant C2 = new Consonant(s + palatal, new Symbol("ç", "*", "*", "|C"));
        public static readonly Consonant ʝ = new Consonant(z + palatal, new Symbol("ʝ", "*", "*", @"j\"));

        public static readonly Consonant x = new Consonant(s + velar, new Symbol("x", "χ", "ch", "x"));
        public static readonly Consonant ɣ1 = new Consonant(z + velar, new Symbol("ɣ", "γ", "h", "G"));
        public static readonly Consonant ɣ2 = new Consonant(z + velar, new Symbol("ɣ", "γ", "h", "|G"));

        public static readonly Consonant X1 = new Consonant(s + uvular, new Symbol("χ", "*", "*", @"X"));
        public static readonly Consonant X2 = new Consonant(s + uvular, new Symbol("χ", "*", "*", @"|X"));
        public static readonly Consonant ʁ1 = new Consonant(z + uvular, new Symbol("ʁ", "*", "*", "R"));
        public static readonly Consonant ʁ2 = new Consonant(z + uvular, new Symbol("ʁ", "*", "*", "|R"));

        public static readonly Consonant h = new Consonant(s + glottal, new Symbol("h", "*", "*", "h"));
        public static readonly Consonant ɦ = new Consonant(z + glottal, new Symbol("ɦ", "*", "*", @"h\"));

        #endregion

        #region: Approximants

        public static readonly Consonant j = new Consonant(ʝ + semivowel, new Symbol("j", "i̯", "j", "j"));
        public static readonly Consonant w1 = new Consonant(j + rounded1 + velar, new Symbol("w", "u̯", "ł", "w"));
        public static readonly Consonant w2 = new Consonant(w1, new Symbol("w", "u̯", "ł", "u_^"));

        public static readonly Consonant P1 = new Consonant(ʝ + labiodental, new Symbol("ʋ", "", "", "P"));
        public static readonly Consonant P2 = new Consonant(ʝ + labiodental, new Symbol("ʋ", "", "", @"v\"));

        public static readonly Consonant l = new Consonant(r + lateral, new Symbol("l"));
        public static readonly Consonant li = new Consonant(l + alveopalatal, new Symbol("ȴ", "l'", "l'", @"l\"));
        public static readonly Consonant L1 = new Consonant(l + palatal, new Symbol("ʎ", "l'", "l'", @"L"));
        public static readonly Consonant L2 = new Consonant(l + palatal, new Symbol("ʎ", "l'", "l'", @"|L"));

        public static readonly Consonant ɹ = new Consonant(r + semivowel, new Symbol("ɹ", "", "", @"r\"));

        #endregion

        #region: Affricates

        public static readonly Consonant ts1 = new Consonant(s + affricate, new Symbol("t͡s", "c", "c", "ts)"));
        public static readonly Consonant ts2 = new Consonant(s + affricate, new Symbol("t͡s", "c", "c", "t^s"));
        public static readonly Consonant dz1 = new Consonant(ts1 + voiced, new Symbol("d͡z", "ʒ", "dz", "dz)"));
        public static readonly Consonant dz2 = new Consonant(ts1 + voiced, new Symbol("d͡z", "ʒ", "dz", "d^z"));

        public static readonly Consonant tS1 = new Consonant(ts1 + postalveolar, new Symbol("t͡ʃ", "č", "cz", "tS)"));
        public static readonly Consonant tS2 = new Consonant(ts1 + postalveolar, new Symbol("t͡ʃ", "č", "cz", "t^S"));
        public static readonly Consonant dZ1 = new Consonant(dz1 + postalveolar, new Symbol("d͡ʒ", "ǯ", "dż", "dZ)"));
        public static readonly Consonant dZ2 = new Consonant(dz1 + postalveolar, new Symbol("d͡ʒ", "ǯ", "dż", "d^Z"));

        public static readonly Consonant tś1 = new Consonant(ts1 + alveopalatal, new Symbol("t͡ɕ", "ć", "ć", @"ts\)"));
        public static readonly Consonant tś2 = new Consonant(ts1 + alveopalatal, new Symbol("t͡ɕ", "ć", "ć", @"t^s\"));
        public static readonly Consonant dź1 = new Consonant(dz1 + alveopalatal, new Symbol("d͡ʑ", "ʒ́", "dź", @"dz\)"));
        public static readonly Consonant dź2 = new Consonant(dz1 + alveopalatal, new Symbol("d͡ʑ", "ʒ́", "dź", @"d^z\"));

        #endregion

        #endregion

        #region: Vowels

        public static readonly Vowel i = new Vowel(Frontness.front, Height.close, Nasality.oral, new Symbol("i"), Roundness.unrounded, Phonation.voiced, Rhoticity.nonRhotic, MannerOfArticulation.vowel);
        public static readonly Vowel y = new Vowel(i + rounded1, new Symbol("y", "*", "*", "y"));

        public static readonly Vowel I1 = new Vowel(i + nearClose + nearFront, new Symbol("ɪ", "", "", "I"));
        public static readonly Vowel I2 = new Vowel(i + nearClose + nearFront, new Symbol("ɪ", "", "", "|I"));

        public static readonly Vowel ɨ1 = new Vowel(i + central, new Symbol("ɨ", "y", "y", "1"));
        public static readonly Vowel ɨ2 = new Vowel(i + central, new Symbol("ɨ", "y", "y", "|1"));
        public static readonly Vowel ɨ3 = new Vowel(i + central, new Symbol("ɨ", "y", "y", @"i\"));
        public static readonly Vowel ʉ1 = new Vowel(ɨ1 + rounded1, new Symbol("ʉ", "*", "*", "}"));
        public static readonly Vowel ʉ2 = new Vowel(ɨ1 + rounded1, new Symbol("ʉ", "*", "*", @"u\"));

        public static readonly Vowel M1 = new Vowel(i + back, new Symbol("ɯ", "*", "*", "M"));
        public static readonly Vowel M2 = new Vowel(i + back, new Symbol("ɯ", "*", "*", "|M"));
        public static readonly Vowel u = new Vowel(M1 + rounded1, new Symbol("u"));


        public static readonly Vowel e = new Vowel(i + closeMid, new Symbol("e", "ė", "*", "e"));
        public static readonly Vowel ø1 = new Vowel(e + rounded1, new Symbol("ø", "*", "*", "2"));
        public static readonly Vowel ø2 = new Vowel(e + rounded1, new Symbol("ø", "*", "*", "|2"));

        public static readonly Vowel ɘ = new Vowel(e + central, new Symbol("ɘ", "*", "*", @"@\"));
        public static readonly Vowel ɵ1 = new Vowel(ɘ + rounded1, new Symbol("ɵ", "*", "*", "8"));
        public static readonly Vowel ɵ2 = new Vowel(ɘ + rounded1, new Symbol("ɵ", "*", "*", "|8"));

        public static readonly Vowel ɤ1 = new Vowel(e + back, new Symbol("ɤ", "*", "*", "7"));
        public static readonly Vowel ɤ2 = new Vowel(e + back, new Symbol("ɤ", "*", "*", "|7"));
        public static readonly Vowel o = new Vowel(ɤ1 + rounded1, new Symbol("o", "*", "*", "o"));


        public static readonly Vowel ə = new Vowel(e + mid + central, new Symbol("ə", "*", "*", @"@"));


        public static readonly Vowel E1 = new Vowel(e + midOpen, new Symbol("ɛ", "e", "e", "E"));
        public static readonly Vowel E2 = new Vowel(e + midOpen, new Symbol("ɛ", "e", "e", "|E"));
        public static readonly Vowel œ1 = new Vowel(E1 + rounded1, new Symbol("œ", "*", "*", "9"));
        public static readonly Vowel œ2 = new Vowel(E1 + rounded1, new Symbol("œ", "*", "*", "|9"));

        public static readonly Vowel ę = new Vowel(E1 + nasal, new Symbol("ɛ˜", "e˜", "ę", "E~"));

        public static readonly Vowel ɜ1 = new Vowel(E1 + central, new Symbol("ɜ", "*", "*", "3"));
        public static readonly Vowel ɜ2 = new Vowel(E1 + central, new Symbol("ɜ", "*", "*", "|3"));
        public static readonly Vowel ɞ1 = new Vowel(ɜ1 + rounded1, new Symbol("ɞ", "*", "*", @"3\"));
        public static readonly Vowel ɞ2 = new Vowel(ɜ1 + rounded1, new Symbol("ɞ", "*", "*", @"|3\"));

        public static readonly Vowel V1 = new Vowel(ɤ1 + midOpen, new Symbol("ʌ", "*", "*", "V"));
        public static readonly Vowel V2 = new Vowel(ɤ1 + midOpen, new Symbol("ʌ", "*", "*", "|V"));
        public static readonly Vowel O1 = new Vowel(V1 + rounded1, new Symbol("ɔ", "o", "o", "O"));
        public static readonly Vowel O2 = new Vowel(V1 + rounded1, new Symbol("ɔ", "o", "o", "|O"));

        public static readonly Vowel ǫ = new Vowel(O1 + nasal, new Symbol("ɔ˜", "o˜", "ą", "O~"));

        public static readonly Vowel æ1 = new Vowel(E1 + nearOpen, new Symbol("æ", "*", "*", "{"));
        public static readonly Vowel æ2 = new Vowel(E1 + nearOpen, new Symbol("æ", "*", "*", "&"));
        public static readonly Vowel ɐ1 = new Vowel(E1 + nearOpen + central, new Symbol("ɐ", "*", "*", "6"));
        public static readonly Vowel ɐ2 = new Vowel(E1 + nearOpen + central, new Symbol("ɐ", "*", "*", "|6"));

        public static readonly Vowel a = new Vowel(E1 + open, new Symbol("a", "*", "*", "a"));
        public static readonly Vowel ɶ1 = new Vowel(a + rounded1, new Symbol("ɶ", "*", "*", "&"));
        public static readonly Vowel ɶ2 = new Vowel(a + rounded1, new Symbol("ɶ", "*", "*", @"&\"));
        public static readonly Vowel a_central = new Vowel(a + central, new Symbol("a", "a", "a", "a"));
        public static readonly Vowel A1 = new Vowel(a + back, new Symbol("ɑ", "*", "*", "A"));
        public static readonly Vowel A2 = new Vowel(a + back, new Symbol("ɑ", "*", "*", "|A"));
        public static readonly Vowel Q1 = new Vowel(A1 + rounded1, new Symbol("ɒ", "*", "*", "Q"));
        public static readonly Vowel Q2 = new Vowel(A1 + rounded1, new Symbol("ɒ", "*", "*", "|Q"));

        #endregion

        #region: Other

        public static readonly Juncture juncture1 = new Juncture("#");
        public static readonly Juncture juncture2 = new Juncture(" ");

        public static readonly Pause pause1 = new Pause("(.)", "|", "|", "(.)");
        public static readonly Pause pause2 = new Pause("(..)", "|", "|", "(..)");
        public static readonly Pause pause3 = new Pause("(...)", "||", "||", "(...)");

        public static readonly UnknownPhone unknownPhone1 = new UnknownPhone("(_)");
        public static readonly UnknownPhone unknownPhone2 = new UnknownPhone("(())");
        public static readonly UnknownPhone unknownPhone3 = new UnknownPhone("((_))");
        public static readonly UnknownPhone unknownPhone4 = new UnknownPhone("*");

        public static readonly NullPhone nullPhone = new NullPhone("");

        public static readonly UnknownPhoneDelimiter unknownPhoneDelimiter1a = new UnknownPhoneDelimiter("(");
        public static readonly UnknownPhoneDelimiter unknownPhoneDelimiter1b = new UnknownPhoneDelimiter(")");
        public static readonly UnknownPhoneDelimiter unknownPhoneDelimiter2a = new UnknownPhoneDelimiter("(/");
        public static readonly UnknownPhoneDelimiter unknownPhoneDelimiter2b = new UnknownPhoneDelimiter("/)");
        public static readonly UnknownPhoneDelimiter unknownPhoneDelimiter3 = new UnknownPhoneDelimiter("/");


        #endregion

        #endregion






        static PhonePrototypes()
        {


























        }





    }
}
