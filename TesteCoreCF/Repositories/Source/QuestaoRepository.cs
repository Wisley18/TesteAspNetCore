using System;
using System.Collections.Generic;
using System.Text;
using TesteCoreCF.Models.Entities;
using TesteCoreCF.Repositories.Interfaces;
using TesteCoreCF.Repositories.Source;

namespace TesteCoreCF.Repositories.Source
{
    class QuestaoRepository : BaseRepository<Questao>, IQuestaoRepository
    {
        public QuestaoRepository(AcademicoContextCF bd)
            : base(bd)
        {
        }
    }
}
