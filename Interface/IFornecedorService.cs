using CovidDados.Entity;
using CovidDados.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidDados.Interface
{
    public interface IFornecedorService
    {
        public List<FornecedorResponse> Listar();
        public FornecedorResponse Obter(int Id);
        public FornecedorResponse ObterPorNome(string nome);
        public BaseResponse Inserir(FornecedorRequest request);
        public BaseResponse Atualizar(FornecedorRequest request);
        public BaseResponse Deletar(int id);
    }
}
