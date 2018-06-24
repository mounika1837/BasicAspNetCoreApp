using System.Collections.Generic;
using MoviesAppNetCore.Models;

namespace MoviesAppNetCore.ViewModels
{
    public class MovieResponseModel
    {
        public IEnumerable<Movie> Movies { get; set; }
        public string BackgroundImage { get; set; }

        public string message { get; set; }
    }
}
