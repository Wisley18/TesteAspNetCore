using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteCoreDF.Models;

namespace TesteCoreDF.Repositories.Interfaces
{
    public interface ITemaRepository
    {
        Task<IEnumerable<Object>> ObterAsync();

        Task<Object> ObterAsync(int id, bool asNoTracking = true);

        Task CriarAsync(Object tema);

        Task EditarAsync(Object tema);

        Task ExcluirAsync(Object tema);
    }
}
