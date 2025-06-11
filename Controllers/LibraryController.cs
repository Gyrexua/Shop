using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("library")]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryRepository _libraryRepo;
        private readonly ApplicationDBContext _context;

        public LibraryController(ILibraryRepository libraryRepo, ApplicationDBContext context)
        {
            _libraryRepo = libraryRepo;
            _context = context;
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetLibrary([FromRoute] string userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userLibrary = await _libraryRepo.GetLibraryAsync(userId);
            if (userLibrary == null)
            {
                return NotFound("Library not found.");
            }
            var libraryDto = userLibrary.Select(s => s.ToLibraryDto()).ToList();

            return Ok(userLibrary);
        }
    }
}