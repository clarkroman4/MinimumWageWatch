using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class CountyWage 
    {
        public int ID { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public double MinWage { get; set; }
        public DateTime EffectiveDate { get; set; }
    }
}
