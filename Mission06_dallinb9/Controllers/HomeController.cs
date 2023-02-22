using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private MovieContext _movieContext { get; set; }

        public HomeController(MovieContext context)
        {
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
            ViewBag.Categories = _movieContext.Categories.ToList();

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
                ViewBag.Categories = _movieContext.Categories.ToList();
                return View(nm);
            }
        }

        public IActionResult MovieList ()
        {
            var movies = _movieContext.Movies
                .Include(x => x.Category)
                .OrderByDescending(x => x.MovieID)
                .ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _movieContext.Categories.ToList();

            var movie = _movieContext.Movies.Single(x => x.MovieID == id);

            return View("UpdateMovie", movie);
        }

        [HttpPost]
        public IActionResult Edit(NewMovieModel movie)
        {
            if (ModelState.IsValid) {
                _movieContext.Update(movie);
                _movieContext.SaveChanges();
                return RedirectToAction("MovieList");
            }
            else
            {
                ViewBag.Categories = _movieContext.Categories.ToList();
                return View("UpdateMovie", movie);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = _movieContext.Movies.Single(x => x.MovieID == id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(NewMovieModel nm)
        {
            _movieContext.Movies.Remove(nm);
            _movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
