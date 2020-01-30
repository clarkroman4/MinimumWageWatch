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
using Microsoft.AspNetCore.Authorization;

namespace FinalProject.Controllers
{   [Authorize]
    public class HomeController : Controller
    {
        private ApplicationDbContext context;
  
        private readonly ILogger<HomeController> _logger;

        public HomeController (ApplicationDbContext dbContext, ILogger<HomeController> logger)
        {
            context = dbContext;
            _logger = logger;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
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
