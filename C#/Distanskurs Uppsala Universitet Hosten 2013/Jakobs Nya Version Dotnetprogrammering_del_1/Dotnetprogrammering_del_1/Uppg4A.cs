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
    /// Formulär för Övningsuppgift 4A
    /// </summary>
    public partial class Uppg4A : Form
    {

        public Uppg4A()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                int ålder = int.Parse(txtAge.Text);
                txtResult.Text = KategoriseraÅlder(ålder);
            }
            catch
            {
                MessageBox.Show("Fel i inmatning. Endast heltal accepteras.", "Felmeddelande", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAge.Clear();
                txtAge.Select();
            }
        }
        
       /// <summary>
       /// Ta reda på vilken kategori personen tillhör,
       /// enligt specifikationen till uppgiften
       /// </summary>
       /// <param name="ålder">Personens ålder</param>
       /// <returns>En textsträng som beskriver kategorin, enl. uppgiftens specifikation</returns>
        private string KategoriseraÅlder(int ålder)
        {

            if (ålder >= 16 && ålder <= 19)
                return "tonåring"; //return avbryter alltid exekvering av metoden
            if (ålder >= 20 && ålder <= 29)
                return "ungdom";
            if (ålder >= 30 && ålder <= 49)
                return "medelålders";
            if (ålder >= 50 && ålder <= 65)
                return "äldre";

            //Har vi kommit hit måste personen vara <16 eller >65!
            return "Personen tillhör inte arbetsför kategori";
        }
    }
}
