using CardapioService.Data;
using CardapioService.Enum;
using CardapioService.Model;
using CardapioService.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardapioService.Structures
{
    public class FactoryResponse<T> where T : BaseEntity
    {
        public IRepository<T> Repository { get; set; }

        public Dictionary<EnumCommand, List<IStrategy<T>>> Strategies { get; set; }

    }
}
