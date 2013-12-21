using Project1Library.Domain_Objects;
using Project1Library.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1Library
{
    class LibraryDbInit : DropCreateDatabaseAlways<LibraryContext>
    {
        protected override void Seed(LibraryContext context)
        {
            base.Seed(context);
            Author alexDumas = new Author("Alexandre Dumas");
            Book monteCristo = new Book("1-85326-733-3", "The Count of Monte Cristo", alexDumas);
            context.Books.Add(monteCristo);
            context.SaveChanges();
        }
    }
}
