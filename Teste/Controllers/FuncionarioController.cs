using Teste.Domain.Business;
using Teste.Domain.IBusiness;
using Teste.Domain.Models.EntityDomain;
using Teste.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Teste.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioBusiness _funcionarioBusiness;

        public FuncionarioController(IFuncionarioBusiness funcionarioBusiness)
        {
            _funcionarioBusiness = funcionarioBusiness;
        }

        [HttpGet]
        public async Task<IEnumerable<Funcionario>> ObterTodosFuncionarios()
            => await _funcionarioBusiness.ObterTodosFuncionarios();

        [HttpPost]
        public async Task<JsonResult> Cadastrar(string nome, string data, decimal salario)
        {
            try
            {
                var result = await _funcionarioBusiness.VerificaSeExisteCadastrado(nome, salario);

                if (result < 1)
                {
                    var model = new Funcionario
                    {
                        nome = nome,
                        data_de_nascimento = Convert.ToDateTime(data),
                        salario = salario
                    };

                    var resultado = await _funcionarioBusiness.Cadastrar(model);

                    return Json(new { erro = resultado.erro, mensagem = resultado.mensagem });
                }

                return Json(new { erro = true, mensagem = "Já existe funcionário com esses dados!" });
                
            }
            catch(Exception e)
            {
                return Json(new { erro = true, mensagem = "Ocorreu um erro. Contate o administrador." });
            }
        }
        
        [HttpPost]
        public async Task<JsonResult> Editar(int id, string nome, string data, decimal salario)
        {
            try
            {
                var result = await _funcionarioBusiness.VerificaSeExisteCadastrado(nome, salario);

                if (result < 1)
                {
                    var model = new Funcionario
                    {
                        id = id,
                        nome = nome,
                        data_de_nascimento = Convert.ToDateTime(data),
                        salario = salario
                    };

                    var resultado = await _funcionarioBusiness.Editar(model);

                    return Json(new { erro = resultado.erro, mensagem = resultado.mensagem });
                }

                return Json(new { erro = true, mensagem = "Já existe funcionário com esses dados!" });

            }
            catch(Exception e)
            {
                return Json(new { erro = true, mensagem = "Ocorreu um erro. Contate o administrador." });
            }
        }

        [HttpGet]
        public async Task<JsonResult> ObterFuncionarioPorId(int id)
        {
            try
            {
                var result = await _funcionarioBusiness.ObterFuncionarioPorId(id);
                return Json(result);
            }
            catch
            {
                return Json("Ocorreu um erro. Contate o administrador.");
            }
        }

    }
}
