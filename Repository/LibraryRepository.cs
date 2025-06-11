using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;

namespace api.Repository
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly ApplicationDBContext _context;
        public LibraryRepository(ApplicationDBContext context)
        {
            // Store the context if needed for database operations
            _context = context;
        }
        public async Task<List<UserLibrary>> GetLibraryAsync(string userId)
        {
                return await _context.UserLibraries
                .Include(l => l.Game) 
                .Where(w => w.UserId == userId)
                .ToListAsync();
        }

    }
}