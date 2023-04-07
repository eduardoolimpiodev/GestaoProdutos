namespace GP.WebApi.Models
{
    public class RepresentantePedido
    {
        public RepresentantePedido() { }

        public RepresentantePedido(int produtoId, int pedidoId)
        {
            this.ProdutoId = produtoId;
            this.PedidoId = pedidoId;

        }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
    }
}