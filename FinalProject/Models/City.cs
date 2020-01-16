using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class City
    {
        public int ID { get; set; }
        public int Name { get; set; }
        public County County { get; set; }
        public State State { get; set; }
    }
}
