using System;
using System.Collections.Generic;

namespace TesteCoreDF.Models
{
    public partial class Alternativa
    {
        public Alternativa()
        {
            Questionarioquestaoalternativa = new HashSet<Questionarioquestaoalternativa>();
        }

        public long Id { get; set; }
        public long IdQuestao { get; set; }
        public string Texto { get; set; }
        public string TipoResposta { get; set; }
        public string StatusRegistro { get; set; }
        public DateTimeOffset? DataHoraCriacao { get; set; }

        public Multiplaescolha IdQuestaoNavigation { get; set; }
        public ICollection<Questionarioquestaoalternativa> Questionarioquestaoalternativa { get; set; }
    }
}
