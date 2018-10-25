using System;
using System.Collections.Generic;

namespace TesteCoreDF.Models
{
    public partial class Questionarioquestaoalternativa
    {
        public long Id { get; set; }
        public long IdQuestionarioQuestao { get; set; }
        public long IdAlternativa { get; set; }

        public Alternativa IdAlternativaNavigation { get; set; }
        public Questionarioquestao IdQuestionarioQuestaoNavigation { get; set; }
    }
}
