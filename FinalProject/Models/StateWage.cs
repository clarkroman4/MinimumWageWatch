using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class StateWage
    {
        public int ID { get; set; }
        public double MinWage { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string State{ get; set; }
    }
}
