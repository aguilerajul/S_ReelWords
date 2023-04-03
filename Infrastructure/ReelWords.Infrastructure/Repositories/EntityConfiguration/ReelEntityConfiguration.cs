using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ReelWords.Infrastructure.Repositories.EntityConfiguration
{
    class ReelEntityConfiguration : IEntityTypeConfiguration<Domain.Entities.Reel>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Reel> builder)
        {
            builder
                .HasKey(k => k.Id);
        }
    }
}
