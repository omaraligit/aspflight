using Flight_Tracking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Flight_Tracking.Data.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Flight_Tracking.Controllers
{
    public class VolController : Controller
    {
        private readonly FlightContext db;

        public IVolService VolService { get; }

        public VolController(FlightContext flightContext, IVolService volService)
        {
            db = flightContext;
            VolService = volService;
        }

        public async Task<IActionResult> Details(int id)
        {
            var volDetail = await VolService.GetVolByIdAsync(id);
            return View(volDetail);
        }
        [HttpGet]
        public IActionResult Create()
        {

            ViewBag.Avions = new SelectList(db.Avions.ToList(), "Id", "code");
            ViewBag.Aeroports = new SelectList(db.Aeroports.ToList(), "Id", "code");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Vol vol)
        {
            await VolService.AddNewMovieAsync(vol);
            return RedirectToAction("Index","Home");
        }
    }
}
