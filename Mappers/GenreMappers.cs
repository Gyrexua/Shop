using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Genre;

namespace api.Mappers
{
    public static class GenreMappers
    {
        public static GenreDto ToGenreDto(this GenreDto genreModel)
        {
            return new GenreDto
            {
                Id = genreModel.Id,
                Name = genreModel.Name,
            };
        }
    }
}