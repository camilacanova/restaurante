using CardapioService.Data;
using CardapioService.Enum;
using CardapioService.Model;
using CardapioService.Strategies;
using CardapioService.Structures;
using CardapioService.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardapioService.Services
{
    public abstract class DefaultFacade<T> : IFacade<T>
        where T : BaseEntity
    {
        public IFactory<T> Factory { get; set; }

        private FactoryResponse<T> factoryResponse;

        public DefaultFacade(IFactory<T> factory)
        {
            Factory = factory;
            factoryResponse = Factory.create();
        }

        public Result<T> Execute(EnumCommand command, T entity)
        {
            try
            {
                if (factoryResponse == null)
                    return new Result<T>()
                    {
                        Success = false,
                        Messages = new List<string>() { "Erro ao construir itens de validação para o objeto" + entity.GetType().Name }
                    };

                var strategies = factoryResponse.Strategies[command];

                Result<T> result = new Result<T>() { Success = true, Messages = new List<string>() };
                foreach (var strategy in strategies)
                {
                    var r = strategy.Execute(entity);
                    result.Success = result.Success && r.Success;
                    result.Messages.AddRange(r.Messages);
                }

                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Result<T> Create(T entity)
        {
            var result = Execute(EnumCommand.CREATE, entity);
            if (result.Success)
                return factoryResponse.Repository.Create(entity);
            return result;
        }

        public Result<T> ReadAll(T entity)
        {
            var result = Execute(EnumCommand.READ, entity);
            if (result.Success)
                return factoryResponse.Repository.ReadAll(entity);
            return result;
        }

        public Result<T> Read(int entityId)
        {
            T entity = (T)(new BaseEntity() { Id = entityId });
            var result = Execute(EnumCommand.READ, entity);
            if (result.Success)
                return factoryResponse.Repository.Read(entityId);
            return result;
        }

        public Result<T> Update(T entity)
        {
            var result = Execute(EnumCommand.UPDATE, entity);
            if (result.Success)
                return factoryResponse.Repository.Create(entity);
            return result;
        }

        public Result<T> Delete(int entityId)
        {
            T entity = (T)(new BaseEntity() { Id = entityId });
            var result = Execute(EnumCommand.DELETE, entity);
            if (result.Success)
                return factoryResponse.Repository.Read(entityId);
            return result;
        }
    }
}
