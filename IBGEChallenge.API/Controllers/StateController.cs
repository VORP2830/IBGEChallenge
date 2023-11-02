using IBGEChallenge.Application.DTOs;
using IBGEChallenge.Application.Interfaces;
using IBGEChallenge.Domain.Exceptions;
using IBGEChallenge.Domain.Filter;
using IBGEChallenge.Domain.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IBGEChallenge.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StateController : ControllerBase
    {
        private readonly IStateService _stateService;
        public StateController(IStateService stateService)
        {
            _stateService = stateService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] StateFilter stateFilter, [FromQuery] PageParams pageParams)
        {
            try
            {
                var result = await _stateService.GetAll(stateFilter, pageParams);
                if(result == null) return NoContent();
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
                    Message = "Erro ao tentar recuperar estado",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _stateService.GetById(id);
                if(result == null) return NoContent();
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
                    Message = "Erro ao tentar recuperar estado",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(StateDTO model)
        {
            try
            {
                var result = await _stateService.Create(model);
                if(result == null) return NoContent();
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
                    Message = "Erro ao tentar criar estado",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(StateDTO model)
        {
            try
            {
                var result = await _stateService.Update(model);
                if(result == null) return NoContent();
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
                    Message = "Erro ao tentar atualizar estado",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var result = await _stateService.Delete(id);
                if(result == null) return NoContent();
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
                    Message = "Erro ao tentar deletar estado",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}