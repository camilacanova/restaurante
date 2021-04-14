using System;
using PedidoAPI.Model;
using PedidoAPI.Util;

namespace PedidoAPI.Data
{
    public interface ITypeRepository<T>
        where T : BaseType
    {
        Result<T> Create(T entity);
        Result<T> ReadAll(T entity);
        Result<T> Read(T entity);
        Result<T> ReadWhere(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        Result<T> Update(T entity);
        Result<T> Delete(T entity);
    }
}
