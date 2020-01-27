using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class WageLocation
    {
        public int ID { get; set; }
        public int LocationID { get; set; }
        public decimal Wage { get; set; }
        public string LocationName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public int ZIP { get; set; }
        
        

    }
}
