using CovidDados.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidDados.Interface
{
    public interface IFornecedorRepository
    {
        public List<Fornecedor> Listar();
        public Fornecedor Obter(int Id);
        public Fornecedor ObterPorNome(string Nome);
        public void Inserir(Fornecedor fornecedor);
        public void Atualizar(Fornecedor fornecedor);
        public void Deletar(int Id);
    }
}
