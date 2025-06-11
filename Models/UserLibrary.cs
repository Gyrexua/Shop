using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class UserLibrary
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public Game Game { get; set; }
        public int GameId { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;
    }
}