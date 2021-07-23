using CovidDados.Entity;
using CovidDados.Interface;
using CovidDados.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidDados.Service
{
    public class PessoaService : IPessoaService
    {
        private IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public List<PessoaResponse> Listar()
        {
            var entity = _pessoaRepository.Listar();

            List<PessoaResponse> response = new List<PessoaResponse>();

            entity.ForEach(p =>{
                response.Add(new PessoaResponse()
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    CPF = p.CPF
                });
            });

            return response;
        }

        public PessoaResponse Obter(int id)
        {
            var entity = _pessoaRepository.Obter(id);

            //PessoaResponse response = new PessoaResponse();
            //response.Id = entity.Id;
            //response.Nome = entity.Nome;
            //response.CPF = entity.CPF;

            //return new PessoaResponse();
            return new PessoaResponse()
            {
                Id = entity.Id,
                Nome = entity.Nome,
                CPF = entity.CPF

            };
        }

        public BaseResponse Inserir(PessoaRequest request)
        {
            if (request.Nome == "")
                return new BaseResponse(){ StatusCode = 400, Mensagem = "NOME precisa ser preenchido!"};

            if (request.CPF == "")
                return new BaseResponse() { StatusCode = 400, Mensagem = "CPF precisa ser preenchido!" };

            var entity = _pessoaRepository.ObterPorCpf(request.CPF);

            if (entity != null)
                return new BaseResponse() { StatusCode = 400, Mensagem = "CPF já cadastrado!" };

            Pessoa pessoa = new Pessoa();
            pessoa.CPF = request.CPF;
            pessoa.Id = request.Id;
            pessoa.Nome = request.Nome;

            _pessoaRepository.Inserir(pessoa);

            return new BaseResponse() { StatusCode = 201 };
        }

        public BaseResponse Atualizar(PessoaRequest request)
        {
            if (request.Nome == "")
                return new BaseResponse() { StatusCode = 400, Mensagem = "NOME precisa ser preenchido!" };

            if (request.CPF == "")
                return new BaseResponse() { StatusCode = 400, Mensagem = "CPF precisa ser preenchido!" };

            var entity = _pessoaRepository.ObterPorCpf(request.CPF);

            if (entity != null)
            {
                if(entity.Id != request.Id)
                    return new BaseResponse() { StatusCode = 400, Mensagem = "CPF já cadastrado!" };
            }
                

            Pessoa pessoa = new Pessoa();
            pessoa.CPF = request.CPF;
            pessoa.Id = request.Id;
            pessoa.Nome = request.Nome;

            _pessoaRepository.Atualizar(pessoa);

            return new BaseResponse() { StatusCode = 200 };
        }

        public BaseResponse Deletar(int id)
        {
            if (id == 0)
                return new BaseResponse() { StatusCode = 400, Mensagem = "Id precisa ser preenchido" };

            _pessoaRepository.Deletar(id);
            return new BaseResponse() { StatusCode = 200, Mensagem = "Deletado com Sucesso!" };
        }
    }
}
