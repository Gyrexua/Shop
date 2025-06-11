using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Wallet;
using api.Models;

namespace api.Interfaces
{
    public interface IWalletRepository
    {
        Task<Wallet?> GetWalletAsync(string userId);
        Task UpdateAsync(Wallet wallet);

        Task<Wallet?> CreateAsync(Wallet wallet);

       Task AddGameToUserLibraryAsync(string userId, int gameId);
    }
}