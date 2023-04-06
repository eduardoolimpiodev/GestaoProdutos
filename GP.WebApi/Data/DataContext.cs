using GP.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GP.WebApi.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Produto> Produtos {get; set;}
        public DbSet<Representante> Representantes {get; set;}
        public DbSet<Fornecedor> Fornecedores {get; set;}
        public DbSet<ProdutoFornecedor> ProdutosFornecedores {get; set;}
    }
}