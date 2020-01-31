using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class CityWage { 
        public int ID { get; set; }
        public decimal MinWage { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public DateTime EffectiveDate { get; set; }
    }
}
