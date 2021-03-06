﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ClienteUI.Models
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public bool Ativo { get; set; }
    }

    public class BaseType
    {
        [Key]
        public int Id { get; set; }
        public bool Ativo { get; set; }

        public string Observacao { get; set; }
    }
}
