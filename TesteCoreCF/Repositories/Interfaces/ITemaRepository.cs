using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteCoreCF.Models.Entities;

namespace TesteCoreCF.Repositories.Interfaces
{
    public interface ITemaRepository
    {
        Task<IEnumerable<Tema>> ObterAsync();

        Task<Tema> ObterAsync(int id, bool asNoTracking = true);

        Task CriarAsync(Tema tema);

        Task EditarAsync(Tema tema);

        Task ExcluirAsync(Tema tema);
    }
}
