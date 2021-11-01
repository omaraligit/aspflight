using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Tracking.Models
{
    public class Vol
    {
        public int ID { get; set; }

        public int AeroportID { get; set; }
        public int idAeroportArrivee { get; set; }
        public Aeroport Aeroport { get; set; }
        public DateTime dateDepart { get; set; }
        public DateTime dateArrivee { get; set; }
        public int AvionID { get; set; }
        public Avion Avion { get; set; }

        public Double calculerDistance()
        {
            // proof of consept 
            // found on https://stackoverflow.com/questions/60700865/find-distance-between-2-coordinates-in-net-core
            // canot use GeoCoordinate in .net Core so i used the other solution du to time limitation
            // more to come to integrate a library
            //var d1 = this.aeroportDepart.latitude * (Math.PI / 180.0);
            //var num1 = this.aeroportDepart.longitude * (Math.PI / 180.0);
            ///var d2 = this.aeroportArrivee.latitude * (Math.PI / 180.0);
            //var num2 = this.aeroportArrivee.longitude * (Math.PI / 180.0) - num1;
            // calculating the distance based on the lan and long cords

            /*var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) +
                     Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);
            return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));*/
            return 11;
        }

        public Double calculerConsomationVol()
        {
            return 10;
            /*double distance = calculerDistance();
            double consomation = (distance * this.avion.consomationKM) + this.avion.consomationDepart;
            return consomation;*/
        }
    }
}
