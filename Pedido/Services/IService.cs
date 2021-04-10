using PedidoAPI.Model;
using PedidoAPI.Util;

namespace PedidoAPI.Services
{
    public interface IService<T>
        where T : BaseEntity
    {
        Result<T> Create(T entity);
        Result<T> ReadAll(T entity);
        Result<T> Read(T entity);
        Result<T> Update(T entity);
    }
}
