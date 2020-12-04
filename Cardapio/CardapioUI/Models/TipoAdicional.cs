using System.ComponentModel.DataAnnotations.Schema;

namespace CardapioUI.Models
{
    [Table("TipoAdicional")]
    public class TipoAdicional : BaseEntity
    {
        public string NomeItem { get; set; }
    }
}