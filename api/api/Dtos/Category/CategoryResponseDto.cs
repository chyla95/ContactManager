using api.Dtos.Subcategory;

namespace api.Dtos.Category
{
#pragma warning disable CS8618
    public class CategoryResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<SubcategoryResponseDto> ApplicableSubcategories { get; set; }
    }
#pragma warning restore CS8618
}
