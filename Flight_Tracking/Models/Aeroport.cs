using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Tracking.Models
{
    public class Aeroport
    {
        public string id { get; set; }
        public string libelle { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }

        public Aeroport(string id, string libelle, double latitude, double longitude)
        {
            this.id = id;
            this.libelle = libelle;
            this.latitude = latitude;
            this.longitude = longitude;
        }
    }
}
