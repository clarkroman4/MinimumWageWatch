﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Data;
using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Web;
using Microsoft.AspNetCore.Authorization;


namespace FinalProject.Controllers
{   [Authorize]
    public class LocationController : Controller
    {
        private readonly ApplicationDbContext context;
        private CountyAPI CountyAPI;

        public LocationController(ApplicationDbContext dbContext)
        {
            context = dbContext;
            CountyAPI api = new CountyAPI();
            CountyAPI = api;
        }

        public IActionResult Index()
        {   
            decimal FedMinimumWage = 7.25m;
            List<Location> locations = context.Locations.ToList();
            List<WageLocation> wageLocations1 = context.WageLocations.ToList();
            List<int> locationIDs = context.Locations.Select(l => l.ID).ToList();
            // Checks to see if any locations need to be deleted from WageLocations Joined Table
            foreach (WageLocation wageLocation in wageLocations1)
            {
                if (!locationIDs.Contains(wageLocation.LocationID))
                {
                    context.WageLocations.Remove(wageLocation);
                    context.SaveChanges();
                }

            }

            foreach (Location location in locations)
                // Checks if existing locations in join table have been edited; saves the changes to the join table database
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
                // Adds new rows to join table and collects the correct minimum wage
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
            // Gathers the updated join table and populates the view model
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

                    //TO DO Refactor to use API
                    County = CountyAPI.GetCounty(addLocationViewModel.Address,addLocationViewModel.City + "," + addLocationViewModel.State ),
                    State = addLocationViewModel.State,
                    ZIP = addLocationViewModel.ZIP
                };
                context.Add(newlocation);
                context.SaveChanges();
                return Redirect("/Location/Index");
            }
            return View(addLocationViewModel);
        }

        public IActionResult CSVSpecs()
        {
            return View();
        }
        
        public IActionResult ImportCSV()
        {
            UploadFileViewModel uploadFileViewModel = new UploadFileViewModel();
            return View(uploadFileViewModel);
        }

        [HttpPost]
        public IActionResult ImportCSV(UploadFileViewModel uploadFileViewModel)
        {
            if (ModelState.IsValid)
            {
                try {
                //Read Contents of file to string
                StreamReader reader = new StreamReader(uploadFileViewModel.file.OpenReadStream());

                string csvData = reader.ReadToEnd();
                
                ////Split based on rows ('\n')

                List<string> locationRows = csvData.Split('\n').ToList();

                ////Execute a loop over the rows.
                foreach (string locationRow in locationRows)
                {
                    if (locationRow != "")
                    {
                        List<string> locationStrings = locationRow.Split(',').ToList();
                        Location location = new Location
                        {
                            Name = locationStrings[0],
                            Address = locationStrings[1],
                            City = locationStrings[2],
                            County = locationStrings[3],
                            State = locationStrings[4],
                            ZIP = int.Parse(locationStrings[5])
                        };
                        context.Add(location);
                        context.SaveChanges();
                    }
                    
                }

                return Redirect("/Location/Index");       
            } catch 
                {
                    ViewBag.Message = "Please Check File Specifications and Try Again";
                }
            } 
            
            return View(uploadFileViewModel);
        }
 
        public IActionResult EditLocation(int ID)
        {
            Location location = context.Locations.Single(l => l.ID == ID);
            ViewSingleLocationViewModel viewSingleLocationViewModel = new ViewSingleLocationViewModel
            {
                ID = location.ID,
                Name = location.Name,
                Address = location.Address,
                City = location.City,
                County = location.County,
                State = location.State,
                ZIP = location.ZIP
            };
            return View(viewSingleLocationViewModel);
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
                location.County = CountyAPI.GetCounty(viewSingleLocationViewModel.Address, viewSingleLocationViewModel.City + "," + viewSingleLocationViewModel.State);
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

        [HttpPost]
        public FileResult Export()
        {
            List<WageLocation> wageLocations = context.WageLocations.ToList();

            StringBuilder sb = new StringBuilder();
            sb.Append("Minimum Wage,Location Name,Address,City,County,State,ZIP,\r\n");

            foreach (WageLocation wageLocation in wageLocations)
            {

                string minWage = wageLocation.Wage.ToString();
                sb.Append(minWage + ',');

                string locName = wageLocation.LocationName;
                sb.Append(locName + ',');

                string address = wageLocation.Address;
                sb.Append(address + ',');

                string city = wageLocation.City;
                sb.Append(city + ',');

                string county = wageLocation.County;
                sb.Append(county + ',');

                string state = wageLocation.State;
                sb.Append(state + ',');

                string ZIP = wageLocation.ZIP.ToString();
                sb.Append(ZIP + ',');

                sb.Append("\r\n");

            }

            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "WageLocations.csv");
        }
       
     }
}

