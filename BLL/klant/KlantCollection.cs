using System;
using System.Collections.Generic;
using System.Text;
using CL;
using FL;

namespace BLL
{
    public class KlantCollection
    {
        IKlantCollectionDAL _klantCollectionDAL = FactoryKlantDAL.CreateKlantCollectionDAL();
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
    }
}
