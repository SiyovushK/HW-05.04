using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Book
{
    public int Id { get; set; }

    [Required, MaxLength(200)]
    public string Title { get; set; }

    [Range(1450, 2100)]
    public int Year { get; set; }

    [Required, StringLength(13, MinimumLength = 10)]
    public string ISBN { get; set; }

    [Range(1, 10000)]
    public int Pages { get; set; }

    [MaxLength(1000)]
    public string? Description { get; set; }

    public int AuthorId { get; set; }
    public int GenreId { get; set; }
    public Author Author { get; set; }
    public Genre Genre { get; set; }
}