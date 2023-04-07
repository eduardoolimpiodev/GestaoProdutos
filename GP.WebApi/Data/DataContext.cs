using System.Collections.Generic;
using GP.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GP.WebApi.Data
{
    public class DataContext : DbContext
    {   
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Produto> Produtos {get; set;}
        public DbSet<Representante> Representantes {get; set;}
        public DbSet<Fornecedor> Fornecedores {get; set;}
        public DbSet<ProdutoFornecedor> ProdutosFornecedores {get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProdutoFornecedor>()
                .HasKey(PF => new {PF.ProdutoId, PF.FornecedorId});
                

            builder.Entity<Representante>()
                .HasData(new List<Representante>(){
                    new Representante(1, "Lauro", 1),
                    new Representante(2, "Roberto", 2),
                    new Representante(3, "Ronaldo", 3),
                    new Representante(4, "Rodrigo", 4),
                    new Representante(5, "Alexandre", 5),
                });
            
            builder.Entity<Fornecedor>()
                .HasData(new List<Fornecedor>{
                    new Fornecedor(1, "Matemática", "Descrição Fornecedor", "CNPJ DO FORNECEDOR", 1),
                    new Fornecedor(2, "Física", "Descrição Fornecedor", "CNPJ DO FORNECEDOR", 2),
                    new Fornecedor(3, "Português", "Descrição Fornecedor", "CNPJ DO FORNECEDOR", 3),
                    new Fornecedor(4, "Inglês", "Descrição Fornecedor", "CNPJ DO FORNECEDOR", 4),
                    new Fornecedor(5, "Programação", "Descrição Fornecedor", "CNPJ DO FORNECEDOR", 5),
                });
            
            builder.Entity<Produto>()
                .HasData(new List<Produto>(){
                    new Produto(1, "Marta", "Kent", "MARCA 01", "Ativo", "2023-04-05T22:12:25.8187892-03:00", "2023-04-05T22:12:25.8187892-03:00"),
                    new Produto(2, "dsdsdsds", "ewwewewewe", "MARCA 02", "Ativo", "2023-04-05T22:12:25.8187892-03:00", "2023-04-05T22:12:25.8187892-03:00"),
                    new Produto(3, "dsdsdsdsd", "dsdsdsd", "MARCA 03", "Ativo", "2023-04-05T22:12:25.8187892-03:00", "2023-04-05T22:12:25.8187892-03:00"),
                    new Produto(4, "cvvcvcvvc", "cvcvvc", "MARCA 04", "Ativo", "2023-04-05T22:12:25.8187892-03:00",  "2023-04-05T22:12:25.8187892-03:00"),
                    new Produto(5, "ddsfsdfdf", "vcxvcxvx", "MARCA 05", "Ativo", "2023-04-05T22:12:25.8187892-03:00",  "2023-04-05T22:12:25.8187892-03:00"),
                    new Produto(6, "bvcvcgfsg", "fdsfsd", "MARCA 06", "Ativo", "2023-04-05T22:12:25.8187892-03:00",  "2023-04-05T22:12:25.8187892-03:00"),
                    new Produto(7, "treteyte", "trtertret", "MARCA 07", "Ativo", "2023-04-05T22:12:25.8187892-03:00",  "2023-04-05T22:12:25.8187892-03:00"),
                });

            builder.Entity<ProdutoFornecedor>()
                .HasData(new List<ProdutoFornecedor>() {
                    new ProdutoFornecedor() {ProdutoId = 1, FornecedorId = 2 },
                    new ProdutoFornecedor() {ProdutoId = 1, FornecedorId = 4 },
                    new ProdutoFornecedor() {ProdutoId = 1, FornecedorId = 5 },
                    new ProdutoFornecedor() {ProdutoId = 2, FornecedorId = 1 },
                    new ProdutoFornecedor() {ProdutoId = 2, FornecedorId = 2 },
                    new ProdutoFornecedor() {ProdutoId = 2, FornecedorId = 5 },
                    new ProdutoFornecedor() {ProdutoId = 3, FornecedorId = 1 },
                    new ProdutoFornecedor() {ProdutoId = 3, FornecedorId = 2 },
                    new ProdutoFornecedor() {ProdutoId = 3, FornecedorId = 3 },
                    new ProdutoFornecedor() {ProdutoId = 4, FornecedorId = 1 },
                    new ProdutoFornecedor() {ProdutoId = 4, FornecedorId = 4 },
                    new ProdutoFornecedor() {ProdutoId = 4, FornecedorId = 5 },
                    new ProdutoFornecedor() {ProdutoId = 5, FornecedorId = 4 },
                    new ProdutoFornecedor() {ProdutoId = 5, FornecedorId = 5 },
                    new ProdutoFornecedor() {ProdutoId = 6, FornecedorId = 1 },
                    new ProdutoFornecedor() {ProdutoId = 6, FornecedorId = 2 },
                    new ProdutoFornecedor() {ProdutoId = 6, FornecedorId = 3 },
                    new ProdutoFornecedor() {ProdutoId = 6, FornecedorId = 4 },
                    new ProdutoFornecedor() {ProdutoId = 7, FornecedorId = 1 },
                    new ProdutoFornecedor() {ProdutoId = 7, FornecedorId = 2 },
                    new ProdutoFornecedor() {ProdutoId = 7, FornecedorId = 3 },
                    new ProdutoFornecedor() {ProdutoId = 7, FornecedorId = 4 },
                    new ProdutoFornecedor() {ProdutoId = 7, FornecedorId = 5 }
                });
        }
    }
}