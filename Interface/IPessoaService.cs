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
        public BaseResponse Inserir(PessoaRequest request);
        public BaseResponse Atualizar(PessoaRequest request);
        public BaseResponse Deletar(int id);
    }
}
