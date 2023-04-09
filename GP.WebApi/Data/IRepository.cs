using System.Collections.Generic;
using System.Threading.Tasks;
using GP.WebApi.Helpers;
using GP.WebApi.Models;

namespace GP.WebApi.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        bool SaveChanges();
        Task<PageList<Produto>> GetAllProdutosAsync(PageParams pageParams, bool includeRepresentante = false);
        Produto[] GetAllProdutos(bool includeRepresentante = false);

        Produto[] GetAllProdutosByFornecedorId(int fornecedorId, bool includeRepresentante = false);

        Produto GetProdutoById(int produtoId, bool includeRepresentante = false);

        //Representante
        Representante[] GetAllRepresentantes(bool includeFornecedores = false);

        Representante[] GetAllRepresentantesByFornecedorId(int fornecedorId, bool includeProdutos = false);

        Representante GetRepresentanteById(int representanteId, bool includeRepresentante = false);

    }
}