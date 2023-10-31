using IBGEChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IBGEChallenge.Infra.Data.EntitiesConfiguration
{
    public class LocalityConfiguration : IEntityTypeConfiguration<Locality>
    {
        public void Configure(EntityTypeBuilder<Locality> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.IBGECode)
                        .HasMaxLength(25)
                        .IsRequired();
        }
    }
}