using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Library.DomainObjects;
using Library.Models;

namespace Library.Repositories
{
    class LoanRepository : IRepository<Loan, int>
    {
        /// <summary>
        /// Parameter holding the LibraryContext singleton.
        /// </summary>
        LibraryContext Context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">LibraryContext</param>
        public LoanRepository(LibraryContext context)
        {
            this.Context = context;
        }

        /// <summary>
        /// Method to add a Loan to the database.
        /// </summary>
        /// <param name="item">Loan</param>
        public void Add(Loan item)
        {
            Context.Loans.Add(item);
            Context.SaveChanges();
        }

        /// <summary>
        /// Method to remove an existing loan from the database.
        /// </summary>
        /// <param name="item">Loan</param>
        public void Remove(Loan item)
        {
            Context.Loans.Remove(item);
            Context.SaveChanges();
        }

        /// <summary>
        /// Method to find a Loan in the database using ID.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Loan if found, null otherwise</returns>
        public Loan Find(int id)
        {
            return Context.Loans.Find(id);
        }

        /// <summary>
        /// Method to Edit an existing Loan in the database.
        /// </summary>
        /// <param name="item">Loan</param>
        /// <exception cref="ArgumentException">Thrown if the Loan doesn't exist in the database.</exception>
        public void Edit(Loan item)
        {
            Loan loanToUpdate = Context.Loans.
                Where(a => a.ID == item.ID).FirstOrDefault();

            if (null == loanToUpdate)
            {
                throw new ArgumentException("Loan with ID " + item.ID +
                    " is unknown to the database, " +
                    "Edit operations is unavailable.", "Author");
            }
            else
            {
                Context.Entry(loanToUpdate).CurrentValues.SetValues(item);
            }
            Context.SaveChanges();
        }

        /// <summary>
        /// Method to get all existing Loans in the database.
        /// </summary>
        /// <returns>IEnumerable&lt;Loan&gt;</returns>
        public IEnumerable<Loan> All()
        {
            return Context.Loans.
                Include(copy => copy.Copy).
                Include(member => member.Member).
                ToList();
        }
    }
}
