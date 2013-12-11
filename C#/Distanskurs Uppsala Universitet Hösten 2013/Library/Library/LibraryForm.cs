using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library.Models;
using Library.Services;
using Library.Repositories;
using System.Data.Entity;
using Library.DomainObjects;

namespace Library
{
    public partial class LibraryForm : Form
    {

        private AuthorService authorService;
        private BookCopyService bookCopyService;
        private BookService bookService;
        private LoanService loanService;
        private MemberService memberService;

        private Author SelectedAuthor;
        private BookCopy SelectedBookCopy;
        private Book SelectedBook;
        private Loan SelectedLoan;
        private Member SelectedMember;

        private enum SelectedServiceList { 
            SSL_NONE,
            SSL_AUTHOR,
            SSL_BOOKCOPY,
            SSL_BOOK,
            SSL_LOAN,
            SSL_MEMBER
        }

        private SelectedServiceList FirstListBox;
        private int FirstListBoxLength;

        public LibraryForm()
        {
            InitializeComponent();

            // Uncomment the line you wish to use
            // Use a derived strategy with a Seed-method
            Database.SetInitializer<LibraryContext>(new LibraryDbInit());

            ContextSingelton.GetContext().Database.Initialize(true);
            // Recreate the database only if the models change
            //Database.SetInitializer<LibraryContext>(new DropCreateDatabaseIfModelChanges<LibraryContext>());
            var test = ContextSingelton.GetContext().Loans.ToList();
            var test2 = test.Where(loan => loan.Copy != null).ToList();
            // Always drop and recreate the database
            //Database.SetInitializer<LibraryContext>(new DropCreateDatabaseAlways<LibraryContext>());
           // MessageBox.Show(LibraryDbInit.GetRandomMember(new Random(DateTime.Now.Second)).PersonalID);

            authorService = new AuthorService();
            bookService = new BookService();
            bookCopyService = new BookCopyService();
            memberService = new MemberService();
            loanService = new LoanService();

            SelectedAuthor = null;
            SelectedBookCopy = null;
            SelectedBook = null;
            SelectedLoan = null;
            SelectedMember = null;

            FirstListBox = SelectedServiceList.SSL_NONE;

            authorService.Updated += new EventHandler(AuthorUpdated);
            bookService.Updated += new EventHandler(BookUpdated);
            loanService.Updated += new EventHandler(LoanUpdated);
            memberService.Updated += new EventHandler(MemberUpdated);

            lbl_firstbox.Text = string.Empty;
        }

        private void msp_file_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void msp_view_authors_Click(object sender, EventArgs e)
        {
            FirstListBox = (false == msp_view_authors.Checked) ? SelectedServiceList.SSL_AUTHOR : SelectedServiceList.SSL_NONE;
            HandleViewCheck();
            PopulateFirstList();
        }

        private void msp_view_members_Click(object sender, EventArgs e)
        {
            FirstListBox = (false == msp_view_members.Checked) ? SelectedServiceList.SSL_MEMBER : SelectedServiceList.SSL_NONE;
            HandleViewCheck();
            PopulateFirstList();
        }

        private void msp_view_books_Click(object sender, EventArgs e)
        {
            FirstListBox = (false == msp_view_books.Checked) ? SelectedServiceList.SSL_BOOK : SelectedServiceList.SSL_NONE;
            HandleViewCheck();
            PopulateFirstList();
        }

        private void msp_file_add_author_Click(object sender, EventArgs e)
        {
            AuthorForm form = new AuthorForm();
            try
            {
                if (DialogResult.OK == form.ShowDialog())
                {
                    authorService.AddAuthor(form.author);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void msp_file_add_member_Click(object sender, EventArgs e)
        {
            MemberForm form = new MemberForm(memberService);
            try
            {
                if (DialogResult.OK == form.ShowDialog())
                {
                    memberService.AddMember(form.Member);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void msp_file_add_book_Click(object sender, EventArgs e)
        {
            BookForm form = new BookForm(authorService);
            try
            {
                if (DialogResult.OK == form.ShowDialog())
                {
                    bookService.AddBook(form.Book);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbx_firsbox_TextChanged(object sender, EventArgs e)
        {
            string text = tbx_firsbox.Text;
            if ( text.Length >= 3 || text.Length < FirstListBoxLength ) // don't redraw before we have 3 signs, or signs is removed.
            {
                lbx_firstbox.DataSource = null;
                switch (FirstListBox)
                {
                    case SelectedServiceList.SSL_AUTHOR:
                        {
                            lbx_firstbox.DataSource = authorService.NameContainsIgnoreCase(text);
                            break;
                        }
                    case SelectedServiceList.SSL_BOOK:
                        {
                            lbx_firstbox.DataSource = bookService.NameOrISBNContainsIgnoreCase(text);
                            break;
                        }
                    case SelectedServiceList.SSL_MEMBER:
                        {
                            lbx_firstbox.DataSource = memberService.NameContainsIgnoreCase(text);
                            break;
                        }
                }
            }
            FirstListBoxLength = text.Length;
        }

        private void lbx_firstbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selection = cbx_second_select.Text;
            var secondSelection = lbx_secondbox.SelectedItem;
            if (-1 != lbx_firstbox.SelectedIndex)
            {
                SelectedAuthor = lbx_firstbox.SelectedItem as Author;
                SelectedBookCopy = lbx_firstbox.SelectedItem as BookCopy;
                SelectedBook = lbx_firstbox.SelectedItem as Book;
                SelectedLoan = lbx_firstbox.SelectedItem as Loan;
                SelectedMember = lbx_firstbox.SelectedItem as Member;
            }
            switch (FirstListBox)
            {
                case SelectedServiceList.SSL_AUTHOR:
                {
                    cbx_second_select.DataSource = authorService.GetListBoxItems();
                    break;
                }
                case SelectedServiceList.SSL_BOOK:
                {
                    cbx_second_select.DataSource = bookService.GetListBoxItems();
                    break;
                }
                case SelectedServiceList.SSL_MEMBER:
                {
                    cbx_second_select.DataSource = memberService.GetListBoxItems();
                    break;
                }
            }
            if (cbx_second_select.Items.Contains(selection))
            {
                cbx_second_select.SelectedItem = selection;
            }
            if (null != secondSelection && lbx_secondbox.Items.Contains(secondSelection))
            {
                lbx_secondbox.SelectedItem = secondSelection;
            }
        }

        private void cbx_second_select_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SelectedText = cbx_second_select.Text;
            lbx_secondbox.DataSource = null;
            //cbx_second_select.DataSource = null;
            if (-1 != lbx_firstbox.SelectedIndex)
            {
                switch (FirstListBox)
                {
                    case SelectedServiceList.SSL_AUTHOR:
                    {
                        if (null != SelectedAuthor)
                        {
                            if (AuthorService.LBX_BOOKS == SelectedText)
                            {
                                lbx_secondbox.DataSource = SelectedAuthor.Books.ToList();
                            }
                            else if (AuthorService.LBX_LOANS == SelectedText)
                            {
                                Loan.SetToStringMethod(Loan.StringFormat.SF_MEMBER);
                                lbx_secondbox.DataSource = loanService.GetLoansByAuthor(SelectedAuthor);
                            }
                        }
                        break;
                    }
                    case SelectedServiceList.SSL_BOOK:
                    {
                        if (null != SelectedBook)
                        {
                            if (BookService.LBX_LOANS == SelectedText)
                            {
                                Loan.SetToStringMethod(Loan.StringFormat.SF_AUTHOR);
                                lbx_secondbox.DataSource = loanService.GetActiveLoansByBook(SelectedBook);
                            }
                            else if (BookService.LBX_ALL_LOANS == SelectedText)
                            {
                                Loan.SetToStringMethod(Loan.StringFormat.SF_AUTHOR);
                                lbx_secondbox.DataSource = loanService.GetAllLoansByBook(SelectedBook);
                            }
                        }
                        break;
                    }
                    case SelectedServiceList.SSL_MEMBER:
                    {
                        if (null != SelectedMember)
                        {
                            if (MemberService.LBX_AVAILABLE_BOOKS == SelectedText)
                            {
                                lbx_secondbox.DataSource = bookService.GetAllAvailableBooks();
                            }
                            else if (MemberService.LBX_LOANS_BY_DATE == SelectedText)
                            {
                                Loan.SetToStringMethod(Loan.StringFormat.SF_AUTHOR);
                                lbx_secondbox.DataSource = loanService.GetLoansByMemberOrderByDate(SelectedMember);
                            }
                            else if (MemberService.LBX_LOANS_BY_DATE_DESC == SelectedText)
                            {
                                Loan.SetToStringMethod(Loan.StringFormat.SF_AUTHOR);
                                lbx_secondbox.DataSource = loanService.GetLoansByMemberOrderByDateDesc(SelectedMember);
                            }
                            else if (MemberService.LBX_CURRENT_LOANS == SelectedText)
                            {
                                Loan.SetToStringMethod(Loan.StringFormat.SF_AUTHOR);
                                lbx_secondbox.DataSource = loanService.GetActiveLoansByMember(SelectedMember);
                            }
                        }
                        break;
                    }
                }
            }
        }

        private void lbx_secondbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (-1 != lbx_secondbox.SelectedIndex)
            {
                /// Assigns the second selection to Selected member if not already selected
                /// in the first listbox (thus the null check).
                SelectedAuthor = (null == SelectedAuthor || null != lbx_secondbox.SelectedItem as Author) ? lbx_secondbox.SelectedItem as Author : SelectedAuthor;
                SelectedBookCopy = (null == SelectedBookCopy || null != lbx_secondbox.SelectedItem as BookCopy) ? lbx_secondbox.SelectedItem as BookCopy : SelectedBookCopy;
                SelectedBook = (null == SelectedBook || null != lbx_secondbox.SelectedItem as Book) ? lbx_secondbox.SelectedItem as Book : SelectedBook;
                SelectedLoan = (null == SelectedLoan || null != lbx_secondbox.SelectedItem as Loan) ? lbx_secondbox.SelectedItem as Loan : SelectedLoan;
                SelectedMember = (null == SelectedMember || null != lbx_secondbox.SelectedItem as Member) ? lbx_secondbox.SelectedItem as Member : SelectedMember;
            }
            else // no selection in second list, repopulate the original.
            {
                SelectedAuthor = lbx_firstbox.SelectedItem as Author;
                SelectedBookCopy = lbx_firstbox.SelectedItem as BookCopy;
                SelectedBook = lbx_firstbox.SelectedItem as Book;
                SelectedLoan = lbx_firstbox.SelectedItem as Loan;
                SelectedMember = lbx_firstbox.SelectedItem as Member;
            }
            PopulateUserForm();
        }

        private void msp_edit_author_Click(object sender, EventArgs e)
        {
            if( null == SelectedAuthor ) // Unknown state, crash application deliberately
            {
                throw new InvalidOperationException("Should not be able to click disabled controls.");
            }
            AuthorForm form = new AuthorForm(SelectedAuthor);
            try
            {
                if (DialogResult.OK == form.ShowDialog())
                {
                    authorService.EditAuthor(form.author);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void msp_edit_member_Click(object sender, EventArgs e)
        {
            if (null == SelectedMember) // Unknown state, crash application deliberately
            {
                throw new InvalidOperationException("Should not be able to click disabled controls.");
            }
            MemberForm form = new MemberForm(memberService, SelectedMember);
            try
            {
                if (DialogResult.OK == form.ShowDialog())
                {
                    memberService.EditMember(form.Member);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void msp_edit_book_Click(object sender, EventArgs e)
        {
            if (null == SelectedBook) // Unknown state, crash application deliberately
            {
                throw new InvalidOperationException("Should not be able to click disabled controls.");
            }
            BookForm form = new BookForm(authorService, SelectedBook);
            try
            {
                if (DialogResult.OK == form.ShowDialog())
                {
                    bookService.EditBook(form.Book);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void eDITToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            msp_edit_author.Enabled = (null != SelectedAuthor);
            msp_edit_book.Enabled = (null != SelectedBook);
            msp_edit_member.Enabled = (null != SelectedMember);
        }

        #region Updated_Events

        private void AuthorUpdated(object sender, EventArgs e)
        {
            if (SelectedServiceList.SSL_AUTHOR == FirstListBox)
            {
                lbx_firstbox.DataSource = null;
                lbx_firstbox.DataSource = authorService.GetAuthors();
            }
        }

        private void BookUpdated(object sender, EventArgs e)
        {
            if (SelectedServiceList.SSL_BOOK == FirstListBox)
            {
                lbx_firstbox.DataSource = null;
                lbx_firstbox.DataSource = bookService.GetBooks();
            }
            if (AuthorService.LBX_BOOKS == cbx_second_select.Text)
            {
                lbx_secondbox.DataSource = null;
                lbx_secondbox.DataSource = SelectedAuthor.Books.ToList();
            }
        }

        private void LoanUpdated(object sender, EventArgs e)
        {
            if (AuthorService.LBX_LOANS == cbx_second_select.Text)
            {
                lbx_secondbox.DataSource = null;
                Loan.SetToStringMethod(Loan.StringFormat.SF_MEMBER);
                lbx_secondbox.DataSource = loanService.GetLoansByAuthor(SelectedAuthor);
            }
            else if (MemberService.LBX_AVAILABLE_BOOKS == cbx_second_select.Text)
            {
                lbx_secondbox.DataSource = null;
                lbx_secondbox.DataSource = bookService.GetAllAvailableBooks();
            }
            else if (MemberService.LBX_CURRENT_LOANS == cbx_second_select.Text)
            {
                lbx_secondbox.DataSource = null;
                Loan.SetToStringMethod(Loan.StringFormat.SF_AUTHOR);
                lbx_secondbox.DataSource = loanService.GetActiveLoansByMember(SelectedMember);
            }
            else if (BookService.LBX_LOANS == cbx_second_select.Text)
            {
                lbx_secondbox.DataSource = null;
                Loan.SetToStringMethod(Loan.StringFormat.SF_AUTHOR);
                lbx_secondbox.DataSource = loanService.GetActiveLoansByBook(SelectedBook);
            }
            else if (BookService.LBX_ALL_LOANS == cbx_second_select.Text)
            {
                lbx_secondbox.DataSource = null;
                Loan.SetToStringMethod(Loan.StringFormat.SF_AUTHOR);
                lbx_secondbox.DataSource = loanService.GetAllLoansByBook(SelectedBook);
            }
        }

        private void MemberUpdated(object sender, EventArgs e)
        {
            if (SelectedServiceList.SSL_MEMBER == FirstListBox)
            {
                lbx_firstbox.DataSource = null;
                lbx_firstbox.DataSource = memberService.GetMembers();
            }
        }

        #endregion

        #region Own_Methods
        /// <summary>
        /// Orders the checked item in the View MenuChoice
        /// </summary>
        private void HandleViewCheck()
        {
            msp_view_authors.Checked = (SelectedServiceList.SSL_AUTHOR == FirstListBox);
            msp_view_books.Checked = (SelectedServiceList.SSL_BOOK == FirstListBox);
            msp_view_members.Checked = (SelectedServiceList.SSL_MEMBER == FirstListBox);
        }

        /// <summary>
        /// Populates first list according to selected item.
        /// </summary>
        private void PopulateFirstList()
        {
            lbx_secondbox.DataSource = null;
            cbx_second_select.DataSource = null;
            //lbx_secondbox.Items.Clear();
            //cbx_second_select.Items.Clear();
            if (SelectedServiceList.SSL_AUTHOR == FirstListBox)
            {
                lbl_firstbox.Text = "Authors:";
                lbx_firstbox.DataSource = authorService.GetAuthors();
            }
            else if (SelectedServiceList.SSL_BOOK == FirstListBox)
            {
                lbl_firstbox.Text = "Books:";
                lbx_firstbox.DataSource = bookService.GetBooks();
            }
            else if (SelectedServiceList.SSL_MEMBER == FirstListBox)
            {
                lbl_firstbox.Text = "Members:";
                lbx_firstbox.DataSource = memberService.GetMembers();
            }
            else
            {
                lbl_firstbox.Text = string.Empty;
                lbx_firstbox.DataSource = null;
            }
            tbx_firsbox.Text = string.Empty;
            tbx_firsbox.Focus();
        }

        /// <summary>
        /// Method that populates the dynamic panel depending on selected items in the list.
        /// </summary>
        private void PopulateUserForm()
        {
            foreach (Control c in scr_second.Panel2.Controls)
            {
                c.Dispose();
            }
            scr_second.Panel2.Controls.Clear();
            if (null != SelectedAuthor && null != SelectedBook)
            {
                scr_second.Panel2.Controls.Add(new UCAuthorBook(authorService, bookService, bookCopyService, SelectedAuthor, SelectedBook));
            }
            else if (null != SelectedMember && null != SelectedBook)
            {
                scr_second.Panel2.Controls.Add(new UCMemberBook(authorService, bookService, bookCopyService, loanService, memberService, SelectedMember, SelectedBook));
            }
            else if (null != SelectedBook && null != SelectedLoan)
            { 
                scr_second.Panel2.Controls.Add(new UCBookLoan(authorService, bookService, bookCopyService, loanService, SelectedBook, SelectedLoan));
            }
            else if (null != SelectedMember && null != SelectedLoan)
            { 
                scr_second.Panel2.Controls.Add(new UCMemberLoan(loanService, memberService, SelectedLoan, SelectedMember));
            }
            else if (null != SelectedAuthor && null != SelectedLoan)
            {
                scr_second.Panel2.Controls.Add(new UCAuthorLoan(authorService, bookService, loanService, SelectedAuthor, SelectedLoan));
            }
        }

        #endregion

        


    }
}
