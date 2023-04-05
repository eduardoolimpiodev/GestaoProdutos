using System.Collections.Generic;

namespace GP.WebApi.Models
{
    public class Representante
    {
        public Representante() { }

        public Representante(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;

        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Fornecedor> Fornecedores { get; set; }
    }
}