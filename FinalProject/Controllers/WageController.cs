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
    public class WageController : Controller
    {
        private readonly ApplicationDbContext context;

        public WageController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index()
        {
            List<StateWage> stateWages = context.StateWages.ToList();
            return View(stateWages);
        }
        public IActionResult CityWages()
        {
            List < CityWage > cityWages = context.CityWages.ToList();
            return View(cityWages);
        }
        public IActionResult AddStateWage()
        {

            AddStateWageViewModel addStateWageViewModel = new AddStateWageViewModel();
            return View(addStateWageViewModel);
 
        }

        [HttpPost]
        public IActionResult AddStateWage(AddStateWageViewModel addStateWageViewModel)
        {
            if (ModelState.IsValid)
            {
                StateWage newStateWage = new StateWage { 
                    MinWage = addStateWageViewModel.MinWage,
                    State = addStateWageViewModel.State,
                    EffectiveDate = addStateWageViewModel.EffectiveDate
                };

                context.Add(newStateWage);
                context.SaveChanges();

                return Redirect("Wage/Index");
            }

            return View(addStateWageViewModel);
        }

       public IActionResult AddCityWage()
        {
            AddCityWageViewModel addCityWageViewModel = new AddCityWageViewModel();
            return View(addCityWageViewModel);
        }
        [HttpPost]
        public IActionResult AddCityWage(AddCityWageViewModel addCityWageViewModel)
        {
            if (ModelState.IsValid)
            {
                CityWage newCityWage = new CityWage
                {
                    MinWage = addCityWageViewModel.MinWage,
                    City = addCityWageViewModel.City,
                    State = addCityWageViewModel.State,
                    EffectiveDate = addCityWageViewModel.EffectiveDate
                };

                context.Add(newCityWage);
                context.SaveChanges();

                return Redirect("Wage/?state=" + addCityWageViewModel.State.ToString());
            }

            return View(addCityWageViewModel);
        }
    }
}