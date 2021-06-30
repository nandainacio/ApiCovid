using CovidDados.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidDados.Interface
{
    public interface IPessoaRepository
    {
        public List<Pessoa> Listar();
        public Pessoa Obter(int Id);
    }
}
