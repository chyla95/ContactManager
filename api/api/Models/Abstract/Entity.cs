using System.ComponentModel.DataAnnotations;

namespace api.Models.Abstract
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
