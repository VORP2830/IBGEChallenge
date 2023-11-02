using IBGEChallenge.Domain.Interfaces;

namespace IBGEChallenge.Infra.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IStateRepository StateRepository => new StateRepository(_context);
        public ILocalityRepository LocalityRepository => new LocalityRepository(_context);
        public IUserRepository UserRepository => new UserRepository(_context);
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}