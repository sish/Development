using Project1Library.Domain_Objects;
using Project1Library.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1Library
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            try
            {
                //Database.SetInitializer<LibraryContext>(new LibraryDbInit());
                LibraryContext db = new LibraryContext();
                // Create the author-object
                Author alexDumas = new Author("Alexandre Dumas");
                Book monteCristo = new Book("1-85326-733-3", "The Count of Monte Cristo", alexDumas);
                // Add the book to the DbSet of books.
                db.Books.Add(monteCristo);
                // Persist changes to the database
                db.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                MessageBox.Show(e.InnerException.ToString());
            }
            // Use a derived strategy with a Seed-method
            //Database.SetInitializer<LibraryContext>(new LibraryDbInit());
            // Recreate the database only if the models change
            //Database.SetInitializer<LibraryContext>(
            //new DropCreateDatabaseIfModelChanges<LibraryContext>());
            // Always drop and recreate the database
            //Database.SetInitializer<LibraryContext>(
            //new DropCreateDatabaseAlways<LibraryContext>());
        }
    }
}
