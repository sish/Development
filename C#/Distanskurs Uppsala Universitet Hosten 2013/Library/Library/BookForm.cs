using Library.DomainObjects;
using Library.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Library
{
    public partial class BookForm : Form
    {

        public Book Book;
        private const string BTN_SAVE = "Save";
        private const string BTN_EDIT = "Edit";
        private AuthorService pAuthorService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">AuthorService reference to check authors.</param>
        public BookForm(AuthorService service)
        {
            InitializeComponent();
            this.Book = new Book();
            btn_save_edit.Text = BTN_SAVE;
            this.pAuthorService = service;
            cbx_author.DataSource = pAuthorService.GetAuthors();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">AuthorService reference to check authors.</param>
        /// <param name="author">Author to preselect to added book.</param>
        public BookForm(AuthorService service, Author author)
        {
            InitializeComponent();
            this.Book = new Book();
            btn_save_edit.Text = BTN_SAVE;
            this.pAuthorService = service;
            cbx_author.DataSource = pAuthorService.GetAuthors();
            cbx_author.SelectedItem = author;
        }

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="service">AuthorService reference to check authors.</param>
        /// <param name="bookToEdit">Book object to edit.</param>
        public BookForm(AuthorService service, Book bookToEdit)
        {
            InitializeComponent();
            this.pAuthorService = service;
            this.Book = bookToEdit;
            btn_save_edit.Text = BTN_EDIT;
            cbx_author.Enabled = false;
            tbx_isbn.Enabled = false;
            tbx_title.Enabled = false;
            rtb_description.Enabled = false;
            tbx_copies.Enabled = false;
            cbx_author.DataSource = pAuthorService.GetAuthors();
            cbx_author.SelectedItem = Book.Author;
            tbx_title.Text = Book.Title;
            tbx_isbn.Text = Book.ISBN;
            tbx_copies.Text = Book.Copies.Count.ToString();
            rtb_description.Text = Book.Description;
        }

        private void btn_save_edit_Click(object sender, EventArgs e)
        {
            if (BTN_EDIT == btn_save_edit.Text)
            {
                btn_save_edit.Text = BTN_SAVE;
                rtb_description.Enabled = true;
                tbx_copies.Enabled = true;
                tbx_title.Enabled = true;
            }
            else if (BTN_SAVE == btn_save_edit.Text)
            {
                Author check = cbx_author.SelectedItem as Author;
                int Copies = int.Parse(tbx_copies.Text);
                if (null == check)
                {
                    throw new InvalidOperationException("Unable to convert selected item to Author.");
                }
                else if (null == pAuthorService.FindAuthor(check.ID))
                {
                    throw new ArgumentException("Selection of non existing Author in list.");
                }
                else if (Copies < Book.Copies.Count)
                {
                    MessageBox.Show("Cannot reduce the number of copies of a book");
                    tbx_copies.Text = Book.Copies.Count.ToString();
                }
                else
                {
                    Book.Author = check;
                    Book.Title = tbx_title.Text;
                    Book.ISBN = tbx_isbn.Text;
                    if (rtb_description.TextLength > 0)
                    {
                        Book.Description = rtb_description.Text;
                    }
                    for (int i = Book.Copies.Count; i < Copies; i++)
                    {
                        Book.Copies.Add(new BookCopy() { Book = Book });
                    }
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


    }
}
