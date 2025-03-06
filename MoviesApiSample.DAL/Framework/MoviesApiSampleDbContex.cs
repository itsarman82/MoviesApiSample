using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MoviesApiSample.Models.ActorNamespace;
using MoviesApiSample.Models.AuthorNamespace;
using MoviesApiSample.Models.MovieNamespace;

namespace MoviesApiSample.DAL.Framework
{
    public class MoviesApiSampleDbContex : DbContext 
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors{ get; set; }
        public DbSet<Author> Authors { get; set; }

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
