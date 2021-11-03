using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Flight_Tracking.Data.Base;
using GeoCoordinatePortable;
using System.ComponentModel.DataAnnotations;

namespace Flight_Tracking.Models
{
    public class Vol:IEntityBase
    {
        public int Id { get; set; }

        public int AeroportId { get; set; }
        public int AeroportArriveeId { get; set; }

        [ForeignKey("AeroportId")]
        public Aeroport Aeroport { get; set; }

        [ForeignKey("AeroportArriveeId")]
        public Aeroport AeroportArrivee { get; set; }
        public DateTime dateDepart { get; set; }
        public DateTime dateArrivee { get; set; }
        public int AvionId { get; set; }
        [ForeignKey("AvionId")]
        public Avion Avion { get; set; }

        public int calculerDistance()
        {
            // proof of consept 
            // calculating the distance based on the lan and long cords
            GeoCoordinate pin1 = new GeoCoordinate(this.Aeroport.latitude, this.Aeroport.longitude);
            GeoCoordinate pin2 = new GeoCoordinate(this.AeroportArrivee.latitude, this.AeroportArrivee.longitude);

            double distanceBetween = pin1.GetDistanceTo(pin2);
            return (int) distanceBetween /1000; // in KM
        }

        public Double calculerConsomationVol()
        {
            double distance = calculerDistance();
            double consomation = (distance * this.Avion.consomationKM) + this.Avion.consomationDepart;
            return consomation; // total
        }
    }
}
