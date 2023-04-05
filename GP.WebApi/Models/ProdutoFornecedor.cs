namespace GP.WebApi.Models
{
    public class ProdutoFornecedor
    {
        public ProdutoFornecedor() { }

        public ProdutoFornecedor(int produtoId, int fornecedorId)
        {
            this.ProdutoId = produtoId;
            this.FornecedorId = fornecedorId;

        }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}