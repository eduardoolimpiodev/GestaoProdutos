using System;
using System.Collections.Generic;

namespace GP.WebApi.Models
{
    public class RepresentanteDto
    {
        
        public int Id { get; set; }
        public string Nome { get; set; }
        public int FornecedorId { get; set; }
    }
}