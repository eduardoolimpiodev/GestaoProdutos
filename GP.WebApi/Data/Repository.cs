using System.Linq;
using GP.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GP.WebApi.Data
{
    public class Repository : IRepository
    {   

        private readonly DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

         public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
           return (_context.SaveChanges() > 0);
        }


        //Produto
        public Produto[] GetAllProdutos(bool includeRepresentante = false)
        {
            IQueryable<Produto> query = _context.Produtos;

            if (includeRepresentante)
            {
                query = query.Include(produto => produto.ProdutosFornecedores)
                             .ThenInclude( prod => prod.Fornecedor)
                             .ThenInclude( forne => forne.RepresentanteId);
            }

            query = query.AsNoTracking().OrderBy( prod => prod.Id);

            return query.ToArray();
        }

        public Produto[] GetAllProdutosByFornecedorId(int fornecedorId, bool includeRepresentante = false)
        {
            IQueryable<Produto> query = _context.Produtos;

            if (includeRepresentante)
            {
                query = query.Include(produto => produto.ProdutosFornecedores)
                            .ThenInclude( prod => prod.Fornecedor)
                            .ThenInclude( forne => forne.RepresentanteId);
            }

            query = query.AsNoTracking()
                            .OrderBy( prod => prod.Id)
                            .Where( produto => produto.ProdutosFornecedores.Any( prodforn => prodforn.FornecedorId == fornecedorId));

            return query.ToArray();
        }

        public Produto GetProdutoById(int produtoId, bool includeRepresentante = false)
        {
            IQueryable<Produto> query = _context.Produtos;

            if (includeRepresentante)
            {
                query = query.Include(produto => produto.ProdutosFornecedores)
                            .ThenInclude( prod => prod.Fornecedor)
                            .ThenInclude( forne => forne.RepresentanteId);
            }

            query = query.AsNoTracking()
                            .OrderBy( prod => prod.Id)
                            .Where( produto => produto.Id == produto.Id);

            return query.FirstOrDefault();
        }


        //Representante
        public Representante[] GetAllRepresentantes(bool includeFornecedores = false)
        {
            IQueryable<Representante> query = _context.Representantes;

            if (includeFornecedores)
            {
                query = query.Include(rep => rep.Fornecedores)
                            .ThenInclude( prod => prod.ProdutosFornecedores)
                            .ThenInclude( prod => prod.Fornecedor);
            }

            query = query.AsNoTracking()
                            .OrderBy( rep => rep.Id);

            return query.ToArray();
        }

        public Representante[] GetAllRepresentantesByFornecedorId(int fornecedorId, bool includeProdutos = false)
        {
            IQueryable<Representante> query = _context.Representantes;

            if (includeProdutos)
            {
                query = query.Include(rep => rep.Fornecedores)
                            .ThenInclude( forn => forn.ProdutosFornecedores)
                            .ThenInclude( pr => pr.ProdutoId);
            }

            query = query.AsNoTracking()
                            .OrderBy( prod => prod.Id)
                            .Where( produto => produto.Fornecedores.Any(
                                prodfor => prodfor.ProdutosFornecedores.Any( prodfor => prodfor.FornecedorId == fornecedorId)
                            ));

            return query.ToArray();
        }

        public Representante GetRepresentanteById(int representanteId, bool includeRepresentante = false)
        {
            IQueryable<Representante> query = _context.Representantes;

            if (includeRepresentante)
            {
                query = query.Include(rep => rep.Fornecedores)
                            .ThenInclude( forne => forne.ProdutosFornecedores)
                            .ThenInclude( prodfor => prodfor.Produto);
            }

            query = query.AsNoTracking()
                            .OrderBy( rep => rep.Id)
                            .Where( representante => representante.Id == representanteId);

            // return query.FirstOrDefault();
            return query.FirstOrDefault();
        }


    }
}