using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Data;
using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{   [Authorize]
    public class WageController : Controller
    {
        private readonly ApplicationDbContext context;

        public WageController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index()
        {
            List<StateWage> stateWages = context.StateWages.OrderBy(sw => sw.State).ToList();
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

                return Redirect("/Wage/Index");
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
                    County = addCityWageViewModel.County,
                    State = addCityWageViewModel.State,
                    EffectiveDate = addCityWageViewModel.EffectiveDate
                };

                context.Add(newCityWage);
                context.SaveChanges();

                return Redirect("/Wage/SeeCityCountyWage?state=" + addCityWageViewModel.State.ToString());
            }

            return View(addCityWageViewModel);
        }

        public IActionResult AddCountyWage()
        {
            AddCountyWageViewModel addCountyWageViewModel = new AddCountyWageViewModel();
            return View(addCountyWageViewModel); 
        }

        [HttpPost]
        public IActionResult AddCountyWage(AddCountyWageViewModel addCountyWageViewModel)
        {
            if (ModelState.IsValid)
            {
                CountyWage newCountyWage = new CountyWage {
                    County = addCountyWageViewModel.County,
                    State = addCountyWageViewModel.State,
                    MinWage = addCountyWageViewModel.MinWage,
                    EffectiveDate = addCountyWageViewModel.EffectiveDate
                };
                context.Add(newCountyWage);
                context.SaveChanges();

                return Redirect("/Wage/SeeCityCountyWage?state=" + addCountyWageViewModel.State.ToString());
            }

            return View(addCountyWageViewModel);
        }
       
        public IActionResult SeeCityCountyWage (string state)
        {
           
            List<CityWage> cityWages = context.CityWages.Where(cw => cw.State == state).ToList();
            List<CountyWage> countyWages = context.CountyWages.Where(ctw => ctw.State == state).ToList();

            ViewCityCountyWagesViewModel viewCityCountyWagesViewModel = new ViewCityCountyWagesViewModel
            {
                CityWage = cityWages,
                CountyWage = countyWages
            };

            return View(viewCityCountyWagesViewModel);
        }

        public IActionResult DeleteStateWage (int ID)
        {
            StateWage stateWage = context.StateWages.Single(sw => sw.ID == ID);
            context.Remove(stateWage);
            context.SaveChanges();

            return Redirect("/Wage/Index");
        }

        public IActionResult EditStateWage(int ID)
        {
            StateWage stateWage = context.StateWages.Single(sw => sw.ID == ID);
            return View(stateWage);
        }

        [HttpPost]
        public IActionResult EditStateWage(AddStateWageViewModel addStateWageViewModel, int ID)
        {
            if (ModelState.IsValid)
            {
                StateWage stateWage = context.StateWages.Single(sw => sw.ID == ID);
                stateWage.MinWage = addStateWageViewModel.MinWage;
                stateWage.EffectiveDate = addStateWageViewModel.EffectiveDate;
                stateWage.State = addStateWageViewModel.State;
                context.SaveChanges();

                return Redirect("/Wage/Index");
            }
            return View(addStateWageViewModel);
        }

        public IActionResult DeleteCityWage (int ID)
        {
            CityWage cityWage = context.CityWages.Single(cw => cw.ID == ID);
            context.Remove(cityWage);
            context.SaveChanges();

            return Redirect("/Wage/SeeCityCountyWage?state=" + cityWage.State.ToString());
        }

        public IActionResult DeleteCountyWage (int ID)
        {
            CountyWage countyWage = context.CountyWages.Single(ctw => ctw.ID == ID);
            context.Remove(countyWage);
            context.SaveChanges();

            return Redirect("/Wage/SeeCityCountyWage?state=" + countyWage.State.ToString());
        }

        public IActionResult EditCityWage(int ID)
        {
            CityWage cityWage = context.CityWages.Single(cw => cw.ID == ID);
            return View(cityWage);
        }
        [HttpPost]
        public IActionResult EditCityWage(AddCityWageViewModel addCityWageViewModel, int ID)
        {
            if (ModelState.IsValid)
            {
                CityWage cityWage = context.CityWages.Single(cw => cw.ID == ID);
                cityWage.City = addCityWageViewModel.City;
                cityWage.County = addCityWageViewModel.County;
                cityWage.State = addCityWageViewModel.State;
                cityWage.EffectiveDate = addCityWageViewModel.EffectiveDate;
                cityWage.MinWage = addCityWageViewModel.MinWage;

                context.SaveChanges();

                return Redirect("Wage/SeeCityCountyWage?state=" + cityWage.State.ToString());
            }
            return View(addCityWageViewModel);
        }

        public IActionResult EditCountyWage(int ID)
        {
            CountyWage countyWage = context.CountyWages.Single(ctw => ctw.ID == ID);
            return View(countyWage);
        }

        [HttpPost]
        public IActionResult EditCountyWage(AddCountyWageViewModel addCountyWageViewModel, int ID)
        {
            if (ModelState.IsValid) 
            { 
                CountyWage countyWage = context.CountyWages.Single(ctw => ctw.ID == ID);
                countyWage.County = addCountyWageViewModel.County;
                countyWage.State = addCountyWageViewModel.State;
                countyWage.EffectiveDate = addCountyWageViewModel.EffectiveDate;
                countyWage.MinWage = addCountyWageViewModel.MinWage;

                context.SaveChanges();
                return Redirect("/Wage/SeeCityCountyWage?state=" + countyWage.State.ToString());
            }
            return View(addCountyWageViewModel);


        }
    }
}