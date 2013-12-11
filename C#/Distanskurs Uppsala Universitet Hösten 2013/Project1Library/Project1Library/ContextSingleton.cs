using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1Library.Repositories;

namespace Project1Library
{
    class ContextSingleton
    {
        static LibraryContext _context = null;
        public static LibraryContext GetContext()
        {
            // if we don't have a instance, create it (happens once)
            if (_context == null)
                _context = new LibraryContext();
            return _context;
        }
    }
}
