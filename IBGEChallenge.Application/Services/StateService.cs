using AutoMapper;
using IBGEChallenge.Application.DTOs;
using IBGEChallenge.Application.Interfaces;
using IBGEChallenge.Domain.Entities;
using IBGEChallenge.Domain.Filter;
using IBGEChallenge.Domain.Interfaces;
using IBGEChallenge.Domain.Pagination;

namespace IBGEChallenge.Application.Services
{
    public class StateService : IStateService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public StateService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<PageList<StateDTO>> GetAll(StateFilter stateFilter, PageParams pageParams)
        {
            var statePage = await _unitOfWork.StateRepository.GetAll(stateFilter, pageParams);
            if (statePage == null) return null;
            var stateDTOs = _mapper.Map<IEnumerable<StateDTO>>(statePage.Items);
            return new PageList<StateDTO>(stateDTOs.ToList(), statePage.TotalCount, statePage.CurrentPage, statePage.PageSize);
        }
        public async Task<StateDTO> GetById(long id)
        {
            State state = await _unitOfWork.StateRepository.GetById(id);
            return _mapper.Map<StateDTO>(state);
        }
        public async Task<StateDTO> Create(StateDTO model)
        {
            State state = _mapper.Map<State>(model);
            _unitOfWork.StateRepository.Add(state);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<StateDTO>(state);
        }
        public async Task<StateDTO> Update(StateDTO model)
        {
            State state = _mapper.Map<State>(model);
            _unitOfWork.StateRepository.Update(state);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<StateDTO>(state);
        }
        public async Task<StateDTO> Delete(long id)
        {
            State state = await _unitOfWork.StateRepository.GetById(id);
            state.SetActive(false);
            _unitOfWork.StateRepository.Update(state);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<StateDTO>(state);
        }
    }
}