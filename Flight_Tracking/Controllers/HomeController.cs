using Flight_Tracking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Tracking.Controllers
{
    public class HomeController : Controller
    {
        public List<Vol> vols = new List<Vol>();
        public List<Aeroport> Aeroports = new List<Aeroport>();
        public List<Avion> Avions = new List<Avion>();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            // filling testing data
            /*Avion avion1 = new Avion("BWNG","boweng1",170,2,20);
            Avion avion2 = new Avion("AIB","AirBus",120,2,50);
            Avions.Add(avion1);
            Avions.Add(avion2);

            Aeroport casaMohamedV = new Aeroport("CASA","casablanca Mohamed V", 33.3707664, -7.5659304);
            Aeroport marrakechMAR = new Aeroport("KECH", "Menara marrakech", 31.6017011, -8.0266516);
            Aeroport agadirAGD = new Aeroport("CASA", "agadir...", 31.6017011, -8.0266516);
            Aeroports.Add(casaMohamedV);
            Aeroports.Add(marrakechMAR);
            Aeroports.Add(agadirAGD);

            Vol casaToKech   = new Vol(1,casaMohamedV, marrakechMAR, new DateTime(), new DateTime(), avion1);
            Vol KechToAgadir = new Vol(2, marrakechMAR, agadirAGD, new DateTime(), new DateTime(), avion2);
            Vol agadirToCasa = new Vol(3, agadirAGD, casaMohamedV, new DateTime(), new DateTime(), avion1);

            vols.Add(casaToKech);
            vols.Add(KechToAgadir);
            vols.Add(agadirToCasa);*/

        }

        public IActionResult Index()
        {
            ViewData["Avions"] = Avions;
            ViewData["Aeroports"] = Aeroports;
            ViewData["vols"] = vols;
            return View();
        }

        [HttpPost]
        public IActionResult Index(string depart, string arrivee, string avion, DateTime dateDepart, DateTime dateArrivee)
        {
            // Vol casaToKech = new Vol(1, findAerport(), marrakechMAR, new DateTime(), new DateTime(), avion1);

            ViewData["vols"] = vols;
            return View();
        }
        public IActionResult Vol()
        {
            return View();
        }

        public IActionResult Privacy()
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
