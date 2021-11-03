using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flight_Tracking.Data.Base;

namespace Flight_Tracking.Models
{
    public class Avion:IEntityBase
    {
        public int Id { get; set; }
        public string code { get; set; }
        public string libelle { get; set; }
        public int nombrePlace { get; set; }
        public double consomationKM { get; set; }
        public double consomationDepart { get; set; }
        public List<Vol> Vols { get; set; }
    }
}
