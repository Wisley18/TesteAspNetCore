using System;
using System.Collections.Generic;
using System.Text;
using TesteCoreCF.Models.Entities;
using TesteCoreCF.Repositories.Interfaces;

namespace TesteCoreCF.Repositories.Source
{
    class TemaRepository : BaseRepository<Tema>, ITemaRepository
    {
        public TemaRepository(AcademicoContextCF bd)
            : base(bd)
        {
        }
    }
}
