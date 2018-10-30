//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;
//using TesteCoreDF.Models;
//using TesteCoreDF.Repositories.Interfaces;

//namespace TesteCoreDF.Repositories.Source
//{
//    public class CoreRepository : AbstractCoreRepository
//    {
//        private readonly AcademicoContext bd;
//        private  IQuestaoRepository iQuestaoRepository;
//        private  ITemaRepository iTemaRepository;



//        private CoreRepository(AcademicoContext bd)
//        {
//            this.bd = bd;
//        }

//        public IQuestaoRepository IQuestaoRepository
//        {
//            get
//            {
//                return iQuestaoRepository = new QuestaoRepository(bd);
//            }
//        }

//        public ITemaRepository ITemaRepository
//        {
//            get
//            {
//                return iTemaRepository = new TemaRepository(bd);
//            }
//        }


//        //public CoreRepository()
//        //    : this(new AcademicoContext())
//        //{

//        //}

//        public async Task PersistirAsync()
//        {
//            await bd.SaveChangesAsync();
//        }
//    }
//}
