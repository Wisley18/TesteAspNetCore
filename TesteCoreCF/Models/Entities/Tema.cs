using System;
using System.Collections.Generic;

namespace TesteCoreCF.Models.Entities
{
    public partial class Tema
    {
        public Tema()
        {
            QuestaoTema = new HashSet<QuestaoTema>();
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string StatusRegistro { get; set; }
        public DateTimeOffset? DataHoraCriacao { get; set; }

        public ICollection<QuestaoTema> QuestaoTema { get; set; }
    }
}
