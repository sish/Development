using Library.DomainObjects;
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
    public partial class AuthorForm : Form
    {
        public Author author { private set; get; }
        private static string BTN_SAVE = "Save";
        private static string BTN_EDIT = "Edit";

        public AuthorForm()
        {
            InitializeComponent();
            author = new Author();
            btn_SaveEdit.Text = BTN_SAVE;
        }

        public AuthorForm(Author edit)
        {
            InitializeComponent();
            author = edit;
            btn_SaveEdit.Text = BTN_EDIT;
            tbx_name.Text = edit.Name;
            tbx_name.Enabled = false;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btn_SaveEdit_Click(object sender, EventArgs e)
        {
            if (BTN_EDIT.Equals(btn_SaveEdit.Text))
            {
                btn_SaveEdit.Text = BTN_SAVE;
                tbx_name.Enabled = true;
            }
            else
            {
                author.Name = tbx_name.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void tbx_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btn_SaveEdit_Click(this, e);
            }
        }
    }
}
