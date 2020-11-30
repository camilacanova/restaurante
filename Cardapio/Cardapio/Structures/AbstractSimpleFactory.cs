using CardapioService.Data;
using CardapioService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardapioService.Structures
{
    public abstract class AbstractSimpleFactory<T> : IFactory<T>
        where T : BaseEntity
    {
        public abstract FactoryResponse<T> create();

        protected CardapioServiceContext Context;
        public AbstractSimpleFactory(CardapioServiceContext context)
        {
            Context = context;
        }
    }
}
