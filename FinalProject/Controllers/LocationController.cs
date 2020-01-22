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