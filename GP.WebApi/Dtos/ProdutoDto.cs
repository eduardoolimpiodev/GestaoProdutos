using System;
using System.Collections.Generic;

namespace GP.WebApi.Models
{
    public class ProdutoDto
    {
        
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public string Peso { get; set; }
        public string Marca { get; set; }
        public bool Situacao { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
    }
}