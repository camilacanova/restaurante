using PedidoAPI.Model;
using PedidoAPI.Util;

namespace PedidoAPI.Strategies
{
    public interface IStrategy<T>
        where T : BaseEntity
    {
        Result<T> execute(T entity);
    }
}
