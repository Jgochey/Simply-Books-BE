﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SimplyBooks.Migrations
{
    [DbContext(typeof(SimplyBooksDbContext))]
    [Migration("20250405182619_editNames")]
    partial class editNames
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SimplyBooks.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Favorite")
                        .HasColumnType("boolean");

                    b.Property<string>("First_Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Last_Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Uid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "Thing1@Thing2.com",
                            Favorite = true,
                            First_Name = "Dr.",
                            Image = "https://upload.wikimedia.org/wikipedia/en/1/19/Dr_Seuss.jpg",
                            Last_Name = "Seuss",
                            Uid = "123"
                        },
                        new
                        {
                            Id = 2,
                            Email = "1Ring@2Rule.net",
                            Favorite = true,
                            First_Name = "J.R.R.",
                            Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4c/J_R_R_Tolkien%2C_1940.jpg/800px-J_R_R_Tolkien%2C_1940.jpg",
                            Last_Name = "Tolkien",
                            Uid = "123"
                        },
                        new
                        {
                            Id = 3,
                            Email = "Never@More.com",
                            Favorite = false,
                            First_Name = "Edgar",
                            Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0c/Edgar_Allan_Poe_%28cropped%29.jpg/800px-Edgar_Allan_Poe_%28cropped%29.jpg",
                            Last_Name = "Poe",
                            Uid = "456"
                        });
                });

            modelBuilder.Entity("SimplyBooks.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("boolean");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<bool>("Sale")
                        .HasColumnType("boolean");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Uid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            Description = "A mischievous cat visits two children on a rainy day.",
                            Image = "https://upload.wikimedia.org/wikipedia/en/3/39/The_Cat_in_the_Hat_%28book%29.jpg",
                            IsPrivate = false,
                            Price = 10,
                            Sale = false,
                            Title = "The Cat in the Hat",
                            Uid = "123"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 2,
                            Description = "A fantasy novel about a hobbit's adventure.",
                            Image = "https://upload.wikimedia.org/wikipedia/en/4/4a/TheHobbit_FirstEdition.jpg",
                            IsPrivate = false,
                            Price = 20,
                            Sale = true,
                            Title = "The Hobbit",
                            Uid = "123"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 3,
                            Description = "A narrative poem about a talking raven.",
                            Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0c/Edgar_Allan_Poe_%28cropped%29.jpg/800px-Edgar_Allan_Poe_%28cropped%29.jpg",
                            IsPrivate = false,
                            Price = 15,
                            Sale = true,
                            Title = "The Raven",
                            Uid = "456"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
