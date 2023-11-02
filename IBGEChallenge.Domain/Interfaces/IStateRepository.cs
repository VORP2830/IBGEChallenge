using IBGEChallenge.Domain.Entities;
using IBGEChallenge.Domain.Filter;
using IBGEChallenge.Domain.Pagination;

namespace IBGEChallenge.Domain.Interfaces
{
    public interface IStateRepository : IGenericRepository<State>
    {
        Task<PageList<State>> GetAll(StateFilter stateFilter, PageParams pageParams);
        Task<State> GetById(long id);
    }
}