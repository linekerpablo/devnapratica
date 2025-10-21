using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevNaPraticaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStatus()
        {
            return Ok(new { message = "API funcionando!" });
        }
    }
}
