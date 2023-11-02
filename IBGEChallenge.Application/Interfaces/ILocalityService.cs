using IBGEChallenge.Application.DTOs;
using IBGEChallenge.Domain.Filter;
using IBGEChallenge.Domain.Pagination;

namespace IBGEChallenge.Application.Interfaces
{
    public interface ILocalityService
    {
        Task<PageList<LocalityDTO>> GetAll(LocalityFilter localityFilter, PageParams pageParams);
        Task<LocalityDTO> GetById(long id);
        Task<LocalityDTO> Create(LocalityDTO model);
        Task<LocalityDTO> Update(LocalityDTO model);
        Task<LocalityDTO> Delete(long id); 
    }
}