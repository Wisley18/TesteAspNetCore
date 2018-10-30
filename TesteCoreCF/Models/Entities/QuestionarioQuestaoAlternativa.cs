using System;
using System.Collections.Generic;

namespace TesteCoreCF.Models.Entities
{
    public partial class QuestionarioQuestaoAlternativa
    {
        public long Id { get; set; }
        public long IdQuestionarioQuestao { get; set; }
        public long IdAlternativa { get; set; }

        public Alternativa Alternativa { get; set; }
        public QuestionarioQuestao QuestionarioQuestao { get; set; }
    }
}
