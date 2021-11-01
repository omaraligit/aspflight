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
        private readonly FlightContext db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, FlightContext flightContext)
        {
            _logger = logger;
            db = flightContext;
            db.Database.EnsureDeleted();
            // recreating the database to contain the new scheema if somthing changed
            db.Database.EnsureCreated();
            // Create
            Console.WriteLine("Inserting a new Avion");
            //lines Avion
            db.Add(new Models.Avion { code = "BWNG", libelle = "boweng1", nombrePlace = 170, consomationKM = 2, consomationDepart = 20 });
            db.SaveChanges();
            db.Add(new Models.Avion { code = "BWNG", libelle = "boweng2", nombrePlace = 170, consomationKM = 2, consomationDepart = 20 });
            db.SaveChanges();
            db.Add(new Models.Avion { code = "AIB", libelle = "AirBus", nombrePlace = 120, consomationKM = 2, consomationDepart = 50 });
            db.SaveChanges();
            //lines Aeroport
            Console.WriteLine("Inserting a new Aeroports");
            db.Add(new Models.Aeroport { code = "CASA", libelle = "casablanca", latitude = 33.3707664, longitude = -7.5659304 });
            db.SaveChanges();
            db.Add(new Models.Aeroport { code = "KECH", libelle = "Menara marrakech", latitude = 31.6017011, longitude = -8.0266516 });
            db.SaveChanges();
            db.Add(new Models.Aeroport { code = "AGADIR", libelle = "agadirAGD", latitude = 32.6552564, longitude = -6.2225365 });
            db.SaveChanges();
            //lines Vol
            Console.WriteLine("Inserting a new Vols");
            db.Add(new Models.Vol { AeroportID = 1, AvionID = 1, dateDepart = DateTime.Now, dateArrivee = DateTime.Now.AddHours(2) });
            db.SaveChanges();
            db.Add(new Models.Vol { AeroportID = 2, AvionID = 3, dateDepart = DateTime.Now, dateArrivee = DateTime.Now.AddHours(2) });
            db.SaveChanges();
            Console.WriteLine("db reading record ===== ");
            
            // Read
            Console.WriteLine("Querying for a Avion");
           

        }

        public IActionResult Index()
        {
            var vols = db.Vols.ToList();

            ViewData["vols"] = vols;
            return View();
        }

        [HttpPost]
        public IActionResult Index(string depart, string arrivee, string avion, DateTime dateDepart, DateTime dateArrivee)
        {
            // Vol casaToKech = new Vol(1, findAerport(), marrakechMAR, new DateTime(), new DateTime(), avion1);

            //db.Add(new Models.Vol { idAeroportDepart = 1, idAeroportArrivee = 2, idAvion = 1, dateDepart = DateTime.Now, dateArrivee = DateTime.Now.AddHours(2) });

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
