using System;
using System.Collections.Generic;

namespace TesteCoreDF.Models.Entities
{
    public partial class QuestaoTema
    {
        public long Id { get; set; }
        public long IdTema { get; set; }
        public long IdQuestao { get; set; }
        public string Relevancia { get; set; }
        public string Dificuldade { get; set; }
        public string StatusRegistro { get; set; }
        public DateTimeOffset? DataHoraCriacao { get; set; }

        public Questao IdQuestaoNavigation { get; set; }
        public Tema IdTemaNavigation { get; set; }
    }
}
