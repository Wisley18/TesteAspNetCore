using System;
using System.Collections.Generic;

namespace TesteCoreCF.Models.Entities
{
    public partial class Alternativa
    {
        public Alternativa()
        {
            QuestionarioQuestaoAlternativa = new HashSet<QuestionarioQuestaoAlternativa>();
        }

        public long Id { get; set; }
        public long IdQuestao { get; set; }
        public string Texto { get; set; }
        public string TipoResposta { get; set; }
        public string StatusRegistro { get; set; }
        public DateTimeOffset? DataHoraCriacao { get; set; }

        public MultiplaEscolha MultiplaEscolha { get; set; }
        public ICollection<QuestionarioQuestaoAlternativa> QuestionarioQuestaoAlternativa { get; set; }
    }
}
