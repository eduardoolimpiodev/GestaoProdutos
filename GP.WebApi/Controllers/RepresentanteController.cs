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

        public readonly IRepository _repo;

        public RepresentanteController(DataContext context, IRepository repo)
        {
            _context = context;
            _repo = repo;

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
            _repo.Add(representante);

           if (_repo.SaveChanges())
           {
                 return Ok(representante);
           }

           return BadRequest("Representante não cadastrado.");

            
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Representante representante)
        {
            var repre = _context.Representantes.AsNoTracking().FirstOrDefault(repre => repre.Id == id);
            if(repre == null) return BadRequest("Representante não encontrado.");

            _repo.Update(representante);

           if (_repo.SaveChanges())
           {
                 return Ok(representante);
           }

           return BadRequest("Representante não atualizado.");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Representante representante)
        {
            var repre = _context.Representantes.AsNoTracking().FirstOrDefault(repre => repre.Id == id);
            if(repre == null) return BadRequest("Representante não encontrado.");

            _repo.Update(representante);

           if (_repo.SaveChanges())
           {
                 return Ok(representante);
           }

           return BadRequest("Representante não atualizado.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var repre = _context.Representantes.FirstOrDefault(repre => repre.Id == id);
            if(repre == null) return BadRequest("Representante não encontrado.");
            
            _repo.Delete(repre);

           if (_repo.SaveChanges())
           {
                 return Ok("Representante deletado.");
           }

           return BadRequest("Representante não deletado.");
        }

    }
}