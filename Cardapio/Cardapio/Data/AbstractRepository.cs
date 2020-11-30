using CardapioService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardapioService.Data
{
    public class AbstractRepository<T> : IRepository<T> where T : BaseEntity
    {
        public CardapioServiceContext context  { get; set; }
        
        public T Create(T entity)
        {
            try
            {
                context.Add(entity);
                context.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
