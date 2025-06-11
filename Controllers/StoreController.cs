using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Game;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("store")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreRepository _gameRepo;

        public StoreController(IStoreRepository gameRepo)
        {
            _gameRepo = gameRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
             if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var games = await _gameRepo.GetAllAsync();

            var gameDtos = games.Select(c => c.ToGameDto());

            return Ok(games);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
                        if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var game = await _gameRepo.GetByIdAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            return Ok(game.ToGameDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGameRequestDto gameDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var gameModel =  gameDto.ToStockFromCreateDTO();
            await _gameRepo.CreateAsync(gameModel);
            return CreatedAtAction(nameof(GetById), new { id = gameModel.Id }, gameModel.ToGameDto());
        }
    }
}