using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CL;
using FL;

namespace BLL
{
    public class KlantCollection
    {
        IKlantCollectionDAL _klantCollectionDAL;

        public KlantCollection()
        {
            _klantCollectionDAL = FactoryKlantDAL.CreateKlantCollectionDAL();
        }
        public KlantCollection(IKlantCollectionDAL klantCollectionDAL)
        {
            _klantCollectionDAL = klantCollectionDAL;
        }
        public IEnumerable<Klant> GetAllKlanten()
        {
            //List <Klant> klanten = new List<Klant>();
            IEnumerable<KlantDTO> klantenDTO = _klantCollectionDAL.GetAllKlanten();
            List<Klant> klanten = new List<Klant>();
            foreach (var klantDTO in klantenDTO)
            {
                Klant _klant = new Klant(klantDTO);
                klanten.Add(_klant);
            }

            return klanten;
        }
        public Klant GetKlantById(int ID)
        {
            KlantDTO klantDTO = _klantCollectionDAL.GetKlantById(ID).FirstOrDefault();
            Klant klant = new Klant(klantDTO);
            return klant;
        }
        public Klant GetKlantDagById(int ID) 
        {
            KlantDTO klantDTO = _klantCollectionDAL.GetKlantById(ID).FirstOrDefault();
            Klant klant = new Klant(klantDTO);
            return klant;
        }
        public void CreateKlant(Klant newKlant)
        {
            KlantDTO newKlantDTO = new KlantDTO
            {
                Voornaam = newKlant.Voornaam,
                Tussenvoegsel = newKlant.Tussenvoegsel,
                Achternaam = newKlant.Achternaam,
                TelNR = newKlant.TelNR,
                Postcode = newKlant.Postcode,
                StraatNaam = newKlant.StraatNaam,
                HuisNR = newKlant.HuisNR,
                Mail = newKlant.Mail,
                DOB = newKlant.DOB
            };
            _klantCollectionDAL.CreateKlant(newKlantDTO);
        }
        public IEnumerable<Klant> GetKlantenByDag(int dagID)
        {
            //List <Klant> klanten = new List<Klant>();
            IEnumerable<KlantDTO> klantenDTO = _klantCollectionDAL.GetKlantenByDag(dagID);
            List<Klant> klanten = new List<Klant>();
            foreach (var klantDTO in klantenDTO)
            {
                Klant _klant = new Klant(klantDTO);
                klanten.Add(_klant);
            }
            if (klanten.Count == 1)
            {
                if (klanten[0].ID == 0)
                {
                    klanten = new List<Klant>();
                }
                
            }
            return klanten;
        }
        public IEnumerable<Klant> GetNotKlantenByDag(int dagID)
        {
            //List <Klant> klanten = new List<Klant>();
            IEnumerable<KlantDTO> klantenInDagDTO = _klantCollectionDAL.GetKlantenByDag(dagID);
            List<Klant> klantenInDag = new List<Klant>();

            foreach (var klantInDagDTO in klantenInDagDTO)
            {
                Klant _klant = new Klant(klantInDagDTO);
                klantenInDag.Add(_klant);
            }
            if (klantenInDag.Count == 1)
            {
                if (klantenInDag[0].ID == 0)
                {
                    klantenInDag = new List<Klant>();
                }

            }

            IEnumerable<KlantDTO> klantenAllDTO = _klantCollectionDAL.GetAllKlanten();
            List<Klant> klantenAll = new List<Klant>();
            foreach (var klantAllDTO in klantenAllDTO)
            {
                Klant _klant = new Klant(klantAllDTO);
                klantenAll.Add(_klant);
            }
            if (klantenAll.Count == 1)
            {
                if (klantenAll[0].ID == 0)
                {
                    klantenAll = new List<Klant>();
                }

            }


            return SeperateKlanten(klantenAll, klantenInDag);
        }
        private List<Klant> SeperateKlanten(List<Klant>  klantenAll, List<Klant> klantenInDag) 
        {
            List<Klant> klanten = new List<Klant>();
            foreach (var klantAll in klantenAll)
            {
                bool existsInDag = false;
                foreach (var klantInDag in klantenInDag)
                {
                    if (klantAll.ID == klantInDag.ID)
                    {
                        existsInDag = true;
                    }
                }
                if (!existsInDag)
                {
                    klanten.Add(klantAll);
                }
            }
            return klanten;
        }
        public void addKlantToDag(int klantID, int dagID, DateTime aankomst, DateTime vertrek) 
        {
            _klantCollectionDAL.AddKlantToDag(klantID, dagID, aankomst, vertrek);
        }
        public void RemoveKlantFromDag(int klantID, int dagID)
        {
            _klantCollectionDAL.RemoveKlantFromDag(klantID, dagID);
        }

    }
}
