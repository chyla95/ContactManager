using api.Models.Abstract;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
#pragma warning disable CS8618
    public class Subcategory : Entity
    {
        [Required]
        [MinLength(3), MaxLength(20)]
        public string Name { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
#pragma warning restore CS8618
}
