using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MoviesApiSample.DAL.ActorConfig;
using MoviesApiSample.DAL.DirectorConfig;
using MoviesApiSample.Models.ActorNamespace;
using MoviesApiSample.Models.DirectorNamespace;
using MoviesApiSample.Models.MovieNamespace;

namespace MoviesApiSample.DAL.Framework
{
    public class MoviesApiSampleDbContex : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }

        public MoviesApiSampleDbContex(DbContextOptions<MoviesApiSampleDbContex> dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost,1433; Database=MoviesDb;User Id=sa; Password=Armanz582; TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ActorEntityConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DirectorEntityConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieEntityConfiguration).Assembly);
        }
    }
}
