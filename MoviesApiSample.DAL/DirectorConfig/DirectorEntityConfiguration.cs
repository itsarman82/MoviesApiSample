using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesApiSample.Models.DirectorNamespace;

namespace MoviesApiSample.DAL.DirectorConfig
{
    class DirectorEntityConfiguration : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            // Specify the table name
            builder.ToTable("Directors");

            // Specify the primary key
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

            // Configure default values
            builder.Property(d => d.Gender)
                .HasDefaultValue("Unknown");

            // Add indexes
            builder.HasIndex(d => d.Name);
            builder.HasIndex(d => d.LastName);

            // Configure relationships
            builder.HasOne(d => d.DirectorMovie)
                .WithOne(dm => dm.Director)
                .HasForeignKey<Director>(d => d.DirectorMovieId)
                .OnDelete(DeleteBehavior.Cascade);

            // Add any additional configurations if needed
        }
    }
}