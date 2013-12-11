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
    public partial class UCMemberLoan : UserControl
    {

        private MemberService pMemberService;
        private LoanService pLoanService;
        private Member pMember;
        private Loan pLoan;

        public UCMemberLoan(LoanService lService, MemberService mService, Loan loan, Member member)
        {
            InitializeComponent();
            pLoanService = lService;
            pMemberService = mService;
            pMember = member;
            pLoan = loan;
            init();
        }

        public void init()
        {
            tbx_name.Text = pMember.Name;
            tbx_ssn.Text = pMember.PersonalID;
            Loan.SetToStringMethod(Loan.StringFormat.SF_AUTHOR);
            cbx_currentloans.DataSource = pLoanService.GetActiveLoansByMember(pMember);
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
            btn_returnBook.Enabled = (null == pLoan.TimeOfReturn);
            btn_return.Enabled = (0 != cbx_currentloans.Items.Count);
        }

        private void UCMemberLoan_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            pMemberService.Updated += new EventHandler(MemberUpdated);
            pLoanService.Updated += new EventHandler(LoanUpdated);
        }

        public void DisposeEvents()
        {
            pMemberService.Updated -= MemberUpdated;
            pLoanService.Updated -= LoanUpdated;
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

        private void MemberUpdated(object sender, EventArgs e)
        {
            tbx_name.Text = pMember.Name;
            tbx_ssn.Text = pMember.PersonalID;
        }

        private void LoanUpdated(object sender, EventArgs e)
        {
            cbx_currentloans.DataSource = null;
            cbx_currentloans.DataSource = pLoanService.GetActiveLoansByMember(pMember);
            tbx_timeOfReturn.Text = (null != pLoan.TimeOfReturn) ? pLoan.TimeOfReturn.Value.ToString("yyyy-MM-dd HH:mm") : "";
            DateTime endTime = (null == pLoan.TimeOfReturn) ? DateTime.Now : pLoan.TimeOfReturn.Value;
            TimeSpan duration = endTime - pLoan.TimeOfLoan;
            tbx_duration.Text = duration.Days + " days " + duration.Hours + ":" + duration.Minutes;
            lbl_information.Text = (0 == pLoanService.CalculatePenaltyFee(pLoan)) ? "" : "PenaltyFee: " + pLoanService.CalculatePenaltyFee(pLoan) + "kr.";
            EnableControls();
        }

    }
}
