using System.Collections.Generic;
using MoviesAppNetCore.Models;

namespace MoviesAppNetCore.Services
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> getAllMovies();
        Movie getMovie(int id);
        Movie AddMovie(Movie model);
    }
}