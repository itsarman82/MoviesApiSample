using Microsoft.EntityFrameworkCore;
using MoviesApiSample.Models.ActorNamespace;

namespace MoviesApiSample.DAL.ActorConfig
{
    class ActorEntityConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Actor> builder)
        {
            // TODO: Write Configurations for Actor entity
            throw new NotImplementedException();
        }
    }
}
