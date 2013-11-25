using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1Library.Repositories;

namespace Project1Library
{
    class RepositoryFactory
    {
        static LibraryContext context
        {
            get { return ContextSingleton.GetContext(); }
        }
        // this method handles the instantiation of the book-repository
        // notice that we pass the context through the constructor of the
        // repository, this is a well-known practice of handling dependencies
        public static AuthorRepository GetAuthorRepository()
        {
            return new AuthorRepository(RepositoryFactory.context);
        }

        public static BookCopyRepository GetBookCopyRepository()
        {
            return new BookCopyRepository(RepositoryFactory.context);
        }

        public static BookRepository GetBookRepository()
        {
            return new BookRepository(RepositoryFactory.context);
        }

        public static LoanRepository GetLoanRepository()
        {
            return new LoanRepository(RepositoryFactory.context);
        }

        public static MemberRepository GetMemberRepository()
        {
            return new MemberRepository(RepositoryFactory.context);
        }
    }
}
