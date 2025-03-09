using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesApiSample.Models.DirectorNamespace;

namespace MoviesApiSample.DAL.DirectorConfig
{
    public class MovieEntityConfiguration : IEntityTypeConfiguration<DirectorMovie>
    {
        public void Configure(EntityTypeBuilder<DirectorMovie> builder)
        {
            // Specify the table name
            builder.ToTable("DirectorMovies");

            // Specify the primary key
            builder.HasKey(dm => dm.Id);

            // Configure properties
            builder.Property(dm => dm.DirectorId)
                .IsRequired();

            builder.Property(dm => dm.MovieId)
                .IsRequired();

            // Configure default values
            builder.Property(dm => dm.DirectorId)
                .HasDefaultValue(0);

            builder.Property(dm => dm.MovieId)
                .HasDefaultValue(0);

            // Add indexes
            builder.HasIndex(dm => dm.DirectorId);
            builder.HasIndex(dm => dm.MovieId);

            // Configure relationships
            builder.HasOne(dm => dm.Director)
                .WithOne(d => d.DirectorMovie)
                .HasForeignKey<Director>(d => d.DirectorMovieId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(dm => dm.Movies)
                .WithOne(m => m.DirectorMovie)
                .HasForeignKey(m => m.DirectorMovieId)
                .OnDelete(DeleteBehavior.Cascade);

            // Add any additional configurations if needed
        }
    }
}