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
    public partial class UCMemberBook : UserControl
    {

        private Member pMember;
        private Book pBook;
        private AuthorService pAuthorService;
        private BookService pBookService;
        private BookCopyService pBookCopyService;
        private LoanService pLoanService;
        private MemberService pMemberService;

        public UCMemberBook(AuthorService aService, BookService bService, BookCopyService bcService, LoanService lService, MemberService mService, Member member, Book book)
        {
            InitializeComponent();
            pMember = member;
            pBook = book;
            pAuthorService = aService;
            pBookService = bService;
            pBookCopyService = bcService;
            pLoanService = lService;
            pMemberService = mService;
            init();
        }

        private void init()
        {
            tbx_name.Text = pMember.Name;
            tbx_ssn.Text = pMember.PersonalID;
            Loan.SetToStringMethod(Loan.StringFormat.SF_AUTHOR);
            cbx_currentloans.DataSource = pLoanService.GetActiveLoansByMember(pMember);
            tbx_title.Text = pBook.Title;
            tbx_isbn.Text = pBook.ISBN;
            tbx_copies.Text = pBook.Copies.Count.ToString();
            rtb_description.Text = pBook.Description;
            tbx_availableCopies.Text = pBookCopyService.GetNoOfAvailableCopies(pBook).ToString();
            EnableControls();
        }

        private void EnableControls()
        {
            btn_loan.Enabled = (0 != int.Parse(tbx_availableCopies.Text));
            btn_return.Enabled = (0 != cbx_currentloans.Items.Count);
        }

        private void UCMemberBook_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            pBookService.Updated += new EventHandler(BookUpdated);
            pBookCopyService.Updated += new EventHandler(BookCopyUpdated);
            pMemberService.Updated += new EventHandler(MemberUpdated);
            pLoanService.Updated += new EventHandler(LoanUpdated);
        }

        private void DisposeEvents()
        {
            pBookService.Updated -= BookUpdated;
            pBookCopyService.Updated -= BookCopyUpdated;
            pMemberService.Updated -= MemberUpdated;
            pLoanService.Updated -= LoanUpdated;
        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            Loan loanToReturn = cbx_currentloans.SelectedItem as Loan;
            if (null == loanToReturn)
            {
                throw new InvalidOperationException("Trying to return a Loan object that is not of type Loan.");
            }
            else
            {
                int penaltyFee = pLoanService.MakeReturn(loanToReturn);
                if (0 != penaltyFee)
                {
                    string errorText = "Bookloan with title: " + loanToReturn.Copy.Book.Title +
                        " has a penalty fee of " + penaltyFee + "kr.";
                    MessageBox.Show(errorText);
                }
            }
        }

        private void btn_addCopy_Click(object sender, EventArgs e)
        {
            pBookCopyService.AddBookCopy(pBook);
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

        private void btn_loan_Click(object sender, EventArgs e)
        {
            pLoanService.MakeLoan(pMember, pBook);
        }

        private void BookUpdated(object sender, EventArgs e)
        {
            tbx_title.Text = pBook.Title;
            rtb_description.Text = pBook.Description;
        }

        private void BookCopyUpdated(object sender, EventArgs e)
        {
            tbx_copies.Text = pBook.Copies.Count.ToString();
            tbx_availableCopies.Text = pBookCopyService.GetNoOfAvailableCopies(pBook).ToString();
            EnableControls();
        }

        private void MemberUpdated(object sender, EventArgs e)
        {
            tbx_name.Text = pMember.Name;
            tbx_ssn.Text = pMember.PersonalID;
        }

        private void LoanUpdated(object sender, EventArgs e)
        {
            cbx_currentloans.DataSource = null;
            cbx_currentloans.DataSource = pLoanService.GetActiveLoansByMember(pMember);
            tbx_availableCopies.Text = pBookCopyService.GetNoOfAvailableCopies(pBook).ToString();
            EnableControls();
        }

        private void btn_editMember_Click(object sender, EventArgs e)
        {
            MemberForm form = new MemberForm(pMemberService, pMember);
            try
            {
                if (DialogResult.OK == form.ShowDialog())
                {
                    pMemberService.EditMember(form.Member);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
