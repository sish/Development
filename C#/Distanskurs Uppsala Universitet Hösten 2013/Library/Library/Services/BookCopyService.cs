using Library.DomainObjects;
using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Services
{
    public class BookCopyService : IService
    {
        /// <summary>
        /// Parameter for accessing the BookCopy repository.
        /// </summary>
        private BookCopyRepository bookCopyRepository;
        /// <summary>
        /// Parameter for accessing the Book Repository.
        /// </summary>
        private BookRepository bookRepository;
        /// <summary>
        /// Parameter for accessing the Loan Repository.
        /// </summary>
        private LoanRepository loanRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        public BookCopyService()
        {
            bookCopyRepository = RepositoryFactory.BookCopys;
            bookRepository = RepositoryFactory.Books;
            loanRepository = RepositoryFactory.Loans;
        }

        /// <summary>
        /// Event property triggered whenever a book copy change is made in the database.
        /// </summary>
        public event EventHandler Updated;

        /// <summary>
        /// Method to add a new copy of an existing book.
        /// </summary>
        /// <param name="book">Book to add a copy too.</param>
        public void AddBookCopy(Book book)
        {
            if (null == bookRepository.Find(book.ISBN))
            {
                throw new ArgumentException("Book with given Title: " + book.Title + " and ISBN: " + book.ISBN + " does not exist in the database.");
            }
            bookCopyRepository.Add(new BookCopy() { Book = book });
            Updated.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Method to access available copies for loan of a specified book.
        /// </summary>
        /// <param name="book">Book to check copies of</param>
        /// <returns>int with the number of copies is available</returns>
        public int GetNoOfAvailableCopies(Book book)
        {
            List<int> noOfCopiesOnLoan = loanRepository.All().
                Where(loan => loan.TimeOfReturn == null).
                Where(loan => loan.Copy.Book.ISBN == book.ISBN).
                Select(loan => loan.Copy.ID).
                ToList();
            int NoOfCopiesNotOnLoan = bookCopyRepository.All().
                Where(copy => false == noOfCopiesOnLoan.Contains(copy.ID)).
                Where(copy => copy.Book.ISBN == book.ISBN).
                Count();
            return NoOfCopiesNotOnLoan;
        }
    }
}
