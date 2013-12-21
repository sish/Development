using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Library.DomainObjects;

namespace Library.Models
{
    /// <summary>
    /// Derived DbContext
    /// </summary>
    class LibraryContext : DbContext
    {
        public DbSet<Author> Authors {get;set;}
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCopy> BookCopys { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Member> Members { get; set; }
    }
}
