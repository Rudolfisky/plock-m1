using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using plock_m1.Models;

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
        public IActionResult KlantenByDag(int ID)
        {
            Dag dag = _dagCollection.GetDagById(ID);
            if (dag.Naam != null)
            {
                ViewBag.DagNaam = dag.Naam + " | ";
            }
            string date = dag.Date.Day + "-" + dag.Date.Month + "-" + dag.Date.Year;
            ViewBag.DagDate = date;
            ViewBag.dagID = ID;

            IEnumerable<Klant> klanten = _klantCollection.GetKlantenByDag(ID);
            return View(klanten);
        }
        public IActionResult AddKlantToDagList(int ID) 
        {
            Dag dag = _dagCollection.GetDagById(ID);
            if (dag.Naam != null)
            {
                ViewBag.DagNaam = dag.Naam + " | ";
            }
            string date = dag.Date.Day + "-" + dag.Date.Month + "-" + dag.Date.Year;
            ViewBag.DagDate = date;

            //IEnumerable<Klant> klanten = _klantCollection.GetKlantenByDag(ID);
            IEnumerable<Klant> klanten = _klantCollection.GetNotKlantenByDag(ID);
            ViewBag.tempID = ID;
            return View(klanten);
        }
        public IActionResult CreateKlant()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateKlant(KlantModel klantModel)
        {
            Klant newKlant = new Klant
            {
                Voornaam = klantModel.Voornaam,
                Tussenvoegsel = klantModel.Tussenvoegsel,
                Achternaam = klantModel.Achternaam,
                TelNR = klantModel.TelNR,
                Postcode = klantModel.Postcode,
                StraatNaam = klantModel.StraatNaam,
                HuisNR = klantModel.HuisNR,
                Mail = klantModel.Mail,
                DOB = klantModel.DOB
            };
            _klantCollection.CreateKlant(newKlant);
            return RedirectToAction("KlantList", "Klant");
        }
        public IActionResult KlantUpdate(int ID)
        {
            Klant klant = _klantCollection.GetKlantById(ID);
            KlantModel newKlantModel = new KlantModel
            {
                Voornaam = klant.Voornaam,
                Tussenvoegsel = klant.Tussenvoegsel,
                Achternaam = klant.Achternaam,
                TelNR = klant.TelNR,
                Postcode = klant.Postcode,
                StraatNaam = klant.StraatNaam,
                HuisNR = klant.HuisNR,
                Mail = klant.Mail,
                DOB = klant.DOB
            };
            return View(newKlantModel);
        }
        [HttpPost]
        public IActionResult KlantUpdate(KlantModel klantModel)
        {
            Klant newKlant = new Klant
            {
                ID = klantModel.ID,
                Voornaam = klantModel.Voornaam,
                Tussenvoegsel = klantModel.Tussenvoegsel,
                Achternaam = klantModel.Achternaam,
                TelNR = klantModel.TelNR,
                Postcode = klantModel.Postcode,
                StraatNaam = klantModel.StraatNaam,
                HuisNR = klantModel.HuisNR,
                Mail = klantModel.Mail,
                DOB = klantModel.DOB
            };
            newKlant.KlantUpdate();
            return RedirectToAction("KlantList", "Klant");
        }
        public IActionResult KlantDagUpdate(int ID, int DagID)
        {
            Console.WriteLine(DagID);
            // GetKlantDagById needs both dag and klant id
            Klant klant = _klantCollection.GetKlantDagById(ID);
            KlantDagModel newKlantModel = new KlantDagModel
            {
                Aankomst = klant.Aankomst,
                AankomstSet = true,
                Vertrek = klant.Vertrek,
                VertrekSet = true
            };
            DateTime nullDate = new DateTime(0001, 1, 1, 00, 00 ,00);
            if (newKlantModel.Aankomst == nullDate)
            {
                newKlantModel.AankomstSet = false;
            }
            if (newKlantModel.Vertrek == nullDate)
            {
                newKlantModel.VertrekSet = false;
            }
            ViewBag.dagID = ID;
            return View(newKlantModel);
        }
        [HttpPost]
        public IActionResult KlantDagUpdate(KlantDagModel klantDagModel)
        {
            bool change = false;
            Klant newKlant = new Klant
            {
                ID = klantDagModel.ID

            };
            if (klantDagModel.AankomstSet == true)
            {
                newKlant.Aankomst = klantDagModel.Aankomst;
                change = true;
            }
            if (klantDagModel.VertrekSet == true)
            {
                newKlant.Vertrek = klantDagModel.Vertrek;
                change = true;
            }
            if (change)
            {
                newKlant.KlantDagUpdate();
            }
            
            return RedirectToAction("KlantList", "Klant", new { ID = ViewBag.dagID });
        }
        

    }
}
