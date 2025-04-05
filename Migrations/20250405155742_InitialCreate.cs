using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SimplyBooks.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    First_Name = table.Column<string>(type: "text", nullable: false),
                    Last_Name = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false),
                    Favorite = table.Column<bool>(type: "boolean", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Sale = table.Column<bool>(type: "boolean", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsPrivate = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Email", "Favorite", "First_Name", "Image", "Last_Name", "Uid" },
                values: new object[,]
                {
                    { 1, "Thing1@Thing2.com", true, "Dr.", "https://upload.wikimedia.org/wikipedia/en/1/19/Dr_Seuss.jpg", "Seuss", "123" },
                    { 2, "1Ring@2Rule.net", true, "J.R.R.", "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4c/J_R_R_Tolkien%2C_1940.jpg/800px-J_R_R_Tolkien%2C_1940.jpg", "Tolkien", "123" },
                    { 3, "Never@More.com", false, "Edgar", "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0c/Edgar_Allan_Poe_%28cropped%29.jpg/800px-Edgar_Allan_Poe_%28cropped%29.jpg", "Poe", "456" }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
