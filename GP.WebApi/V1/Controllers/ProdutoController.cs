using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GP.WebApi.Data;
using GP.WebApi.V1.Dtos;
using GP.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GP.WebApi.V1.Models;
using System.Threading.Tasks;
using GP.WebApi.Helpers;

namespace GP.WebApi.V1.Controllers
{
    /// <summary>
    /// Versão 1 do meu controlador de Produtos.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProdutoController : ControllerBase
    {
        public readonly IRepository _repo;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public ProdutoController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        /// <summary>
        /// Método responsável por retornar todos os meus produtos.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]PageParams pageParams)
        {
            var produtos = await _repo.GetAllProdutosAsync(pageParams, true);

            var produtosResult = _mapper.Map<IEnumerable<ProdutoDto>>(produtos);

            Response.AddPagination(produtos.CurrentPage, produtos.PageSize, produtos.TotalCount, produtos.TotalPages);

            return Ok(produtosResult);
        }


        /// <summary>
        /// Método responsável para retornar apenas um único produto por meio de Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        public IActionResult Post(ProdutoRegistrarDto model)
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
        public IActionResult Put(int id, ProdutoRegistrarDto model)
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

        // [HttpPatch("{id}")]
        // public IActionResult Patch(int id, ProdutoRegistrarDto model)
        // {
        //     var produto = _repo.GetProdutoById(id);
        //     if (produto == null) return BadRequest("Produto não encontrado.");

        //     _mapper.Map(model, produto);

        //     _repo.Update(produto);
        //     if (_repo.SaveChanges())
        //     {
        //         return Created($"/api/produto/{model.Id}", _mapper.Map<ProdutoDto>(produto));
        //     }

        //     return BadRequest("Produto não atualizado.");
        // }

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