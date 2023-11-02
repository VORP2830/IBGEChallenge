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
    public class LocalityController : ControllerBase
    {
        private readonly ILocalityService _localityService;
        public LocalityController(ILocalityService localityService)
        {
            _localityService = localityService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] LocalityFilter localityFilter, [FromQuery] PageParams pageParams)
        {
            try
            {
                var result = await _localityService.GetAll(localityFilter, pageParams);
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
                    Message = "Erro ao tentar recuperar localidade",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _localityService.GetById(id);
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
                    Message = "Erro ao tentar recuperar localidade",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(LocalityDTO model)
        {
            try
            {
                var result = await _localityService.Create(model);
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
                    Message = "Erro ao tentar criar localidade",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(LocalityDTO model)
        {
            try
            {
                var result = await _localityService.Update(model);
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
                    Message = "Erro ao tentar atualizar localidade",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var result = await _localityService.Delete(id);
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
                    Message = "Erro ao tentar deletar localidade",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}