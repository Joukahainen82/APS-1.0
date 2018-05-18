using APS_1.Phonetics;
using APS_1.Phonetics.Enums;
using APS_1.Symbols.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_1.Symbols
{
    public class Diacritic : Phone
    {
        #region Properties

        public DiacriticPlace ModificationDirection { get; set; }

        public Nullable<Stress> Stress { get; set; }
        public Nullable<Palatalization> Palatalization { get; set; }

        #endregion


        #region Constructors

        public Diacritic(Phone phone, int diacriticImpact = 0)
        {
            this.Context = phone.Context;
            this.Example = phone.Example;
            this.Length = phone.Length;
            this.Nasality = phone.Nasality;
            this.Phonation = phone.Phonation;
            this.Speaker = phone.Speaker;
            this.Symbol = phone.Symbol;

            this.DiacriticImpact = diacriticImpact;
        }

        public Diacritic(Consonant phone, int diacriticImpact = 0)
        {
            this.Palatalization = phone.Palatalization;

            this.Context = phone.Context;
            this.Example = phone.Example;
            this.Length = phone.Length;
            this.Nasality = phone.Nasality;
            this.Phonation = phone.Phonation;
            this.Speaker = phone.Speaker;
            this.Symbol = phone.Symbol;

            this.DiacriticImpact = diacriticImpact;
        }

        public Diacritic(Vowel phone, int diacriticImpact = 0)
        {
            this.Stress = phone.Stress;

            this.Context = phone.Context;
            this.Example = phone.Example;
            this.Length = phone.Length;
            this.Nasality = phone.Nasality;
            this.Phonation = phone.Phonation;
            this.Speaker = phone.Speaker;
            this.Symbol = phone.Symbol;

            this.DiacriticImpact = diacriticImpact;
        }

        #endregion

        #region Operator overloads

        public static Consonant operator +(Consonant cons, Diacritic phone)
        {
            return new Consonant()
            {
                Nasality = phone.Nasality == null ? cons.Nasality : phone.Nasality,
                Phonation = phone.Phonation == null ? cons.Phonation : phone.Phonation,

                MannerOfArticulation = phone.MannerOfArticulation == null ? cons.MannerOfArticulation : phone.MannerOfArticulation,
                Palatalization = phone.Palatalization == null ? cons.Palatalization : phone.Palatalization,

                PlaceOfArticulation = cons.PlaceOfArticulation,
                Roundness = cons.Roundness,
                Retroflex = cons.Retroflex,

                Context = phone.Context == null ? cons.Context : phone.Context,
                Example = phone.Example == null ? cons.Example : phone.Example,
                Speaker = phone.Speaker == null ? cons.Speaker : phone.Speaker,
                Length = phone.Length == null ? cons.Length : phone.Length,

                DiacriticImpact = cons.DiacriticImpact,

            };
        }


        public static Vowel operator +(Vowel v, Diacritic p)
        {
            return new Vowel()
            {
                MannerOfArticulation = p.MannerOfArticulation == null ? v.MannerOfArticulation : p.MannerOfArticulation,

                Stress = p.Stress == null ? v.Stress : p.Stress,

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


        #endregion






    }
}
