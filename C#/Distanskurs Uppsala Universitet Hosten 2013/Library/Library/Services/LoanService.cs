using Library.DomainObjects;
using Library.Models;
using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Services
{
    public class LoanService : IService
    {
        /// <summary>
        /// Parameter for accessing Loan Repository.
        /// </summary>
        private LoanRepository loanRepository;
        /// <summary>
        /// Parameter for accessing Member Repository.
        /// </summary>
        private MemberRepository memberRepository;
        /// <summary>
        /// Parameter for accessing BookCopy Repository.
        /// </summary>
        private BookCopyRepository bookCopyRepository;
        /// <summary>
        /// Parameter for accessing Book Repository.
        /// </summary>
        private BookRepository bookRepository;

        /// <summary>
        /// Static parameter holding the allowed timespan of a book.
        /// </summary>
        private static TimeSpan AllowedLoan = new TimeSpan(15, 0, 0, 0);
        /// <summary>
        /// Static parameter holding the overdue fee for a book.
        /// </summary>
        private static int OverdueFeePerDay = 10;

        /// <summary>
        /// Constructor
        /// </summary>
        public LoanService()
        {
            loanRepository = RepositoryFactory.Loans;
            memberRepository = RepositoryFactory.Members;
            bookCopyRepository = RepositoryFactory.BookCopys;
            bookRepository = RepositoryFactory.Books;
        }

        /// <summary>
        /// Event property triggered whenever a loan change is made in the database.
        /// </summary>
        public event EventHandler Updated;

        /// <summary>
        /// Method to make a loan of a book for a member.
        /// </summary>
        /// <param name="member">Member that makes the loan.</param>
        /// <param name="book">Book the member wants to loan.</param>
        public void MakeLoan(Member member, Book book)
        {
            if (null == bookRepository.Find(book.ISBN))
            {
                throw new ArgumentException("No book wit ISBN: " + book.ISBN + " found in database.");
            }
            else
            {
                List<int> noOfCopiesOnLoan = loanRepository.All().
                    Where(loan => loan.TimeOfReturn == null).
                    Where(loan => loan.Copy.Book.ISBN == book.ISBN).
                    Select(loan => loan.Copy.ID).
                    ToList();
                BookCopy copyToLoan = bookCopyRepository.All().
                    Where(c => false == noOfCopiesOnLoan.Contains(c.ID)).
                    Where(c => c.Book.ISBN == book.ISBN).
                    FirstOrDefault();
                if (null == copyToLoan)
                {
                    throw new ArgumentException("No bookcopy available for Title: " + book.Title + ".");
                }
                else
                {
                    MakeLoan(member, copyToLoan);
                }
            }
        }

        /// <summary>
        /// Method to make a loan for a member.
        /// </summary>
        /// <param name="member">Member that makes the loan.</param>
        /// <param name="bookCopy">Specific copy of the book the member want's to loan.</param>
        public void MakeLoan(Member member, BookCopy bookCopy)
        {
            if (null == memberRepository.Find(member.ID))
            {
                throw new ArgumentException("No member with name: " + member.Name + " available in the database.");
            }
            else if (null == bookCopyRepository.Find(bookCopy.ID))
            {
                throw new ArgumentException("No Bookcopy with id: " + bookCopy.ID + " available in the database.");
            }
            else
            {
                Loan loanToBe = new Loan();
                loanToBe.Copy = bookCopy;
                loanToBe.TimeOfLoan = DateTime.Now;
                loanToBe.DueDate = loanToBe.TimeOfLoan + AllowedLoan;
                loanToBe.TimeOfReturn = null;
                loanToBe.Member = member;
                loanRepository.Add(loanToBe);
                Updated.Invoke(this, new EventArgs());
            }
        }

        /// <summary>
        /// Method to return a loan to the library.
        /// </summary>
        /// <param name="loan">Loan that is being returned.</param>
        /// <returns>int with the penalty fee. 0 if no fee.</returns>
        public int MakeReturn(Loan loan)
        {
            int penaltyFee = 0;
            if (loan.TimeOfReturn != null)
            {
                throw new ArgumentException("Invalid loan provided for MakeReturn method, expected one that needs returning");
            }
            else if (null == loanRepository.Find(loan.ID))
            {
                throw new ArgumentException("Loan provided to MakeReturn method was not found in database.");
            }
            loan.TimeOfReturn = DateTime.Now;
            penaltyFee = CalculatePenaltyFee(loan);
            loanRepository.Edit(loan);
            Updated.Invoke(this, new EventArgs());
            return penaltyFee;
        }

        /// <summary>
        /// Method to calculate the current penalty fee for a loan.
        /// </summary>
        /// <param name="loan">Loan to check for penalty fee.</param>
        /// <returns>int with the fee in sek. 0 if no penalty.</returns>
        public int CalculatePenaltyFee(Loan loan)
        {
            int penaltyFee = 0;
            DateTime endTime = (loan.TimeOfReturn == null) ? DateTime.Now : loan.TimeOfReturn.Value;
            TimeSpan loanTime = endTime - loan.TimeOfLoan;
            if (loanTime > AllowedLoan)
            {
                penaltyFee = (loanTime - AllowedLoan).Days;
                penaltyFee *= OverdueFeePerDay;
            }
            return penaltyFee;
        }

        /// <summary>
        /// Method to get all loans by a specified Author.
        /// </summary>
        /// <param name="author">Author to check for.</param>
        /// <returns>IEnumerable&lt;Loan&gt;</returns>
        public IEnumerable<Loan> GetLoansByAuthor(Author author)
        {
            return loanRepository.All().
                Where(loan => loan.TimeOfReturn == null).
                Where(loan => loan.Copy.Book.Author == author).
                ToList();
        }

        /// <summary>
        /// Method to get all active loans made on a book (not individual copies).
        /// </summary>
        /// <param name="book">Book to look for.</param>
        /// <returns>IEnumerable&lt;Loan&gt;</returns>
        public IEnumerable<Loan> GetActiveLoansByBook(Book book)
        {
            return loanRepository.All().
                Where(loan => loan.TimeOfReturn == null).
                Where(loan => loan.Copy.Book == book).
                ToList();
        }

        /// <summary>
        /// Method to gett all loans by a specified book.
        /// </summary>
        /// <param name="book">Book to check for</param>
        /// <returns>IEnumerable&lt;Loan&gt;</returns>
        public IEnumerable<Loan> GetAllLoansByBook(Book book)
        {
            return loanRepository.All().
                Where(loan => loan.Copy.Book.ISBN == book.ISBN).
                    OrderBy(loan => loan.DueDate).ToList();
        }

        /// <summary>
        /// Method to get all loans by a specific member ordered oldest first.
        /// </summary>
        /// <param name="member">Member to check for.</param>
        /// <returns>IEnumerable&lt;Loan&gt;</returns>
        public IEnumerable<Loan> GetLoansByMemberOrderByDate(Member member)
        {
            return loanRepository.All().
                Where(loan => loan.Member.ID == member.ID).
                OrderBy(loan => loan.TimeOfLoan.Ticks).
                ToList();
        }

        /// <summary>
        /// Method to get all loans by a specific member ordered latest first.
        /// </summary>
        /// <param name="member">Member to check for.</param>
        /// <returns>IEnumerable&lt;Loan&gt;</returns>
        public IEnumerable<Loan> GetLoansByMemberOrderByDateDesc(Member member)
        {
            return loanRepository.All().
                Where(loan => loan.Member.ID == member.ID).
                OrderByDescending(loan => loan.TimeOfLoan.Ticks).
                ToList();
        }

        /// <summary>
        /// Method to get active loans by a specific member.
        /// </summary>
        /// <param name="member">Member to check for.</param>
        /// <returns>IEnumerable&lt;Loan&gt;</returns>
        public IEnumerable<Loan> GetActiveLoansByMember(Member member)
        {
            return loanRepository.All().
                Where(loan => loan.Member.ID == member.ID &&
                    loan.TimeOfReturn == null).
                OrderBy(loan => loan.TimeOfLoan.Ticks).
                ToList();
        }
    }
}
