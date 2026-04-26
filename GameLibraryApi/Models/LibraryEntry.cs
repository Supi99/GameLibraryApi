namespace GameLibraryApi.Models;

public class LibraryEntry
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public int GameId { get; set; }
    public Game Game { get; set; } = null!;
    public DateTime AddedAt { get; set; }
}