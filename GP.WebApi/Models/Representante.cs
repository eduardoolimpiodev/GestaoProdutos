using System.Collections.Generic;

namespace GP.WebApi.Models
{
    public class Representante
    {
        public Representante() { }


        public Representante(int id, string nome, int fornecedorId)
        {
            this.Id = id;
            this.Nome = nome;
            this.FornecedorId = fornecedorId;

        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public int FornecedorId { get; set; }
        public IEnumerable<Fornecedor> Fornecedores { get; set; }
    }
}