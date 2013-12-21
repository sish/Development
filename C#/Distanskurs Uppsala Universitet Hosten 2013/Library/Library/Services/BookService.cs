using Library.DomainObjects;
using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Services
{
    public class BookService : IService
    {
        /// <summary>
        /// Parameter for accessing the Book Repository.
        /// </summary>
        private BookRepository bookRepository;
        /// <summary>
        /// Parameter for accessing the BookCopy Repository.
        /// </summary>
        private BookCopyRepository bookCopyRepository;
        /// <summary>
        /// Parameter for accessing the Loan Repository.
        /// </summary>
        private LoanRepository loanRepository;
       
        static public string LBX_ALL_LOANS = "All loans by book";
        static public string LBX_LOANS = "Active loans by book.";

        /// <summary>
        /// Constructor
        /// </summary>
        public BookService()
        {
            bookRepository = RepositoryFactory.Books;
            bookCopyRepository = RepositoryFactory.BookCopys;
            loanRepository = RepositoryFactory.Loans;
        }

        /// <summary>
        /// Event property triggered whenever a book change is made in the database.
        /// </summary>
        public event EventHandler Updated;

        /// <summary>
        /// Method to add a book to the database.
        /// </summary>
        /// <param name="book">Book</param>
        public void AddBook(Book book)
        {
            if (null != bookRepository.Find(book.ISBN))
            {
                throw new ArgumentException("Trying to add aready existing book according to ISBN no: " + book.ISBN + ".");
            }
            bookRepository.Add(book);
            Updated.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Method to edit an existing book.
        /// </summary>
        /// <param name="book">Book</param>
        public void EditBook(Book book)
        {
            bookRepository.Edit(book);
            Updated.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Method to get all books in database.
        /// </summary>
        /// <returns>IEnumerable&lt;Book&gt;</returns>
        public IEnumerable<Book> GetBooks()
        {
            return bookRepository.All();
        }

        /// <summary>
        /// Method to get a sublist of books filtered by text.
        /// </summary>
        /// <param name="text">string with the text to look for</param>
        /// <returns>IEnumerable&lt;Book&gt;</returns>
        public IEnumerable<Book> NameOrISBNContainsIgnoreCase(string text)
        {
            IEnumerable<Book> retValue = bookRepository.All();
            if (3 <= text.Length)
            {
                retValue = retValue.
                    Where(book => book.Title.IndexOf(text, StringComparison.CurrentCultureIgnoreCase) >= 0 ||
                    book.ISBN.Contains(text)).ToList();
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
            retValue.Add(LBX_ALL_LOANS);
            retValue.Add(LBX_LOANS);
            return retValue.OrderBy(str => str).ToList();
        }

        /// <summary>
        /// Method to get books available books for loan.
        /// </summary>
        /// <returns>IEnumerable&lt;Book&gt;</returns>
        public IEnumerable<Book> GetAllAvailableBooks()
        {
            var BookCopysOnLoan = loanRepository.All().
                Where(loan => loan.TimeOfReturn == null).
                Select(loan => loan.Copy.ID);
            var BookCopysNotOnLoan = bookCopyRepository.All().
                Where(copy => false == BookCopysOnLoan.Contains(copy.ID)).
                Select(copy => copy.Book).
                Distinct().
                ToList();
            return BookCopysNotOnLoan;
        }

    }
}
