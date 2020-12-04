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
            if (string.IsNullOrEmpty(entity.Nome))
                return new Result<Cardapio>() { Success = false, Messages = new List<string> { "Nome é obrigatório" } };
            return new Result<Cardapio>() { Success = true };
        }
    }
}
