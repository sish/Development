using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library.Services;
using Library.DomainObjects;

namespace Library
{
    public partial class UCAuthorLoan : UserControl
    {

        private AuthorService pAuthorService;
        private BookService pBookService;
        private LoanService pLoanService;
        private Author pAuthor;
        private Loan pLoan;

        public UCAuthorLoan(AuthorService aService, BookService bService, LoanService lService, Author author, Loan loan)
        {
            InitializeComponent();
            pAuthorService = aService;
            pBookService = bService;
            pLoanService = lService;
            pAuthor = author;
            pLoan = loan;
            init();
        }

        public void init()
        {
            tbx_author.Text = pAuthor.Name;
            tbx_noOfBooks.Text = pAuthor.Books.Count.ToString();
            tbx_timeOfLoan.Text = pLoan.TimeOfLoan.ToString("yyyy-MM-dd HH:mm");
            tbx_timeOfReturn.Text = (null != pLoan.TimeOfReturn) ? pLoan.TimeOfReturn.Value.ToString("yyyy-MM-dd HH:mm") : "";
            DateTime endTime = (null == pLoan.TimeOfReturn) ? DateTime.Now : pLoan.TimeOfReturn.Value;
            TimeSpan duration = endTime - pLoan.TimeOfLoan;
            tbx_duration.Text = duration.Days + " days " + duration.Hours + ":" + duration.Minutes;
            lbl_information.Text = (0 == pLoanService.CalculatePenaltyFee(pLoan)) ? "" : "PenaltyFee: " + pLoanService.CalculatePenaltyFee(pLoan) + "kr.";
        }

        private void EnableControls()
        {
            btn_returnBook.Enabled = (null == pLoan.TimeOfReturn);
        }

        private void UCAuthorLoan_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            pBookService.Updated += new EventHandler(BookUpdated);
            pLoanService.Updated += new EventHandler(LoanUpdated);
        }

        private void DisposeEvents()
        {
            pBookService.Updated -= BookUpdated;
            pLoanService.Updated -= LoanUpdated;
        }

        private void btn_returnBook_Click(object sender, EventArgs e)
        {
            if (null == pLoan)
            {
                throw new InvalidOperationException("Trying to return a Loan object that is not of type Loan.");
            }
            else
            {
                int penaltyFee = pLoanService.MakeReturn(pLoan);
                if (0 != penaltyFee)
                {
                    string errorText = "Bookloan with title: " + pLoan.Copy.Book.Title +
                        " has a penalty fee of " + penaltyFee + "kr.";
                    MessageBox.Show(errorText);
                }
            }
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

        private void LoanUpdated(object sender, EventArgs e)
        {
            tbx_timeOfReturn.Text = (null != pLoan.TimeOfReturn) ? pLoan.TimeOfReturn.Value.ToString("yyyy-MM-dd HH:mm") : "";
            DateTime endTime = (null == pLoan.TimeOfReturn) ? DateTime.Now : pLoan.TimeOfReturn.Value;
            TimeSpan duration = endTime - pLoan.TimeOfLoan;
            tbx_duration.Text = duration.Days + " days " + duration.Hours + ":" + duration.Minutes;
            lbl_information.Text = (0 == pLoanService.CalculatePenaltyFee(pLoan)) ? "" : "PenaltyFee: " + pLoanService.CalculatePenaltyFee(pLoan) + "kr.";
            EnableControls();
        }

        private void BookUpdated(object sender, EventArgs e)
        {
            tbx_noOfBooks.Text = pAuthor.Books.Count.ToString();
        }
        
    }
}
