using System;
using System.Collections.Generic;

namespace TesteCoreDF.Models
{
    public partial class Questionarioquestao
    {
        public Questionarioquestao()
        {
            Questionarioquestaoalternativa = new HashSet<Questionarioquestaoalternativa>();
        }

        public long Id { get; set; }
        public long IdQuestionario { get; set; }
        public long IdQuestao { get; set; }

        public Questao IdQuestaoNavigation { get; set; }
        public Questionario IdQuestionarioNavigation { get; set; }
        public ICollection<Questionarioquestaoalternativa> Questionarioquestaoalternativa { get; set; }
    }
}
