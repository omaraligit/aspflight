using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Tracking.Models
{
    public class Vol
    {
        public int id { get; set; }
        public Aeroport depart { get; set; }
        public Aeroport arrivee { get; set; }
        public DateTime dateDepart { get; set; }
        public DateTime dateArrivee { get; set; }
        public Avion avion { get; set; }

        public Vol(int id, Aeroport depart, Aeroport arrivee, DateTime dateDepart, DateTime dateArrivee, Avion avion)
        {
            this.id = id;
            this.depart = depart;
            this.arrivee = arrivee;
            this.dateDepart = dateDepart;
            this.dateArrivee = dateArrivee;
            this.avion = avion;
        }

        public Double calculerDistance()
        {
            // proof of consept 
            // found on https://stackoverflow.com/questions/60700865/find-distance-between-2-coordinates-in-net-core
            // canot use GeoCoordinate in .net Core so i used the other solution du to time limitation
            // more to come to integrate a library
            var d1 = depart.latitude * (Math.PI / 180.0);
            var num1 = depart.longitude * (Math.PI / 180.0);
            var d2 = arrivee.latitude * (Math.PI / 180.0);
            var num2 = arrivee.longitude * (Math.PI / 180.0) - num1;
            // calculating the distance based on the lan and long cords

            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) +
                     Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);
            return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
        }
    }
}
