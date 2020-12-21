using CardapioService.Data;
using CardapioService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardapioService.Structures
{
    public abstract class AbstractBuilder<T> : IBuilder<T>
        where T : BaseEntity
    {
        public abstract BuilderResponse<T> create();

        protected CardapioServiceContext Context;
        public AbstractBuilder(CardapioServiceContext context)
        {
            Context = context;
        }
    }
}
