using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteCoreCF.Models.Entities;
using TesteCoreCF.Repositories.Source;

namespace TesteCoreCF.Models
{
    public class Academico
    {
        private readonly IAbstractCoreRepository CoreRepositories;

        public Academico(IAbstractCoreRepository cr)
        {
            CoreRepositories = cr;
        }

        public async Task<Tema> CriarTema(Tema tema)
        {
            if (tema == null)
            {
                throw new ArgumentNullException();
            }

            var _tema = new Tema()
            {
                Nome = tema.Nome,
                Descricao = tema.Descricao,
                StatusRegistro = "1"
            };

            await CoreRepositories.ITemaRepository.CriarAsync(_tema);
            await CoreRepositories.PersistirAsync();

            return _tema;
        }

        public async Task<IEnumerable<Tema>> ObterTema()
        {
            return await CoreRepositories.ITemaRepository.ObterAsync();
        }
    }
}
