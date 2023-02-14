using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission06_dallinb9.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_dallinb9.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private MovieContext _movieContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieContext context)
        {
            _logger = logger;
            _movieContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewMovie(NewMovieModel nm)
        {
            if (ModelState.IsValid)
            {
                _movieContext.Add(nm);
                _movieContext.SaveChanges();
                return View("Confirmation", nm);
            }
            else
            {
                return View(nm);
            }
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
