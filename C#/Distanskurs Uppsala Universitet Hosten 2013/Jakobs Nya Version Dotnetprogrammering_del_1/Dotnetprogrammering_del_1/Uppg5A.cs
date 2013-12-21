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
    /// Formulär till Övningsuppgift 5A
    /// </summary>
    public partial class Uppg5A : Form
    {
        public Uppg5A()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                string förnamn = txtFirstname.Text;
                string efternamn = txtLastname.Text;
                string ort = txtCity.Text;
                string ålder = txtAge.Text;

                //Felhantering, kontroll av indata
                KollaIndata(förnamn, efternamn, ort, ålder);
                
                //Anropa metoden som formaterar strängen och skriv ut i textboxen
                lblResult.Text = Uppgift7A(förnamn, efternamn, ort, ålder);
 
            }
            catch (FormatException exc)
            {
                MessageBox.Show(this, exc.Message, "Felmeddelande", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Kontrollera att parametrarna har godkända värden.
        /// Kasta FormatException om de inte har det.
        /// </summary>
        /// <param name="förnamn">Förnamn: får inte vara ""</param>
        /// <param name="efternamn">Efternamn: får inte vara ""</param>
        /// <param name="ort">Ort: får inte vara ""</param>
        /// <param name="ålder">Ålder: måste kunna omvandlas till heltal</param>
        private void KollaIndata(string förnamn, string efternamn, string ort, string ålder)
        {
            if (förnamn == "")
                throw new FormatException("Ange förnamn.");
            if (efternamn == "")
                throw new FormatException("Ange efternamn.");
            if (ort == "")
                throw new FormatException("Ange bostadsort.");
            int x;
            if (!int.TryParse(ålder, out x))
                throw new FormatException("Ange ålder.");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Smidigt sätt att iterera över alla textboxar på formuläret.
            //(Överkurs)
            foreach (TextBox textbox in this.Controls.OfType<TextBox>())
                textbox.Clear();

            lblResult.Text = "";
        }

        /// <summary>
        /// Skapa en textsträng enl. spec. till uppgiften
        /// </summary>
        /// <param name="förnamn"></param>
        /// <param name="efternamn"></param>
        /// <param name="bostadsort"></param>
        /// <param name="ålder"></param>
        /// <returns>En textsträng på formen "{förnamn} {efternamn} är {ålder} år gammal och bor i {bostadsort}."</returns>
        private string Uppgift7A(string förnamn, string efternamn, string bostadsort, string ålder)
        {
            return förnamn + " " + efternamn + " är " + ålder + " år gammal och bor i " + bostadsort + ".";
        }
    }
}
