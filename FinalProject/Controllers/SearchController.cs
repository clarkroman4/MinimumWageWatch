using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Data;
using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace FinalProject.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext context;

        public SearchController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SearchResults(SearchViewModel searchViewModel)
        {
            if (ModelState.IsValid)
            {                     
                int searchTermInt = 0;
                decimal searchTermDecimal = 0;
                string searchTermString = "";

                if (searchViewModel.SearchBy == "ZIP")
                {
                    searchTermInt = int.Parse(searchViewModel.SearchTerm);
                }
                else if (searchViewModel.SearchBy == "Minimum Wage")
                {
                    searchTermDecimal = decimal.Parse(searchViewModel.SearchTerm);
                } else
                {
                    searchTermString = searchViewModel.SearchTerm.ToString();
                }
                List<WageLocation> allWageLocations = context.WageLocations.ToList();
                List<WageLocation> searchResults = new List<WageLocation>();

                if (searchViewModel.SearchBy == "Minimum Wage")
                {
                    foreach (var wl in allWageLocations)
                    {
                        if (searchTermDecimal == wl.Wage)
                        {
                            searchResults.Add(wl);
                        }
                    }
                } else if (searchViewModel.SearchBy == "Location Name")
                {
                    foreach (var wl in allWageLocations)
                    {
                        if (wl.LocationName.Contains(searchTermString))
                        {
                            searchResults.Add(wl);
                        }
                    }
                } else if (searchViewModel.SearchBy == "Address")
                {
                    foreach (var wl in allWageLocations)
                    {
                        if (wl.Address.Contains(searchTermString))
                        {
                            searchResults.Add(wl);
                        }
                    }
                } else if (searchViewModel.SearchBy == "City")
                {
                    foreach (var wl in allWageLocations)
                    {
                        if (wl.City.Contains(searchTermString))
                        {
                            searchResults.Add(wl);
                        }
                    }
                } else if (searchViewModel.SearchBy == "County")
                {
                    foreach (var wl in allWageLocations)
                    {
                        if (wl.County.Contains(searchTermString))
                        {
                            searchResults.Add(wl);
                        }

                    }
                } else if (searchViewModel.SearchBy == "State")
                {
                    foreach (var wl in allWageLocations)
                    {
                        if (wl.State.Contains(searchTermString))
                        {
                            searchResults.Add(wl);
                        }
                    }
                } else if (searchViewModel.SearchBy == "ZIP")
                {
                    foreach (var wl in allWageLocations)
                    {
                        if (wl.ZIP == searchTermInt)
                        {
                            searchResults.Add(wl);
                        }
                    }
                }
                ViewBag.searchResults = searchResults;
                return View();
            }

            // TO DO: Figure out this exception
               
             

        

            return View(searchViewModel);
             }
    }

}