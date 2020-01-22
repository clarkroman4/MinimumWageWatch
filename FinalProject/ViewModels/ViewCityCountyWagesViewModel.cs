using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.ViewModels
{
    public class ViewCityCountyWagesViewModel
    {
        public IEnumerable<CityWage> CityWage { get; set; }

        public IEnumerable<CountyWage> CountyWage { get; set; }

        public ViewCityCountyWagesViewModel() { }
    }
}
