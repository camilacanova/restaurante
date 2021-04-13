using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClienteUI.Models
{
    public class ItemCarrinho : BaseEntity
    {
        public string NomeItem { get; set; }

        public decimal Valor { get; set; }

        public int CardapioId { get; set; }

        public int ItemId { get; set; }

        public int Quantidade { get; set; }

    }
}