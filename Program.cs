using SimplyBooks.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<SimplyBooksDbContext>(builder.Configuration["SimplyBooksDbConnectionString"]);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


// GET Authors
app.MapGet("/authors", (SimplyBooksDbContext db) =>
{
    return db.Authors.ToList();
});

// GET Single Author by Id
app.MapGet("authors/{id}", (SimplyBooksDbContext db, int id) =>
{
    try
    {
        var author = db.Authors.Single(a => a.Id == id);
        return Results.Ok(author);
    }
    catch (InvalidOperationException)
    {
        return Results.NotFound("Author was not found.");
    }
});

// POST Author
app.MapPost("/authors", (SimplyBooksDbContext db, Author author) =>
{
    try
    {
        db.Authors.Add(author);
        db.SaveChanges();
        return Results.Created($"/authors/{author.Id}", author);
    }
    catch (DbUpdateException)
    {
        return Results.Problem("An error occurred while trying to save the author.");
    }
});

// DELETE Author
app.MapDelete("/authors/{id}", (SimplyBooksDbContext db, int id) =>
{
    try
    {
        Author? author = db.Authors.SingleOrDefault(author => author.Id == id);
        if (author == null)
        {
            return Results.NotFound();
        }
        db.Authors.Remove(author);
        db.SaveChanges();
    }
    catch (InvalidOperationException)
    {
        return Results.NotFound("Author was not found.");
    }
    return Results.NoContent();
});

// UPDATE Author
app.MapPut("/authors/{id}", (SimplyBooksDbContext db, int id, Author author) =>
{
    Author? authorToUpdate = db.Authors.SingleOrDefault(author => author.Id == id);
    if (authorToUpdate == null)
    {
        return Results.NotFound();
    }
    authorToUpdate.Email = author.Email;
    authorToUpdate.First_Name = author.First_Name;
    authorToUpdate.Last_Name = author.Last_Name;
    authorToUpdate.Image = author.Image;
    authorToUpdate.Favorite = author.Favorite;

    db.SaveChanges();
    return Results.Ok(author);
});

// GET a Single Author's Books
app.MapGet("/authors/{id}/books", (SimplyBooksDbContext db, int id) =>
{
    try
    {
        var authorBooks = db.Books.Where(b => b.AuthorId == id).ToList();
        return Results.Ok(authorBooks);
    }
    catch (InvalidOperationException)
    {
        return Results.NotFound("Author was not found.");
    }
});

// GET Favorite Authors by Uid (User)
app.MapGet("/authors/{uid}/favorites", (SimplyBooksDbContext db, string uid) =>
{
    try
    {
        var favoriteAuthors = db.Authors.Where(a => a.Favorite == true && a.Uid == uid).ToList();
        return Results.Ok(favoriteAuthors);
    }
    catch (InvalidOperationException)
    {
        return Results.NotFound("Author was not found.");
    }
});

// GET Books
app.MapGet("/books", (SimplyBooksDbContext db) =>
{
    var books = db.Books.Where(b => b.IsPrivate == false).ToList();
    return books.ToList();
});

// GET Single Book by Id
app.MapGet("/books/{id}", (SimplyBooksDbContext db, int id) =>
{
    try
    {
        var book = db.Books.Single(b => b.Id == id);
        return Results.Ok(book);
    }
    catch (InvalidOperationException)
    {
        return Results.NotFound("Book was not found.");
    }
});

// DELETE Book
app.MapDelete("/books/{id}", (SimplyBooksDbContext db, int id) =>
{
    try
    {
        Book? book = db.Books.SingleOrDefault(book => book.Id == id);
        if (book == null)
        {
            return Results.NotFound();
        }
        db.Books.Remove(book);
        db.SaveChanges();
    }
    catch (InvalidOperationException)
    {
        return Results.NotFound("Book was not found.");
    }
    return Results.NoContent();
});

// POST Book
app.MapPost("/books", (SimplyBooksDbContext db, Book book) =>
{
    try
    {
        db.Books.Add(book);
        db.SaveChanges();
        return Results.Created($"/books/{book.Id}", book);
    }
    catch (DbUpdateException)
    {
        return Results.Problem("An error occurred while trying to save the book.");
    }
});

// UPDATE Book
app.MapPut("/books/{id}", (SimplyBooksDbContext db, int id, Book book) =>
{
    Book? bookToUpdate = db.Books.SingleOrDefault(book => book.Id == id);
    if (bookToUpdate == null)
    {
        return Results.NotFound();
    }
    bookToUpdate.Title = book.Title;
    bookToUpdate.AuthorId = book.AuthorId;
    bookToUpdate.Image = book.Image;
    bookToUpdate.Sale = book.Sale;
    bookToUpdate.Price = book.Price;
    bookToUpdate.Uid = book.Uid;
    bookToUpdate.Description = book.Description;
    bookToUpdate.IsPrivate = book.IsPrivate;

    db.SaveChanges();
    return Results.Ok(book);
});

// GET On Sale Books
app.MapGet("/books/sale", (SimplyBooksDbContext db) =>
{
    var onSaleBooks = db.Books.Where(b => b.Sale == true).ToList();
    return Results.Ok(onSaleBooks);
});

// GET Private Books
app.MapGet("/books/{uid}/private", (SimplyBooksDbContext db, string uid) =>
{
    try
    {
        var privateBooks = db.Books.Where(b => b.Uid == uid && b.IsPrivate == true).ToList();
        return Results.Ok(privateBooks);
    }
    catch (InvalidOperationException)
    {
        return Results.NotFound("Books were not found.");
    }
});

// View Book Details
app.MapGet("/books/{id}/details", (SimplyBooksDbContext db, int id) =>
{
    try
    {
        var book = db.Books.Single(b => b.Id == id);
        var author = db.Authors.Single(a => a.Id == book.AuthorId);
        return Results.Ok(new { book, author });
    }
    catch (InvalidOperationException)
    {
        return Results.NotFound("Book or Author was not found.");
    }
});

// View Author Details
app.MapGet("/authors/{id}/details", (SimplyBooksDbContext db, int id) =>
{
    try
    {
        var author = db.Authors.Single(a => a.Id == id);
        var authorBooks = db.Books.Where(b => b.AuthorId == id).ToList();
        return Results.Ok(new { author, authorBooks });
    }
    catch (InvalidOperationException)
    {
        return Results.NotFound("Author or Books were not found.");
    }
});

// Delete Author and their Books
app.MapDelete("/authors/{id}/books", (SimplyBooksDbContext db, int id) =>
{
    try
    {
        var authorBooks = db.Books.Where(b => b.AuthorId == id).ToList();
        foreach (var book in authorBooks)
        {
            db.Books.Remove(book);
        }
        db.SaveChanges();

        Author? author = db.Authors.SingleOrDefault(author => author.Id == id);
        if (author == null)
        {
            return Results.NotFound();
        }
        db.Authors.Remove(author);
        db.SaveChanges();
    }
    catch (InvalidOperationException)
    {
        return Results.NotFound("Author or Books were not found.");
    }
    return Results.NoContent();
});

app.Run();
