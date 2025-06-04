using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesApiSample.Models.DirectorNamespace;
using MoviesApiSample.Models.MovieNamespace;

namespace MoviesApiSample.DAL.DirectorConfig
{
    public class MovieEntityConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            
        }
    }
}