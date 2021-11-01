using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Tracking.Models
{
    public class Avion
    {
        public int ID { get; set; }
        public string code { get; set; }
        public string libelle { get; set; }
        public int nombrePlace { get; set; }
        public double consomationKM { get; set; }
        public double consomationDepart { get; set; }
    }
}
