using System;
using System.Collections.Generic;

namespace TesteCoreDF.Models.Entities
{
    public partial class Tema
    {
        public Tema()
        {
            QuestaoTema = new HashSet<QuestaoTema>();
            Questionario = new HashSet<Questionario>();
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string StatusRegistro { get; set; }
        public DateTimeOffset? DataHoraCriacao { get; set; }

        public ICollection<QuestaoTema> QuestaoTema { get; set; }
        public ICollection<Questionario> Questionario { get; set; }
    }
}
