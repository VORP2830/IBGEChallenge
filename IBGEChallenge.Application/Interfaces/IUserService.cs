using IBGEChallenge.Application.DTOs;

namespace IBGEChallenge.Application.Interfaces
{
    public interface IUserService
    {
        Task<Object> Register(UserUpdateDTO model);
        Task<Object> Login(UserLoginDTO model);
        Task<UserDTO> Update(UserUpdateDTO model, long userId);
        Task<UserDTO> Get(long id);
    }
}