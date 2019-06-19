using System.Collections.Generic;
using App.Modules.Design.Shared.Models.Entities;

namespace App.Modules.Design.Infrastructure.Data.Db
{

    // Fake Repo for dev purposes only
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static class BookDataSource
    {
        private static IList<Book> _books { get; set; }

        public static IList<Book> GetBooks()
        {
            if (_books != null)
            {
                return _books;
            }

            _books = new List<Book>();

            // book #1
            Book book = new Book
            {
                Id = 1.ToGuid(),
                ISBN = "978-0-321-87758-1",
                Title = "Essential C#5.0",
                Author = "Mark Michaelis",
                Price = 59.99m,
                Location = new Address { City = "Redmond", Street = "156TH AVE NE" },
                Press = new Press
                {
                    Id = 1.ToGuid(),
                    Name = "Addison-Wesley",
                    Category = Category.Book
                }
            };
            _books.Add(book);

            // book #2
            book = new Book
            {
                Id = 2.ToGuid(),
                ISBN = "063-6-920-02371-5",
                Title = "Enterprise Games",
                Author = "Michael Hugos",
                Price = 49.99m,
                Location = new Address { City = "Bellevue", Street = "Main ST" },
                Press = new Press
                {
                    Id = 2.ToGuid(),
                    Name = "O'Reilly",
                    Category = Category.EBook,
                }
            };
            _books.Add(book);

            return _books;
        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
