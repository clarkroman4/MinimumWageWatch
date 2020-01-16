using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Location
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public City City { get; set; }
        public County County { get; set; }
        public State State { get; set; }
        public int ZIP { get; set; }
       
    }
}
