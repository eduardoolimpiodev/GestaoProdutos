using Microsoft.AspNetCore.Mvc;

namespace GP.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RepresentanteController : ControllerBase
    {
        public RepresentanteController() { }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Roberto Eduardo, Roberto, Eduardo");
        }
    }
}