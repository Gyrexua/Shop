using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
       public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
    : base(options)
{
}


        public DbSet<Genre> Genres { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<UserLibrary> UserLibraries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            List<IdentityRole> roles = new List<IdentityRole>
            {
                  new IdentityRole
        {
            Id = "1", // або Guid: "b0e1f926-96c3-4e88-b02b-7f9fcbf12d01"
            Name = "Admin",
            NormalizedName = "ADMIN"
        },
        new IdentityRole
        {
            Id = "2", // або Guid: "a1c4f6f2-c2cf-4a0b-9b3f-46dbd22b4d5a"
            Name = "User",
            NormalizedName = "USER"
        }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
    
        
    
}