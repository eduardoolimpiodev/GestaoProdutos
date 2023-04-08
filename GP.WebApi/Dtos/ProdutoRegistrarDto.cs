using System;
using System.Collections.Generic;
using GP.WebApi.Models;

namespace GP.WebApi.Dtos
{
    /// <summary>
    /// Este é o Dto de Produto para registrar.
    /// </summary>
    public class ProdutoRegistrarDto
    {
        /// <summary>
        /// Identificador e chave do banco.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nome do produto.
        /// </summary>
        public string Nome { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public string Peso { get; set; }
        public string Marca { get; set; }
        public bool Situacao { get; set; } = true;
        public DateTime DataFabricacao { get; set; } = DateTime.Now;
        public DateTime DataValidade { get; set; }
        
    }
}