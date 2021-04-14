using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PedidoAPI.Data;
using PedidoAPI.Data.Repositories;
using PedidoAPI.Model;
using PedidoAPI.Strategies;
using PedidoAPI.Util;

namespace PedidoAPI.Services
{
    public class MesaService : ITypeService<Mesa>
    {
        private AbstractTypeRepository<Mesa> repo;

        public MesaService(AbstractTypeRepository<Mesa> repo)
        {
            this.repo = repo;
        }

        public Result<Mesa> Create(Mesa entity)
        {
            return repo.Create(entity);
        }

        public Result<Mesa> Read(Mesa entity)
        {
            var result = repo.Read(entity);
            return result;
        }

        public Result<Mesa> ReadAll(Mesa entity)
        {
            var result = repo.ReadAll(entity);
            return result;
        }

        public Result<Mesa> ReadWhere(Expression<Func<Mesa, bool>> predicate)
        {
            var result = repo.ReadWhere(predicate);
            return result;
        }

        public Result<Mesa> Update(Mesa entity)
        {
            return repo.Update(entity);
        }
    }
}
