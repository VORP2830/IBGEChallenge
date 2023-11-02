using IBGEChallenge.Domain.Entities;
using IBGEChallenge.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IBGEChallenge.Infra.Data.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public Task<User> GetByEmail(string email)
        {
            return _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
        public Task<User> GetById(long id)
        {
            return _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }
        public Task<User> GetByUserName(string userName)
        {
            return _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        }
    }
}