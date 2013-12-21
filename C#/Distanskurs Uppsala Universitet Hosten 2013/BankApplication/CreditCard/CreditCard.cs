using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankApplication;

namespace CreditCard
{
    public partial class CreditCard : Form
    {
        public CreditCard()
        {
            InitializeComponent();
            ClearForm();
            EnableControls();
        }

        private Prenumerationsregister register = new Prenumerationsregister();

        private void btn_clean_Click(object sender, EventArgs e)
        {
            ClearForm();
            EnableControls();
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            if (true == rdb_bank.Checked)
            {
                register.LäggTillPrenumerant(new Prenumerant(tbx_lastname.Text, tbx_firstname.Text, new Bankkonto(1000.0)));
            }
            else if (true == rdb_creditcard.Checked)
            {
                register.LäggTillPrenumerant(new Prenumerant(tbx_lastname.Text, tbx_firstname.Text, new KreditKort(0.0)));
            }
            else
            { 
                // What to do, ms doesn't work.
                MessageBox.Show("Unknown error occurred, contact Bill.");
            }
            ClearForm();
            EnableControls();
        }

        private void btn_debitall_Click(object sender, EventArgs e)
        {
            try
            {
                double belopp = double.Parse(tbx_masswithdraw.Text);
                register.DraÅrsavgiftFrånAllaPrenumeranter(belopp);
            }
            catch (FormatException)
            {
                MessageBox.Show("Måste vara ett giltigt flyttal som debiteras kunderna.");
            }
        }

        private void btn_listcustomers_Click(object sender, EventArgs e)
        {
            lbx_customers.Items.Clear();
            foreach (Prenumerant pre in register.Prenumeranter)
            {
                lbx_customers.Items.Add(pre.ToString());
            }
        }

        private void tbx_firstname_TextChanged(object sender, EventArgs e)
        {
            EnableControls();
        }

        private void tbx_lastname_TextChanged(object sender, EventArgs e)
        {
            EnableControls();
        }

        /// <summary>
        /// Method that clears the input for new customers.
        /// </summary>
        private void ClearForm()
        {
            rdb_bank.Checked = true;
            tbx_firstname.Clear();
            tbx_lastname.Clear();
        }

        /// <summary>
        /// Method to enable or disable controls in the form.
        /// </summary>
        private void EnableControls()
        {
            btn_clean.Enabled = (tbx_firstname.Text.Length > 0 || tbx_lastname.Text.Length > 0);
            btn_create.Enabled = (tbx_firstname.Text.Length > 0 && tbx_lastname.Text.Length > 0);
            btn_debitall.Enabled = (register.Prenumeranter.Count > 0);
            btn_listcustomers.Enabled = (register.Prenumeranter.Count > 0);
        }
    }
}
