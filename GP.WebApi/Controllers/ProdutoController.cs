using System;
using System.Collections.Generic;
using System.Linq;
using GP.WebApi.Data;
using GP.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GP.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly DataContext _context;
        public readonly IRepository _repo;

        public ProdutoController(DataContext context, IRepository repo)
        {
            _repo = repo;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Produtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(prod => prod.Id == id);
            if (produto == null) return BadRequest("Produto não encontrado.");
            return Ok(produto);
        }

        //Query String  api/produto/byid?id=1
        [HttpGet("byId")]
        public IActionResult QueryStringGetById(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(prod => prod.Id == id);
            if (produto == null) return BadRequest("Produto não encontrado.");
            return Ok(produto);
        }

        // byName?nome=Arroz 1Kg&marca=Sepe   
        [HttpGet("ByName")]
        public IActionResult GetByName(string nome, string marca)
        {
            var produto = _context.Produtos.FirstOrDefault(prod => prod.Nome.Contains(nome)
            && prod.Marca.Contains(marca));
            if (produto == null) return BadRequest("Produto não encontrado.");
            return Ok(produto);
        }

        [HttpPost]
        public IActionResult Post(Produto produto)
        {
            _repo.Add(produto);

           if (_repo.SaveChanges())
           {
                 return Ok(produto);
           }

           return BadRequest("Produto não cadastrado.");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Produto produto)
        {
            var prod = _context.Produtos.AsNoTracking().FirstOrDefault(prod => prod.Id == id);
            if (prod == null) return BadRequest("Produto não encontrado.");
            _context.Update(produto);
            _context.SaveChanges();
            return Ok(produto);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Produto produto)
        {
            var prod = _context.Produtos.AsNoTracking().FirstOrDefault(prod => prod.Id == id);
            if (prod == null) return BadRequest("Produto não encontrado.");
            _context.Update(produto);
            _context.SaveChanges();
            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(prod => prod.Id == id);
            if (produto == null) return BadRequest("Produto não encontrado.");
            _context.Remove(produto);
            _context.SaveChanges();
            return Ok(produto);
        }

    }
}