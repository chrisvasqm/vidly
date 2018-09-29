using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        [Route("movies")]
        public IActionResult Index(int pageIndex = 1, string sortBy = "Name")
        {
            return Content(String.Format("pageIndex:{0} & sortBy: {1}", pageIndex, sortBy));
        }
        
        [Route("movies/random")]
        public IActionResult Random()
        {
            var movie = new Movie {Name = "Shrek"};
            
            return View(movie);
        }

        [Route("movies/edit/{id}")]
        public IActionResult Edit(int id)
        {
            return Content("id: " + id);
        }

        [Route("movies/released/{year}/{month}")]
        public IActionResult ByReleaseDate(int year, byte month)
        {
            return Content(string.Format("Year: {0}, Month: {1}", year, month));
        }
    }
}