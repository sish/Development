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
    /// Formulär till Övningsuppgift 4B
    /// </summary>
    public partial class Uppg4B : Form
    {
        public Uppg4B()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                int x = int.Parse(txtNumber.Text);
                //Anropa funktionen ÄrUdda i villkoret till if-satsen.
                if (ÄrUdda(x))
                    lblResult.Text = "Talet är udda.";
                else
                    lblResult.Text = "Talet är jämnt.";
            }
            catch
            {
                lblResult.Text = "Felaktig inmatning. Talet är ej ett heltal.";
                txtNumber.Clear();
                txtNumber.Select();
            }
        }

        /// <summary>
        /// Ta reda på om ett tal är udda eller jämnt
        /// </summary>
        /// <param name="talet">Talet som vi undrar över</param>
        /// <returns>True om talet är udda, false om talet är jämnt</returns>
        private bool ÄrUdda(int talet)
        {
            //om resten vid heltalsdivision med 2 är 0 är talet jämnt, annars är det udda.
            //! betyder icke. Vi returnerar true om resten icke är 0.
            return (talet % 2 != 0);
        }
    }
}
