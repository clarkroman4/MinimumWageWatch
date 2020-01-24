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
        //[HttpPost]
        //public IActionResult Index(SearchViewModel searchViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        string searchTerm = searchViewModel.ToString();
        //        List<WageLocation> searchResults = new List<WageLocation>();

        //        if 


        //        return View(searchResults);
        //    }

        //    return View(searchViewModel);
        //}
    }
   
}