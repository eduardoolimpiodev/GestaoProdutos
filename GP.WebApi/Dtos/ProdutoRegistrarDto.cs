using System;
using System.Collections.Generic;
using GP.WebApi.Models;

namespace GP.WebApi.Dtos
{
    public class ProdutoRegistrarDto
    {
        public int Id { get; set; }
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