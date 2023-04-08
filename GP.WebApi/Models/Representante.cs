using System.Collections.Generic;

namespace GP.WebApi.Models
{
    public class Representante
    {
        public Representante() { }

        public Representante(int id, string nome, string telefone, int pedidoId, int fornecedorId)
        {
            this.Id = id;
            this.Nome = nome;
            this.Telefone = telefone;
            this.FornecedorId = fornecedorId;

        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public int FornecedorId { get; set; }
        public IEnumerable<Fornecedor> Fornecedores { get; set; }
    }
}