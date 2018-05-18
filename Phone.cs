using APS_1.ApsManager;
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
    public class Phone
    {

        #region: Properties


        public Reading Reading { get; set; }


        public int PhoneNo { get; set; }

        public Nullable<SpeakerType> SpeakerType { get; set; }

        public Speaker Speaker { get; set; }

        public Symbol Symbol { get; set; }

        public Nullable<Phonation> Phonation { get; set; }

        public PhoneContext Context { get; set; }

        public Example Example { get; set; }

        public Nullable<Nasality> Nasality { get; set; }

        public Nullable<Length> Length { get; set; }

        public Nullable<Roundness> Roundness { get; set; }

        public Nullable<MannerOfArticulation> MannerOfArticulation { get; set; }

        public Nullable<Rhoticity> Retroflex { get; set;} 

        //public Nullable<DiacriticPlace> IfDiacritic { get; set; }

                

        /// <summary>
        /// Liczba symboli, na które oddziałuje symbol przypisany temu fonowi. Dla symboli literowych wynosi 0, dla diakrytów jest ujemny (jeśli diakryt odnosi się do symboli poprzedzajacych) lub dodatni (jeśli do następujących).
        /// </summary>
        public int DiacriticImpact { get; set; }

        #endregion

        #region: Constructors

        public Phone(Symbol symbol = null, int diacriticImpact = 0)
        {
            this.Speaker = null;
            this.Phonation = null;
            this.Context = null;
            this.Example = null;
            this.Length = null;

            this.DiacriticImpact = diacriticImpact;
            this.Symbol = symbol;
        }

        public Phone(Roundness roundness, Symbol symbol = null, int diacriticImpact = 0)
        {
            this.DiacriticImpact = diacriticImpact;
            this.Symbol = symbol;
            this.Roundness = roundness;
            
            this.Length = null;
            this.Example = null;
            this.Nasality = null;
            this.Context = null;
            this.Speaker = null;
            this.Phonation = null;             
        }

        public Phone (Rhoticity rhoticity, Symbol symbol = null, int diacriticImpact = 0)
        {
            this.Retroflex = rhoticity;
            this.Symbol = symbol;
            this.DiacriticImpact = diacriticImpact;
        }

        public Phone(Phone phone, Symbol symbol = null, int diacriticImpact = 0)
        {
            this.Speaker = phone.Speaker;
            this.Phonation = phone.Phonation;
            this.Nasality = phone.Nasality;
            this.Length = phone.Length;
            this.Example = phone.Example;
            this.Context = phone.Context;
            this.MannerOfArticulation = phone.MannerOfArticulation;

            this.DiacriticImpact = diacriticImpact;

            this.Symbol = symbol == null ? phone.Symbol : symbol;
        }

        public Phone(Phonation phonation, Symbol symbol = null, int diacriticImpact = 0)
        {
            this.Phonation = phonation;
            this.Symbol = symbol;

            this.DiacriticImpact = diacriticImpact;
        }

        public Phone(Nasality nasality, Symbol symbol = null, int diacriticImpact = 0)
        {
            this.Nasality = nasality;
            this.Symbol = symbol;

            this.DiacriticImpact = diacriticImpact;
        }

        public Phone(Length length, Symbol symbol = null, int diacriticImpact = 0)
        {
            this.Length = length;
            this.Symbol = symbol;

            this.DiacriticImpact = diacriticImpact;
        }

        public Phone(string text, int diacriticImpact = 0)
        {
            this.Symbol = new Symbol(text);

            this.DiacriticImpact = diacriticImpact;
        }

        public Phone(MannerOfArticulation mannerOfArticulation, Symbol symbol, int diacriticImpact = 0)
        {
            this.MannerOfArticulation = mannerOfArticulation;
            this.Symbol = symbol;
            this.DiacriticImpact = diacriticImpact;
        }

        public Phone(Nullable<Roundness> roundness, Nullable<Phonation> phonation, Nullable<Nasality> nasality, Nullable<Length> length, Symbol symbol)
        {
            this.Length = length;
            this.Nasality = nasality;
            this.Phonation = phonation;
            this.Roundness = roundness;
            this.Symbol = symbol;
        }



        #endregion

        #region: Operator overloads

        public static Consonant operator +(Consonant cons, Phone phone)
        {
            return new Consonant()
            {
                Nasality = phone.Nasality == null ? cons.Nasality : phone.Nasality,
                Phonation = phone.Phonation == null ? cons.Phonation : phone.Phonation,

                MannerOfArticulation = phone.MannerOfArticulation == null ? cons.MannerOfArticulation : phone.MannerOfArticulation,
                Roundness = phone.Roundness == null ? cons.Roundness : phone.Roundness,

                PlaceOfArticulation = cons.PlaceOfArticulation,
                Palatalization = cons.Palatalization,
                Retroflex = cons.Retroflex,

                Context = phone.Context == null ? cons.Context : phone.Context,
                Example = phone.Example == null ? cons.Example : phone.Example,
                Speaker = phone.Speaker == null ? cons.Speaker : phone.Speaker,
                Length = phone.Length == null ? cons.Length : phone.Length,

                DiacriticImpact = cons.DiacriticImpact,
                
            };
        }


        public static Vowel operator +(Vowel v, Phone p)
        {
            return new Vowel()
            {
                MannerOfArticulation = p.MannerOfArticulation == null ? v.MannerOfArticulation : p.MannerOfArticulation,                
                
                Stress = v.Stress, 

                Frontness = v.Frontness,
                Height = v.Height,
                Rhoticity = v.Rhoticity,
                Frequency = v.Frequency,
                AvgFrequency = v.AvgFrequency,
                Retroflex = v.Retroflex, 
                Symbol = v.Symbol, 

                Roundness = p.Roundness == null ? v.Roundness : p.Roundness,
                Nasality = p.Nasality == null ? v.Nasality : p.Nasality,
                Phonation = p.Phonation == null ? v.Phonation : p.Phonation,                

                Speaker = p.Speaker == null ? v.Speaker : p.Speaker,
                Length = p.Length == null ? v.Length : p.Length,
                Context = p.Context == null ? v.Context : p.Context,
                Example = p.Example == null ? v.Example : p.Example,

                DiacriticImpact = v.DiacriticImpact,
                

            };
        }


        //public static Phone operator +(Phone p1, Phone p2)
        //{
        //    //return new Phone(p1 + p2);


        //    if (p1 is Consonant)
        //    {
        //        var res = new Consonant((Consonant)p1, new Symbol());
        //        res += p2;
        //        return res;
        //    }
        //    else if (p1 is Vowel)
        //    {
        //        var res = new Vowel((Vowel)p1, new Symbol());
        //        res += p2;
        //        return res;
        //    }
        //    else if (p1 is Juncture)
        //    {
        //        var res = new Juncture();
        //        res += p2;
        //        return res;
        //    }
        //    else
        //    {
        //        return new Phone(p1 + p2);
        //    }


        //}

        #endregion


        /// <summary>
        /// Sprawdza, czy dwa fony są identyczne (czy wszystkie ich cechy są takie same).
        /// </summary>
        /// <param name="phone">Porównywany fon.</param>
        /// <returns>"True", jeśli oba fony są identyczne.</returns>
        public virtual bool Equals(Phone phone)
        {
            var c1 = phone.Length == this.Length;
            var c2 = phone.MannerOfArticulation == this.MannerOfArticulation;
            var c3 = phone.Nasality == this.Nasality;
            var c4 = phone.Phonation == this.Phonation;
            var c5 = phone.Retroflex == this.Retroflex;
            var c6 = phone.Roundness == this.Roundness;

            return c1 && c2 && c3 && c4 && c5 && c6;
        }

        


    }


    public class Vowel : Phone
    {

        #region: Properties

        public Frequency Frequency { get; set; }

        public Frequency AvgFrequency { get; set; }

        public Nullable<Frontness> Frontness { get; set; }

        public Nullable<Height> Height { get; set; }

        public Nullable<Rhoticity> Rhoticity { get; set; }

        public Nullable<Stress> Stress { get; set; }

        #endregion

        #region: Constructors

        public Vowel() : base()
        {
            this.MannerOfArticulation = Enums.MannerOfArticulation.vowel;
            this.Frontness = null;
            this.Height = null;
            this.Roundness = null;
            this.Rhoticity = null;
        }

        public Vowel(Frontness frontness) : base() { this.Frontness = frontness; this.MannerOfArticulation = Enums.MannerOfArticulation.vowel; }

        public Vowel(Height height) : base() { this.Height = height; this.MannerOfArticulation = Enums.MannerOfArticulation.vowel; }

        public Vowel(Nasality nasality) : base() { this.Nasality = nasality; this.MannerOfArticulation = Enums.MannerOfArticulation.vowel; }

        public Vowel(Roundness roundness) : base() { this.Roundness = roundness; this.MannerOfArticulation = Enums.MannerOfArticulation.vowel; }

        public Vowel(MannerOfArticulation mannerOfArticulation, Symbol symbol = null)
        {
            this.MannerOfArticulation = mannerOfArticulation;
            this.Symbol = symbol;
        }

        public Vowel(Vowel vowel, Symbol symbol, int diacriticImpact = 0)
        {
            this.MannerOfArticulation = vowel.MannerOfArticulation;

            this.AvgFrequency = vowel.AvgFrequency;
            this.Context = vowel.Context;
            this.Example = vowel.Example;
            this.Frequency = vowel.Frequency;
            this.Frontness = vowel.Frontness;
            this.Height = vowel.Height;
            this.DiacriticImpact = diacriticImpact != 0 ? diacriticImpact : vowel.DiacriticImpact;
            this.Length = vowel.Length;
            this.Nasality = vowel.Nasality;
            this.Phonation = vowel.Phonation;
            this.Rhoticity = vowel.Rhoticity;
            this.Roundness = vowel.Roundness;
            this.Speaker = vowel.Speaker;
            this.Stress = vowel.Stress;

            this.Symbol = symbol;
        }

        public Vowel(Stress stress, Symbol symbol = null, int diacriticImpact = 0) : base(symbol, diacriticImpact) 
        {
            this.MannerOfArticulation = Enums.MannerOfArticulation.vowel;
            this.Stress = stress;
        }

        public Vowel(string symbol) : base(symbol)
        {
            this.MannerOfArticulation = Enums.MannerOfArticulation.vowel;

            this.Frontness = null;
            this.Height = null;
            this.Roundness = null;
            this.Rhoticity = null;
        }

        public Vowel(Frontness frontness, Height height, Nasality nasality, Symbol symbol, Roundness roundness, Phonation phonation = Phonetics.Phonation.voiced, Rhoticity rhoticity = Phonetics.Rhoticity.nonRhotic, MannerOfArticulation mannerOfArticulation = Enums.MannerOfArticulation.vowel)
            : base()
        {
            this.MannerOfArticulation = mannerOfArticulation;

            this.Frontness = frontness;
            this.Height = height;
            this.Nasality = nasality;
            this.Phonation = phonation;
            this.Rhoticity = rhoticity;
            this.Roundness = roundness;
            this.Symbol = symbol;
        }

        #endregion

        #region: Operator overloads

        public static Vowel operator +(Vowel v1, Vowel v2)
        {
            return new Vowel()
            {
                Frontness = v2.Frontness == null ? v1.Frontness : v2.Frontness,
                Height = v2.Height == null ? v1.Height : v2.Height,
                Nasality = v2.Nasality == null ? v1.Nasality : v2.Nasality,
                Roundness = v2.Roundness == null ? v1.Roundness : v2.Roundness,
                Rhoticity = v2.Rhoticity == null ? v1.Rhoticity : v2.Rhoticity,

                Stress = v2.Stress == null ? v1.Stress : v2.Stress, 
                MannerOfArticulation = v2.MannerOfArticulation == null ? v1.MannerOfArticulation : v2.MannerOfArticulation, 
                Retroflex = v2.Retroflex == null ? v1.Retroflex : v2.Retroflex, 

                AvgFrequency = v2.AvgFrequency == null ? v1.AvgFrequency : v2.AvgFrequency,
                Context = v2.Context == null ? v1.Context : v2.Context,
                Example = v2.Example == null ? v1.Example : v2.Example,
                Frequency = v2.Frequency == null ? v1.Frequency : v2.Frequency,
                Length = v2.Length == null ? v1.Length : v2.Length,
                Phonation = v2.Phonation == null ? v1.Phonation : v2.Phonation,
                Speaker = v2.Speaker == null ? v1.Speaker : v2.Speaker,

                DiacriticImpact = v1.DiacriticImpact,

                Symbol = v1.Symbol
            };
        }

        public static Vowel operator +(Consonant c, Vowel v)
        {
            return new Vowel()
            {
                Frontness = v.Frontness, 
                Height = v.Height, 
                Nasality = v.Nasality == null ? c.Nasality : v.Nasality, 
                Roundness = v.Roundness == null ? c.Roundness : v.Roundness, 
                Rhoticity = v.Rhoticity,

                Stress = v.Stress,
                Retroflex = v.Retroflex == null ? c.Retroflex : v.Retroflex,

                AvgFrequency = v.AvgFrequency,
                Context = v.Context == null ? c.Context : v.Context,
                Example = v.Example == null ? c.Example : v.Example,
                Frequency = v.Frequency,
                Length = v.Length == null ? c.Length : v.Length,
                Phonation = v.Phonation == null ? c.Phonation : v.Phonation,
                Speaker = v.Speaker == null ? c.Speaker : v.Speaker,

                DiacriticImpact = c.DiacriticImpact,

                Symbol = c.Symbol
            };
        }

        public static Vowel operator +(Phone p, Vowel v)
        {
            return new Vowel()
            {
                Frontness = v.Frontness,
                Height = v.Height,
                Nasality = v.Nasality == null ? p.Nasality : v.Nasality,
                Roundness = v.Roundness == null ? p.Roundness : v.Roundness,
                Rhoticity = v.Rhoticity,

                Stress = v.Stress,
                Retroflex = v.Retroflex == null ? p.Retroflex : v.Retroflex,

                AvgFrequency = v.AvgFrequency,
                Context = v.Context == null ? p.Context : v.Context,
                Example = v.Example == null ? p.Example : v.Example,
                Frequency = v.Frequency,
                Length = v.Length == null ? p.Length : v.Length,
                Phonation = v.Phonation == null ? p.Phonation : v.Phonation,
                Speaker = v.Speaker == null ? p.Speaker : v.Speaker,

                DiacriticImpact = p.DiacriticImpact,

                Symbol = p.Symbol
            };
        }

        #endregion


        /// <summary>
        /// Sprawdza, czy dwa fony są identyczne (czy wszystkie ich cechy są takie same).
        /// </summary>
        /// <param name="phone">Porównywany fon.</param>
        /// <returns>"True", jeśli oba fony są identyczne.</returns>
        public override bool Equals(Phone phone)
        {
            var c1 = phone.Length == this.Length;
            var c2 = phone.MannerOfArticulation == this.MannerOfArticulation;
            var c3 = phone.Nasality == this.Nasality;
            var c4 = phone.Phonation == this.Phonation;
            var c5 = phone.Retroflex == this.Retroflex;
            var c6 = phone.Roundness == this.Roundness;

            var c7 = phone.GetType() == typeof(Vowel) ? ((Vowel)phone).Frontness == this.Frontness : true;
            var c8 = phone.GetType() == typeof(Vowel) ? ((Vowel)phone).Height == this.Height : true;
            var c9 = phone.GetType() == typeof(Vowel) ? ((Vowel)phone).Rhoticity == this.Rhoticity : true;
            var c10 = phone.GetType() == typeof(Vowel) ? ((Vowel)phone).Stress == this.Stress : true;
            
            return c1 && c2 && c3 && c4 && c5 && c6 && c7 && c8 && c9 && c10;
        }


    }

    public class Consonant : Phone
    {

        #region: Properties

        public Nullable<PlaceOfArticulation> PlaceOfArticulation { get; set; }

        public Nullable<Palatalization> Palatalization { get; set; }

        #endregion

        #region: Constructors

        public Consonant(Consonant phone, Symbol symbol, int diacriticImpact = 0) : base(symbol, diacriticImpact)
        {
            this.Context = phone.Context;
            this.Example = phone.Example;            
            this.Length = phone.Length;
            this.MannerOfArticulation = phone.MannerOfArticulation;
            this.Nasality = phone.Nasality;
            this.Palatalization = phone.Palatalization;
            this.Phonation = phone.Phonation;
            this.PlaceOfArticulation = phone.PlaceOfArticulation;
            this.Roundness = phone.Roundness;
            this.Speaker = phone.Speaker;            

            this.Symbol = symbol;
        }

        public Consonant(Symbol symbol = null, int diacriticImpact = 0) : base(symbol, diacriticImpact)
        {
            this.Nasality = null;
            this.Roundness = null;
            this.PlaceOfArticulation = null;
            this.MannerOfArticulation = null;
            this.Palatalization = null;
        }

        public Consonant(PlaceOfArticulation placeOfArticulation, Symbol symbol = null, int diacriticImpact = 0) : base(symbol, diacriticImpact) { this.PlaceOfArticulation = placeOfArticulation; }

        public Consonant(MannerOfArticulation mannerOfArticulation, Symbol symbol = null, int diacriticImpact = 0) : base(symbol, diacriticImpact) { this.MannerOfArticulation = mannerOfArticulation; }

        public Consonant(Roundness roundness, Symbol symbol = null, int diacriticImpact = 0) : base(symbol, diacriticImpact) { this.Roundness = roundness; }

        public Consonant(Palatalization palatalization, Symbol symbol = null, int diacriticImpact = 0) : base(symbol, diacriticImpact) { this.Palatalization = palatalization; }

        public Consonant(
            PlaceOfArticulation placeOfArticulation, 
            MannerOfArticulation mannerOfArticulation, 
            Nullable<Phonation> phonation, 
            Nullable<Nasality> nasality, 
            Symbol symbol, 
            Roundness roundness = Phonetics.Roundness.unrounded,
            int diacriticImpact = 0)
            : base(symbol, diacriticImpact)
        {
            this.Symbol = symbol;
            this.Roundness = roundness;
            this.PlaceOfArticulation = placeOfArticulation;
            this.Phonation = phonation;
            this.Nasality = nasality;
            this.MannerOfArticulation = mannerOfArticulation;
            this.DiacriticImpact = diacriticImpact;
        }

        #endregion

        #region: Operator overloads

        public static Consonant operator +(Consonant c1, Consonant c2)
        {
            return new Consonant()
            {
                Nasality = c2.Nasality == null ? c1.Nasality : c2.Nasality,
                Roundness = c2.Roundness == null ? c1.Roundness : c2.Roundness,
                PlaceOfArticulation = c2.PlaceOfArticulation == null ? c1.PlaceOfArticulation : c2.PlaceOfArticulation,
                MannerOfArticulation = c2.MannerOfArticulation == null ? c1.MannerOfArticulation : c2.MannerOfArticulation,
                Phonation = c2.Phonation == null ? c1.Phonation : c2.Phonation,
                Palatalization = c2.Palatalization == null ? c1.Palatalization : c2.Palatalization,

                Context = c2.Context == null ? c1.Context : c2.Context,
                Example = c2.Example == null ? c1.Example : c2.Example,
                Speaker = c2.Speaker == null ? c1.Speaker : c2.Speaker,
                Length = c2.Length == null ? c1.Length : c2.Length,

                DiacriticImpact = c1.DiacriticImpact,

                Symbol = c1.Symbol
            };
        }

        public static Consonant operator +(Vowel v, Consonant c)
        {
            return new Consonant()
            {
                Context = c.Context == null ? v.Context : c.Context,
                Example = c.Example == null ? v.Example : c.Example,
                Speaker = c.Speaker == null ? v.Speaker : c.Speaker,
                Length = c.Length == null ? v.Length : c.Length,

                DiacriticImpact = v.DiacriticImpact,

                MannerOfArticulation = c.MannerOfArticulation,
                Nasality = c.Nasality == null ? v.Nasality : c.Nasality,
                Palatalization = c.Palatalization,
                Phonation = c.Phonation == null ? v.Phonation : c.Phonation,
                PlaceOfArticulation = c.PlaceOfArticulation,
                Retroflex = c.Retroflex == null ? v.Retroflex : c.Retroflex,
                Roundness = c.Roundness == null ? v.Roundness : c.Roundness,
                Symbol = v.Symbol

            };
        }

        public static Consonant operator +(Phone p, Consonant c)
        {
            return new Consonant()
            {
                Context = c.Context == null ? p.Context : c.Context,
                Example = c.Example == null ? p.Example : c.Example,
                Speaker = c.Speaker == null ? p.Speaker : c.Speaker,
                Length = c.Length == null ? p.Length : c.Length,

                DiacriticImpact = p.DiacriticImpact,

                MannerOfArticulation = c.MannerOfArticulation,
                Nasality = c.Nasality == null ? p.Nasality : c.Nasality,
                Palatalization = c.Palatalization,
                Phonation = c.Phonation == null ? p.Phonation : c.Phonation,
                PlaceOfArticulation = c.PlaceOfArticulation,
                Retroflex = c.Retroflex == null ? p.Retroflex : c.Retroflex,
                Roundness = c.Roundness == null ? p.Roundness : c.Roundness,
                Symbol = p.Symbol

            };
        }

        #endregion


        /// <summary>
        /// Sprawdza, czy dwa fony są identyczne (czy wszystkie ich cechy są takie same).
        /// </summary>
        /// <param name="phone">Porównywany fon.</param>
        /// <returns>"True", jeśli oba fony są identyczne.</returns>
        public override bool Equals(Phone phone)
        {
            var c1 = phone.Length == this.Length;
            var c2 = phone.MannerOfArticulation == this.MannerOfArticulation;
            var c3 = phone.Nasality == this.Nasality;
            var c4 = phone.Phonation == this.Phonation;
            var c5 = phone.Retroflex == this.Retroflex;
            var c6 = phone.Roundness == this.Roundness;

            var c7 = phone.GetType() == typeof(Consonant) ? ((Consonant)phone).Palatalization == this.Palatalization : true;
            var c8 = phone.GetType() == typeof(Consonant) ? ((Consonant)phone).PlaceOfArticulation == this.PlaceOfArticulation : true;
            
            return c1 && c2 && c3 && c4 && c5 && c6 && c7 && c8;
        }

    }



    public class Juncture : Phone
    {
        public Juncture() : base() { }

        public Juncture(string symbol)
            : base()
        {
            this.Symbol = new Symbol(symbol);
        }

        public static Juncture operator + (Juncture j, Phone p)
        {
            return new Juncture()
            {
                Symbol = j.Symbol == null ? p.Symbol : j.Symbol
            };
        }

    }

    public class Pause : Phone
    {
        public Pause() : base() { }

        public Pause(string symbol)
            : base()
        {
            this.Symbol = new Symbol(symbol);
        }

        public Pause(string IpaSymbol, string SpaSymbol, string simplifiedSymbol, string SampaSymbol)
        {
            this.Symbol = new Symbol(IpaSymbol, SpaSymbol, simplifiedSymbol, SampaSymbol);
        }
    }

    public class UnknownPhone : Phone
    {
        public Phone PreviouslyRecognizedPhone { get; set; }

        public UnknownPhone()
            : base()
        {
            this.Symbol = new Symbol("");
        }

        public UnknownPhone(string symbol)
            : base()
        {
            this.Symbol = new Symbol(symbol);
        }


        public UnknownPhone(Symbol symbol)
        {
            this.Symbol = symbol;
        }


        public UnknownPhone(Phone phone)
        {
            this.PreviouslyRecognizedPhone = phone;
        }
    }



    public class NullPhone : Phone
    {
        public NullPhone(string symbol)
            : base()
        {
            this.Symbol = new Symbol(symbol);
        }
    }






}
