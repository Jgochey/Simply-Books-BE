using System.ComponentModel.DataAnnotations;

namespace SimplyBooks.Models;

public class Book
{
    public int Id { get; set; }
    [Required]
    public int AuthorId { get; set; }
    public string? Title { get; set; }
    public string? Image { get; set; }
    public int Price { get; set; }
    public bool Sale { get; set; }

    public string? Uid { get; set; } // The firebaseKey will be a string, not an int.
    public string? Description { get; set; }
    public bool IsPrivate { get; set; }
}
