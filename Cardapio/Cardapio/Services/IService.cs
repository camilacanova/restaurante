using CardapioService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardapioService.Services
{
    public interface IService<T>
        where T : BaseEntity
    {
        T Create(T entity);
        List<T> Read(T entity);
        T Update(T entity);
        bool Delete(int entityId);
    }
}
