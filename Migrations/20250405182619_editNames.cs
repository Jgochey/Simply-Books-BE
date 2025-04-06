using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SimplyBooks.Migrations
{
    /// <inheritdoc />
    public partial class editNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "Image", "IsPrivate", "Price", "Sale", "Title", "Uid" },
                values: new object[,]
                {
                    { 1, 1, "A mischievous cat visits two children on a rainy day.", "https://upload.wikimedia.org/wikipedia/en/3/39/The_Cat_in_the_Hat_%28book%29.jpg", false, 10, false, "The Cat in the Hat", "123" },
                    { 2, 2, "A fantasy novel about a hobbit's adventure.", "https://upload.wikimedia.org/wikipedia/en/4/4a/TheHobbit_FirstEdition.jpg", false, 20, true, "The Hobbit", "123" },
                    { 3, 3, "A narrative poem about a talking raven.", "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0c/Edgar_Allan_Poe_%28cropped%29.jpg/800px-Edgar_Allan_Poe_%28cropped%29.jpg", false, 15, true, "The Raven", "456" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "Image", "IsPrivate", "Price", "Sale", "Title", "Uid" },
                values: new object[,]
                {
                    { -3, 3, "A narrative poem about a talking raven.", "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0c/Edgar_Allan_Poe_%28cropped%29.jpg/800px-Edgar_Allan_Poe_%28cropped%29.jpg", false, 15, true, "The Raven", "456" },
                    { -2, 2, "A fantasy novel about a hobbit's adventure.", "https://upload.wikimedia.org/wikipedia/en/4/4a/TheHobbit_FirstEdition.jpg", false, 20, true, "The Hobbit", "123" },
                    { -1, 1, "A mischievous cat visits two children on a rainy day.", "https://upload.wikimedia.org/wikipedia/en/3/39/The_Cat_in_the_Hat_%28book%29.jpg", false, 10, false, "The Cat in the Hat", "123" }
                });
        }
    }
}
