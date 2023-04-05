using System;
using System.Collections.Generic;

namespace GP.WebApi.Models
{
    public class Produto
    {
        public Produto() { }

        public Produto(int id, string nome, string descricao, bool situacao, DateTime dataFabricacao, DateTime dataValidade)
        {
            this.Id = id;
            this.Nome = nome;
            this.Descricao = descricao;
            this.Situacao = situacao;
            this.DataFabricacao = dataFabricacao;
            this.DataValidade = dataValidade;

        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Situacao { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public IEnumerable<ProdutoFornecedor> ProdutosFornecedores { get; set; }
    }
}