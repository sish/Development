using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Library.DomainObjects;
using Library.Models;

namespace Library.Repositories
{
    class AuthorRepository : IRepository<Author, int>
    {
        /// <summary>
        /// Parameter holding the LibraryContext singleton.
        /// </summary>
        LibraryContext Context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">LibraryContext</param>
        public AuthorRepository(LibraryContext context)
        {
            this.Context = context;
        }

        /// <summary>
        /// Method to add an item to the database.
        /// </summary>
        /// <param name="item">Author</param>
        public void Add(Author item)
        {
            Context.Authors.Add(item);
            Context.SaveChanges();
        }

        /// <summary>
        /// Method to remove an item from the database.
        /// </summary>
        /// <param name="item">Author</param>
        public void Remove(Author item)
        {
            Context.Authors.Remove(item);
            Context.SaveChanges();
        }

        /// <summary>
        /// Method to find an Author from database using ID.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Author</returns>
        public Author Find(int id)
        {
            return Context.Authors.Find(id);
        }

        /// <summary>
        /// Method to edit an existing item from the database.
        /// </summary>
        /// <param name="item">Author</param>
        /// <exception cref="ArgumentException">Thrown if the edit item doesn't exist in the database using the key.</exception>
        public void Edit(Author item)
        {
            Author authorToUpdate = Context.Authors.
                Where(a => a.ID == item.ID).FirstOrDefault();

            if (null == authorToUpdate)
            {
                throw new ArgumentException("Author with ID " + item.ID + 
                    " and name " + item.Name + "is unknown to the database, " +
                    "Edit operations is unavailable.", "Author");
            }
            else
            {
                Context.Entry(authorToUpdate).CurrentValues.SetValues(item);
            }
            Context.SaveChanges();
        }

        /// <summary>
        /// Method to get an enumerator with all Authors in the database.
        /// </summary>
        /// <returns>IEnumerable&lt;Author&gt;</returns>
        public IEnumerable<Author> All()
        {
            return Context.Authors.
                Include(book => book.Books).
                ToList();
        }
    }
}
