using CardapioService.Data;
using CardapioService.Model;
using CardapioService.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardapioService.Services
{
    public abstract class DefaultService<T> : IService<T>
        where T : BaseEntity
    {
        public List<IStrategy<T>> Strategies { get; set; }
        public IRepository<T> Repository { get; set; }

        public DefaultService()
        {

        }
        public T Create(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public List<T> Read(T entity)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
