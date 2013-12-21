using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1Library.Domain_Objects;

namespace Project1Library.Repositories
{
    class MemberRepository : IRepository<Member, int>
    {
        private LibraryContext Context;

        public MemberRepository(LibraryContext context)
        {
            this.Context = context;
        }

        public void Add(Member item)
        {
            throw new NotImplementedException();
        }

        public void Remove(Member item)
        {
            throw new NotImplementedException();
        }

        public Member Find(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Member item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Member> All()
        {
            return Context.Members.ToList();
        }
    }
}
