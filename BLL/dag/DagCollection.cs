using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CL;
using FL;

namespace BLL
{
    public class DagCollection
    {
        IDagCollectionDAL _dagCollectionDAL = FactoryDagDAL.CreateDagCollectionDAL();
        public IEnumerable<Dag> GetAllDagen()
        {
            //List <Klant> klanten = new List<Klant>();
            IEnumerable<DagDTO> dagenDTO = _dagCollectionDAL.GetAllDagen();
            List<Dag> dagen = new List<Dag>();
            foreach (var dagDTO in dagenDTO)
            {
                Dag _dag = new Dag(dagDTO);
                dagen.Add(_dag);
            }

            return dagen;
        }
        public Dag GetDagById(int ID)
        {
            DagDTO dagDTO = _dagCollectionDAL.GetDagById(ID).FirstOrDefault();
            Dag dag = new Dag(dagDTO);
            return dag;
        }
        public void CreateDag(Dag newDag)
        {
            DagDTO newDagDTO = new DagDTO
            {
                UserID = newDag.UserID,
                Date = newDag.Date,
                Naam = newDag.Naam,
                DagType = newDag.DagType,
                BeginTijd = newDag.BeginTijd,
                EindTijd = newDag.EindTijd,
                Beschrijving = newDag.Beschrijving
            };
            _dagCollectionDAL.CreateDag(newDagDTO);
        }
        public void EditDag(Dag editedDag) 
        {
            DagDTO editedDagDTO = new DagDTO
            {
                dagID = editedDag.ID,
                Date = editedDag.Date,
                Naam = editedDag.Naam,
                DagType = editedDag.DagType,
                BeginTijd = editedDag.BeginTijd,
                EindTijd = editedDag.EindTijd,
                Beschrijving = editedDag.Beschrijving
            };
            _dagCollectionDAL.UpdateDag(editedDagDTO);
        }
        public void DagDelete(int ID) 
        {
            _dagCollectionDAL.DagDelete(ID);
        }
    }
}
