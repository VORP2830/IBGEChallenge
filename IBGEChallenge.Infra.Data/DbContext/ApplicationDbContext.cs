using IBGEChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IBGEChallenge.Infra.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Locality> Localities { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.ModifiedAt = DateTime.UtcNow;
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}