using System;
using System.Collections.Generic;
using System.Text;
using TesteCoreDF.Helpers;
using TesteCoreDF.Repositories.Source;

namespace TesteCoreDF.Models
{
    public partial class QuestionarioQuestao : BaseContext
    {
        public QuestionarioQuestao(AbstractCoreRepository cr)
            : base(cr)
        {

        }
    }
}
