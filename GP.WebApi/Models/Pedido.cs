using System.Collections.Generic;

namespace GP.WebApi.Models
{
    public class Pedido
    {
        public Pedido() { }


        
        public Pedido(int id, int representanteId)
        {
            this.Id = id;
            this.RepresentanteId = representanteId;

        }
        public int Id { get; set; }

        public int RepresentanteId { get; set; }
        public IEnumerable<Fornecedor> Fornecedores { get; set; }
    }
}