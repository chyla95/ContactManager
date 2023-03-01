using api.Dtos.Category;
using api.Dtos.User;
using api.Models;
using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Contact
{
#pragma warning disable CS8618
    public class ContactResponseDto
    {
        public UserResponseDto Owner { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsPublic { get; set; }
        public CategoryResponseDto Category { get; set; }
        public string? Subcategory { get; set; }
        public DateTime Birthday { get; set; }
    }
#pragma warning restore CS8618
}
