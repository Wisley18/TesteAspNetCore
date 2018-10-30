using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteCoreDF.Repositories.Interfaces;

namespace TesteCoreDF.Repositories.Source
{
    public interface AbstractCoreRepository
    {
        IQuestaoRepository IQuestaoRepository { get; }
        ITemaRepository ITemaRepository { get; }




        Task PersistirAsync();
    }
}
