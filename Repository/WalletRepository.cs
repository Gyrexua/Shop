using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Wallet;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class WalletRepository : IWalletRepository
    {
        private readonly ApplicationDBContext _context;
        public WalletRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Wallet?> CreateAsync(Wallet walletModel)
        {
            await _context.Wallets.AddAsync(walletModel);
            await _context.SaveChangesAsync();
            return walletModel;
        }

        public async Task<Wallet?> GetWalletAsync(string userId)
        {
            return await _context.Wallets.FirstOrDefaultAsync(w => w.UserId == userId);
        }

        public async Task UpdateAsync(Wallet wallet)
        {
            _context.Wallets.Update(wallet); // можна і без Update, якщо wallet відслідковується
            await _context.SaveChangesAsync();
        }
        
        public async Task AddGameToUserLibraryAsync(string userId, int gameId)
    {
        var userLibrary = new UserLibrary
        {
            UserId = userId,
            GameId = gameId,
            PurchaseDate = DateTime.UtcNow
        };

        await _context.UserLibraries.AddAsync(userLibrary);
        await _context.SaveChangesAsync();
    }
    }
}