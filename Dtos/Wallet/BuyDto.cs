using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Wallet
{
    public class BuyDto
    {
        [Required]
        [Range(0.01, 10000, ErrorMessage = "Сума має бути в діапазоні від 0.01 до 10 000.")]
        public decimal Amount { get; set; }
        [Required]
        public string UserId { get; set; }
    }
}