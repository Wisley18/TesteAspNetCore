using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteCoreDF.Models;

namespace TesteCoreDF.Repositories.Interfaces
{
    public interface IQuestaoRepository
    {
        Task<IEnumerable<Object>> ObterAsync();

        Task<Tuple<IEnumerable<Object>, int>> ObterAsync(int skip, int take, bool asNoTracking = true);
    }
}
