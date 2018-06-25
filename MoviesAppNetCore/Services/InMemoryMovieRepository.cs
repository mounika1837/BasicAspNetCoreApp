using System.Collections.Generic;
using System.Linq;
using MoviesAppNetCore.Models;
using NLog;

namespace MoviesAppNetCore.Services
{
    public class InMemoryMovieRepository : IMovieRepository
    {
   
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public InMemoryMovieRepository()
        {
            movies = new List<Movie>
            {
                new Movie {Name = "Movie1",Id = 1,Genre = "Thriller",SmallImage = "1.jpg",Synopsis = "thriller"},
                new Movie {Name = "Movie2",Id = 2,Genre = "Comedy",SmallImage = "2.jpg",Synopsis = "Hilarious"},
                new Movie {Name = "Movie3",Id = 3,Genre = "Horror",SmallImage = "3.jpg",Synopsis = "Horrifying"},
                new Movie {Name = "Movie4",Id = 4,Genre = "Sci-Fi",SmallImage = "4.jpg",Synopsis = "Exciting"}
            };
        }
        public List<Movie> movies { get; set; }
        public IEnumerable<Movie> getAllMovies()
        {
            return movies;
        }

        public Movie getMovie(int id)
        {
            logger.Info("In Repository");
            return movies.FirstOrDefault(r => r.Id.Equals(id));
        }

        public Movie AddMovie(Movie movie)
        {
            movie.Id = movies.Count + 1;
            movies.Add(movie);
            return movie;
        }
    }
}