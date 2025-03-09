using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesApiSample.Models.ActorNamespace;

namespace MoviesApiSample.DAL.ActorConfig
{
    class ActorEntityConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            // Table name
            builder.ToTable("Actors");

            // Primary key
            builder.HasKey(a => a.Id);

            // Properties
            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd();

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Gender)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(a => a.Age)
                .IsRequired();

            // Relationships
            builder.HasOne(a => a.ActorMovie)
                .WithMany(am => am.Actors)
                .HasForeignKey(a => a.ActorMovieId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
