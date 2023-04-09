using System;
using System.Collections.Generic;
using GP.WebApi.Models;

namespace GP.WebApi.V1.Dtos
{
    public class RepresentanteRegistrarDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public int FornecedorId { get; set; }
        
    }
}