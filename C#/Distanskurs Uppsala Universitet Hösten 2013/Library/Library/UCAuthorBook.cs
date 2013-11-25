using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library.DomainObjects;
using Library.Services;

namespace Library
{
    public partial class UCAuthorBook : UserControl
    {

        private Author pAuthor;
        private Book pBook;
        private AuthorService pAuthorService;
        private BookService pBookService;
        private BookCopyService pBookCopyService;

        public UCAuthorBook(AuthorService aService, BookService bService, BookCopyService bcService, Book book)
        {
            InitializeComponent();
            pBook = book;
            pAuthor = book.Author;
            pAuthorService = aService;
            pBookService = bService;
            pBookCopyService = bcService;
            init();
        }

        public UCAuthorBook(AuthorService aService, BookService bService, BookCopyService bcService, Author author, Book book)
        {
            InitializeComponent();
            pBook = book;
            pAuthor = author;
            pAuthorService = aService;
            pBookService = bService;
            pBookCopyService = bcService;
            init();
        }

        private void init()
        {
            tbx_author.Text = pAuthor.Name;
            tbx_noOfBooks.Text = pAuthor.Books.Count.ToString();
            tbx_title.Text = pBook.Title;
            tbx_isbn.Text = pBook.ISBN;
            tbx_copies.Text = pBook.Copies.Count.ToString();
            rtb_description.Text = pBook.Description;
        }

        private void btn_addBook_Click(object sender, EventArgs e)
        {
            BookForm form = new BookForm(pAuthorService, pAuthor);
            try
            {
                if (DialogResult.OK == form.ShowDialog())
                {
                    pBookService.AddBook(form.Book);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_editBook_Click(object sender, EventArgs e)
        {
            BookForm form = new BookForm(pAuthorService, pBook);
            try
            {
                if (DialogResult.OK == form.ShowDialog())
                {
                    pBookService.EditBook(form.Book);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_addCopy_Click(object sender, EventArgs e)
        {
            pBookCopyService.AddBookCopy(pBook);
        }

        private void UCAuthorBook_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            pBookService.Updated += new EventHandler(BookUpdated);
            pBookCopyService.Updated += new EventHandler(BookCopyUpdated);
        }

        private void DisposeEvents()
        {
            pBookService.Updated -= BookUpdated;
            pBookCopyService.Updated -= BookCopyUpdated;
        }

        private void BookUpdated(object sender, EventArgs e)
        {
            tbx_noOfBooks.Text = pAuthor.Books.Count.ToString();
            tbx_title.Text = pBook.Title;
            tbx_isbn.Text = pBook.ISBN;
            rtb_description.Text = pBook.Description;
        }

        private void BookCopyUpdated(object sender, EventArgs e)
        {
            tbx_copies.Text = pBook.Copies.Count.ToString();
        }

    }
}
