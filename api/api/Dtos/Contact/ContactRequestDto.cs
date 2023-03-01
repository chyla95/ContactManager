using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Contact
{
#pragma warning disable CS8618
    public class ContactRequestDto
    {
        [Required]
        [MinLength(2), MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2), MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MinLength(2), MaxLength(30)]
        public string Phone { get; set; }

        [Required]
        public bool IsPublic { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [MinLength(3), MaxLength(20)]
        public string? Subcategory { get; set; }

        [Required]
        public DateTime Birthday { get; set; }
    }
#pragma warning restore CS8618
}
