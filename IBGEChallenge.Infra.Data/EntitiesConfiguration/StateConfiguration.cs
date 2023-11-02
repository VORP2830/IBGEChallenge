using IBGEChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IBGEChallenge.Infra.Data.EntitiesConfiguration
{
    public class StateConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                        .HasMaxLength(50)
                        .IsRequired();

            builder.HasMany(s => s.Localities)
                    .WithOne(c => c.State)
                    .HasForeignKey(c => c.StateId);
        }
    }
}