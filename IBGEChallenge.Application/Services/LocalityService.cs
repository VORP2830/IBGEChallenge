using AutoMapper;
using IBGEChallenge.Application.DTOs;
using IBGEChallenge.Application.Interfaces;
using IBGEChallenge.Domain.Entities;
using IBGEChallenge.Domain.Filter;
using IBGEChallenge.Domain.Interfaces;
using IBGEChallenge.Domain.Pagination;

namespace IBGEChallenge.Application.Services
{
    public class LocalityService : ILocalityService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public LocalityService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<PageList<LocalityDTO>> GetAll(LocalityFilter localityFilter, PageParams pageParams)
        {
            var localityPage = await _unitOfWork.LocalityRepository.GetAll(localityFilter, pageParams);
            if (localityPage == null) return null;
            var localityDTOs = _mapper.Map<IEnumerable<LocalityDTO>>(localityPage.Items);
            return new PageList<LocalityDTO>(localityDTOs.ToList(), localityPage.TotalCount, localityPage.CurrentPage, localityPage.PageSize);
        }
        public async Task<LocalityDTO> GetById(long id)
        {
            Locality locality = await _unitOfWork.LocalityRepository.GetById(id);
            return _mapper.Map<LocalityDTO>(locality);
        }
        public async Task<LocalityDTO> Create(LocalityDTO model)
        {
            Locality locality = _mapper.Map<Locality>(model);
            _unitOfWork.LocalityRepository.Add(locality);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<LocalityDTO>(locality);
        }
        public async Task<LocalityDTO> Update(LocalityDTO model)
        {
            Locality locality = _mapper.Map<Locality>(model);
            _unitOfWork.LocalityRepository.Update(locality);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<LocalityDTO>(locality);
        }
        public async Task<LocalityDTO> Delete(long id)
        {
            Locality locality = await _unitOfWork.LocalityRepository.GetById(id);
            locality.SetActive(false);
            _unitOfWork.LocalityRepository.Update(locality);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<LocalityDTO>(locality);
        }
    }
}