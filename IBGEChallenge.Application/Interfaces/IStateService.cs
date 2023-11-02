using IBGEChallenge.Application.DTOs;
using IBGEChallenge.Domain.Filter;
using IBGEChallenge.Domain.Pagination;

namespace IBGEChallenge.Application.Interfaces
{
    public interface IStateService
    {
        Task<PageList<StateDTO>> GetAll(StateFilter stateFilter, PageParams pageParams);
        Task<StateDTO> GetById(long id);
        Task<StateDTO> Create(StateDTO model);
        Task<StateDTO> Update(StateDTO model);
        Task<StateDTO> Delete(long id); 
    }
}