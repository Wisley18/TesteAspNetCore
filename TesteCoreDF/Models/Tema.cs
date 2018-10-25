using System;
using System.Collections.Generic;

namespace TesteCoreDF.Models
{
    public partial class Tema
    {
        public Tema()
        {
            Questaotema = new HashSet<Questaotema>();
            Questionario = new HashSet<Questionario>();
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string StatusRegistro { get; set; }
        public DateTimeOffset? DataHoraCriacao { get; set; }

        public ICollection<Questaotema> Questaotema { get; set; }
        public ICollection<Questionario> Questionario { get; set; }
    }
}
