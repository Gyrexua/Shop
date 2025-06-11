using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Game;
using api.Dtos.Library;
using api.Models;
using Microsoft.Extensions.DependencyModel;

namespace api.Mappers
{
    public static class LibraryMappers
    {
        public static LibraryGameDto ToLibraryDto(this UserLibrary userLibrary)
        {
            return new LibraryGameDto
            {
                Title = userLibrary.Game.Name,
                Description = userLibrary.Game.Description
            };
        }
        public static AddToLibraryDto addToLibraryDto(this UserLibrary userLibrary)
        {
            return new AddToLibraryDto
            {
                UserId = userLibrary.UserId,
                GameId = userLibrary.GameId,
                PurchaseDate = userLibrary.PurchaseDate
            };
        }
    }
}