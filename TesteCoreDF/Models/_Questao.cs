//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;
//using TesteCoreDF.Helpers;
//using TesteCoreDF.Repositories.Interfaces;
//using TesteCoreDF.Repositories.Source;

//namespace TesteCoreDF.Models
//{
//    public partial class Questao : BaseContext, IEntity
//    {
//        public Questao(AbstractCoreRepository cr)
//            : base(cr)
//        {

//        }

//        public async Task<IEnumerable<Questao>> ObterTodas()
//        {
//            return await CoreRepositories.IQuestaoRepository.ObterAsync();
//        }

//        public async Task<Tuple<IEnumerable<Questao>, int>> ObterTodas(int skip, int take)
//        {
//            return await CoreRepositories.IQuestaoRepository.ObterAsync(skip, take);
//        }


//    }
//}
