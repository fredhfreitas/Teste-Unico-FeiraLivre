using System.ComponentModel.DataAnnotations;

namespace Unico.FeiraLivre.Domain
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
