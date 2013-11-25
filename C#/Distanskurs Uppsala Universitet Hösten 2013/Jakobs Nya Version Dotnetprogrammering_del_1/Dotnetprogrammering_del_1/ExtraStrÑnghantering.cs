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
    /// Formulär till uppgift 7D
    /// </summary>
    public partial class ExtraStränghantering : Form
    {
        public ExtraStränghantering()
        {
            InitializeComponent();
        }

        private void btnTranslate_Click(object sender, EventArgs e)
        {
            txtResult.Text = ÖversättTillRövarspråk(txtText.Text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Smidigt sätt att iterera över alla textboxar på formuläret.
            foreach (TextBox textbox in this.Controls.OfType<TextBox>())
                textbox.Clear();
        }

        /// <summary>
        /// Översätt text till rövarspråket
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private string ÖversättTillRövarspråk(string text)
        {
            string output = ""; //Tom resultatsträng

            //Gå igenom texten tecken för tecken.
            //Om tecknet är konsonant, lägg till o och tecknet (som gemen),
            //annars lägg till tecknet som det är.
            for (int i = 0; i < text.Length; i++)
            {
                string bokstav = text.Substring(i, 1);
                if (ÄrKonsonant(bokstav))
                    output += bokstav + "o" + bokstav.ToLower();
                else output += bokstav;
            }
            return output;
        }

        /// <summary>
        /// Är bokstaven konsonant eller inte?
        /// </summary>
        /// <param name="bokstav"></param>
        /// <returns></returns>
        private bool ÄrKonsonant(string bokstav)
        {
            //Gör först bokstaven till gemen
            //så vi slipper räkna upp både versala
            //och gemena konsonanter
            switch (bokstav.ToLower())
            {
                case "b":
                case "c":
                case "d":
                case "f":
                case "g":
                case "h":
                case "j":
                case "k":
                case "l":
                case "m":
                case "n":
                case "p":
                case "q":
                case "r":
                case "s":
                case "t":
                case "v":
                case "w":
                case "x":
                case "z":
                    return true;
                    //här behöver vi inte break, eftersom return
                    //avbryter exekveringen.
                default:
                    return false;
            }
        }
    }
}
