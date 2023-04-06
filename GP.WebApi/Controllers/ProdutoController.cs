using System;
using System.Collections.Generic;
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
    }
}