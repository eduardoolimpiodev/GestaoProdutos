using Microsoft.EntityFrameworkCore.Migrations;

namespace GP.WebApi.Migrations
{
    public partial class tree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Marca = table.Column<string>(nullable: true),
                    Situacao = table.Column<string>(nullable: true),
                    DataFabricacao = table.Column<string>(nullable: true),
                    DataValidade = table.Column<string>(nullable: true)
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
                    FornecedorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Representantes", x => x.Id);
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
                    RepresentanteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.Id);
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
                table: "Produtos",
                columns: new[] { "Id", "DataFabricacao", "DataValidade", "Descricao", "Marca", "Nome", "Situacao" },
                values: new object[] { 1, "2023-04-05T22:12:25.8187892-03:00", "2023-04-05T22:12:25.8187892-03:00", "Kent", "MARCA 01", "Marta", "Ativo" });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "DataFabricacao", "DataValidade", "Descricao", "Marca", "Nome", "Situacao" },
                values: new object[] { 2, "2023-04-05T22:12:25.8187892-03:00", "2023-04-05T22:12:25.8187892-03:00", "ewwewewewe", "MARCA 02", "dsdsdsds", "Ativo" });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "DataFabricacao", "DataValidade", "Descricao", "Marca", "Nome", "Situacao" },
                values: new object[] { 3, "2023-04-05T22:12:25.8187892-03:00", "2023-04-05T22:12:25.8187892-03:00", "dsdsdsd", "MARCA 03", "dsdsdsdsd", "Ativo" });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "DataFabricacao", "DataValidade", "Descricao", "Marca", "Nome", "Situacao" },
                values: new object[] { 4, "2023-04-05T22:12:25.8187892-03:00", "2023-04-05T22:12:25.8187892-03:00", "cvcvvc", "MARCA 04", "cvvcvcvvc", "Ativo" });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "DataFabricacao", "DataValidade", "Descricao", "Marca", "Nome", "Situacao" },
                values: new object[] { 5, "2023-04-05T22:12:25.8187892-03:00", "2023-04-05T22:12:25.8187892-03:00", "vcxvcxvx", "MARCA 05", "ddsfsdfdf", "Ativo" });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "DataFabricacao", "DataValidade", "Descricao", "Marca", "Nome", "Situacao" },
                values: new object[] { 6, "2023-04-05T22:12:25.8187892-03:00", "2023-04-05T22:12:25.8187892-03:00", "fdsfsd", "MARCA 06", "bvcvcgfsg", "Ativo" });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "DataFabricacao", "DataValidade", "Descricao", "Marca", "Nome", "Situacao" },
                values: new object[] { 7, "2023-04-05T22:12:25.8187892-03:00", "2023-04-05T22:12:25.8187892-03:00", "trtertret", "MARCA 07", "treteyte", "Ativo" });

            migrationBuilder.InsertData(
                table: "Representantes",
                columns: new[] { "Id", "FornecedorId", "Nome" },
                values: new object[] { 1, 1, "Lauro" });

            migrationBuilder.InsertData(
                table: "Representantes",
                columns: new[] { "Id", "FornecedorId", "Nome" },
                values: new object[] { 2, 2, "Roberto" });

            migrationBuilder.InsertData(
                table: "Representantes",
                columns: new[] { "Id", "FornecedorId", "Nome" },
                values: new object[] { 3, 3, "Ronaldo" });

            migrationBuilder.InsertData(
                table: "Representantes",
                columns: new[] { "Id", "FornecedorId", "Nome" },
                values: new object[] { 4, 4, "Rodrigo" });

            migrationBuilder.InsertData(
                table: "Representantes",
                columns: new[] { "Id", "FornecedorId", "Nome" },
                values: new object[] { 5, 5, "Alexandre" });

            migrationBuilder.InsertData(
                table: "Fornecedores",
                columns: new[] { "Id", "CNPJ", "Descricao", "Nome", "RepresentanteId" },
                values: new object[] { 1, "CNPJ DO FORNECEDOR", "Descrição Fornecedor", "Matemática", 1 });

            migrationBuilder.InsertData(
                table: "Fornecedores",
                columns: new[] { "Id", "CNPJ", "Descricao", "Nome", "RepresentanteId" },
                values: new object[] { 2, "CNPJ DO FORNECEDOR", "Descrição Fornecedor", "Física", 2 });

            migrationBuilder.InsertData(
                table: "Fornecedores",
                columns: new[] { "Id", "CNPJ", "Descricao", "Nome", "RepresentanteId" },
                values: new object[] { 3, "CNPJ DO FORNECEDOR", "Descrição Fornecedor", "Português", 3 });

            migrationBuilder.InsertData(
                table: "Fornecedores",
                columns: new[] { "Id", "CNPJ", "Descricao", "Nome", "RepresentanteId" },
                values: new object[] { 4, "CNPJ DO FORNECEDOR", "Descrição Fornecedor", "Inglês", 4 });

            migrationBuilder.InsertData(
                table: "Fornecedores",
                columns: new[] { "Id", "CNPJ", "Descricao", "Nome", "RepresentanteId" },
                values: new object[] { 5, "CNPJ DO FORNECEDOR", "Descrição Fornecedor", "Programação", 5 });

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
                name: "IX_Fornecedores_RepresentanteId",
                table: "Fornecedores",
                column: "RepresentanteId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosFornecedores_FornecedorId",
                table: "ProdutosFornecedores",
                column: "FornecedorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutosFornecedores");

            migrationBuilder.DropTable(
                name: "Fornecedores");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Representantes");
        }
    }
}
