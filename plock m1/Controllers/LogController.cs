using Microsoft.AspNetCore.Mvc;
using plock_m1.Models;
using System;
using BLL;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plock_m1.Controllers
{
    public class LogController : Controller
    {
        public List<Dag> dagen = null;
        public List<Klant> klanten = null;
        public IActionResult Index()
        {
        
            //DagenSetup();
            return View();
        }
        public IActionResult DagLoggen()
        {
            return View();
        }
        public IActionResult DagList()
        {

            //DagenSetup();
            //for (int i = 0; i < 50; i++)
            //{
            //    dagen.Add(new dag(new DateTime(2021, 10, 10), "avond", "20:00", "01:00"));
            //}
            List<Dag> SortedDagen = dagen.OrderBy(o => o.Date).ToList();
            SortedDagen.Reverse();
            return View(SortedDagen);
        }
        public IActionResult KlantList()
        {

            //KlantenSetup();
            //for (int i = 0; i < 50; i++)
            //{
            //    dagen.Add(new dag(new DateTime(2021, 10, 10), "avond", "20:00", "01:00"));
            //}
            List<Klant> sortedKlanten = klanten.OrderBy(o => o.Voornaam).ToList();
            sortedKlanten.Reverse();
            return View(sortedKlanten);
        }
        public IActionResult DagSelected() 
        {
            Console.WriteLine("test");
            return View("DagList");
        }
        //public IActionResult DagDetails(int id)
        //{
        //    DagenSetup();
        //    Console.WriteLine(dagen);
        //    Dag selectedDag = null;
        //    Console.WriteLine(id);
        //    foreach (var dag in dagen)
        //    {
        //        if (dag.ID == id)
        //        {
        //            selectedDag = dag;
        //        }
        //    }
        //    return View(selectedDag);
        //}
        //public void DagenSetup()
        //{
        //    List<Dag> dagenSetup = new List<Dag>();
        //    dagenSetup.Add(new Dag(1, new DateTime(2021, 1, 1), null, "20:00", "01:00", 20));
        //    dagenSetup.Add(new Dag(2, new DateTime(1999, 7, 26), null, "20:00", "01:00", 20));
        //    dagenSetup.Add(new Dag(4, new DateTime(2021, 1, 2), null, "20:00", "01:00", 20));
        //    dagenSetup.Add(new Dag(6, new DateTime(2021, 1, 3), null, "20:00", "01:00", 20));
        //    dagenSetup.Add(new Dag(7, new DateTime(2011, 1, 3), null, "20:00", "01:00", 20));
        //    dagenSetup.Add(new Dag(8, new DateTime(2021, 1, 4), null, "20:00", "01:00", 20));
        //    dagenSetup.Add(new Dag(9, new DateTime(2021, 10, 10), "Stones avond", "20:00", "01:00", 162));
        //    dagen = dagenSetup;
        //}
        //public void KlantenSetup()
        //{
        //    List<Klant> klantenSetup = new List<Klant>();
        //    klantenSetup.Add(new Klant(1, "piet", null, "van de Maas", 123456789, "1234XL" , "12C", "amail@mail.io", new DateTime(2000 , 1, 4)));
        //    klanten = klantenSetup;
        //}
    }
}
