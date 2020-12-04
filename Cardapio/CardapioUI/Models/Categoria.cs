using System.ComponentModel.DataAnnotations.Schema;

namespace CardapioUI.Models
{
    [Table("Categoria")]
    public class Categoria : BaseEntity
    {
        public string NomeCategoria { get; set; }
    }
}