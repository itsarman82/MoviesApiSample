using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesApiSample.Models.DirectorNamespace;

namespace MoviesApiSample.DAL.DirectorConfig
{
    class DirectorMovieEntityConfiguration : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            // Set the primary key
            builder.HasKey(d => d.Id);

            // Configure properties
            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(d => d.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(d => d.Gender)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(d => d.Age)
                .IsRequired();

            // Configure relationships
            builder.HasOne(d => d.DirectorMovie)
                .WithOne(dm => dm.Director)
                .HasForeignKey<Director>(d => d.DirectorMovieId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure table name if different from class name
            builder.ToTable("Directors");
        }
    }
}