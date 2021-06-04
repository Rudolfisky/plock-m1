using System;
using Dapper;
using System.Collections.Generic;
using System.Text;
using CL;
using SQLAccess;
using Dapper;

namespace DAL
{
    public class KlantDALTest : IKlantDAL, IKlantCollectionDAL
    {
        public void AddKlantToDag(int klantID, int dagID, DateTime aankomst, DateTime vertrek)
        {
            throw new NotImplementedException();
        }

        public void Delete(KlantDTO klantDTO)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KlantDTO> GetAllKlanten()
        {
            List<KlantDTO> klantDTOs = new List<KlantDTO>();

            for (int i = 0; i < 4; i++)
            {
                KlantDTO klantDTO = new KlantDTO
                {
                    PersoonInfoID = i
                };
                klantDTOs.Add(klantDTO);
            }

            return klantDTOs;
        }

        public IEnumerable<KlantDTO> GetKlantById(int ID)
        {
            List<KlantDTO> klantDTOs = new List<KlantDTO>();

            KlantDTO klantDTO = new KlantDTO 
            { 
            PersoonInfoID = 7
            };

            klantDTOs.Add(klantDTO);

            return klantDTOs;
        }

        public IEnumerable<KlantDTO> GetKlantDagById(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KlantDTO> GetKlantenByDag(int dagID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KlantDTO> GetNotKlantenByDag(int dagID)
        {
            throw new NotImplementedException();
        }

        public void RemoveKlantFromDag(int KlantID, int DagID)
        {
            throw new NotImplementedException();
        }
    }
}
