using Teste.Domain.IRepository.Base;
using Teste.Domain.Models.EntityDomain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Teste.Domain.IRepository
{
    public interface IFilhoRepository : IRepositoryBase<Filho>
    {
        Task<IEnumerable<Filho>> ObterTodosFilhos();
    }
}
