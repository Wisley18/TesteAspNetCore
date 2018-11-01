using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteCoreCF.Models.Entities;
using TesteCoreCF.Repositories.Interfaces;

namespace TesteCoreCF.Repositories.Source
{
    public class CoreRepository : IAbstractCoreRepository
    {
        private readonly AcademicoContextCF bd;
        private IQuestaoRepository iQuestaoRepository;
        private ITemaRepository iTemaRepository;



        public CoreRepository(AcademicoContextCF bd)
        {
            this.bd = bd;
        }

        public IQuestaoRepository IQuestaoRepository
        {
            get
            {
                return iQuestaoRepository = new QuestaoRepository(bd);
            }
        }

        public ITemaRepository ITemaRepository
        {
            get
            {
                return iTemaRepository = new TemaRepository(bd);
            }
        }


        //public CoreRepository()
        //    : this(new AcademicoContext())
        //{

        //}

        public async Task PersistirAsync()
        {
            await bd.SaveChangesAsync();
        }
    }
}
