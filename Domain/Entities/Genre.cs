using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Genre
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    public bool IsFiction { get; set; }

    [Range(0, 100)]
    public int Popularity { get; set; }

    public List<Book> Books { get; set; }
}