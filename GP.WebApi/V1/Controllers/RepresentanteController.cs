using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GP.WebApi.Data;
using GP.WebApi.V1.Dtos;
using GP.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GP.WebApi.V1.Models;

namespace GP.WebApi.v1.Controllers
{
    /// <summary>
    /// Versão 1 do meu controlador de Representante.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class RepresentanteController : ControllerBase
    {


        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public RepresentanteController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }


        [HttpGet]
        public IActionResult Get()
        {
            var representantes = _repo.GetAllRepresentantes(true);

            return Ok(_mapper.Map<IEnumerable<RepresentanteDto>>(representantes));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var representante = _repo.GetRepresentanteById(id, false);
            if (representante == null) return BadRequest("Representante não encontrado.");

            var representanteDto = _mapper.Map<RepresentanteDto>(representante);

            return Ok(representanteDto);
        }

        // //Query String  api/produto/byid?id=1
        // [HttpGet("byId")]
        // public IActionResult QueryStringGetById(int id)
        // {
        //     var representante = _context.Representantes.FirstOrDefault(repre => repre.Id == id);
        //     if (representante == null) return BadRequest("Representante não encontrado.");
        //     return Ok(representante);
        // }

        // // byName?nome=Arroz 1Kg&marca=Sepe   
        // [HttpGet("ByName")]
        // public IActionResult GetByName(string nome)
        // {
        //     var repre = _context.Representantes.FirstOrDefault(prod => prod.Nome.Contains(nome));
        //     if (repre == null) return BadRequest("Produto não encontrado.");
        //     return Ok(nome);
        // }

        [HttpPost]
        public IActionResult Post(RepresentanteRegistrarDto model)
        {
            var representante = _mapper.Map<Representante>(model);

            _repo.Add(representante);
            if (_repo.SaveChanges())
            {
                return Created($"/api/representante/{model.Id}", _mapper.Map<RepresentanteDto>(representante));
            }

            return BadRequest("Representante não cadastrado");


        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, RepresentanteRegistrarDto model)
        {
            var representante = _repo.GetRepresentanteById(id);
            if (representante == null) return BadRequest("Representante não encontrado.");

            _mapper.Map(model, representante);

            _repo.Update(representante);
            if (_repo.SaveChanges())
            {
                return Created($"/api/produto/{model.Id}", _mapper.Map<RepresentanteDto>(representante));
            }

            return BadRequest("Representante não atualizado.");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, RepresentanteRegistrarDto model)
        {
            var representante = _repo.GetRepresentanteById(id);
            if (representante == null) return BadRequest("Representante não encontrado.");

            _mapper.Map(model, representante);

            _repo.Update(representante);
            if (_repo.SaveChanges())
            {
                return Created($"/api/representante/{model.Id}", _mapper.Map<RepresentanteDto>(representante));
            }

            return BadRequest("Representante não atualizado.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var representante = _repo.GetRepresentanteById(id);
            if (representante == null) return BadRequest("Representante não encontrado.");

            _repo.Delete(representante);
            if (_repo.SaveChanges())
            {
                return Ok("Representante deletado.");
            }

            return BadRequest("Representante não deletado.");
        }

    }
}