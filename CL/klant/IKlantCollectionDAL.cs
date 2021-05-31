using System;
using System.Collections.Generic;
using System.Text;

namespace CL
{
    public interface IKlantCollectionDAL
    {
        void CreateKlant(KlantDTO klantDTO) { }
        void Delete(KlantDTO klantDTO);
        IEnumerable<KlantDTO> GetAllKlanten();
        IEnumerable<KlantDTO> GetKlantById(int ID);
        IEnumerable<KlantDTO> GetKlantDagById(int ID);
        IEnumerable<KlantDTO> GetKlantenByDag(int dagID);
        IEnumerable<KlantDTO> GetNotKlantenByDag(int dagID);
        void AddKlantToDag(int klantID, int dagID, DateTime aankomst, DateTime vertrek);
        void RemoveKlantFromDag(int KlantID, int DagID);
    }
}
