using System;
using System.Collections.Generic;

namespace TesteCoreDF.Models.Entities
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

        public Questao IdQuestaoNavigation { get; set; }
        public Questionario IdQuestionarioNavigation { get; set; }
        public ICollection<QuestionarioQuestaoAlternativa> QuestionarioQuestaoAlternativa { get; set; }
    }
}
