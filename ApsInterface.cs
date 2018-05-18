using APS_2.ApsManager.Enums;
using APS_2.Phonetics;
using APS_2.Phonetics.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_2.ApsManager
{
    /// <summary>
    /// Fasada gromadząca dane przy użyciu funkcji (metod). 
    /// </summary>
    public class ApsInterface
    {

        public static vIdent RozpoznanieSamogłoski(
            Phone odpowiednikStaropolski, 
            ContextType kontekst, 
            Education wykształcenie, 
            Age wiek, 
            PlaceType typMiejscowości, 
            DwellingTime okresZamieszkania, 
            ParentsOrigin pochodzenieRodziców, 
            Accented akcentowana, 
            RecPlace pozycjaWNagraniu
            )
        {
            throw new NotImplementedException(); 
        }


        public static ident MiejsceAkcentu(
            StressPlace pozycjaAkcentu)
        {
            throw new NotImplementedException(); 
        }


        public static ident Mazurzenie(
            MazurzenieType typMazurzenia)
        {
            throw new NotImplementedException(); 
        }


        public static ident CzwartaPalatalizacja()
        {
            throw new NotImplementedException(); 
        }



        public static ident iPoDawnymMiekkimR()
        {
            throw new NotImplementedException(); 
        }


        public static ident FonetykaMiędzywyrazowa(
            SandhiType typFonetykiMiędzywyrazowej)
        {
            throw new NotImplementedException(); 
        }


        public static ApplicationIdentity RozłożenieNosówki(NasalVowelContType typKontynuacji)
        {
            throw new NotImplementedException(); 
        }











    }
}
