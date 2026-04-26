using GameLibraryApi.DTOs;
using GameLibraryApi.Repositories.Interfaces;
using GameLibraryApi.Services.Interfaces;

namespace GameLibraryApi.Services
{
    public class GamesService : IGamesService
    {
        private readonly IGamesRepository _repository;

        public GamesService(IGamesRepository repos)
        {
            _repository = repos;
        }

        public async Task<GameDto> CreateAsync(CreateGameDto dto)
        {
            var game = new Models.Game
            {
                Title = dto.Title,
                Genre = dto.Genre,
                Description = dto.Description,
                Price = dto.Price,
                ReleaseDate = dto.ReleaseDate
            };
            var x = await _repository.CreateAsync(game);
            return GameDto.FromEntity(x);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<GameDto>> GetAllAsync()
        {
            var gs = await _repository.GetAllAsync();
            return gs.Select(GameDto.FromEntity);
        }

        public async Task<GameDto?> GetByIdAsync(int id)
        {
            var x = await _repository.GetByIdAsync(id);
            if (x == null)
                return null;
            return GameDto.FromEntity(x);
        }

        public async Task<GameDto?> UpdateAsync(int id, UpdateGameDto dto)
        {
            var game = await _repository.GetByIdAsync(id);

            if (game is null)
                return null;

            game.Title = dto.Title;
            game.Description = dto.Description;
            game.Price = dto.Price;
            game.Genre = dto.Genre;

            var updated = await _repository.UpdateAsync(id, game);
            if (updated == null)
                return null;
            return GameDto.FromEntity(updated);
        }
    }
}