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
    public interface IFactory<T> where T : BaseEntity
    {
        FactoryResponse<T> create();
    }
}
