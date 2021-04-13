using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClienteUI.Models
{
    public class Carrinho : BaseType
    {
        public List<ItemCarrinho> Itens { get; set; }
    }
}