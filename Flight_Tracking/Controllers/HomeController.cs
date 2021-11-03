using Flight_Tracking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Flight_Tracking.Data.Services;


namespace Flight_Tracking.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public IVolService VolService { get; }

        public HomeController(ILogger<HomeController> logger,IVolService volService)
        {
            _logger = logger;
            VolService = volService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await VolService.GetAllAsync(vol=>vol.Avion, col=>col.Aeroport, cc=>cc.AeroportArrivee);
            return View(data);
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
