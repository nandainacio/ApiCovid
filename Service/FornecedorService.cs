using CovidDados.Entity;
using CovidDados.Interface;
using CovidDados.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidDados.Service
{
    public class FornecedorService : IFornecedorService
    {
        private IFornecedorRepository _fornecedorRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public List<FornecedorResponse> Listar()
        {
            var entity = _fornecedorRepository.Listar();

            List<FornecedorResponse> response = new List<FornecedorResponse>();

            entity.ForEach(f =>
            {
                response.Add(new FornecedorResponse()
                {
                    Id = f.Id,
                    Nome = f.Nome,
                    QtdApli = f.QtdApli
                });
            });

            return response;
        }

        public FornecedorResponse Obter(int id)
        {
            var entity = _fornecedorRepository.Obter(id);

            return new FornecedorResponse()
            {
                Id = entity.Id,
                Nome = entity.Nome,
                QtdApli = entity.QtdApli
            };
        }

        public FornecedorResponse ObterPorNome(string nome)
        {
            var entity = _fornecedorRepository.ObterPorNome(nome);
            return new FornecedorResponse()
            {
                Id = entity.Id,
                Nome = entity.Nome,
                QtdApli = entity.QtdApli
            };
        }

        public BaseResponse Inserir(FornecedorRequest request)
        {
            if (request.Nome == "")
                return new BaseResponse() { StatusCode = 400, Mensagem = "NOME precisa ser preenchido" };
            if(request.QtdApli == null || request.QtdApli == 0)

                return new BaseResponse() { StatusCode = 400, Mensagem = "Quantidade de aplicações precisa ser preenchido e ser maior do que 0(zero)" };

            var entity = _fornecedorRepository.ObterPorNome(request.Nome);

            if (entity != null )
                return new BaseResponse() { StatusCode = 400, Mensagem = "Fornecedor já cadastrado" };

            Fornecedor fornecedor = new Fornecedor();
            fornecedor.Nome = request.Nome;
            fornecedor.Id = request.Id;
            fornecedor.QtdApli = request.QtdApli;

            _fornecedorRepository.Inserir(fornecedor);
            return new BaseResponse() { StatusCode = 201 };
        }

        public BaseResponse Atualizar(FornecedorRequest request)
        {
            if (request.Nome == "")
                return new BaseResponse() { StatusCode = 400, Mensagem = "Nome precisa ser preenchido" };

            if(request.QtdApli == 0)
                return new BaseResponse() { StatusCode = 400, Mensagem = "Quantidade de aplicações precisa ser preenchido e ser maior do que 0(zero)" };

            var entity = _fornecedorRepository.ObterPorNome(request.Nome);

            if(entity != null)
            {
                if (entity.Id != request.Id)
                    return new BaseResponse() { StatusCode = 400, Mensagem = "Nome da vacina já cadastrado" };
            }

            Fornecedor fornecedor = new Fornecedor();
            fornecedor.Nome = request.Nome;
            fornecedor.Id = request.Id;
            fornecedor.QtdApli = request.QtdApli;

            _fornecedorRepository.Atualizar(fornecedor);
            return new BaseResponse() { StatusCode = 200 };
            
        }

        public BaseResponse Deletar(int id)
        {
            if (id == 0)
                return new BaseResponse() { StatusCode = 400, Mensagem = "Id precisa ser preenchido" };

            _fornecedorRepository.Deletar(id);
            return new BaseResponse() { StatusCode = 200, Mensagem = "Item deletado com sucesso" };
        }
    }
}