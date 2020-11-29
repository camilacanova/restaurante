using System.ComponentModel.DataAnnotations;

namespace CardapioCrud.Core
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
