using System;
using System.Collections.Generic;

namespace TesteCoreDF.Models.Entities
{
    public partial class QuestionarioQuestaoAlternativa
    {
        public long Id { get; set; }
        public long IdQuestionarioQuestao { get; set; }
        public long IdAlternativa { get; set; }

        public Alternativa IdAlternativaNavigation { get; set; }
        public QuestionarioQuestao IdQuestionarioQuestaoNavigation { get; set; }
    }
}
