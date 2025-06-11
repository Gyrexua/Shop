using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IStoreRepository
    {
        Task<List<Game>> GetAllAsync();
        Task<Game?> GetByIdAsync(int id);
        Task<Game> CreateAsync(Game gameModel);
        Task<Game?> UpdateAsync(int id, Game gameModel);
        Task<Game>DeleteAsync(int id);
    }
}