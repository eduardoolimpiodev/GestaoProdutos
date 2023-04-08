using System;
using System.Collections.Generic;

namespace GP.WebApi.Models
{
    public class Produto
    {
        public Produto() { }


        public Produto(int id, string nome, int codigo, string descricao, string peso, string marca, bool situacao, DateTime dataFabricacao, DateTime dataValidade)
        {
            this.Id = id;
            this.Nome = nome;
            this.Codigo = codigo;
            this.Descricao = descricao;
            this.Peso = peso;
            this.Marca = marca;
            this.Situacao = situacao;
            this.DataFabricacao = dataFabricacao;
            this.DataValidade = dataValidade;

        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public string Peso { get; set; }
        public string Marca { get; set; }
        public int Validade { get; set; }
        public bool Situacao { get; set; } = true;
        public DateTime DataFabricacao { get; set; } = DateTime.Now;
        public DateTime DataValidade { get; set; }
        public IEnumerable<ProdutoFornecedor> ProdutosFornecedores { get; set; }
    }
}