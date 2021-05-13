using System;
using System.Collections.Generic;
using System.Text;

namespace CL
{
    public interface IKlantCollectionDAL
    {
        void Create(KlantDTO klantDTO);
        void Delete(KlantDTO klantDTO);
        IEnumerable<KlantDTO> GetAllKlanten();
        IEnumerable<KlantDTO> GetKlantenByDag(int dagID);
    }
}
