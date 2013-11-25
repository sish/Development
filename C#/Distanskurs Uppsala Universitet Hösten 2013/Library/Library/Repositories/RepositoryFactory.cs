using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Models;

namespace Library.Repositories
{
    class RepositoryFactory
    {
        /// <summary>
        /// Wrapper property to access the context
        /// </summary>
        static LibraryContext context
        {
            get { return ContextSingelton.GetContext(); }
        }

        /// <summary>
        /// Wrapper property to access the AuthorRepository.
        /// </summary>
        public static AuthorRepository Authors
        {
            get { return new AuthorRepository(RepositoryFactory.context); }
        }

        /// <summary>
        /// Wrapper property to access the BookCopyRepository.
        /// </summary>
        public static BookCopyRepository BookCopys
        {
            get { return new BookCopyRepository(RepositoryFactory.context); }
        }

        /// <summary>
        /// Wrapper property to access the BookRepository.
        /// </summary>
        public static BookRepository Books
        {
            get { return new BookRepository(RepositoryFactory.context); }
        }

        /// <summary>
        /// Wrapper property to access the LoanRepository.
        /// </summary>
        public static LoanRepository Loans
        {
            get { return new LoanRepository(RepositoryFactory.context);  }
        }

        /// <summary>
        /// Wrapper property to access the MemberRepository.
        /// </summary>
        public static MemberRepository Members
        {
            get { return new MemberRepository(RepositoryFactory.context);  }
        }
        
    }
}
