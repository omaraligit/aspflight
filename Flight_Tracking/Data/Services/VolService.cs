using Flight_Tracking.Data.Base;
using Flight_Tracking.Data.Services;
using Flight_Tracking.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Tracking.Data.Services
{
    public class VolService : EntityBaseRepository<Vol>, IVolService
    {
        private readonly FlightContext _context;
        public VolService(Flight_Tracking.FlightContext context) : base(context) {
            _context = context;
        }

        public async Task<Vol> GetVolByIdAsync(int id)
        {
            var volDetails = await _context.Vols
                .Include(c => c.Aeroport)
                .Include(cc => cc.AeroportArrivee)
                .Include(p => p.Avion)
                .FirstOrDefaultAsync(n => n.Id == id);

            return volDetails;
        }

        public async Task AddNewMovieAsync(Vol data)
        {
            await _context.Vols.AddAsync(data);
            await _context.SaveChangesAsync();
        }
    }
}
