using AutoMapper;
using BCryptNet = BCrypt.Net;
using IBGEChallenge.Application.DTOs;
using IBGEChallenge.Application.Interfaces;
using IBGEChallenge.Domain.Entities;
using IBGEChallenge.Domain.Exceptions;
using IBGEChallenge.Domain.Interfaces;

namespace IBGEChallenge.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;
        public UserService(IMapper mapper, IUnitOfWork unitOfWork, ITokenService tokenService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
        }

        public async Task<UserDTO> Get(long id)
        {
            User user = await _unitOfWork.UserRepository.GetById(id);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<object> Login(UserLoginDTO model)
        {
            User userLogin = await _unitOfWork.UserRepository.GetByUserName(model.UserName);
            bool isSuccess = false;
            if (userLogin != null)
            {
                isSuccess = BCryptNet.BCrypt.Verify(model.Password, userLogin.Password);
                if (userLogin.Active == false)
                {
                    throw new IBGEException("Conta desativada. Entre em contato com o administrador");
                }
            }
            if (!isSuccess)
            {
                throw new IBGEException("Usuário ou senha incorretos");
            }
            if(isSuccess)
            {
                var token = await _tokenService.GenerateToken(userLogin.Id, userLogin.UserName);
                return new {
                        name = userLogin.Name,
                        token = token
                };
            }
            throw new IBGEException("Usuário ou senha incorretos");
        }

        public async Task<object> Register(UserUpdateDTO model)
        {
            User userEmail = await _unitOfWork.UserRepository.GetByEmail(model.Email);
            if(userEmail != null)
            {
                throw new IBGEException("O endereço de e-mail já está em uso");
            }
            User userLogin = await _unitOfWork.UserRepository.GetByUserName(model.UserName);
            if(userLogin != null)
            {
                throw new IBGEException("O nome de usuário já está em uso");
            }
            User user = _mapper.Map<User>(model);
            user.SetPassword(BCryptNet.BCrypt.HashPassword(model.Password));
            user.SetActive(true);
            _unitOfWork.UserRepository.Add(user);
            await _unitOfWork.SaveChangesAsync();
            var token = await _tokenService.GenerateToken(user.Id, user.UserName);
            return new {
                    name = user.Name,
                    token = token
            };
        }

        public async Task<UserDTO> Update(UserUpdateDTO model, long userId)
        {
            if(userId != model.Id)
            {
                throw new IBGEException("Você não tem autorização para modificar as informações de outro usuário");
            }
            User user = await _unitOfWork.UserRepository.GetById(model.Id);
            if(model.UserName != user.UserName)
            {
                throw new IBGEException("Não é possível alterar o nome de usuário");
            }
            if(string.IsNullOrEmpty(model.Password))
            {
                model.Password = user.Password;
            }
            else
            {
                model.Password = BCryptNet.BCrypt.HashPassword(model.Password);
            }
            User userUpdate = _mapper.Map<User>(model);
            _unitOfWork.UserRepository.Update(userUpdate);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<UserDTO>(userUpdate);
        }
    }
}