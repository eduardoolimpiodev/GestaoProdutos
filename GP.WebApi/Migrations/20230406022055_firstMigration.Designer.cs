﻿// <auto-generated />
using System;
using GP.WebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GP.WebApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230406022055_firstMigration")]
    partial class firstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("GP.WebApi.Models.Fornecedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CNPJ")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RepresentanteId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.HasIndex("RepresentanteId");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("GP.WebApi.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataFabricacao")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataValidade")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Marca")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Situacao")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("GP.WebApi.Models.ProdutoFornecedor", b =>
                {
                    b.Property<int>("ProdutoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FornecedorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProdutoId", "FornecedorId");

                    b.HasIndex("FornecedorId");

                    b.ToTable("ProdutosFornecedores");
                });

            modelBuilder.Entity("GP.WebApi.Models.Representante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Representantes");
                });

            modelBuilder.Entity("GP.WebApi.Models.Fornecedor", b =>
                {
                    b.HasOne("GP.WebApi.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GP.WebApi.Models.Representante", null)
                        .WithMany("Fornecedores")
                        .HasForeignKey("RepresentanteId");
                });

            modelBuilder.Entity("GP.WebApi.Models.ProdutoFornecedor", b =>
                {
                    b.HasOne("GP.WebApi.Models.Fornecedor", "Fornecedor")
                        .WithMany("ProdutosFornecedores")
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GP.WebApi.Models.Produto", "Produto")
                        .WithMany("ProdutosFornecedores")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
