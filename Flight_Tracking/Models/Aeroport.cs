using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flight_Tracking.Data.Base;
namespace Flight_Tracking.Models
{
    public class Aeroport: IEntityBase
    {
        public int Id { get; set; }
        public string code { get; set; }
        public string libelle { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }

    }
}
