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
    /// Formulär till Övningsuppgift 5B
    /// </summary>
    public partial class Uppg5B : Form
    {
        public Uppg5B()
        {
            InitializeComponent();
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            //Räkna vokaler och konsonanter i texten.
            string antalVokaler = RäknaVokaler(txtText.Text).ToString();
            string antalKonsonanter = RäknaKonsonanter(txtText.Text).ToString();

            //Skriv ut resultaten i textboxen på ett snyggt sätt.
            string v = " vokaler";
            if (antalVokaler == "1")
                v = " vokal";
            string k = " konsonanter";
            if (antalKonsonanter == "1")
                k = " konsonant";
            lblResult.Text = "Texten innehåller " + antalVokaler + v + " och " + antalKonsonanter + k + ".";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtText.Clear();
            lblResult.Text = "";
        }

        /// <summary>
        /// Räkna antalet vokaler i en text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private int RäknaVokaler(string text)
        {
            int sum = 0;
            for (int i = 0; i < text.Length; i++)

                //switch-satser är ibland ett smidigt alternativ
                //till if - else if - satser.
               
                switch (text.Substring(i, 1).ToLower()) //här står ett uttryck som vi vill testa mot
                {
                    case "a": //är uttrycket lika med a?
                    case "e": //eller lika med e?
                    case "i": //osv...
                    case "o":
                    case "u":
                    case "y":
                    case "å":
                    case "ä":
                    case "ö":
                        sum++;
                        break; //man måste ha med break
                }
            return sum;
        }

        /// <summary>
        /// Räkna antalet konsonanter i en text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private int RäknaKonsonanter(string text)
        {
            int sum = 0;
            for (int i = 0; i < text.Length; i++)
            {
                switch (text.Substring(i, 1).ToLower())
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
                        sum++;
                        break;
                }
            }
            return sum;
        }
    }
}
