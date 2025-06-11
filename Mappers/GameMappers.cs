using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Game;
using api.Models;

namespace api.Mappers
{
    public static class GameMappers
    {
        public static GameDto ToGameDto(this Game gameModel)
        {
            return new GameDto
            {
                Id = gameModel.Id,
                Name = gameModel.Name,
                Developer = gameModel.Developer,
                Description = gameModel.Description,
                Price = gameModel.Price,
                ReleaseDate = gameModel.ReleaseDate,
                Genres = gameModel.Genres.Select(g => new Genre
                {
                    Id = g.Id,
                    Name = g.Name
                }).ToList()
            };
        }
        public static Game ToStockFromCreateDTO(this CreateGameRequestDto gameDto)
        {
            return new Game
            {
                Name = gameDto.Name,
                Description = gameDto.Description,
                Developer = gameDto.Developer,
                Price = gameDto.Price,
                ReleaseDate = gameDto.ReleaseDate,
            };
        }
    }
}