using AutoMapper;
using IBGEChallenge.Application.DTOs;
using IBGEChallenge.Domain.Entities;

namespace IBGEChallenge.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Locality, LocalityDTO>().ReverseMap();
            CreateMap<State, StateDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserUpdateDTO>().ReverseMap();
        }
    }
}