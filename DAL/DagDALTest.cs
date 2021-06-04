using System;
using System.Collections.Generic;
using System.Text;
using CL;
using SQLAccess;
using Dapper;

namespace DAL
{
    public class DagDALTest : IDagDAL, IDagCollectionDAL
    {
        public void CreateDag(DagDTO dagDTO)
        {
            throw new NotImplementedException();
        }

        public void DagDelete(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DagDTO> GetAllDagen()
        {
            List<DagDTO> dagDTOs = new List<DagDTO>();
            DagDTO dagDTOA = new DagDTO {
                dagID = 1,
                UserID = 2
            };
            dagDTOs.Add(dagDTOA);
            return dagDTOs;
        }

        public IEnumerable<DagDTO> GetDagById(int ID)
        {
            throw new NotImplementedException();
        }

        public void UpdateDag(DagDTO dagDTO)
        {
            throw new NotImplementedException();
        }
    }
}
