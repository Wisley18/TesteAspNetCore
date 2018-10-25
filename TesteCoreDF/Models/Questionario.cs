using System;
using System.Collections.Generic;

namespace TesteCoreDF.Models
{
    public partial class Questionario
    {
        public Questionario()
        {
            Questionarioquestao = new HashSet<Questionarioquestao>();
        }

        public long Id { get; set; }
        public long IdTema { get; set; }
        public string Título { get; set; }
        public string Descricao { get; set; }
        public string StatusRegistro { get; set; }

        public Tema IdTemaNavigation { get; set; }
        public ICollection<Questionarioquestao> Questionarioquestao { get; set; }
    }
}
