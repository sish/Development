using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.DomainObjects;
using Library.Models;

namespace Library.Repositories
{
    class BookCopyRepository : IRepository<BookCopy, int>
    {
        /// <summary>
        /// Parameter holding the LibraryContext singleton.
        /// </summary>
        LibraryContext Context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">LibraryContext</param>
        public BookCopyRepository(LibraryContext context)
        {
            this.Context = context;
        }

        /// <summary>
        /// Method to add a BookCopy to the database.
        /// </summary>
        /// <param name="item">BookBopy</param>
        public void Add(BookCopy item)
        {
            Context.BookCopys.Add(item);
            Context.SaveChanges();
        }

        /// <summary>
        /// Method to remove an existing BookCopy from the database.
        /// </summary>
        /// <param name="item">BookCopy</param>
        public void Remove(BookCopy item)
        {
            Context.BookCopys.Remove(item);
            Context.SaveChanges();
        }

        /// <summary>
        /// Method to fins a BookCopy from the database using ID.
        /// </summary>
        /// <param name="id">int with the id to look for.</param>
        /// <returns>BookCopy if found, otherwise null.</returns>
        public BookCopy Find(int id)
        {
            return Context.BookCopys.Find(id);
        }

        /// <summary>
        /// Method to Edit an existing BookCopy in the database.
        /// </summary>
        /// <param name="item">BookCopy</param>
        /// <exception cref="ArgumentException">Thrown if no BookCopy was found for the given ID.</exception>
        public void Edit(BookCopy item)
        {
            BookCopy bookCopyToUpdate = Context.BookCopys.
                Where(a => a.ID == item.ID).FirstOrDefault();

            if (null == bookCopyToUpdate)
            {
                throw new ArgumentException("BookCopy with ID " + item.ID +
                    " is unknown to the database, " +
                    "Edit operations is unavailable.", "BookCopy");
            }
            else
            {
                Context.Entry(bookCopyToUpdate).CurrentValues.SetValues(item);
            }
            Context.SaveChanges();
        }

        /// <summary>
        /// Method to get an enumerable with all BookCopys in the database.
        /// </summary>
        /// <returns>IEnumerable&lt;BookCopy&gt;</returns>
        public IEnumerable<BookCopy> All()
        {
            return Context.BookCopys.ToList();
        }
    }
}
