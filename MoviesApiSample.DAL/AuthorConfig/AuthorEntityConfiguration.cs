using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesApiSample.Models.AuthorNamespace;

namespace MoviesApiSample.DAL.AuthorConfig
{
    class AuthorEntityConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            // TODO: Write configuraion for Author entity
            throw new NotImplementedException();
        }
    }
}
