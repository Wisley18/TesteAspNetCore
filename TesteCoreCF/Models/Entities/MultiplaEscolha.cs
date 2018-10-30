using System;
using System.Collections.Generic;

namespace TesteCoreCF.Models.Entities
{
    public partial class MultiplaEscolha
    {
        public MultiplaEscolha()
        {
            Alternativa = new HashSet<Alternativa>();
        }

        public long Id { get; set; }

        public Questao Questao { get; set; }
        public ICollection<Alternativa> Alternativa { get; set; }
    }
}
