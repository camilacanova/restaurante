using PedidoAPI.Model;
using PedidoAPI.Util;

namespace PedidoAPI.Strategies
{
    public interface ITypeStrategy<T>
        where T : BaseType
    {
        Result<T> execute(T entity);
    }
}
