using CardapioService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardapioService.Strategies
{
    public interface IStrategy<T>
        where T : BaseEntity
    {
        bool Execute(T entity);
    }
}
