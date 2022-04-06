using JqueryCascade.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JqueryCascade.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        JDbContext dbContext;

        public HomeController(ILogger<HomeController> logger, JDbContext context)
        {
            _logger = logger;
            dbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetCountries()
        {
            var countries = dbContext.Countries.ToList();
            return Json(countries);
        }
        public JsonResult GetStates(int id)
        {
            var states = dbContext.States.Where(e => e.Country.Id == id).ToList();
            return Json(states);
        }
        public JsonResult GetCities(int id)
        {
            var cities = dbContext.Cities.Where(e=>e.State.Id==id).ToList();
            return Json(cities);
        }

        public IActionResult Privacy()
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
