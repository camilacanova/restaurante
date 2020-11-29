using System.ComponentModel.DataAnnotations.Schema;

namespace CardapioService.Model
{
    [Table("Categoria")]
    public class Categoria : BaseEntity
    {
        public string NomeCategoria { get; set; }
    }
}