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
    public partial class MemberForm : Form
    {

        public Member Member = null;
        private MemberService pMemberService;
        private const string BTN_SAVE = "Save";
        private const string BTN_EDIT = "Edit";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mService">MemberService to use for opeartions of member.</param>
        public MemberForm(MemberService mService)
        {
            InitializeComponent();
            Member = new Member();
            btn_save_edit.Text = BTN_SAVE;
            pMemberService = mService;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mService">MemberService to use for opeartions of member.</param>
        /// <param name="member">Member object to edit</param>
        public MemberForm(MemberService mService, Member member)
        {
            InitializeComponent();
            Member = member;
            btn_save_edit.Text = BTN_EDIT;
            tbx_name.Text = Member.Name;
            tbx_name.Enabled = false;
            tbx_personal_id.Text = Member.PersonalID;
            tbx_personal_id.Enabled = false;
            pMemberService = mService;
        }

        private void btn_save_edit_Click(object sender, EventArgs e)
        {
            if (BTN_EDIT == btn_save_edit.Text)
            {
                btn_save_edit.Text = BTN_SAVE;
                tbx_name.Enabled = true;
                tbx_personal_id.Enabled = true;
            }
            else if (BTN_SAVE == btn_save_edit.Text)
            {
                try
                {
                    Member.Name = tbx_name.Text;
                    Member.PersonalID = tbx_personal_id.Text;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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

        private void tbx_personal_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btn_save_edit_Click(this, e);
            }
        }

    }
}
