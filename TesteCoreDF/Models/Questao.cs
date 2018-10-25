using System;
using System.Collections.Generic;

namespace TesteCoreDF.Models
{
    public partial class Questao
    {
        public Questao()
        {
            Questaotema = new HashSet<Questaotema>();
            Questionarioquestao = new HashSet<Questionarioquestao>();
        }

        public long Id { get; set; }
        public string Texto { get; set; }
        public string Tipo { get; set; }
        public string StatusRegistro { get; set; }
        public DateTimeOffset? DataHoraCriacao { get; set; }

        public Multiplaescolha Multiplaescolha { get; set; }
        public ICollection<Questaotema> Questaotema { get; set; }
        public ICollection<Questionarioquestao> Questionarioquestao { get; set; }
    }
}
