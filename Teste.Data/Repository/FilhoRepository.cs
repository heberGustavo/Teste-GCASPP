using AutoMapper;
using Teste.Data.EntityData;
using Teste.Data.Repository.Base;
using Teste.Domain.IRepository;
using Teste.Domain.Models.EntityDomain;
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Teste.Data.Repository
{
    public class FilhoRepository : RepositoryBase<Filho, FilhoData>, IFilhoRepository
    {
        public FilhoRepository(SqlDataContext dataContext, IMapper mapper) : base(dataContext, mapper)
        {
        }

        public Task<IEnumerable<Filho>> ObterTodosFilhos()
            => _dataContext.Connection.QueryAsync<Filho>(@"SELECT *
                                                           FROM TB_FILHO
                                                           ORDER BY nome");
    }
}
