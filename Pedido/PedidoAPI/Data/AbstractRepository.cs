using PedidoAPI.Model;
using PedidoAPI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoAPI.Data
{
    public class AbstractRepository<T> : IRepository<T> where T : BaseEntity
    {
        public PedidoContext context  { get; set; }
        public AbstractRepository()
        {
            this.context = context;
        }
        
        public virtual Result<T> Create(T entity)
        {
            try
            {
                context.Add(entity);
                context.SaveChanges();
                Result<T> result = new Result<T>(true, entity);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual Result<T> Delete(T entity)
        {
            try
            {
                T item = context.Set<T>().SingleOrDefault(c => c.Id == entity.Id);

                context.Remove(item);
                context.SaveChanges();
                Result<T> result = new Result<T>(true, item);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual Result<T> Read(T entity)
        {
            try
            {
                T item = context.Set<T>().SingleOrDefault(c => c.Id == entity.Id);
                Result<T> result = new Result<T>(true, item);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual Result<T>  ReadAll(T entity)
        {
            try
            {
                List<T> itens = context.Set<T>().OrderBy(x => x.Id).ToList();
                Result<T> result = new Result<T>(true, itens);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual Result<T> Update(T entity)
        {
            try
            {
                context.Update(entity);
                context.SaveChanges();
                Result<T> result = new Result<T>(true, entity);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
