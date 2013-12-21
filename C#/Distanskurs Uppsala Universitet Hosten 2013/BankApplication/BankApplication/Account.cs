using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankApplication
{
    public partial class Account : Form
    {
        public Account()
        {
            InitializeComponent();
            EnableDisableButtons();
        }

        BankkontoMedRäntaOchInnehavare AktuelltKonto = null;

        private void btn_create_Click(object sender, EventArgs e)
        {
            double saldo = 0.0;
            double interest = 0.0;
            try
            {
                saldo = double.Parse(tbx_create.Text);
                interest = double.Parse(tbx_interest.Text);
                if (tbx_firstname.Text.Length == 0)
                {
                    MessageBox.Show("Måste ange ett förnamn för att kunna skapa ett konto.");
                }
                else if (tbx_lastname.Text.Length == 0)
                {
                    MessageBox.Show("Måste ange ett efternamn för att kunna skapa ett konto.");
                }
                else
                {
                    Person person = new Person(tbx_lastname.Text, tbx_firstname.Text);
                    BankkontoMedRäntaOchInnehavare konto = new BankkontoMedRäntaOchInnehavare(saldo, interest, person);
                    lbx_accounts.Items.Add(konto);
                    lbx_accounts.SelectedIndex = lbx_accounts.Items.Count - 1;
                    lbx_accounts.Focus();
                    AktuelltKonto = konto;
                    UpdateAktuelltKonto();
                    EnableDisableButtons();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Ogiltigt värde, måste ha giltiga flyttal för saldo och ränta.");
            }
        }

        private void btn_deposit_Click(object sender, EventArgs e)
        {
            try
            {
                double belopp = double.Parse(tbx_modify.Text);
                if (null == AktuelltKonto)
                {
                    MessageBox.Show("Du har inget konto valt för att sätta in pengar på.");
                }
                else if (0 > belopp)
                {
                    MessageBox.Show("Får endast sätta in positiva belopp.");
                }
                else
                {
                    AktuelltKonto.SättInPengar(belopp);
                    UpdateAktuelltKonto();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Måste ha ett giltigt flyttals värde inskrivet belopp formuläret.");
            }
        }

        private void btn_withdraw_Click(object sender, EventArgs e)
        {
            try
            {
                double belopp = double.Parse(tbx_modify.Text);
                if (null == AktuelltKonto)
                {
                    MessageBox.Show("Du har inget konto valt för att ta ut pengar ifrån.");
                }
                else if (0 > belopp)
                {
                    MessageBox.Show("Får endast ta ut positiva belopp.");
                }
                else
                {
                    AktuelltKonto.TaUtPengar(belopp);
                    UpdateAktuelltKonto();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Måste ha ett giltigt flyttals värde inskrivet i belopp formuläret.");
            }
            catch (ÖvertrasseringsException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lbx_accounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            AktuelltKonto = (BankkontoMedRäntaOchInnehavare)lbx_accounts.SelectedItem;
            UpdateAktuelltKonto();
            EnableDisableButtons();
        }

        private void btn_changeIntrest_Click(object sender, EventArgs e)
        {
            if (null == AktuelltKonto)
            {
                MessageBox.Show("Du har inget konto valt för att ändra räntesatsen.");
            }
            else
            {
                try
                {
                    AktuelltKonto.Räntesats = double.Parse(tbx_interest.Text);
                    UpdateAktuelltKonto();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Måste ha ett giltigt flyttals värde inskrivet i Ränta formuläret."); 
                }
            }
            EnableDisableButtons();
        }

        private void btn_addIntrest_Click(object sender, EventArgs e)
        {
            if (null == AktuelltKonto)
            {
                MessageBox.Show("Du har inget konto valt för att addera räntesatsen.");
            }
            else
            {
                AktuelltKonto.SättInRänta();
                UpdateAktuelltKonto();
            }
        }

        private void tbx_interest_TextChanged(object sender, EventArgs e)
        {
            EnableDisableButtons();
        }

        /// <summary>
        /// Method to update the visual fields to the current Class 
        /// </summary>
        private void UpdateAktuelltKonto()
        {
            if (null != AktuelltKonto)
            {
                tbx_firstname.Text = AktuelltKonto.Innehavare.Förnamn;
                tbx_lastname.Text = AktuelltKonto.Innehavare.Efternamn;
                tbx_create.Text = AktuelltKonto.Saldo.ToString();
                tbx_interest.Text = AktuelltKonto.Räntesats.ToString();
            }
        }

        /// <summary>
        /// Method to enable or disable buttons.
        /// </summary>
        private void EnableDisableButtons()
        {
            btn_changeIntrest.Enabled = (null != AktuelltKonto && AktuelltKonto.Räntesats.ToString() != tbx_interest.Text);
            btn_deposit.Enabled = (null != AktuelltKonto && tbx_modify.Text.Length > 0);
            btn_withdraw.Enabled = btn_deposit.Enabled;
        }

        private void tbx_modify_TextChanged(object sender, EventArgs e)
        {
            EnableDisableButtons();
        }


    }
}
