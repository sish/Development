using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1Library.Domain_Objects;

namespace Project1Library.Repositories
{
    class BookCopyRepository : IRepository<BookCopy, int>
    {

        private LibraryContext Context;

        public BookCopyRepository(LibraryContext context)
        {
            this.Context = context;
        }

        public void Add(BookCopy item)
        {
            throw new NotImplementedException();
        }

        public void Remove(BookCopy item)
        {
            throw new NotImplementedException();
        }

        public BookCopy Find(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(BookCopy item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookCopy> All()
        {
            return Context.BookCopys.ToList();
        }
    }
}
