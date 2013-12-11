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
    /// Formulär till Övningsuppgift 5C
    /// </summary>
    public partial class Uppg5C : Form
    {
       
        public Uppg5C()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            //Formatera texten i textboxen
            txtText.Text = FormateraVersalerOchGemener(txtText.Text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtText.Clear();
        }

        /// <summary>
        /// Formatera texten enl. specifikationen till uppgiften.
        /// Första bokstaven i en mening ska vara versal, alla andra
        /// bokstäver gemener.
        /// </summary>
        /// <param name="text">Texten som ska formateras</param>
        /// <returns></returns>
        private string FormateraVersalerOchGemener(string text)
        {
            string output = ""; //Tom sträng som ska bli resultatet.

            //Flaggvariabel som håller reda på om nästa bokstav ska bli versal eller inte.
            bool skaBliVersal = true; //true därför att första bokstaven alltid ska vara versal.

            text = text.ToLower(); //Gör först alla tecken till gemener.

            //Gå igenom texten tecken för tecken.
            for (int i = 0; i < text.Length; i++)
            {
                //Ta ut aktuellt tecken.
                string bokstav = text.Substring(i, 1);

                //Gör till versal och gemen på rätt sätt.
                if (skaBliVersal)
                {
                    bokstav = text.Substring(i, 1).ToUpper();
                }
            
                //Lägg till bokstaven till resultatsträngen
                output += bokstav;

                //Ta reda på om påföljande bokstav ska bli versal eller inte.
                switch (bokstav)
                {
                    //Efter skiljetecken ska det vara versal.
                    case ".":
                    case "!":
                    case "?":
                        skaBliVersal = true; 
                        break;

                    //Om bokstaven är mellanslag ska
                    //skaBliVersal behålla sitt värde.
                    case " ":
                        break;

                    //Bokstaven är varken skiljetecken eller mellanslag.
                    //Då ska påföljande bokstav icke bli versal.
                    default:
                        skaBliVersal = false;
                        break;
                }
            }
            return output;
        }
    }
}
