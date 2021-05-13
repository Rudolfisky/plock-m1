using System;
using System.Collections.Generic;
using System.Text;

namespace CL
{
    public interface IDagCollectionDAL
    {
        IEnumerable<DagDTO> GetAllDagen();
        public IEnumerable<DagDTO> GetDagById(int ID);
        void CreateDag(DagDTO dagDTO);
        void UpdateDag(DagDTO dagDTO);
    }
}
