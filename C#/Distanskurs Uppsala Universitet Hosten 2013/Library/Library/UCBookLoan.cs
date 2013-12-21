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
    public partial class UCBookLoan : UserControl
    {

        private Book pBook;
        private Loan pLoan;
        private LoanService pLoanService;
        private BookService pBookService;
        private AuthorService pAuthorService;
        private BookCopyService pBookCopyService;

        public UCBookLoan(AuthorService aService, BookService bService, BookCopyService bcService, LoanService lService, Book book, Loan loan)
        {
            InitializeComponent();
            pAuthorService = aService;
            pBookService = bService;
            pBookCopyService = bcService;
            pLoanService = lService;
            pBook = book;
            pLoan = loan;
            init();
        }

        private void init()
        {
            tbx_title.Text = pBook.Title;
            tbx_isbn.Text = pBook.ISBN;
            tbx_copies.Text = pBook.Copies.Count.ToString();
            rtb_description.Text = pBook.Description;
            tbx_timeOfLoan.Text = pLoan.TimeOfLoan.ToString("yyyy-MM-dd HH:mm");
            tbx_timeOfReturn.Text = (null != pLoan.TimeOfReturn) ? pLoan.TimeOfReturn.Value.ToString("yyyy-MM-dd HH:mm") : "";
            DateTime endTime = (null == pLoan.TimeOfReturn) ? DateTime.Now : pLoan.TimeOfReturn.Value;
            TimeSpan duration = endTime - pLoan.TimeOfLoan;
            tbx_duration.Text = duration.Days + " days " + duration.Hours + ":" + duration.Minutes;
            lbl_information.Text = (0 == pLoanService.CalculatePenaltyFee(pLoan)) ? "" : "PenaltyFee: " + pLoanService.CalculatePenaltyFee(pLoan) + "kr.";
            EnableControls();
        }

        private void EnableControls()
        {
            btn_return.Enabled = (null == pLoan.TimeOfReturn);
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

        private void btn_return_Click(object sender, EventArgs e)
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

        private void UCBookLoan_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            pBookService.Updated += new EventHandler(BookUpdated);
            pBookCopyService.Updated += new EventHandler(BookCopyUpdated);
            pLoanService.Updated += new EventHandler(LoanUpdated);
        }

        private void DisposeEvents()
        {
            pBookService.Updated -= BookUpdated;
            pBookCopyService.Updated -= BookCopyUpdated;
            pLoanService.Updated -= LoanUpdated;
        }

        private void BookUpdated(object sender, EventArgs e)
        {
            tbx_title.Text = pBook.Title;
            rtb_description.Text = pBook.Description;
        }

        private void BookCopyUpdated(object sender, EventArgs e)
        {
            tbx_copies.Text = pBook.Copies.Count.ToString();
            EnableControls();
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

    }
}
