using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PedidoAPI.Model
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public bool Ativo { get; set; }
    }
}
