using Microsoft.AspNetCore.Mvc;

namespace IBGEChallenge.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var response = new
                {
                    DataAcesso = DateTime.Now.ToLongDateString(),
                    IPUsuario = HttpContext.Connection.RemoteIpAddress.ToString()
                };
                return Ok(response);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}