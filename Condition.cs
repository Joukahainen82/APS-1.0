using APS_1.ApsManager.Enums;
using APS_1.Phonetics;
using APS_1.Phonetics.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_1.ApsManager
{
    public class Condition
    {

        #region Properties

        public OldPolishVowels OldPolishVowel { get; set; }


        public ContextType ContextType { get; set; }



        public ExcerptNo ExcerptNo { get; set; }


        #region Demographic features

        public Age Age { get; set; }

        public Education Education { get; set; }

        public PlaceType PlaceType { get; set; }

        public DwellingTime DwellingTime { get; set; }
        public ParentsOrigin ParentOrigin { get; set; }

        #endregion 

        public MorphCategory MorphCategory { get; set; }

        #endregion 


        #region Constructors

        

        //public Condition(Nullable<OldPolishVowels> oldPolishVowel = null, Nullable<ContextType> contextType = null, Nullable<ExcerptNo> excerptNo = null, Nullable<Age> age = null, Nullable<Education> education = null, Nullable<PlaceType> placeType = null, Nullable<DwellingTime> dwellingTime = null, Nullable<ParentsOrigin> parentOrigin = null)
        //{
        //    this.OldPolishVowel = oldPolishVowel.HasValue ? oldPolishVowel.Value : OldPolishVowels.allVowels;
        //    this.ContextType = contextType.HasValue ? contextType.Value : Phonetics.Enums.ContextType.unspecified;

        //    this.ExcerptNo = excerptNo.HasValue ? excerptNo.Value : ExcerptNo.bothExcerpts;

        //    this.Age = age.HasValue ? age.Value : Age.noInformation;
        //    this.Education = education.HasValue ? education.Value : Education.noInformation;
        //    this.PlaceType = placeType.HasValue ? placeType.Value : PlaceType.noInformation;
        //    this.DwellingTime = dwellingTime.HasValue ? dwellingTime.Value : DwellingTime.noInformation;
        //    this.ParentOrigin = parentOrigin.HasValue ? parentOrigin.Value : ParentsOrigin.noInformation;

        //}


        public Condition(Nullable<OldPolishVowels> oldPolishVowel = null, Nullable<ContextType> contextType = null,             
            Nullable<ExcerptNo> excerptNo = null, Nullable<Age> age = null, Nullable<Education> education = null, Nullable<PlaceType> placeType = null, Nullable<DwellingTime> dwellingTime = null, Nullable<ParentsOrigin> parentOrigin = null, Nullable<MorphCategory> morphCategory = null)
        {
            this.OldPolishVowel = oldPolishVowel.HasValue ? oldPolishVowel.Value : OldPolishVowels.allVowels;
            this.ContextType = contextType.HasValue ? contextType.Value : Phonetics.Enums.ContextType.unspecified;

            this.MorphCategory = morphCategory.HasValue ? morphCategory.Value : MorphCategory.inne;

            this.ExcerptNo = excerptNo.HasValue ? excerptNo.Value : ExcerptNo.bothExcerpts;

            this.Age = age.HasValue ? age.Value : Age.noInformation;
            this.Education = education.HasValue ? education.Value : Education.noInformation;
            this.PlaceType = placeType.HasValue ? placeType.Value : PlaceType.noInformation;
            this.DwellingTime = dwellingTime.HasValue ? dwellingTime.Value : DwellingTime.noInformation;
            this.ParentOrigin = parentOrigin.HasValue ? parentOrigin.Value : ParentsOrigin.noInformation;

        }






        #endregion



        #region: Operators


        public static Condition operator+(Condition c1, Condition c2)
        {
            var res = new Condition();

            res.Age = c2.Age != Age.noInformation ? c2.Age : c1.Age;
            res.ContextType = c2.ContextType != ContextType.unspecified ? c2.ContextType : c1.ContextType;
            res.DwellingTime = c2.DwellingTime != DwellingTime.noInformation ? c2.DwellingTime : c1.DwellingTime;
            res.Education = c2.Education != Education.noInformation ? c2.Education : c1.Education;
            res.ExcerptNo = c2.ExcerptNo != ExcerptNo.bothExcerpts ? c2.ExcerptNo : c1.ExcerptNo;
            res.MorphCategory = c2.MorphCategory != MorphCategory.inne ? c2.MorphCategory : c1.MorphCategory;
            res.OldPolishVowel = c2.OldPolishVowel;
            res.ParentOrigin = c2.ParentOrigin != ParentsOrigin.noInformation ? c2.ParentOrigin : c1.ParentOrigin;
            res.PlaceType = c2.PlaceType != PlaceType.noInformation ? c2.PlaceType : c1.PlaceType; 
            
            return res; 
        }



        #endregion



    }
}
