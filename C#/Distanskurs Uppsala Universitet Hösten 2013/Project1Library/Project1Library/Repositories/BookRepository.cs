using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1Library.Domain_Objects;
using System.Data.Entity;

namespace Project1Library.Repositories
{
    class BookRepository : IRepository<Book, int>
    {

        private LibraryContext Context;

        public BookRepository(LibraryContext context)
        {
            this.Context = context;
        }

        public void Add(Book item)
        {
            throw new NotImplementedException();
        }

        public void Remove(Book item)
        {
            throw new NotImplementedException();
        }

        public Book Find(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Book item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> All()
        {
            return Context.Books.ToList();
        }
    }
}
