using PedidoAPI.Model;
using PedidoAPI.Util;

namespace PedidoAPI.Data
{
    public interface IRepository<T>
        where T : BaseEntity
    {
        Result<T> Create(T entity);
        Result<T> ReadAll(T entity);
        Result<T> Read(T entity);
        Result<T> Update(T entity);
        Result<T> Delete(T entity);
    }
}
