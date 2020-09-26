using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using MyReaderBook.Data;
using MyReaderBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyReaderBook.ConsoleApp
{
    class Program
    {
        static MyReaderBookContext context = new MyReaderBookContext();
        static void Main(string[] args)
        {
            //GetAuthorFromBook();
            //CreateAProjection();
            //GetAuthorFromBook_Explicity();
            //BooksWrittenFilt();
            //update();
            //BooksWritten();
            //addReaderBook();
            //AddReader();
            //GetAuthorFromBook();
            //AddBookWithAuthor();
            //AddAnotherBook();
            //UpdateBook();
            //AddBook();
            //UpdateAsNoTracking();
            //UpdateAnotherAuthor();
            //UpdateAuthor();
            //InsertMoreAuthors();
            //InsertAuthors();
            //InsertAuthor();

        }

        static void InsertAuthor()
        {
            var author = new Author() { FirstName = "Aurelio", LastName = "Jargas" };

            context.Authors.Add(author);
            context.SaveChanges();
        }

        static void InsertAuthors()
        {
            var authors = new List<Author>()
            {
                new Author() { FirstName = "Eric", LastName = "Evans" },
                new Author() { FirstName = "Robert", LastName = "Martin" },
                new Author() { FirstName = "Kenneth", LastName = "Rubin" }
            };

            context.Authors.AddRange(authors);
            context.SaveChanges();
        }

        static void FindAuthor()
        {
            var author = context.Authors.Find(1);
            Console.WriteLine($"Author name: {author.FirstName}");
        }

        static void FindAuthors()
        {
            var authors = context.Authors
                .Where(e => e.FirstName.StartsWith("A") || e.FirstName.StartsWith("E"))
                .ToList();

            foreach (var author in authors)
            {
                Console.WriteLine($"Author name: {author.FirstName}");
            }
        }

        static void DeleteAuthor()
        {
            var autor = context.Authors.Single(e => e.FirstName == "Aurelio");
            context.Authors.Remove(autor);
            context.SaveChanges();
        }

        static void InsertMoreAuthors()
        {
            var authors = new List<Author>()
            {
                new Author() { FirstName = "Ken", LastName = "Schwaber" },
                new Author(){ FirstName = "Jeff", LastName = "Southerland"}
            };

            context.Authors.AddRange(authors);
            context.SaveChanges();
        }

        static void UpdateAuthor()
        {
            var author = context.Authors.Find(7);
            author.LastName = "Sutherland";

            context.Authors.Update(author);
            context.SaveChanges();
        }

        static void UpdateAnotherAuthor()
        {
            var author = context.Authors
                .Single(e => e.FirstName == "Robert" && e.LastName == "Martin");

            author.FirstName = "Robert C.";

            context.SaveChanges();
        }

        static void UpdateAsNoTracking()
        {
            var author = context.Authors.AsNoTracking()
                .Single(e => e.FirstName.Contains("Robert"));

            author.FirstName = "Tiririca";

            context.SaveChanges();
        }

        static void AddBook()
        {
            var book = new Book()
            {
                Title = "Scrum Essencial",
                PublicationDate = new DateTime(2017, 01, 01),
                AuthorId = 3

            };

            context.Books.Add(book);
            context.SaveChanges();
        }

        static void UpdateBook()
        {
            var book = context.Books.Single(e => e.Title == "Scrum Essencial");
            book.PublicationDate = new DateTime(2017, 01, 01);

            context.SaveChanges();
        }

        static void AddAnotherBook()
        {
            var author = context.Authors
                .Single(e => e.FirstName == "Aurelio" && e.LastName == "Jargas");

            var book = new Book()
            {
                Title = "Expressões Regulares",
                PublicationDate = new DateTime(2006, 01, 01),
                Author = author
            };

            context.Books.Add(book);
            context.SaveChanges();
        }

        static void AddBookWithAuthor()
        {
            var boook = new Book()
            {
                Title = "Cálculo Volume 1",
                PublicationDate = new DateTime(2013, 01, 01),
                Author = new Author()
                {
                    FirstName = "James",
                    LastName = "Stewart"
                }

            };

            context.Books.Add(boook);
            context.SaveChanges();
        }

        static void GetAuthorFromBook()
        {
            var book = context.Books
                .FirstOrDefault(e => e.Title == "Cálculo Volume 1");

            Console.WriteLine($"Author: {book.Author.FirstName}");
        }

        static void AddReader()
        {
            var reader = new Reader()
            {
                FirstName = "Alexandre",
                LastName = "Tavares"
            };

            context.Readers.Add(reader);
            context.SaveChanges();
        }

        static void AddReaderBook()
        {
            var reader = context.Readers
                .FirstOrDefault(e => e.FirstName == "Alexandre");

            var book = context.Books
                .FirstOrDefault(e => e.Title == "Expressões Regulares");

            var readerBook = new ReaderBook() { ReaderId = reader.Id, BookId = book.Id };

            context.Set<ReaderBook>().Add(readerBook);
            context.SaveChanges();
        }

        static void QueryReaderBooks()
        {
            var readerBooks = context.Set<ReaderBook>().Where(e => e.ReaderId == 1);

            var books = new List<Book>();
            foreach (var readerBook in readerBooks)
            {
                var book = context.Books.Find(readerBook.BookId);
                books.Add(book);
            }

            foreach (var book in books)
            {
                Console.WriteLine($"Books: {book.Title}");
            }

        }

        static void BooksWritten()
        {
            var author = context.Authors
                .Include(e => e.BooksWritten)
                .FirstOrDefault(e => e.FirstName == "James");

            Console.WriteLine($"Books written by {author.FirstName} {author.LastName}:");
            foreach (var book in author.BooksWritten)
            {
                Console.WriteLine(book.Title);
            }
        }

        static void BooksWrittenAll()
        {
            var author = context.Authors.FirstOrDefault(e => e.FirstName == "James");
            context.Entry(author).Collection(e => e.BooksWritten).Load();

            Console.WriteLine($"Books written by {author.FirstName} {author.LastName}:");
            foreach (var book in author.BooksWritten)
            {
                Console.WriteLine(book.Title);
            }

        }

        static void BooksWrittenFilt()
        {
            var author = context.Authors.FirstOrDefault(e => e.FirstName == "James");
            context.Entry(author)
                .Collection(e => e.BooksWritten)
                .Query()
                .Where(e => e.Title.Contains("2")).Load();


            Console.WriteLine($"Books written by {author.FirstName} {author.LastName}:");
            foreach (var book in author.BooksWritten)
            {
                Console.WriteLine(book.Title);
            }

        }
        static void update()
        {
            var book = context.Books.Find(1002);
            book.AuthorId = 8;
            context.SaveChanges();
        }

        static void GetAuthorFromBook_Explicity()
        {
            var book = context.Books
                .FirstOrDefault(e => e.Title == "Cálculo Volume 1");

            context.Entry(book).Reference(e => e.Author).Load();

            Console.WriteLine($"Author: {book.Author.FirstName}");
        }

        static void CreateAProjection()
        {
            var authors = context.Authors
                .Select(e => new
                {
                    AuthorFirstName = e.FirstName,
                    e.BooksWritten
                });

            foreach (var author in authors)
            {
                Console.WriteLine($"Author: {author.AuthorFirstName} ");
                foreach (var book in author.BooksWritten)
                {
                    Console.WriteLine($"Livro: {book.Title}");
                }
            }

        }
    }
}
