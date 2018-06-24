using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoviesAppNetCore.Models;
using MoviesAppNetCore.Services;
using MoviesAppNetCore.ViewModels;

namespace MoviesAppNetCore.Controllers
{
    [Route("movies")]
    public class MoviesController : Controller
    {
        private IMovieRepository _repository;
        private ILogger _logger { get; }
        public MoviesController(IMovieRepository movieRepository,ILogger<MoviesController> logger)
        {
            _repository = movieRepository;
            _logger = logger;
        }
        [Route("")]
        public IActionResult Movies()
        {
            _logger.LogInformation("In Movies Controller");
            var model = new MovieResponseModel();
            model.Movies= _repository.getAllMovies();
            model.message = "Movie Dashboard";
            model.BackgroundImage = "background.jpg";
            return View(model);
        }

        [Route("/{id:int}")]
        public IActionResult MovieDetail(int id)
        {
            _logger.LogInformation("Get Movie Details");
            var model = _repository.getMovie(id);
            return View(model);
        }

        [HttpGet]
        [Route("addMovie")]
        public IActionResult AddMovie()
        {
            return View();
        }
        [HttpPost]
        [Route("addMovie")]
        public IActionResult AddMovie(MovieRequestModel movie)
        {
            var model = new Movie();
            model.Name = movie.Name;
            model.Synopsis = movie.Synopsis;
            model.Genre = movie.Genre;

            model =_repository.AddMovie(model);
            return RedirectToAction(nameof(MovieDetail), new {id = model.Id});
        }
    }

}