using System;
using System.Collections.Generic;

namespace TesteCoreCF.Models.Entities
{
    public partial class Alternativa
    {
        public long Id { get; set; }
        public long IdQuestao { get; set; }
        public string Texto { get; set; }
        public string TipoResposta { get; set; }
        public string StatusRegistro { get; set; }
        public DateTimeOffset? DataHoraCriacao { get; set; }

        public MultiplaEscolha MultiplaEscolha { get; set; }
    }
}
