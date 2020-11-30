using CardapioService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardapioService.Data
{
    public interface IRepository<T> 
        where T : BaseEntity
    {
        T Create(T entity);
        List<T> Read(T entity);
        T Update(T entity);
        bool Delete(int entityId);
    }
}
