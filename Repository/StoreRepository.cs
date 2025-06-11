using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StoreRepository : IStoreRepository
    {
        private readonly ApplicationDBContext _context;
        public StoreRepository(ApplicationDBContext context)
        {
            // Store the context if needed for database operations
            _context = context;
        }

        public async Task<Game> CreateAsync(Game gameModel)
        {
            await _context.Games.AddAsync(gameModel);
            await _context.SaveChangesAsync();
            return gameModel;
        }

        public async Task<List<Game>> GetAllAsync()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task<Game?> GetByIdAsync(int id)
        {
            return await _context.Games.FindAsync(id);
        }

        public async Task<Game?> UpdateAsync(int id, Game gameModel)
        {
            var existingGame = await _context.Games.FindAsync(id);
            if (existingGame == null)
            {
                return null; // Game not found
            }
            existingGame.Name = gameModel.Name;
            existingGame.Price = gameModel.Price;
            existingGame.Description = gameModel.Description;
            existingGame.ReleaseDate = gameModel.ReleaseDate;
            existingGame.Genres = gameModel.Genres;
            existingGame.Developer = gameModel.Developer;


            await _context.SaveChangesAsync();
            return existingGame;
        }
        public async Task<Game> DeleteAsync(int id)
        {
            var Game = await _context.Games.FirstOrDefaultAsync(c => c.Id == id);
            if (Game == null)
            {
                return null; // Game not found
            }
            _context.Games.Remove(Game);
            await _context.SaveChangesAsync();
            return Game;
        }
    }
}