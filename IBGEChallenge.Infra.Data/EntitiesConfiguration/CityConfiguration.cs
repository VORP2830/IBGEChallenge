using IBGEChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IBGEChallenge.Infra.Data.EntitiesConfiguration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                        .HasMaxLength(50)
                        .IsRequired();

            builder.HasMany(c => c.Localities)
                    .WithOne(l => l.City)
                    .HasForeignKey(l => l.CityId);
        }
    }
}