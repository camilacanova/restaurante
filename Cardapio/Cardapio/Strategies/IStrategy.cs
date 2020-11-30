using CardapioService.Model;
using CardapioService.Util;

namespace CardapioService.Strategies
{
    public interface IStrategy<T>
        where T : BaseEntity
    {
        Result<T> Execute(T entity);
    }
}
