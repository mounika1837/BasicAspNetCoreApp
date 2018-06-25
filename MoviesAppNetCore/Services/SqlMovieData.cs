using System.Collections.Generic;
using System.Linq;
using MoviesAppNetCore.Data;
using MoviesAppNetCore.Models;

namespace MoviesAppNetCore.Services
{
    public class SqlMovieData : IMovieRepository
    {
        private readonly MovieDBContext _context;

        public SqlMovieData(MovieDBContext context)
        {
            _context = context;
        }
        public IEnumerable<Movie> getAllMovies()
        {
           return _context.Movies;
        }

        public Movie getMovie(int id)
        {
            return _context.Movies.FirstOrDefault(m => m.Id == id);
        }

        public Movie AddMovie(Movie model)
        {
            _context.Movies.Add(model);
            _context.SaveChanges();
            return model;
        }
    }
}
