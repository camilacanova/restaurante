using CardapioService.Model;
using CardapioService.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardapioService.Strategies
{
    public class CreateCardapio : IStrategy<Cardapio>
    {
        public Result<Cardapio> Execute(Cardapio entity)
        {
            if (string.IsNullOrEmpty(entity.Nome) || entity.RestauranteId <= 0)
                return new Result<Cardapio>() { Success = false, Messages = new List<string> { "Nome e id do Restaurante são obrigatórios" } };
            return new Result<Cardapio>() { Success = true };
        }
    }
}
