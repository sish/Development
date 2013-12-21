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
    /// Formulär för Övningsuppgift 3D
    /// </summary>
    public partial class Uppg3D : Form
    {
        public Uppg3D()
        {
            InitializeComponent();
        }

        private void rdbCylinder_CheckedChanged(object sender, EventArgs e)
        {
            //Visa rätt text i lblBase utifrån vilken radiobutton som är ikryssad.
            if (rdbCylinder.Checked)
                lblBase.Text = "Radien:";
            else
                lblBase.Text = "Basytans area:";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Smidigt sätt att iterera över alla textboxar på formuläret.
            //Sudda texten i alla textboxar.
            //(Detta behöver ni inte förstå än.)
            foreach (TextBox textbox in this.Controls.OfType<TextBox>())
                textbox.Clear();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //Läs in värden från textboxar.
            //Läs av radiobuttons så att vi vet vilken sorts
            //kropps volym som ska beräknas.
            //Beräkna volymen.
            //Visa resultatet, formaterat till fyra decimaler.
            try
            {
                double b = double.Parse(txtBase.Text);
                double h = double.Parse(txtHeight.Text);

                if (rdbCylinder.Checked)
                    txtResult.Text = BeräknaCylinderVolym(b, h).ToString("0.0000");
                else if (rdbPrism.Checked)
                    txtResult.Text = BeräknaPrismaVolym(b, h).ToString("0.0000");
                else
                    txtResult.Text = BeräknaPyramidVolym(b, h).ToString("0.0000");
            }
            catch
            {
                MessageBox.Show("Fel i inmatning. Försök igen.", "Felmeddelande",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //
        //Metoder som beräknar volymen för geometriska kroppar
        //

        /// <summary>
        /// Beräkna volymen av ett prisma
        /// </summary>
        /// <param name="bottenArea">Prismats bottenarea</param>
        /// <param name="höjd">Prismats höjd, vinkelrätt mot bottenarean</param>
        /// <returns>Prismats volym</returns>
        private double BeräknaPrismaVolym(double bottenArea, double höjd)
        {
            return bottenArea * höjd;
        }

        /// <summary>
        /// Beräkna volymen av en cylinder
        /// </summary>
        /// <param name="radie">Cylinderns radie</param>
        /// <param name="höjd">Cylinderns höjd, vinkelrätt mot bottenytan</param>
        /// <returns>Cylinderns volym</returns>
        private double BeräknaCylinderVolym(double radie, double höjd)
        {
            return Math.PI * radie * radie * höjd;
        }

        /// <summary>
        /// Beräkna volymen av en pyramid
        /// </summary>
        /// <param name="bottenArea">Pyramidens bottenarea</param>
        /// <param name="höjd">Pyramidens höjd, vinkelrätt mot bottenarean</param>
        /// <returns>Pyramidens volym</returns>
        private double BeräknaPyramidVolym(double bottenArea, double höjd)
        {
            return (bottenArea * höjd) / 3;
        }
    }
}
