using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Game
{
    public class CreateGameRequestDto
    {
        [Required]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(300, ErrorMessage = "Description cannot be longer than 300 characters.")]
        [MinLength(10, ErrorMessage = "Description must be at least 10 characters long.")]
        public string Description { get; set; } = string.Empty;
        [Required]
        [StringLength(50, ErrorMessage = "Developer cannot be longer than 50 characters.")]
        [MinLength(3, ErrorMessage = "Developer must be at least 3 characters long.")]
        public string Developer { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        [Required]
        [Range(0.01, 1000, ErrorMessage = "Price must be between 0.01 and 1000.")]
        public decimal Price { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "Release date must be between 1900 and 2100.")]
        public DateTime ReleaseDate { get; set; }
    }
}