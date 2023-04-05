namespace GP.WebApi.Models
{
    public class Fornecedor

    {
        public Fornecedor() { }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string CNPJ { get; set; }

        
    }
}