using System;
using System.Collections.Generic;
using System.Text;
using TesteCoreCF.Repositories.Source;

namespace TesteCoreCF.Models.EntitiesBusiness
{
    public class BaseContext
    {
        public IAbstractCoreRepository CoreRepositories;

        public BaseContext()
        {
            
        }

        public BaseContext(IAbstractCoreRepository cr)
        {
            CoreRepositories = cr;
        }
    }
}
