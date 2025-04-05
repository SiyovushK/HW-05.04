using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Author
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; }

    [Range(1000, 2100)]
    public int BirthYear { get; set; }

    [MaxLength(100)]
    public string? Country { get; set; }

    [MaxLength(1000)]
    public string? Biography { get; set; }

    public List<Book> Books { get; set; }
}