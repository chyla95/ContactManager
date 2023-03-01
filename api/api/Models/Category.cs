using api.Models.Abstract;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
#pragma warning disable CS8618
    public class Category : Entity
    {
        [Required]
        [MinLength(3), MaxLength(20)]
        public string Name { get; set; }

        public IEnumerable<Subcategory>? ApplicableSubcategories { get; set; }
        public Subcategory? Subcategory { get; private set; }

        public void ApplySubcategory(Subcategory subcategory)
        {
            if (ApplicableSubcategories == null) throw new Exception("This category does not support any subcategories!");
            if (!ApplicableSubcategories.Any(sc => sc == subcategory)) throw new Exception("This subcategory is not applicable to this category!");
            Subcategory = subcategory;
        }
    }
#pragma warning restore CS8618
}
