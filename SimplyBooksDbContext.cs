using Microsoft.EntityFrameworkCore;
using SimplyBooks.Models;

public class SimplyBooksDbContext : DbContext
{

  public DbSet<Author> Authors { get; set; }
  public DbSet<Book> Books { get; set; }

  public SimplyBooksDbContext(DbContextOptions<SimplyBooksDbContext> context) : base(context)
  {

  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {

    modelBuilder.Entity<Author>().HasData(new Author[]
    {
          new Author {Id = 1, First_Name = "Dr.", Last_Name = "Seuss", Email = "Thing1@Thing2.com", Image = "https://upload.wikimedia.org/wikipedia/en/1/19/Dr_Seuss.jpg", Favorite = true, Uid = "123" },
          new Author {Id = 2, First_Name = "J.R.R.", Last_Name = "Tolkien", Email = "1Ring@2Rule.net", Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4c/J_R_R_Tolkien%2C_1940.jpg/800px-J_R_R_Tolkien%2C_1940.jpg", Favorite = true, Uid = "123" },
          new Author {Id = 3, First_Name = "Edgar", Last_Name = "Poe", Email = "Never@More.com", Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0c/Edgar_Allan_Poe_%28cropped%29.jpg/800px-Edgar_Allan_Poe_%28cropped%29.jpg", Favorite = false, Uid = "456" },

    });

    modelBuilder.Entity<Book>().HasData(new Book[]
    {
        new Book {Id = 1, Title = "The Cat in the Hat", AuthorId = 1, Image = "https://upload.wikimedia.org/wikipedia/en/3/39/The_Cat_in_the_Hat_%28book%29.jpg", Price = 10, Sale = false, Uid = "123", Description = "A mischievous cat visits two children on a rainy day." },
        new Book {Id = 2, Title = "The Hobbit", AuthorId = 2, Image = "https://upload.wikimedia.org/wikipedia/en/4/4a/TheHobbit_FirstEdition.jpg" , Price = 20, Sale = true, Uid = "123", Description = "A fantasy novel about a hobbit's adventure." },
        new Book {Id = 3, Title = "The Raven", AuthorId = 3, Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0c/Edgar_Allan_Poe_%28cropped%29.jpg/800px-Edgar_Allan_Poe_%28cropped%29.jpg", Price = 15, Sale = true, Uid = "456", Description = "A narrative poem about a talking raven." },
    });


  }
}
