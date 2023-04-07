using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GP.WebApi.Migrations
{
    public partial class tree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RepresentanteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Codigo = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Peso = table.Column<string>(nullable: true),
                    Marca = table.Column<string>(nullable: true),
                    Situacao = table.Column<bool>(nullable: false),
                    DataFabricacao = table.Column<DateTime>(nullable: false),
                    DataValidade = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Representantes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    FornecedorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Representantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdutosPedidos",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(nullable: false),
                    PedidoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosPedidos", x => new { x.PedidoId, x.ProdutoId });
                    table.ForeignKey(
                        name: "FK_ProdutosPedidos_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutosPedidos_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    CNPJ = table.Column<string>(nullable: true),
                    RepresentanteId = table.Column<int>(nullable: false),
                    PedidoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fornecedores_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fornecedores_Representantes_RepresentanteId",
                        column: x => x.RepresentanteId,
                        principalTable: "Representantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdutosFornecedores",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(nullable: false),
                    FornecedorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosFornecedores", x => new { x.ProdutoId, x.FornecedorId });
                    table.ForeignKey(
                        name: "FK_ProdutosFornecedores_Fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutosFornecedores_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pedidos",
                columns: new[] { "Id", "RepresentanteId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "Pedidos",
                columns: new[] { "Id", "RepresentanteId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "Pedidos",
                columns: new[] { "Id", "RepresentanteId" },
                values: new object[] { 3, 1 });

            migrationBuilder.InsertData(
                table: "Pedidos",
                columns: new[] { "Id", "RepresentanteId" },
                values: new object[] { 4, 2 });

            migrationBuilder.InsertData(
                table: "Pedidos",
                columns: new[] { "Id", "RepresentanteId" },
                values: new object[] { 5, 3 });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Codigo", "DataFabricacao", "DataValidade", "Descricao", "Marca", "Nome", "Peso", "Situacao" },
                values: new object[] { 7, 654, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição 07", "MARCA", "treteyte", "500", true });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Codigo", "DataFabricacao", "DataValidade", "Descricao", "Marca", "Nome", "Peso", "Situacao" },
                values: new object[] { 6, 98, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição 06", "MARCA", "bvcvcgfsg", "500", true });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Codigo", "DataFabricacao", "DataValidade", "Descricao", "Marca", "Nome", "Peso", "Situacao" },
                values: new object[] { 5, 365, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição 05", "MARCA", "ddsfsdfdf", "500", true });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Codigo", "DataFabricacao", "DataValidade", "Descricao", "Marca", "Nome", "Peso", "Situacao" },
                values: new object[] { 4, 121, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição 04", "MARCA", "cvvcvcvvc", "500", true });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Codigo", "DataFabricacao", "DataValidade", "Descricao", "Marca", "Nome", "Peso", "Situacao" },
                values: new object[] { 3, 789, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição 03", "MARCA", "dsdsdsdsd", "500", true });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Codigo", "DataFabricacao", "DataValidade", "Descricao", "Marca", "Nome", "Peso", "Situacao" },
                values: new object[] { 2, 456, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição 02", "MARCA", "dsdsdsds", "500", true });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Codigo", "DataFabricacao", "DataValidade", "Descricao", "Marca", "Nome", "Peso", "Situacao" },
                values: new object[] { 1, 23, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição 01", "MARCA", "Marta", "500", true });

            migrationBuilder.InsertData(
                table: "Representantes",
                columns: new[] { "Id", "FornecedorId", "Nome", "Telefone" },
                values: new object[] { 1, 1, "Lauro", "2799654985" });

            migrationBuilder.InsertData(
                table: "Representantes",
                columns: new[] { "Id", "FornecedorId", "Nome", "Telefone" },
                values: new object[] { 2, 2, "Roberto", "2799654455" });

            migrationBuilder.InsertData(
                table: "Representantes",
                columns: new[] { "Id", "FornecedorId", "Nome", "Telefone" },
                values: new object[] { 3, 3, "Ronaldo", "2799654125" });

            migrationBuilder.InsertData(
                table: "Representantes",
                columns: new[] { "Id", "FornecedorId", "Nome", "Telefone" },
                values: new object[] { 4, 4, "Rodrigo", "2799658005" });

            migrationBuilder.InsertData(
                table: "Representantes",
                columns: new[] { "Id", "FornecedorId", "Nome", "Telefone" },
                values: new object[] { 5, 5, "Alexandre", "2799652325" });

            migrationBuilder.InsertData(
                table: "Fornecedores",
                columns: new[] { "Id", "CNPJ", "Descricao", "Nome", "PedidoId", "RepresentanteId" },
                values: new object[] { 1, "CNPJ DO FORNECEDOR", "Descrição Fornecedor", "Matemática", null, 1 });

            migrationBuilder.InsertData(
                table: "Fornecedores",
                columns: new[] { "Id", "CNPJ", "Descricao", "Nome", "PedidoId", "RepresentanteId" },
                values: new object[] { 2, "CNPJ DO FORNECEDOR", "Descrição Fornecedor", "Física", null, 2 });

            migrationBuilder.InsertData(
                table: "Fornecedores",
                columns: new[] { "Id", "CNPJ", "Descricao", "Nome", "PedidoId", "RepresentanteId" },
                values: new object[] { 3, "CNPJ DO FORNECEDOR", "Descrição Fornecedor", "Português", null, 3 });

            migrationBuilder.InsertData(
                table: "Fornecedores",
                columns: new[] { "Id", "CNPJ", "Descricao", "Nome", "PedidoId", "RepresentanteId" },
                values: new object[] { 4, "CNPJ DO FORNECEDOR", "Descrição Fornecedor", "Inglês", null, 4 });

            migrationBuilder.InsertData(
                table: "Fornecedores",
                columns: new[] { "Id", "CNPJ", "Descricao", "Nome", "PedidoId", "RepresentanteId" },
                values: new object[] { 5, "CNPJ DO FORNECEDOR", "Descrição Fornecedor", "Programação", null, 5 });

            migrationBuilder.InsertData(
                table: "ProdutosFornecedores",
                columns: new[] { "ProdutoId", "FornecedorId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "ProdutosFornecedores",
                columns: new[] { "ProdutoId", "FornecedorId" },
                values: new object[] { 4, 5 });

            migrationBuilder.InsertData(
                table: "ProdutosFornecedores",
                columns: new[] { "ProdutoId", "FornecedorId" },
                values: new object[] { 2, 5 });

            migrationBuilder.InsertData(
                table: "ProdutosFornecedores",
                columns: new[] { "ProdutoId", "FornecedorId" },
                values: new object[] { 1, 5 });

            migrationBuilder.InsertData(
                table: "ProdutosFornecedores",
                columns: new[] { "ProdutoId", "FornecedorId" },
                values: new object[] { 7, 4 });

            migrationBuilder.InsertData(
                table: "ProdutosFornecedores",
                columns: new[] { "ProdutoId", "FornecedorId" },
                values: new object[] { 6, 4 });

            migrationBuilder.InsertData(
                table: "ProdutosFornecedores",
                columns: new[] { "ProdutoId", "FornecedorId" },
                values: new object[] { 5, 4 });

            migrationBuilder.InsertData(
                table: "ProdutosFornecedores",
                columns: new[] { "ProdutoId", "FornecedorId" },
                values: new object[] { 4, 4 });

            migrationBuilder.InsertData(
                table: "ProdutosFornecedores",
                columns: new[] { "ProdutoId", "FornecedorId" },
                values: new object[] { 1, 4 });

            migrationBuilder.InsertData(
                table: "ProdutosFornecedores",
                columns: new[] { "ProdutoId", "FornecedorId" },
                values: new object[] { 7, 3 });

            migrationBuilder.InsertData(
                table: "ProdutosFornecedores",
                columns: new[] { "ProdutoId", "FornecedorId" },
                values: new object[] { 5, 5 });

            migrationBuilder.InsertData(
                table: "ProdutosFornecedores",
                columns: new[] { "ProdutoId", "FornecedorId" },
                values: new object[] { 6, 3 });

            migrationBuilder.InsertData(
                table: "ProdutosFornecedores",
                columns: new[] { "ProdutoId", "FornecedorId" },
                values: new object[] { 7, 2 });

            migrationBuilder.InsertData(
                table: "ProdutosFornecedores",
                columns: new[] { "ProdutoId", "FornecedorId" },
                values: new object[] { 6, 2 });

            migrationBuilder.InsertData(
                table: "ProdutosFornecedores",
                columns: new[] { "ProdutoId", "FornecedorId" },
                values: new object[] { 3, 2 });

            migrationBuilder.InsertData(
                table: "ProdutosFornecedores",
                columns: new[] { "ProdutoId", "FornecedorId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "ProdutosFornecedores",
                columns: new[] { "ProdutoId", "FornecedorId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "ProdutosFornecedores",
                columns: new[] { "ProdutoId", "FornecedorId" },
                values: new object[] { 7, 1 });

            migrationBuilder.InsertData(
                table: "ProdutosFornecedores",
                columns: new[] { "ProdutoId", "FornecedorId" },
                values: new object[] { 6, 1 });

            migrationBuilder.InsertData(
                table: "ProdutosFornecedores",
                columns: new[] { "ProdutoId", "FornecedorId" },
                values: new object[] { 4, 1 });

            migrationBuilder.InsertData(
                table: "ProdutosFornecedores",
                columns: new[] { "ProdutoId", "FornecedorId" },
                values: new object[] { 3, 1 });

            migrationBuilder.InsertData(
                table: "ProdutosFornecedores",
                columns: new[] { "ProdutoId", "FornecedorId" },
                values: new object[] { 3, 3 });

            migrationBuilder.InsertData(
                table: "ProdutosFornecedores",
                columns: new[] { "ProdutoId", "FornecedorId" },
                values: new object[] { 7, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedores_PedidoId",
                table: "Fornecedores",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedores_RepresentanteId",
                table: "Fornecedores",
                column: "RepresentanteId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosFornecedores_FornecedorId",
                table: "ProdutosFornecedores",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosPedidos_ProdutoId",
                table: "ProdutosPedidos",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutosFornecedores");

            migrationBuilder.DropTable(
                name: "ProdutosPedidos");

            migrationBuilder.DropTable(
                name: "Fornecedores");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Representantes");
        }
    }
}
