using System;
using System.Collections.Generic;

namespace TesteCoreDF.Models
{
    public partial class Multiplaescolha
    {
        public Multiplaescolha()
        {
            Alternativa = new HashSet<Alternativa>();
        }

        public long Id { get; set; }

        public Questao IdNavigation { get; set; }
        public ICollection<Alternativa> Alternativa { get; set; }
    }
}
