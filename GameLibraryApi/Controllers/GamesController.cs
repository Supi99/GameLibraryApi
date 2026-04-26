using GameLibraryApi.DTOs;
using GameLibraryApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameLibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGamesService _service;

        public GamesController(IGamesService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dtos = await _service.GetAllAsync();
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var game = await _service.GetByIdAsync(id);
            if (game is null) return NotFound();
            return Ok(game);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGameDto dto)
        {
            var game = await _service.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = game.Id }, game);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateById([FromBody] UpdateGameDto dto, int id)
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await _service.DeleteAsync(id);
            if (status)
                return Ok();
            else
                return NotFound();
        }
    }
}