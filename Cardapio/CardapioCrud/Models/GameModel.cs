using CardapioCrud.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace CardapioCrud.Models
{
    public class GameModel : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
