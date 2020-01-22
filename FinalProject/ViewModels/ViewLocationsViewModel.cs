using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.ViewModels
{
    public class ViewLocationsViewModel
    {
        public IEnumerable <Location> Locations { get; set; }
        public double Wage { get; set; }


        public ViewLocationsViewModel()
        {

        }
    }
}
