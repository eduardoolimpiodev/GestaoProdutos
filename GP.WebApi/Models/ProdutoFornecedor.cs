namespace GP.WebApi.Models
{
    public class ProdutoFornecedor
    {
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}