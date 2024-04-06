using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using pandafilm.Models;

namespace identityStep.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<ApplicationUser> applicationUsers { get; set; }
        public DbSet<MovieModel> movieModels { get; set; }
        public DbSet<FavMovieViewModel> favMovies { get; set; }
        public DbSet<WatchLaterMovieViewModel> watchLaterMovies { get; set; }
        public DbSet<MovieHistoryViewModel> userHistory { get; set; }
    }
}
