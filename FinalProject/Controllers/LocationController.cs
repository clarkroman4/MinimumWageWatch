using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Data;
using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    public class LocationController : Controller
    {
        private readonly ApplicationDbContext context;

        public LocationController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        

        public IActionResult Index()
        {
            List<Location> locations = context.Locations.ToList();
            double wage = 7.25;


            foreach (Location location in locations)
            {
                if (context.CityWages.Where(cw => cw.State == location.State).Where(cw => cw.County == location.County).Where(cw => cw.City == location.City) != null)
                {
                    var TempList = context.CityWages.Where(cw => cw.State == location.State).Where(cw => location.County == cw.County).Where(cw => cw.State == location.State).ToList();
                    wage = (double)TempList.Select(cw => cw.MinWage).FirstOrDefault();
                }
                else if (context.CountyWages.Where(ctw => ctw.State == location.State).Where(ctw => ctw.County == location.County).ToList() != null)
                {
                    var TempList = context.CountyWages.Where(ctw => ctw.County == location.County).Where(ctw => ctw.State == location.State).ToList();
                    wage = (double)TempList.Select(cw => cw.MinWage).FirstOrDefault();
                }
                else if (context.StateWages.Where(sw => sw.State == location.State) != null)
                {
                    var TempList = context.StateWages.Where(sw => sw.State == location.State).ToList();
                    wage = (double)TempList.Select(sw => sw.MinWage).FirstOrDefault();
                }
                else
                {
                    wage=wage;
                }
            }
            
            
            ViewLocationsViewModel viewLocationsViewModel = new ViewLocationsViewModel
            {
                Locations = locations,
                Wage = wage
            };

            return View(viewLocationsViewModel);
            
 
        }

        public IActionResult AddLocation()
        {
            AddLocationViewModel addLocationViewModel = new AddLocationViewModel();
            return View(addLocationViewModel);
        }    

        [HttpPost]
        public IActionResult AddLocation(AddLocationViewModel addLocationViewModel)
        {
            if (ModelState.IsValid)
            {
                Location newlocation = new Location
                {
                    Name = addLocationViewModel.Name,
                    Address = addLocationViewModel.Address,
                    City = addLocationViewModel.City,
                    County = addLocationViewModel.County,
                    State = addLocationViewModel.State,
                    ZIP = addLocationViewModel.ZIP
                };

                context.Add(newlocation);
                context.SaveChanges();

                return Redirect("/Location/Index");
            }

            return View(addLocationViewModel);
        }

    }

}