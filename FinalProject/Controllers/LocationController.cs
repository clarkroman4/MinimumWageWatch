﻿using System;
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
            double FedMinimumWage = 7.25;

            foreach (Location location in locations)
            // Updates WageLocation Table with correct LocationID and Wage 
            {
                if (context.WageLocations.Where(wl => location.ID == wl.LocationID).Count() != 0)
                {

                    if (context.CityWages.Where(sw => sw.State == location.State).Where(sw => sw.City == location.City).Where(sw => sw.County == location.County).Count() != 0)
                    {
                        WageLocation wageLocation = context.WageLocations.FirstOrDefault(wl => wl.LocationID == location.ID);
                        wageLocation.Wage = context.CityWages.Where(cw => cw.City == location.City).Select(cw => cw.MinWage).FirstOrDefault();
                        wageLocation.LocationID = location.ID;
                        wageLocation.LocationName = location.Name;
                        wageLocation.Address = location.Address;
                        wageLocation.City = location.City;
                        wageLocation.County = location.County;
                        wageLocation.State = location.State;
                        wageLocation.ZIP = location.ZIP;
                        context.SaveChanges();
                    }

                    else if (context.CountyWages.Where(ctw => ctw.County == location.County).Where(ctw => ctw.State == location.State).Count() != 0)
                    {
                        WageLocation wageLocation = context.WageLocations.FirstOrDefault(wl => wl.LocationID == location.ID);
                        wageLocation.Wage = context.CountyWages.Where(ctw => ctw.County == location.County).Select(ctw => ctw.MinWage).FirstOrDefault();
                        wageLocation.LocationID = location.ID;
                        wageLocation.LocationName = location.Name;
                        wageLocation.Address = location.Address;
                        wageLocation.City = location.City;
                        wageLocation.County = location.County;
                        wageLocation.State = location.State;
                        wageLocation.ZIP = location.ZIP;
                        context.SaveChanges();
                    }
                    else if (context.StateWages.Where(sw => sw.State == location.State).Count() != 0)
                    {
                        WageLocation wageLocation = context.WageLocations.FirstOrDefault(wl => wl.LocationID == location.ID);
                        wageLocation.Wage = context.StateWages.Where(sw => sw.State == location.State).Select(sw => sw.MinWage).FirstOrDefault();
                        wageLocation.LocationID = location.ID;
                        wageLocation.LocationName = location.Name;
                        wageLocation.Address = location.Address;
                        wageLocation.City = location.City;
                        wageLocation.County = location.County;
                        wageLocation.State = location.State;
                        wageLocation.ZIP = location.ZIP;
                        context.SaveChanges();
                    }

                    else
                    {
                        WageLocation wageLocation = context.WageLocations.FirstOrDefault(wl => wl.LocationID == location.ID);
                        wageLocation.Wage = FedMinimumWage;
                        wageLocation.LocationID = location.ID;
                        wageLocation.LocationName = location.Name;
                        wageLocation.Address = location.Address;
                        wageLocation.City = location.City;
                        wageLocation.County = location.County;
                        wageLocation.State = location.State;
                        wageLocation.ZIP = location.ZIP;
                        context.SaveChanges();
                    }
                }

                else
                {
                    if (context.CityWages.Where(sw => sw.State == location.State).Where(sw => sw.City == location.City).Where(sw => sw.County == location.County).Count() != 0)
                    {
                        WageLocation wageLocation = new WageLocation
                        {
                            Wage = context.CityWages.Where(cw => cw.City == location.City).Select(cw => cw.MinWage).FirstOrDefault(),
                            LocationID = location.ID,
                            LocationName = location.Name,
                            Address = location.Address,
                            City = location.City,
                            County = location.County,
                            State = location.State,
                            ZIP = location.ZIP
                        };
                        context.WageLocations.Add(wageLocation);
                        context.SaveChanges();
                    }

                    else if (context.CountyWages.Where(ctw => ctw.County == location.County).Where(ctw => ctw.State == location.State).Count() != 0)
                    {
                        WageLocation wageLocation = new WageLocation
                        {
                            Wage = context.CountyWages.Where(ctw => ctw.County == location.County).Select(ctw => ctw.MinWage).FirstOrDefault(),
                            LocationID = location.ID,
                            LocationName = location.Name,
                            Address = location.Address,
                            City = location.City,
                            County = location.County,
                            State = location.State,
                            ZIP = location.ZIP
                        };
                        context.WageLocations.Add(wageLocation);
                        context.SaveChanges();
                    }
                    else if (context.StateWages.Where(sw => sw.State == location.State).Count() != 0)
                    {
                        WageLocation wageLocation = new WageLocation
                        {
                            Wage = context.StateWages.Where(sw => sw.State == location.State).Select(sw => sw.MinWage).FirstOrDefault(),
                            LocationID = location.ID,
                            LocationName = location.Name,
                            Address = location.Address,
                            City = location.City,
                            County = location.County,
                            State = location.State,
                            ZIP = location.ZIP
                        };
                        context.WageLocations.Add(wageLocation);
                        context.SaveChanges();
                    }

                    else
                    {
                        WageLocation wageLocation = new WageLocation
                        {
                            Wage = FedMinimumWage,
                            LocationID = location.ID,
                            LocationName = location.Name,
                            Address = location.Address,
                            City = location.City,
                            County = location.County,
                            State = location.State,
                            ZIP = location.ZIP

                        };
                        context.WageLocations.Add(wageLocation);
                        context.SaveChanges();
                    }
                }
            }
            // Fix this ViewModel
            List<WageLocation> wageLocations = context.WageLocations.ToList();
            ViewLocationsViewModel viewLocationsViewModel = new ViewLocationsViewModel
            {
                WageLocations = wageLocations
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

        public IActionResult EditLocation(int ID)
        {
            Location location = context.Locations.Single(l => l.ID == ID);
            return View(location);
        }

        [HttpPost]
        public IActionResult EditLocation(ViewSingleLocationViewModel viewSingleLocationViewModel, int ID)
        {
            if (ModelState.IsValid)
            {
                Location location = context.Locations.SingleOrDefault(l => l.ID == viewSingleLocationViewModel.ID);
                location.Name = viewSingleLocationViewModel.Name;
                location.Address = viewSingleLocationViewModel.Address;
                location.City = viewSingleLocationViewModel.City;
                location.County = viewSingleLocationViewModel.County;
                location.State = viewSingleLocationViewModel.State;
                location.ZIP = viewSingleLocationViewModel.ZIP;

                context.SaveChanges();

                return Redirect("/Location/Index");

            };
            return View(viewSingleLocationViewModel);
        } 

        [HttpPost]
        public IActionResult DeleteLocation(int ID)
        {
            Location location = context.Locations.SingleOrDefault(l => l.ID == ID);
            context.Locations.Remove(location);
            context.SaveChanges();

            return Redirect("/Location/Index");
        }
    }

}