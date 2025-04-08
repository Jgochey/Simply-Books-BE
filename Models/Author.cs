using System.ComponentModel.DataAnnotations;

namespace SimplyBooks.Models;


public class Author
{
    public int Id { get; set; }
    [Required]
    public string? Email { get; set; }
    public string? First_Name { get; set; }
    public string? Last_Name { get; set; }
    public string? Image { get; set; }
    public bool Favorite { get; set; }
    public string? Uid { get; set; } // The firebaseKey will be a string, not an int.
}
