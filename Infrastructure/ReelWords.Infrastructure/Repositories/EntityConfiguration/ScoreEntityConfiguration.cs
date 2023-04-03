using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ReelWords.Infrastructure.Repositories.EntityConfiguration
{
    class ScoreEntityConfiguration : IEntityTypeConfiguration<Domain.Entities.Score>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Score> builder)
        {
            builder
                .HasKey(k => k.Id);
        }
    }
}
