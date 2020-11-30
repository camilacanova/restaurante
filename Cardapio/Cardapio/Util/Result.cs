using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardapioService.Util
{
    public class Result<T>
    {
        public Result()
        {

        }
        public Result(bool success, T entities)
        {
            Success = success;
            Entities = new List<T>() { entities };
        }

        public Result(bool success, List<T> entities)
        {
            Success = success;
            Entities = entities;
        }

        public List<T> Entities { get; set; }
        public bool Success { get; set; }
        public List<String> Messages { get; set; }
    }
}
