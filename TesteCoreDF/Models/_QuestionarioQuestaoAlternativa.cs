﻿using System;
using System.Collections.Generic;
using System.Text;
using TesteCoreDF.Helpers;
using TesteCoreDF.Repositories.Source;

namespace TesteCoreDF.Models
{
    public partial class QuestionarioQuestaoAlternativa : BaseContext
    {
        public QuestionarioQuestaoAlternativa(AbstractCoreRepository cr)
            : base(cr)
        {

        }
    }
}
