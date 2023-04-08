using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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
        public readonly IRepository _repo;
        private readonly IMapper _mapper;

        public ProdutoController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var produtos = _repo.GetAllProdutos(true);

            return Ok(_mapper.Map<IEnumerable<ProdutoDto>>(produtos));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var produto = _repo.GetProdutoById(id, false);
            if (produto == null) return BadRequest("Produto não encontrado.");

            var produtoDto = _mapper.Map<ProdutoDto>(produto);

            return Ok(produtoDto);
        }

        //Query String  api/produto/byid?id=1
        // [HttpGet("byId")]
        // public IActionResult QueryStringGetById(int id)
        // {
        //     var produto = _repo.Produtos.FirstOrDefault(prod => prod.Id == id);
        //     if (produto == null) return BadRequest("Produto não encontrado.");
        //     return Ok(produto);
        // }

        // // byName?nome=Arroz 1Kg&marca=Sepe   
        // // [HttpGet("ByName")]
        // // public IActionResult GetByName(string nome, string marca)
        // // {
        // //     var produto = _repo.Produtos.FirstOrDefault(prod => prod.Nome.Contains(nome)
        // //     && prod.Marca.Contains(marca));
        // //     if (produto == null) return BadRequest("Produto não encontrado.");
        // //     return Ok(produto);
        // // }

        [HttpPost]
        public IActionResult Post(ProdutoDto model)
        {
            var produto = _mapper.Map<Produto>(model);

            _repo.Add(produto);
            if (_repo.SaveChanges())
            {
                return Created($"/api/produto/{model.Id}", _mapper.Map<ProdutoDto>(produto));
            }

            return BadRequest("Aluno não cadastrado");
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, ProdutoDto model)
        {
            var produto = _repo.GetProdutoById(id);
            if (produto == null) return BadRequest("Produto não encontrado.");

            _mapper.Map(model, produto);

            _repo.Update(produto);
            if (_repo.SaveChanges())
            {
                return Created($"/api/produto/{model.Id}", _mapper.Map<ProdutoDto>(produto));
            }

            return BadRequest("Produto não atualizado.");

        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, ProdutoDto model)
        {
            var produto = _repo.GetProdutoById(id);
            if (produto == null) return BadRequest("Produto não encontrado.");

            _mapper.Map(model, produto);

            _repo.Update(produto);
            if (_repo.SaveChanges())
            {
                return Created($"/api/produto/{model.Id}", _mapper.Map<ProdutoDto>(produto));
            }

            return BadRequest("Produto não atualizado.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var produto = _repo.GetProdutoById(id);
            if (produto == null) return BadRequest("Produto não encontrado.");

            _repo.Delete(produto);
            if (_repo.SaveChanges())
            {
                return Ok("Produto deletado.");
            }

            return BadRequest("Produto não deletado.");
        }

    }
}