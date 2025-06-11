using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Game
{
    public class UserLibraryDto
    {
        public string UserId { get; set; } = string.Empty;
        public int GameId { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}