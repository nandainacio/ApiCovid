using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidDados.Entity
{
    public class Aplicacao
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public int PessoaId { get; set; }
        public int FornecedorId { get; set; }
    }
}
