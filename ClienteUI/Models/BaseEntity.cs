using System.ComponentModel.DataAnnotations;

namespace ClienteUI.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public bool Ativo { get; set; }

        public string Observacao { get; set; }
    }
}
