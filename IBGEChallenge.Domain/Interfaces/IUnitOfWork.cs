namespace IBGEChallenge.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IStateRepository StateRepository { get; }
        ILocalityRepository LocalityRepository { get; }
        IUserRepository UserRepository { get; }
        Task<bool> SaveChangesAsync();  
    }
}