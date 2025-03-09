using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MoviesApiSample.Models.ActorNamespace;
using MoviesApiSample.Models.DirectorNamespace;
using MoviesApiSample.Models.MovieNamespace;

namespace MoviesApiSample.DAL.Framework
{
    public class MoviesApiSampleDbContex : DbContext 
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors{ get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<DirectorMovie> DirectorMovies { get; set; }
        public DbSet<ActorMovie> ActorMovies { get; set; }

        public MoviesApiSampleDbContex(DbContextOptions<MoviesApiSampleDbContex> dbContextOptions) : base(dbContextOptions)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Initial Catalog=MoviesAPI; User Id=sa; Password=armanz582; TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
