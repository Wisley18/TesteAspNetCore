using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteCoreCF.Repositories.Interfaces;

namespace TesteCoreCF.Repositories.Source
{
    public interface IAbstractCoreRepository
    {
        IQuestaoRepository IQuestaoRepository { get; }
        ITemaRepository ITemaRepository { get; }




        Task PersistirAsync();
    }
}
