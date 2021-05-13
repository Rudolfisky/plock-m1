using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;

namespace plock_m1.Controllers
{
    public class KlantController : Controller
    {
        KlantCollection _klantCollection = new KlantCollection();
        DagCollection _dagCollection = new DagCollection();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult KlantList()
        {
            IEnumerable<Klant> klanten = _klantCollection.GetAllKlanten();
            return View(klanten);
        }
        //public IActionResult KlantListDag(int dagID)
        //{
        //    IEnumerable<Klant> klanten = _klantCollection.GetKlantenByDag(dagID);
        //    return View(klanten);
        //}
        public IActionResult KlantenByDag(int dagID)
        {
            Dag dag = _dagCollection.GetDagById(dagID);
            if (dag.Naam != null)
            {
                ViewBag.DagNaam = dag.Naam + " - ";
            }
            string date = dag.Date.Day + "-" + dag.Date.Month + "-" + dag.Date.Year;
            ViewBag.DagDate = date;

            IEnumerable<Klant> klanten = _klantCollection.GetKlantenByDag(dagID);
            return View(klanten);
        }
    }
}
