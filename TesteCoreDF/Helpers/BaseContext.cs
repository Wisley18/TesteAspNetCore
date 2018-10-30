using System;
using System.Collections.Generic;
using System.Text;
using TesteCoreDF.Repositories.Source;

namespace TesteCoreDF.Helpers
{
    public class BaseContext
    {
        public readonly AbstractCoreRepository CoreRepositories;

        //public BaseContext()
        //    : this(new CoreRepository())
        //{

        //}

        public BaseContext(AbstractCoreRepository CoreRepositories)
        {
            this.CoreRepositories = CoreRepositories;
        }
    }
}
