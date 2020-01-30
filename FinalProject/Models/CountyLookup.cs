using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class CountyLookup
    {
      
            public int ErrorCode { get; set; }
            public string ErrorMessage { get; set; }
            public string AddressLine1 { get; set; }
            public string AddressLine2 { get; set; }
            public string Number { get; set; }
            public string PreDir { get; set; }
            public string Street { get; set; }
            public string Suffix { get; set; }
            public string PostDir { get; set; }
            public string Sec { get; set; }
            public string SecNumber { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Zip { get; set; }
            public string Zip4 { get; set; }
            public string County { get; set; }
            public string StateFP { get; set; }
            public string CountyFP { get; set; }
            public string CensusTract { get; set; }
            public string CensusBlock { get; set; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public int GeoPrecision { get; set; }
        
    }
}
