using System.Linq;
using GP.WebApi.Data;
using GP.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GP.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RepresentanteController : ControllerBase
    {
        private readonly DataContext _context;
        public RepresentanteController(DataContext context)
        {
            _context = context;

        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Representantes);
        }

        
        //Query String  api/produto/byid?id=1
        [HttpGet("byId")]
        public IActionResult QueryStringGetById(int id)
        {
            var representante = _context.Representantes.FirstOrDefault(repre => repre.Id == id);
            if (representante == null) return BadRequest("Representante não encontrado.");
            return Ok(representante);
        }

        // byName?nome=Arroz 1Kg&marca=Sepe   
        [HttpGet("ByName")]
        public IActionResult GetByName(string nome)
        {
            var repre = _context.Representantes.FirstOrDefault(prod => prod.Nome.Contains(nome));
            if (repre == null) return BadRequest("Produto não encontrado.");
            return Ok(nome);
        }

        [HttpPost]
        public IActionResult Post(Representante representante)
        {
            _context.Add(representante);
            _context.SaveChanges();
            return Ok(representante);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Representante representante)
        {
            var repre = _context.Representantes.AsNoTracking().FirstOrDefault(repre => repre.Id == id);
            if(repre == null) return BadRequest("Representante não encontrado.");

            _context.Update(representante);
            _context.SaveChanges();
            return Ok(representante);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Representante representante)
        {
            var repre = _context.Representantes.AsNoTracking().FirstOrDefault(repre => repre.Id == id);
            if(repre == null) return BadRequest("Representante não encontrado.");

            _context.Update(representante);
            _context.SaveChanges();
            return Ok(representante);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Representante = _context.Representantes.FirstOrDefault(repre => repre.Id == id);
            if(Representante == null) return BadRequest("Representante não encontrado.");
            _context.Remove(Representante);
            _context.SaveChanges();
            return Ok();
        }

    }
}