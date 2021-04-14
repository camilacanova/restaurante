using PedidoAPI.Model;
using PedidoAPI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PedidoAPI.Data
{
    public class AbstractTypeRepository<T> : ITypeRepository<T> where T : BaseType
    {
        public PedidoContext context  { get; set; }
        public AbstractTypeRepository(PedidoContext context)
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

        public Result<T> ReadWhere(Expression<Func<T, bool>> predicate)
        {
            try
            {
                List<T> itens = context.Set<T>()
                    .Where(predicate)
                    .ToList();
                Result<T> result = new Result<T>(true, itens);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
