using System;
using System.Collections.Generic;

namespace TesteCoreDF.Models.Entities
{
    public partial class Questao
    {
        public Questao()
        {
            QuestaoTema = new HashSet<QuestaoTema>();
            QuestionarioQuestao = new HashSet<QuestionarioQuestao>();
        }

        public long Id { get; set; }
        public string Texto { get; set; }
        public string Tipo { get; set; }
        public string StatusRegistro { get; set; }
        public DateTimeOffset? DataHoraCriacao { get; set; }

        public MultiplaEscolha MultiplaEscolha { get; set; }
        public ICollection<QuestaoTema> QuestaoTema { get; set; }
        public ICollection<QuestionarioQuestao> QuestionarioQuestao { get; set; }
    }
}
