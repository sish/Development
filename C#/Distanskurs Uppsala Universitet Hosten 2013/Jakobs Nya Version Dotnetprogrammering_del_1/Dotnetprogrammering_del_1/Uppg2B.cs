using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//----------------------------------------------
//Uppsala Universitet
//Institutionen för informatik och media
//
//Andreas Zetterström
//andreas.zetterstrom@im.uu.se
//
//2010-08-26
//----------------------------------------------

namespace Dotnetprogrammering_del_1
{
    /// <summary>
    /// Formulär för Övningsuppgift 2B
    /// </summary>
    public partial class Uppg2B : Form
    {
        public Uppg2B()
        {
            InitializeComponent();
        }

        private void btnBeräkna_Click(object sender, EventArgs e)
        {
            try
            {
                //Läs in från textboxen och lägg i variabeln nettoPris
                double nettoPris = double.Parse(txtNetto.Text);
                //Gör uträkningen
                double bruttoPris = nettoPris * 1.25;
                txtBrutto.Text = bruttoPris.ToString("0.00"); //Formatera utskriften.
                txtNetto.Text = nettoPris.ToString("0.00"); //Formatera även nettopriset.
            }
            catch 
            {
                MessageBox.Show("Fel i inmatning. Försök igen.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Sudda textboxarna
            txtNetto.Clear();
            txtBrutto.Clear();
        }
    }
}
