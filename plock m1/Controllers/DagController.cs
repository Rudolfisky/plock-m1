using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using plock_m1.Models;

namespace plock_m1.Controllers
{
    public class DagController : Controller
    {
        DagCollection _dagCollection = new DagCollection();
       
        public IActionResult DagList()
        {
            IEnumerable<Dag> dagen = _dagCollection.GetAllDagen();
            return View(dagen);
        }
        public IActionResult DagDetails(int ID)
        {
            Dag dag = _dagCollection.GetDagById(ID);
            Console.WriteLine("iets");
            //DagModel dagModel = new DagModel()
            //{
            //    Date = dag.Date,
            //    Naam = dag.Naam,
            //    DagType = dag.DagType,
            //    BeginTijd = dag.BeginTijd,
            //    EindTijd = dag.EindTijd,
            //    Beschrijving = dag.Beschrijving
            //};
            return View(dag);
        }
        public IActionResult CreateDag()
        {
            return View();
        }
        public IActionResult EditDag(int id)
        {
            Dag dag = _dagCollection.GetDagById(id);
            DagModel newDagModel = new DagModel
            {
                ID = dag.ID,
                Date = dag.Date,
                Naam = dag.Naam,
                DagType = dag.DagType,
                BeginTijd = dag.BeginTijd,
                EindTijd = dag.EindTijd,
                Beschrijving = dag.Beschrijving
            };
            ViewBag.dID = dag.ID;
            return View(newDagModel);
        }
        [HttpPost]
        public IActionResult CreateDag(DagModel newDagModel)
        {
            if (newDagModel.DagType=="event")
            {
                Dag newDag = new Dag
                {
                    UserID = 1,
                    Date = newDagModel.Date,
                    Naam = newDagModel.Naam,
                    DagType = newDagModel.DagType,
                    BeginTijd = newDagModel.BeginTijd,
                    EindTijd = newDagModel.EindTijd,
                    Beschrijving = newDagModel.Beschrijving

                };
                _dagCollection.CreateDag(newDag);
            }
            else
            {
                Dag newDag = new Dag
                {
                    UserID = 1,
                    Date = newDagModel.Date,
                    DagType = newDagModel.DagType,
                    BeginTijd = newDagModel.BeginTijd,
                    EindTijd = newDagModel.EindTijd

                };
                _dagCollection.CreateDag(newDag);
            }

            
            return RedirectToAction("DagList", "Dag"); 
        }
        [HttpPost]
        public IActionResult EditDag(DagModel newDagModel)
        {
            if (newDagModel.DagType == "event")
            {
                Dag newDag = new Dag
                {
                    ID = newDagModel.ID,
                    Date = newDagModel.Date,
                    Naam = newDagModel.Naam,
                    DagType = newDagModel.DagType,
                    BeginTijd = newDagModel.BeginTijd,
                    EindTijd = newDagModel.EindTijd,
                    Beschrijving = newDagModel.Beschrijving
                };
                //_dagCollection.EditDag(newDag);
                newDag.EditDag();
            }
            else
            {
                Dag newDag = new Dag
                {
                    ID = newDagModel.ID,
                    Date = newDagModel.Date,
                    DagType = newDagModel.DagType,
                    BeginTijd = newDagModel.BeginTijd,
                    EindTijd = newDagModel.EindTijd

                };
                //_dagCollection.EditDag(newDag);
                newDag.EditDag();
            }
            return RedirectToAction("DagList", "Dag");
        }
        public IActionResult DagDelete(int ID) 
        {
            Dag dag = _dagCollection.GetDagById(ID);
            return View(dag);
        }
        [HttpPost]
        public IActionResult DagDelete(Dag dag)
        {
            _dagCollection.DagDelete(dag.ID);
            return RedirectToAction("DagList", "Dag");
        }
    }
}
