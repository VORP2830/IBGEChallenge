using IBGEChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IBGEChallenge.Infra.Data.EntitiesConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                        .HasMaxLength(50)
                        .IsRequired();

            builder.Property(s => s.Email)
                        .HasMaxLength(50)
                        .IsRequired();
            
            builder.Property(s => s.Password)
                        .HasMaxLength(100)
                        .IsRequired();
            
        }
    }
}