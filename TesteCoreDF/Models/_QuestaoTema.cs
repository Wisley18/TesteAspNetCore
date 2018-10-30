using System;
using System.Collections.Generic;
using System.Text;
using TesteCoreDF.Helpers;
using TesteCoreDF.Repositories.Source;

namespace TesteCoreDF.Models
{
    public partial class QuestaoTema : BaseContext
    {
        public QuestaoTema(AbstractCoreRepository cr)
            : base(cr)
        {

        }
    }
}
