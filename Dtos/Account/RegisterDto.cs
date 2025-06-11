using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Account
{
    public class RegisterDto
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }
        [Required]
        [MinLength(12, ErrorMessage = "Password must be at least 12 characters long.")]
        [MaxLength(20, ErrorMessage = "Password cannot exceed 20 characters.")]
        public string? Password { get; set; }
        
    }

}