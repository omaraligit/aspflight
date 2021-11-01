using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flight_Tracking.Models;
using Microsoft.EntityFrameworkCore;

namespace Flight_Tracking
{
    public class FlightContext : DbContext
    {
        public DbSet<Avion> Avions { get; set; }
        public DbSet<Vol> Vols { get; set; }
        public DbSet<Aeroport> Aeroports { get; set; }
        public string DbPath { get; private set; }

        public FlightContext(DbContextOptions<FlightContext> options)
        : base(options)
        {
            // saving the database file to root project folder
            // var folder = Environment.CurrentDirectory;
            // DbPath = $"{folder}{System.IO.Path.DirectorySeparatorChar}flights.db";
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }


        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
            // => options.UseSqlite($"Data Source={DbPath}");
    }
}
