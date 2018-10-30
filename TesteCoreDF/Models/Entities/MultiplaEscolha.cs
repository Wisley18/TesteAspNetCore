using System;
using System.Collections.Generic;

namespace TesteCoreDF.Models.Entities
{
    public partial class MultiplaEscolha
    {
        public MultiplaEscolha()
        {
            Alternativa = new HashSet<Alternativa>();
        }

        public long Id { get; set; }

        public Questao IdNavigation { get; set; }
        public ICollection<Alternativa> Alternativa { get; set; }
    }
}
