using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1Library.Domain_Objects;

namespace Project1Library.Repositories
{
    class LoanRepository : IRepository<Loan, int>
    {
        private LibraryContext Context;

        public LoanRepository(LibraryContext context)
        {
            this.Context = context;
        }

        public void Add(Loan item)
        {
            throw new NotImplementedException();
        }

        public void Remove(Loan item)
        {
            throw new NotImplementedException();
        }

        public Loan Find(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Loan item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Loan> All()
        {
            return Context.Loans.ToList();
        }
    }
}
