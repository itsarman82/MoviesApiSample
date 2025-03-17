using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesApiSample.Models.DirectorNamespace;

namespace MoviesApiSample.DAL.DirectorConfig
{
    class DirectorMovieEntityConfiguration : IEntityTypeConfiguration<Director>
    {
        // Constants for property configurations
        private const int NameMaxLength = 100;
        private const int LastNameMaxLength = 100;
        private const int GenderMaxLength = 10;

        public void Configure(EntityTypeBuilder<Director> builder)
        {
            // Set the primary key
            builder.HasKey(d => d.Id);

            // Configure table name if different from class name
            builder.ToTable("Directors");
        }
    }
}