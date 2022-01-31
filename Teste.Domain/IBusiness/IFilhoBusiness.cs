using Teste.Domain.IBusiness.Base;
using Teste.Domain.Models.EntityDomain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Teste.Domain.IBusiness
{
    public interface IFilhoBusiness : IFuncionarioBase<Filho>
    {
        Task<IEnumerable<Filho>> ObterTodosFilhos();
        Task<ResultResponseModel> Cadastrar(Filho model);
    }
}
