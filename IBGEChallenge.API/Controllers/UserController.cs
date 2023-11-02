using IBGEChallenge.API.Extensions;
using IBGEChallenge.Application.DTOs;
using IBGEChallenge.Application.Interfaces;
using IBGEChallenge.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IBGEChallenge.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserUpdateDTO model)
        {
            try
            {
                var result = await _userService.Register(model);
                return Ok(result);
            }
            catch(IBGEException ex)
            {
                var errorResponse = new
                {
                    Message = ex.Message
                };
                return BadRequest(errorResponse);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao tentar adicionar usuário"
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDTO model)
        {
            try
            {
                var result = await _userService.Login(model);
                return Ok(result);
            }
            catch (IBGEException ex)
            {
                var errorResponse = new 
                {
                    Message = ex.Message
                };
                return BadRequest(errorResponse);
            }
            catch (Exception)
            {
                var errorResponse = new 
                {
                    Message = "Erro ao tentar fazer login"
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _userService.Get(User.GetUserId());
                return Ok(result);
            }
            catch (IBGEException ex)
            {
                var errorResponse = new 
                {
                    Message = ex.Message
                };
                return BadRequest(errorResponse);
            }
            catch (Exception)
            {
                var errorResponse = new 
                {
                    Message = "Erro ao tentar pegar usuário",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpPut("UpdatePersonalUser")]
        public async Task<IActionResult> UpdatePerosnalUser(UserUpdateDTO model)
        {
            try
            {
                var result = await _userService.Update(model, User.GetUserId());
                return Ok(result);
            }
            catch(IBGEException ex)
            {
                var errorResponse = new
                {
                    Message = ex.Message
                };
                return BadRequest(errorResponse);
            }
            catch (Exception)
            {
                var errorResponse = new
                {
                    Message = "Erro ao tentar alterar usuário"
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}