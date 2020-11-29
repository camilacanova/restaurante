using System.ComponentModel.DataAnnotations.Schema;

namespace CardapioService.Model
{
    [Table("TipoAdicional")]
    public class TipoAdicional : BaseEntity
    {
        public string NomeItem { get; set; }
    }
}