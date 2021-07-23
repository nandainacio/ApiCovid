using CovidDados.Interface;
using CovidDados.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidDados.Controllers
{
    [Route("[Controller]")]
    public class FornecedorController
    {
        private IFornecedorService _fornecedorService;

        public FornecedorController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            var response = _fornecedorService.Listar();
            return new ObjectResult(response) { StatusCode = 200 };
        }

        [HttpGet("obter")]
        public IActionResult Obter([FromQuery] int id)
        {
            var response = _fornecedorService.Obter(id);
            return new ObjectResult(response) { StatusCode = 200 };
        }

        [HttpGet("obterPorNome")]
        public IActionResult ObterPorNome([FromQuery] string nome)
        {
            var response = _fornecedorService.ObterPorNome(nome);
            return new ObjectResult(response) { StatusCode = 200 };
        }

        [HttpPost("inserir")]
        public IActionResult Inserir([FromBody] FornecedorRequest request)
        {
            var response = _fornecedorService.Inserir(request);
            return new ObjectResult(request) { StatusCode = response.StatusCode };
        }
        
        [HttpPut("atualizar")]
        public IActionResult Atualizar([FromBody] FornecedorRequest request)
        {
            var response = _fornecedorService.Atualizar(request);
            return new ObjectResult(request) { StatusCode = response.StatusCode };
        }

        [HttpDelete("deletar")]
        public IActionResult Deletar([FromQuery] int id)
        {
            var response = _fornecedorService.Deletar(id);
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
