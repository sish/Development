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
//2009-08-28
//----------------------------------------------

namespace Dotnetprogrammering_del_1
{
    /// <summary>
    /// Formulär för Övningsuppgift 2A
    /// </summary>
    public partial class Uppg2A : Form
    {
        public Uppg2A()
        {
            InitializeComponent();
        }

        private void btnBeräkna_Click(object sender, EventArgs e)
        {
            //Variabler vi kommer att behöva
            int tal1;
            int tal2;
            int summa;
            int differens;
            int produkt;
            int kvot;

            //Det här med try och catch behöver ni inte förstå än. Det är till för att programmet inte ska krascha
            //om man exempelvis skriver in bokstäver i textboxarna. Vi kommer förklara det när vi kommer fram till
            //exceptions.
            try
            {
                //Läs in från textboxarna och omvandla till integer
                tal1 = int.Parse(textBox1.Text);
                tal2 = int.Parse(textBox2.Text);

                //Beräkna
                summa = tal1 + tal2;
                differens = tal1 - tal2;
                produkt = tal1 * tal2;
                kvot = tal1 / tal2;

                //Visa resultatet
                MessageBox.Show("Summan av talen är " + summa + ". Differensen är " + differens +
                    ". Produkten är " + produkt + ". Kvoten är " + kvot + ".");

            }
            catch (DivideByZeroException )
            {
                MessageBox.Show("Det går ej att dividera med 0!");
            }
            catch (FormatException )
            {
                MessageBox.Show("Fel i inmatning. Endast heltal accepteras.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Sudda textboxarna
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
