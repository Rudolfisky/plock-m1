using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using plock_m1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace plock_m1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        //public IActionResult DagLoggen()
        //{
        //    return View();
        //}
        //public IActionResult DagList()
        //{
        //    DagenSetup();
        //    //for (int i = 0; i < 50; i++)
        //    //{
        //    //    dagen.Add(new dag(new DateTime(2021, 10, 10), "avond", "20:00", "01:00"));
        //    //}
        //    List<dag> SortedDagen = dagen.OrderBy(o => o.Date).ToList();
        //    SortedDagen.Reverse();
        //    return View(SortedDagen);
        //}
        //public IActionResult DagDetails(int id)
        //{
        //    DagenSetup();
        //    Console.WriteLine(dagen);
        //    dag selectedDag = null;
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
        //    List<dag> dagenSetup = new List<dag>();
        //    dagenSetup.Add(new dag(1, new DateTime(2021, 1, 1), null, "20:00", "01:00", 20));
        //    dagenSetup.Add(new dag(2, new DateTime(1999, 7, 26), null, "20:00", "01:00", 20));
        //    dagenSetup.Add(new dag(4, new DateTime(2021, 1, 2), null, "20:00", "01:00", 20));
        //    dagenSetup.Add(new dag(6, new DateTime(2021, 1, 3), null, "20:00", "01:00", 20));
        //    dagenSetup.Add(new dag(7, new DateTime(2011, 1, 3), null, "20:00", "01:00", 20));
        //    dagenSetup.Add(new dag(8, new DateTime(2021, 1, 4), null, "20:00", "01:00", 20));
        //    dagenSetup.Add(new dag(9, new DateTime(2021, 10, 10), "Stones avond", "20:00", "01:00", 162));
        //    dagen = dagenSetup;
        //}
        public IActionResult Login()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
