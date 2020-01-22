using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FinalProject.Models;
using FinalProject.ViewModels;
using FinalProject.Data;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext context;
    /*    
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        */
        public HomeController (ApplicationDbContext dbContext)
        {
            context = dbContext;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }

        public IActionResult CreateUser()
        {
            CreateUserViewModel createUserViewModel = new CreateUserViewModel();
            return View(createUserViewModel);
        }
        [HttpPost]
        public IActionResult CreateUser(CreateUserViewModel createUser)
        {
            if (ModelState.IsValid)
            {
                User newUser = new User
                {
                    Email = createUser.Email,
                    Username = createUser.Username,
                    Password = createUser.Password
                };
                context.Add(newUser);
                context.SaveChanges();
                return Redirect("/location");
            }

            return View(createUser);
        }

        public IActionResult LoggedInHomePage()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
