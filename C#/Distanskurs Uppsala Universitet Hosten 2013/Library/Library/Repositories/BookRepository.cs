using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Library.DomainObjects;
using Library.Models;

namespace Library.Repositories
{
    class BookRepository : IRepository<Book, string>
    {
        /// <summary>
        /// Parameter holding the LibraryContext singleton.
        /// </summary>
        LibraryContext Context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">LibraryContext</param>
        public BookRepository(LibraryContext context)
        {
            this.Context = context;
        }

        /// <summary>
        /// Method to add a Book to the database.
        /// </summary>
        /// <param name="item">Book</param>
        public void Add(Book item)
        {
            Context.Books.Add(item);
            Context.SaveChanges();
        }

        /// <summary>
        /// Method to remove an existing Book from the database.
        /// </summary>
        /// <param name="item">Book</param>
        public void Remove(Book item)
        {
            Context.Books.Remove(item);
            Context.SaveChanges();
        }

        /// <summary>
        /// Method to find an existing Book in the database using ISBN.
        /// </summary>
        /// <param name="id">string with ISBN id.</param>
        /// <returns>Book if found, otherwise null.</returns>
        public Book Find(string id)
        {
            return Context.Books.Find(id);
        }

        /// <summary>
        /// Method to edit an existing Book in the database.
        /// </summary>
        /// <param name="item">Book</param>
        /// <exception cref="ArgumentException">Thrown if the book to be edited isnt in the database.</exception>
        public void Edit(Book item)
        {
            Book bookToUpdate = Context.Books.
                Where(a => a.ISBN.Equals(item.ISBN)).FirstOrDefault();

            if (null == bookToUpdate)
            {
                throw new ArgumentException("Book with ISBN " + item.ISBN +
                    " and Title " + item.Title + "is unknown to the database, " +
                    "Edit operations is unavailable.", "Book");
            }
            else
            {
                Context.Entry(bookToUpdate).CurrentValues.SetValues(item);
            }
            Context.SaveChanges();
        }

        /// <summary>
        /// Method to get all Books in the database.
        /// </summary>
        /// <returns>IEnumerable&lt;Book&gt;</returns>
        public IEnumerable<Book> All()
        {
            return Context.Books.
                Include(book => book.Copies).
                ToList();
        }
    }
}
