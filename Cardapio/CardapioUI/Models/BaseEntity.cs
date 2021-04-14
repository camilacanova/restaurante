using System;
using System.ComponentModel.DataAnnotations;

namespace CardapioUI.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public bool Ativo { get; set; }

        public string Observacao { get; set; }
    }

    public class BaseType
    {
        [Key]
        public Guid Id { get; set; }
        public bool Ativo { get; set; }
    }
}
