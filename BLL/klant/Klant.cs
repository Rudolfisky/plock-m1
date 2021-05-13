using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CL;

namespace BLL
{
    public class Klant
    {
        public int ID { get; }
        public string Voornaam { get; set; }
        public string Tussenvoegsel { get; set; }
        public string Achternaam { get; set; }
        public int TelNR { get; set; }
        public string Postcode { get; set; }
        public string HuisNR { get; set; }
        public string Mail { get; set; }
        public DateTime DOB { get; set; }
        public DateTime Aankomst { get; set; }
        public DateTime Vertrek { get; set; }
        public Klant() 
        { 
        
        }
        public Klant(KlantDTO klantDTO) 
        {
            ID = klantDTO.PersoonInfoID;
            Voornaam = klantDTO.Voornaam;
            Tussenvoegsel = klantDTO.Tussenvoegsel;
            Achternaam = klantDTO.Achternaam;
            TelNR = klantDTO.TelNR;
            Postcode = klantDTO.Postcode;
            HuisNR = klantDTO.HuisNR;
            Mail = klantDTO.Mail;
            DOB = klantDTO.DOB;
            Aankomst = klantDTO.Aankomst;
            Vertrek = klantDTO.Vertrek;
        }
        //public Klant(int aID, string aVNaam, string aTVoegsel, string aANaam, int aTelNR, string aPostcode, string aHuisNR, string aMail, string aDOB)
        //{
        //    ID = aID;
        //    Voornaam = aVNaam;
        //    Tussenvoegsel = aTVoegsel;
        //    Achternaam = aANaam;
        //    TelNR = aTelNR;
        //    Postcode = aPostcode;
        //    HuisNR = aHuisNR;
        //    Mail = aMail;
        //    DOB = aDOB;
        //}
    }
}
