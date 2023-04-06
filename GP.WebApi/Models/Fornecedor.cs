using System.Collections.Generic;

namespace GP.WebApi.Models
{
    public class Fornecedor

    {
        public Fornecedor() { }


        public Fornecedor(int id, string nome, string descricao, string cNPJ, int produtoId, int representanteId)
        {
            this.Id = id;
            this.Nome = nome;
            this.Descricao = descricao;
            this.CNPJ = cNPJ;
            this.ProdutoId = produtoId;
            this.RepresentanteId = representanteId;

        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string CNPJ { get; set; }

        public int ProdutoId { get; set; }
        public int RepresentanteId { get; set; }
        public Produto Produto { get; set; }
        public IEnumerable<ProdutoFornecedor> ProdutosFornecedores { get; set; }
    }
}