using Microsoft.EntityFrameworkCore;
using MoviesAppNetCore.Models;

namespace MoviesAppNetCore.Data
{
    public class MovieDBContext : DbContext
    {
        public MovieDBContext(DbContextOptions options):base(options)
        {
            
        }
          public DbSet<Movie> Movies { get; set; }
    }
}