using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Library
{
    public class AddToLibraryDto
    {
        public string UserId { get; set; } = string.Empty;
        public int GameId { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.Now;
    }
}