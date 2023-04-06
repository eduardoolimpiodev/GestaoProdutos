using Microsoft.AspNetCore.Mvc;

namespace GP.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        public ProdutoController() { }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Arroz, Feijão, Picanha");
        }
    }
}