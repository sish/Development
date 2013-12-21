using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1Library.Domain_Objects;

namespace Project1Library.Repositories
{
    class AuthorRepository : IRepository<Author, int>
    {

        private LibraryContext Context;

        public AuthorRepository(LibraryContext context)
        {
            this.Context = context;
        }

        public void Add(Author item)
        {
            Context.Authors.Add(item);
        }

        public void Remove(Author item)
        {
            Context.Authors.Remove(item);
        }

        public Author Find(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Author item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Author> All()
        {
            return Context.Authors.ToList();
        }
    }
}
