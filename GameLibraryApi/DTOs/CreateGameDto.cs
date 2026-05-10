using System.ComponentModel.DataAnnotations;

namespace GameLibraryApi.DTOs
{
    public class CreateGameDto
    {
        [Required(ErrorMessage = "Title is required")]
        [MaxLength(200, ErrorMessage = "Title cannot exceed 200 characters")]
        public string Title { get; set; } = string.Empty;

        [MaxLength(2000, ErrorMessage = "Description cannot exceed 2000 characters")]
        public string Description { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Genre { get; set; } = string.Empty;

        [Range(0.0, 9999.99, ErrorMessage = "Price must be between 0 and 9999.99")]
        public decimal Price { get; set; }

        [Range(typeof(DateTime), "1970-01-01", "2100-12-31", ErrorMessage = "Release date must be between 1970 and 2100")]
        public DateTime ReleaseDate { get; set; }
    }
}