using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteCoreCF.Models.EntitiesBusiness;
using TesteCoreCF.Repositories.Interfaces;
using TesteCoreCF.Repositories.Source;

namespace TesteCoreCF.Models.Entities
{
    public partial class Questao : BaseContext, IEntity
    {

        public async Task<IEnumerable<Questao>> ObterTodas()
        {
            return await CoreRepositories.IQuestaoRepository.ObterAsync();
        }

        public async Task<Tuple<IEnumerable<Questao>, int>> ObterTodas(int skip, int take)
        {
            return await CoreRepositories.IQuestaoRepository.ObterAsync(skip, take);
        }


    }
}
