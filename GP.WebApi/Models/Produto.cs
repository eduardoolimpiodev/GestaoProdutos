using System;
using System.Collections.Generic;

namespace GP.WebApi.Models
{
    public class Produto
    {
        public Produto() { }


        public Produto(int id, string nome, string descricao, string marca, string situacao, string dataFabricacao, string dataValidade)
        {
            this.Id = id;
            this.Nome = nome;
            this.Descricao = descricao;
            this.Marca = marca;
            this.Situacao = situacao;
            this.DataFabricacao = dataFabricacao;
            this.DataValidade = dataValidade;

        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Marca { get; set; }
        public string Situacao { get; set; }
        public string DataFabricacao { get; set; }
        public string DataValidade { get; set; }
        public IEnumerable<ProdutoFornecedor> ProdutosFornecedores { get; set; }
    }
}