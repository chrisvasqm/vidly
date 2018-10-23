using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }

        public string Title => (Movie.Name != null && Movie.Id != 0) ? "New Movie" : "Edit Movie";
    }
}