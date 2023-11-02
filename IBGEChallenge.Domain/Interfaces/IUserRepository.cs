using IBGEChallenge.Domain.Entities;

namespace IBGEChallenge.Domain.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetById(long id);
        Task<User> GetByEmail(string email);
        Task<User> GetByUserName(string userName);
    }
}