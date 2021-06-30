using CovidDados.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidDados.Interface
{
    public interface IPessoaService
    {
        public List<PessoaResponse> Listar();
        public PessoaResponse Obter(int id);
    }
}
