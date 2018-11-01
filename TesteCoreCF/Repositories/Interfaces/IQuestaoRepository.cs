using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteCoreCF.Models.Entities;

namespace TesteCoreCF.Repositories.Interfaces
{
    public interface IQuestaoRepository
    {
        Task<IEnumerable<Questao>> ObterAsync();

        Task<Tuple<IEnumerable<Questao>, int>> ObterAsync(int skip, int take, bool asNoTracking = true);
    }
}
