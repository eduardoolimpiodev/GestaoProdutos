# GestaoProdutos

Project para Teste


add global.json
dotnet new globaljson --sdk

create WebAPI
dotnet new webapi -n EOT.WebAPI


Criação das Models:
Produto
ProdutoFornecedor
Fornecedor
Representante

Onde Produto e Fornecedor - muitos para muitos, pois um produto pode ter diversos fornecedores e um fornecedor pode ter diversos produtos.

E Representante e Fornecedor - um para muitos, pois um Representante pode representar diversos fornecedores e uma fornecedor pode ter somente um representante.

Add Migrations:
dotnet ef migrations add Init

Add SqLite Database:
dotnet ef database update

Create Solution:
dotnet new sln -n GP

Add project in solution:
dotnet sln GP.sln add GP.WebAPI/GP.WebApi.csproj

Add Migrations:
dotnet ef migrations add firstMigration

Create Database:
dotnet ef database update