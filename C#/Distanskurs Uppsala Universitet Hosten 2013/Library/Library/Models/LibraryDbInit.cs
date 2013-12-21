using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Library.DomainObjects;

namespace Library.Models
{
    /// <summary>
    /// Derived database strategy
    /// </summary>
    class LibraryDbInit : DropCreateDatabaseAlways<LibraryContext>
    {

        static List<string> fnamn = new List<string>() { "Maria", "Anna", "Margareta", "Elisabeth", "Eva", "Birgitta", "Kristina", "Karin", "Elisabet", "Marie", "Ingrid", "Christina", "Linnéa", "Marianne", "Sofia", "Erik", "Lars", "Karl", "Anders", "Johan", "Per", "Nils", "Jan", "Carl", "Mikael", "Lennart", "Hans", "Olof", "Gunnar", "Peter" };
        static List<string> enamn = new List<string>() { "Johansson", "Andersson", "Karlsson", "Nilsson", "Eriksson", "Larsson", "Olsson", "Persson", "Svensson", "Gustafsson", "Pettersson", "Jonsson", "Jansson", "Hansson", "Bengtsson" };
        /// <summary>
        /// Method that randoizes a Member class
        /// </summary>
        /// <param name="rndGen">Random instance to use in random seeding.</param>
        /// <returns>Member</returns>
        public static Member GetRandomMember(Random rndGen)
        {
            Member m = new Member();
            m.Name = fnamn[rndGen.Next(fnamn.Count)] + " " + enamn[rndGen.Next(enamn.Count)];
            TimeSpan from = new TimeSpan(18 * 365, 0, 0, 0);
            TimeSpan to = new TimeSpan(100 * 365, 0, 0, 0);
            TimeSpan range = new TimeSpan(to.Ticks - from.Ticks);
            var randTimeSpan = new TimeSpan((long)(rndGen.NextDouble() * range.Ticks));
            DateTime gen = DateTime.Now - randTimeSpan;
            m.PersonalID = String.Format("{0:D4}{1:D2}{2:D2}-{3:D4}", gen.Year, gen.Month, gen.Day, gen.Millisecond);
            return m;
        }

        /// <summary>
        /// Overridden seed method to populate with testdata.
        /// </summary>
        /// <param name="context">LibraryContext</param>
        protected override void Seed(LibraryContext context)
        {
            base.Seed(context);
            // Authors
            Author alexDumas = new Author() { Name = "Alexandre Dumas" };
            Author astrLindgren = new Author() { Name = "Astrid Lindgren" };
            Author barbrLindgren = new Author() { Name = "Barbro Lindgren" };
            // Books
            Book monteCristo = new Book() { ISBN = "1853267333", Title = "The Count of Monte Cristo", Description="Greven av Monte Cristo", Author = alexDumas };
            Book musketeers = new Book() { ISBN = "9188680118", Title="The Three Musketeers", Description = "De tre musketörerna", Author = alexDumas };
            Book tulip = new Book() { ISBN = "0140448926", Title = "The Black Tulip", Description = "Den svarta tulpanen", Author = alexDumas };
            Book pippi = new Book() { ISBN = "9129654424", Title = "Pippi Longstocking", Description = "Pippi Långstrump", Author = astrLindgren };
            Book madicken = new Book { ISBN = "9789129657869", Title = "Madicken", Description = "Madicken", Author = astrLindgren };
            Book maxkaka = new Book { ISBN = "9789129663983", Title = "Max Kaka", Description = "Max Kaka", Author = barbrLindgren };
            List<Book> list = new List<Book>() { monteCristo, musketeers, tulip, pippi, madicken, maxkaka };
            Random rand = new Random(DateTime.Now.Second);
            // BookCopys
            foreach (Book book in list)
            {
                for (int i = 0; i < rand.Next(1,4); i++) // 1 to 3 copies.
                {
                    book.Copies.Add(new BookCopy() { Book = book });
                }
                context.Books.Add(book);
            }
            // Members
            int noOfMembers = rand.Next(50, 100);
            for (int i = 0; i < noOfMembers; i++) 
            { 
                context.Members.Add(GetRandomMember(rand));
            }
            // need to save to be able to iterate on members afterwards.
            context.SaveChanges();
            // Loans
            Dictionary<BookCopy, DateTime> loans = new Dictionary<BookCopy, DateTime>();
            foreach (BookCopy copy in context.BookCopys.ToList())
            {
                loans.Add(copy, DateTime.Now);
            }
            TimeSpan LoanTime = new TimeSpan(15, 0, 0, 0);
            TimeSpan SpanTime = new TimeSpan(5, 0, 0, 0);
            bool doOnce = true;
            foreach (Member m in context.Members.ToList())
            {

                if (doOnce) // create 2 loans out of time for the first member.
                {
                    doOnce = false;
                    for (int i = 0; i < 2; i++)
                    {
                        // find the book that was latest loaned.
                        KeyValuePair<BookCopy, DateTime> t = loans.OrderByDescending(r => r.Value.Ticks).First();
                        Loan l = new Loan();
                        l.Member = m;
                        int days = rand.Next(16, 20);
                        // TimeOfLoan is between 16 to 20 days ago
                        l.TimeOfLoan = DateTime.Now - new TimeSpan(days, 0, 0, 0);
                        // DueDate is always 15 days from TimeOfLoan
                        l.DueDate = l.TimeOfLoan + LoanTime;
                        // add the bookcopy
                        l.Copy = t.Key;
                        // add the loan.
                        context.Loans.Add(l);
                        // save changes.
                        context.SaveChanges();
                        // Update the time of loan for the BookCopy so that we don't get 2 loans overlapping.
                        loans[t.Key] = l.TimeOfLoan;
                    }
                }
                else
                {
                    int noOfLoans = rand.Next(7);
                    for (int i = 0; i < noOfLoans; i++)
                    {
                        // find the book that was latest loaned.
                        KeyValuePair<BookCopy, DateTime> t = loans.OrderByDescending(r => r.Value.Ticks).First();
                        Loan l = new Loan();
                        l.Member = m;
                        // TimeOfReturns is between 0 and 5 days from the last TimeOfLoan.
                        l.TimeOfReturn = t.Value - new TimeSpan((long)(rand.NextDouble() * SpanTime.Ticks));
                        // TimeOfLoan is between 0 to 20 days (5 days possible overdue)
                        l.TimeOfLoan = l.TimeOfReturn.Value - new TimeSpan((long)(rand.NextDouble() * (LoanTime.Ticks + (LoanTime.Ticks / 3))));
                        // DueDate is always 15 days from TimeOfLoan
                        l.DueDate = l.TimeOfLoan + LoanTime;
                        // add the bookcopy
                        l.Copy = t.Key;
                        // add the loan.
                        context.Loans.Add(l);
                        // save changes.
                        context.SaveChanges();
                        // Update the time of loan for the BookCopy so that we don't get 2 loans overlapping.
                        loans[t.Key] = l.TimeOfLoan;
                    }
                }
            }
            var test = context.Loans.ToList();
            var test2 = test.Where(loan => loan.Copy != null).ToList();
        }
    }
}
