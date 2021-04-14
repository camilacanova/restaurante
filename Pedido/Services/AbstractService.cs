using System;
using PedidoAPI.Model;
using PedidoAPI.Util;

namespace PedidoAPI.Services
{
    public abstract class AbstractService<T> : IService<T>
    where T : BaseEntity
    {
        public abstract Result<T> Create(T entity);
        public abstract Result<T> Read(T entity);
        public abstract Result<T> ReadAll(T entity);
        public abstract Result<T> ReadWhere(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        public abstract Result<T> Update(T entity);
    }
}
