using Library.DomainObjects;
using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Services
{
    public class AuthorService : IService
    {
        /// <summary>
        /// Parameter to access the author repository.
        /// </summary>
        private AuthorRepository authorRepository;
        
        static public string LBX_BOOKS = "Books by author";
        static public string LBX_LOANS = "Active loans by author";

        /// <summary>
        /// Constructor
        /// </summary>
        public AuthorService()
        {
            authorRepository = RepositoryFactory.Authors;
        }

        /// <summary>
        /// Event property triggered whenever a author change is made in the database.
        /// </summary>
        public event EventHandler Updated;

        /// <summary>
        /// Method to add an author to the database.
        /// </summary>
        /// <param name="author">Author</param>
        public void AddAuthor(Author author)
        {
            authorRepository.Add(author);
            if (null != Updated)
            {
                Updated.Invoke(this, new EventArgs());
            }
        }

        /// <summary>
        /// Method to edit an existing author in the database.
        /// </summary>
        /// <param name="author">Author</param>
        public void EditAuthor(Author author)
        {
            authorRepository.Edit(author);
            if (null != Updated)
            {
                Updated.Invoke(this, new EventArgs());
            }
        }

        /// <summary>
        /// Method to find an author in the database.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Author if found, otherwise null.</returns>
        public Author FindAuthor(int id)
        {
            return authorRepository.Find(id);
        }

        /// <summary>
        /// Method to get all Authors in the database.
        /// </summary>
        /// <returns>IEnumerable&lt;Author&gt;</returns>
        public IEnumerable<Author> GetAuthors()
        {
            return authorRepository.All();
        }

        /// <summary>
        /// Method to get a filtered list of Authors from name.
        /// </summary>
        /// <param name="text">string to look for, at least 3 chars otherwise the whole list is returned</param>
        /// <returns>IEnumerable&lt;Author&gt;</returns>
        public IEnumerable<Author> NameContainsIgnoreCase(string text)
        {
            IEnumerable<Author> retValue = authorRepository.All();
            if (3 <= text.Length)
            {
                retValue = retValue.
                    Where(author => author.Name.IndexOf(text, StringComparison.CurrentCultureIgnoreCase) >= 0).
                    ToList();
            }
            return retValue;
        }

        /// <summary>
        /// Method to get selected filters for second listbox.
        /// </summary>
        /// <returns>List&lt;string&gt;</returns>
        public List<string> GetListBoxItems()
        {
            List<string> retValue = new List<string>();
            retValue.Add(LBX_BOOKS);
            retValue.Add(LBX_LOANS);
            return retValue.OrderBy(str => str).ToList();
        }

    }
}
