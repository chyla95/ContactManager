﻿using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Authentication
{
#pragma warning disable CS8618
    public class UserSignUpRequestDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(5), MaxLength(50)]
        public string Password { get; set; }
    }
#pragma warning restore CS8618
}
