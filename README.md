## Simply Books

## Overview
This app allows users to create their own collection of Books and Authors. Users can:
- Create and manage authors: Add new authors, edit or delete existing authors, and view detailed information about each author.
- Manage books: Link books to authors, view all books by an author, and set certain books as favorites or private.
- View author details: For each author, you can explore their list of works, and related information.
- Privacy and favorite features: Set certain books to private, or mark authors as favorites for easier access.

[View Frontend Application](https://jgochey-simply-books.netlify.app)

## Features
- Full CRUD on Authors and Books.
- User-specific Author and Book data, including favorite Authors and private Books.
- Book view displays details about a specific Book and its Author.
- Author view displays details about an Author as well as all of the Books associated with them.
- API endpoints to retrieve book and author data.

## Getting Started
Prerequisites
- .NET 8 SDK
- PostgreSQL
- Postman (Optional for testing API requests)

Set up the Database
Create a new appsettings.Development.json inside the project and add your PostgreSQL connection string:
  - { "SimplyBooksBEDbConnectionString": "Host=localhost;Port=5432;Database=SimplyBooksBE;Username=postgres;Password=yourpassword" }

The API uses SQL Server for storing book and author data. Run the following command to set up the database schema:
  - dotnet ef database update

After configuring the settings, you can run the API locally:
  - dotnet watch run

### Links

- [Github Project Board](https://github.com/users/Jgochey/projects/10/)
- [LOOM Postman Walkthrough](https://www.loom.com/share/abd47c4979f14211aa207cb89cff82a0?sid=0cec1235-14dd-4a91-85bb-fd6a37fdd5c4)
- [Postman Collection](https://documenter.getpostman.com/view/36639418/2sB2cUBhvr)

## Technologies Used
Technologies Used
- .NET Core 8
- Entity Framework Core 8
- PostgreSQL
- Swagger

## Contributors
- Josh Gochey:  https://github.com/Jgochey
