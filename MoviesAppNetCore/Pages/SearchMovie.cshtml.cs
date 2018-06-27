
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesAppNetCore.Models;
using MoviesAppNetCore.Services;

namespace MoviesAppNetCore.Pages
{
    public class SearchMovieModel : PageModel
    {
        private IMovieRepository _repository;

        public SearchMovieModel(IMovieRepository movieRepository)
        {
            _repository = movieRepository;
        }

        public Movie movie { get; set; }

        public void OnGet(int id = 1)
        {
            movie = _repository.getMovie(id);

        }
    }
}