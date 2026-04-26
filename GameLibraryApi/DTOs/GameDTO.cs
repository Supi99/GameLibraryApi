using GameLibraryApi.Models;

namespace GameLibraryApi.DTOs
{
    public class GameDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }

        public static GameDto FromEntity(Game game) => new GameDto
        {
            Id = game.Id,
            Title = game.Title,
            Genre = game.Genre,
            Description = game.Description,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }
}