using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesApiSample.Models.MovieNamespace;

namespace MoviesApiSample.DAL.MovieConfig
{
    class MovieEntityConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            // TODO: Write configuration for Movie entity
            throw new NotImplementedException();
        }
    }
}
