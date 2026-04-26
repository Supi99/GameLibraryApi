using GameLibraryApi.Data;
using GameLibraryApi.Models;
using GameLibraryApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameLibraryApi.Repositories;

public class GamesRepository : IGamesRepository
{
    private readonly AppDbContext _context;

    public GamesRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Game>> GetAllAsync()
    {
        return await _context.Games.ToListAsync();
    }

    public async Task<Game?> GetByIdAsync(int id)
    {
        return await _context.Games.FindAsync(id);
    }

    public async Task<Game> CreateAsync(Game game)
    {
        _context.Games.Add(game);
        await _context.SaveChangesAsync();
        return game;
    }

    public async Task<Game?> UpdateAsync(int id, Game game)
    {
        var existing = await _context.Games.FindAsync(id);
        if (existing is null) return null;

        existing.Title = game.Title;
        existing.Genre = game.Genre;
        existing.Description = game.Description;
        existing.Price = game.Price;
        existing.ReleaseDate = game.ReleaseDate;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var deleted = await _context.Games
            .Where(g => g.Id == id)
            .ExecuteDeleteAsync();
        return deleted > 0;
    }
}