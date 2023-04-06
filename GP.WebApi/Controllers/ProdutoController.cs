using System;
using System.Collections.Generic;
using System.Linq;
using GP.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GP.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        public List<Produto> Produtos = new List<Produto> () {
            new Produto() {
            Id = 1,
            Nome = "Arroz 1Kg",
            Descricao = "Arroz Japonês",
            Marca = "Sepe",
            Situacao = "Ativo",
            DataFabricacao = DateTime.Now,
            DataValidade = DateTime.Now,
            },
            new Produto() {
            Id = 2,
            Nome = "Feijão 1Kg",
            Descricao = "Feijão Preto",
            Marca = "ComBrasil",
            Situacao = "Inativo",
            DataFabricacao = DateTime.Now,
            DataValidade = DateTime.Now,
            },
            new Produto() {
            Id = 3,
            Nome = "Picanha a vácuo 1Kg",
            Descricao = "Picanha a Vácuo",
            Marca = "Do Lula",
            Situacao = "Ativo",
            DataFabricacao = DateTime.Now,
            DataValidade = DateTime.Now,
            },
        };
        public ProdutoController() { }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Produtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var produto = Produtos.FirstOrDefault(prod => prod.Id == id);
            if (produto == null) return BadRequest("Produto não encontrado.");
            return Ok(produto);
        }

        //Query String  api/produto/byid?id=1
        [HttpGet("byId")]
        public IActionResult QueryStringGetById(int id)
        {
            var produto = Produtos.FirstOrDefault(prod => prod.Id == id);
            if (produto == null) return BadRequest("Produto não encontrado.");
            return Ok(produto);
        }

        // byName?nome=Arroz 1Kg&marca=Sepe   
        [HttpGet("ByName")]
        public IActionResult GetByName(string nome, string marca)
        {
            var produto = Produtos.FirstOrDefault(prod => prod.Nome.Contains(nome)
            && prod.Marca.Contains(marca));
            if (produto == null) return BadRequest("Produto não encontrado.");
            return Ok(produto);
        }

        [HttpPost]
        public IActionResult Post(Produto produto)
        {
           return Ok(produto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Produto produto)
        {
           return Ok(produto);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Produto produto)
        {
           return Ok(produto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           return Ok();
        }

    }
}