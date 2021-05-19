using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CL;
using FL;

namespace BLL
{
    public class Klant
    {
        IKlantDAL _klantDAL = FactoryKlantDAL.CreateKlantDAL();
        public int ID { get; set; }
        public string Voornaam { get; set; }
        public string Tussenvoegsel { get; set; }
        public string Achternaam { get; set; }
        public int TelNR { get; set; }
        public string Postcode { get; set; }
        public string StraatNaam { get; set; }
        public string HuisNR { get; set; }
        public string Mail { get; set; }
        public DateTime DOB { get; set; }
        public DateTime Aankomst { get; set; }
        public DateTime Vertrek { get; set; }
        public bool IsAddedToDag { get; set; }
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
            StraatNaam = klantDTO.StraatNaam;
            HuisNR = klantDTO.HuisNR;
            Mail = klantDTO.Mail;
            DOB = klantDTO.DOB;
            Aankomst = klantDTO.Aankomst;
            Vertrek = klantDTO.Vertrek;
        }
        public void KlantUpdate()
        {
            KlantDTO updatedKlantDTO = new KlantDTO
            {
                PersoonInfoID = this.ID,
                Voornaam = this.Voornaam,
                Tussenvoegsel = this.Tussenvoegsel,
                Achternaam = this.Achternaam,
                TelNR = this.TelNR,
                Postcode = this.Postcode,
                StraatNaam = this.StraatNaam,
                HuisNR = this.HuisNR,
                Mail = this.Mail,
                DOB = this.DOB
            };
            _klantDAL.KlantUpdate(updatedKlantDTO);
        }
        public void KlantDagUpdate() 
        {
            KlantDTO updatedKlantDTO = new KlantDTO
            {
                PersoonInfoID = this.ID,
                Aankomst = this.Aankomst,
                Vertrek = this.Vertrek
            };
            _klantDAL.KlantDagUpdate(updatedKlantDTO);
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
