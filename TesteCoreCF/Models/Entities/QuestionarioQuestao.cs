using System;
using System.Collections.Generic;

namespace TesteCoreCF.Models.Entities
{
    public partial class QuestionarioQuestao
    {
        public QuestionarioQuestao()
        {
            QuestionarioQuestaoAlternativa = new HashSet<QuestionarioQuestaoAlternativa>();
        }

        public long Id { get; set; }
        public long IdQuestionario { get; set; }
        public long IdQuestao { get; set; }

        public Questao Questao { get; set; }
        public Questionario Questionario { get; set; }
        public ICollection<QuestionarioQuestaoAlternativa> QuestionarioQuestaoAlternativa { get; set; }
    }
}
