using GameLibraryApi.DTOs;
using GameLibraryApi.Models;

namespace GameLibraryApi.Services.Interfaces
{
    public interface IGamesService
    {
        Task<IEnumerable<GameDto>> GetAllAsync();

        Task<GameDto?> GetByIdAsync(int id);

        Task<GameDto> CreateAsync(CreateGameDto dto);

        Task<GameDto?> UpdateAsync(int id, UpdateGameDto dto);

        Task<bool> DeleteAsync(int id);
    }
}