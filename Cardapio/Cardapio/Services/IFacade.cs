using CardapioService.Model;
using CardapioService.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardapioService.Services
{
    public interface IFacade<T>
        where T : BaseEntity
    {
        Result<T> Create(T entity);
        Result<T> ReadAll(T entity);
        Result<T> Read(T entity);
        Result<T> Update(T entity);
        Result<T> Delete(T entity);
    }
}
