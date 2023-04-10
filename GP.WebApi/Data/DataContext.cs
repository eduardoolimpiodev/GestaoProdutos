using System;
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
        public DbSet<RepresentantePedido> ProdutosPedidos {get; set;}
        public DbSet<Pedido> Pedidos {get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProdutoFornecedor>()
                .HasKey(PF => new {PF.ProdutoId, PF.FornecedorId});

             builder.Entity<RepresentantePedido>()
                .HasKey(RP => new {RP.ProdutoId, RP.PedidoId});
                    
            //Soft Delete - Deleção Lógica        
            builder.Entity<Produto>()
                .HasQueryFilter(prod => prod.Situacao);    

            builder.Entity<Representante>()
                .HasData(new List<Representante>(){
                    new Representante(1, "Lauro", "2799654985",2, 1),
                    new Representante(2, "Roberto","2799654455",2, 2),
                    new Representante(3, "Ronaldo","2799654125",1, 3),
                    new Representante(4, "Rodrigo","2799658005",1, 4),
                    new Representante(5, "Alexandre","2799652325",3, 5),
                });
            
            builder.Entity<Pedido>()
                .HasData(new List<Pedido>(){
                    new Pedido(1, 2),
                    new Pedido(2, 1),
                    new Pedido(3, 1),
                    new Pedido(4, 2),
                    new Pedido(5, 3),
                });

            builder.Entity<Fornecedor>()
                .HasData(new List<Fornecedor>(){
                    new Fornecedor(1, "Fornecedor", "Descrição TESTE", "12345478998 CNPJ", 2, 1),
                    new Fornecedor(2, "Física", "Descrição Fornecedor", "CNPJ DO FORNECEDOR", 2, 1),
                    new Fornecedor(3, "Português", "Descrição Fornecedor", "CNPJ DO FORNECEDOR", 3, 1),
                    new Fornecedor(4, "Inglês", "Descrição Fornecedor", "CNPJ DO FORNECEDOR", 4, 1),
                    new Fornecedor(5, "Programação", "Descrição Fornecedor", "CNPJ DO FORNECEDOR", 5, 1),
                });
            
            builder.Entity<Produto>()
                .HasData(new List<Produto>(){
                    new Produto(1, "Marta", 23, "Descrição 01", "500", "MARCA", true , DateTime.Parse("05/04/2023"), DateTime.Parse("05/04/2024")),
                    new Produto(2, "dsdsdsds", 456, "Descrição 02", "500", "MARCA", true,  DateTime.Parse("05/04/2023"), DateTime.Parse("05/04/2024")),
                    new Produto(3, "dsdsdsdsd", 789, "Descrição 03", "500", "MARCA",true , DateTime.Parse("05/04/2023"), DateTime.Parse("05/04/2024")),
                    new Produto(4, "cvvcvcvvc", 121, "Descrição 04", "500", "MARCA",true , DateTime.Parse("05/04/2023"), DateTime.Parse("05/04/2024")),
                    new Produto(5, "ddsfsdfdf", 365, "Descrição 05", "500", "MARCA",true , DateTime.Parse("05/04/2023"), DateTime.Parse("05/04/2024")),
                    new Produto(6, "bvcvcgfsg", 98, "Descrição 06", "500", "MARCA",true , DateTime.Parse("05/04/2023"), DateTime.Parse("05/04/2024")),
                    new Produto(7, "treteyte", 654, "Descrição 07", "500", "MARCA",true , DateTime.Parse("05/04/2023"), DateTime.Parse("05/04/2024")),
                });

            // builder.Entity<RepresentantePedido>()
            //     .HasData(new List<RepresentantePedido>(){
            //         new RepresentantePedido(1, 1),
            //         new RepresentantePedido(1, 2),
            //         new RepresentantePedido(1, 3),
            //         new RepresentantePedido(1, 2),

            //     });

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