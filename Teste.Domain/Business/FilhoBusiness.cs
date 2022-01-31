using Teste.Domain.Business.Base;
using Teste.Domain.IBusiness;
using Teste.Domain.IRepository;
using Teste.Domain.Models.EntityDomain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Teste.Domain.Business
{
    public class FilhoBusiness : BusinessBase<Filho>, IFilhoBusiness
    {
        private readonly IFilhoRepository _filhoRepository;

        public FilhoBusiness(IFilhoRepository filhoRepository) : base(filhoRepository)
        {
            _filhoRepository = filhoRepository;
        }

        public async Task<ResultResponseModel> Cadastrar(Filho model)
        {
            try
            {
                var result = await _filhoRepository.CreateAsync(model);
                if (result == 0) return new ResultResponseModel(true, "Erro ao cadastrar Filho. Tente novamente!");

                return new ResultResponseModel(false, "Filho cadastrado com sucesso!");
            }
            catch (Exception e)
            {
                return new ResultResponseModel(true, "Erro ao cadastrar Filho. Contate o administrador.");
            }
        }

        public Task<IEnumerable<Filho>> ObterTodosFilhos()
            => _filhoRepository.ObterTodosFilhos();
    }
}
