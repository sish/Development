using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.DomainObjects;
using Library.Models;

namespace Library.Repositories
{
    class MemberRepository : IRepository<Member, int>
    {
        /// <summary>
        /// Parameter holding the LibraryContext singleton.
        /// </summary>
        LibraryContext Context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">LibraryContext</param>
        public MemberRepository(LibraryContext context)
        {
            this.Context = context;
        }

        /// <summary>
        /// Method to add a Member to the database.
        /// </summary>
        /// <param name="item">Member</param>
        public void Add(Member item)
        {
            Context.Members.Add(item);
            Context.SaveChanges();
        }

        /// <summary>
        /// Method to remove an existing Member from the database.
        /// </summary>
        /// <param name="item">Member</param>
        public void Remove(Member item)
        {
            Context.Members.Remove(item);
            Context.SaveChanges();
        }

        /// <summary>
        /// Method to find an existing Member in the database using ID.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Member if found, null otherwise</returns>
        public Member Find(int id)
        {
            return Context.Members.Find(id);
        }

        /// <summary>
        /// Method to Edit an existing member in the database.
        /// </summary>
        /// <param name="item">Member</param>
        /// <exception cref="ArgumentException">Thrown if the Member doesnät exist in the database.</exception>
        public void Edit(Member item)
        {
            Member memberToUpdate = Context.Members.
                Where(a => a.ID == item.ID).FirstOrDefault();

            if (null == memberToUpdate)
            {
                throw new ArgumentException("Member with ID " + item.ID +
                    " and name " + item.Name + "is unknown to the database, " +
                    "Edit operations is unavailable.", "Member");
            }
            else
            {
                Context.Entry(memberToUpdate).CurrentValues.SetValues(item);
            }
            Context.SaveChanges();
        }

        /// <summary>
        /// Method to get all existing Members in the database.
        /// </summary>
        /// <returns>IEnumerable&lt;Member&gt;</returns>
        public IEnumerable<Member> All()
        {
            return Context.Members.ToList();
        }
    }
}
