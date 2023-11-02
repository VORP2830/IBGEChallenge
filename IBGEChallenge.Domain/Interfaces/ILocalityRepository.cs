using IBGEChallenge.Domain.Entities;
using IBGEChallenge.Domain.Filter;
using IBGEChallenge.Domain.Pagination;

namespace IBGEChallenge.Domain.Interfaces
{
    public interface ILocalityRepository : IGenericRepository<Locality>
    {
        Task<PageList<Locality>> GetAll(LocalityFilter localityFilter, PageParams pageParams);
        Task<Locality> GetById(long id);
    }
}