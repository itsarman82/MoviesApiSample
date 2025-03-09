using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesApiSample.Models.ActorNamespace;

namespace MoviesApiSample.DAL.ActorConfig
{
    class ActorMovieEntityConfiguration : IEntityTypeConfiguration<ActorMovie>
    {
        public void Configure(EntityTypeBuilder<ActorMovie> builder)
        {
            // Table name
            builder.ToTable("ActorMovies");

            // Primary key
            builder.HasKey(am => am.Id);

            // Properties
            builder.Property(am => am.Id)
                .ValueGeneratedOnAdd();

            // Relationships
            builder.HasMany(am => am.Actors)
                .WithOne(a => a.ActorMovie)
                .HasForeignKey(a => a.ActorMovieId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(am => am.Movies)
                .WithOne(m => m.ActorMovie)
                .HasForeignKey(m => m.ActorMovieId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

