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
    /// Formulär till Övningsuppgift 4C
    /// </summary>
    public partial class Uppg4C : Form
    {
        public Uppg4C()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string resultString = "";
            try
            {
                int antalFibonacci = int.Parse(txtNumber.Text);

                //Kolla att antal fibonaccital håller sig inom rimliga ramar.
                if (antalFibonacci > 45 || antalFibonacci < 1)
                    throw new Exception();

                //Skriv ut antalFibbonacci fibonaccital i textboxen.
                for (int i = 0; i < antalFibonacci; i++)
                {
                    resultString += Fibonacci(i).ToString() + Environment.NewLine;
                }
                txtResult.Text = resultString;
            }
            catch
            {
                MessageBox.Show("Felaktig inmatning. Mata in ett heltal mellan 1 och 45.", "Felmeddelande", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumber.Clear();
                txtNumber.Select();
            }
        }

        /// <summary>
        /// Räkna ut det n:te fibonaccitalet
        /// </summary>
        /// <param name="n">Vilket fibonaccital i ordningen vill veta, från 0 och framåt</param>
        /// <returns>Det n:te fibonaccitalet</returns>
        public int Fibonacci(int n)
        {
            int fibLast = 0; //Senaste fibonaccital
            int fibSecondLast = 0; //Näst senaste fibonaccital
            int fibCurrent = 0; //Nuvarande fibonaccital

            //De två första talen i fibonacci-serien
            fibSecondLast = 0;
            fibLast = 1;

            if (n == 0)
                fibCurrent = fibSecondLast;
            else if (n == 1)
                fibCurrent = fibLast;
            else
            {
                //Loopa från 2 till n. Addera fibLast och fibSecondLast
                //och lägg i fibCurrent. Flytta sedan fram ett steg så
                //fibSecondLast får värdet av fibLast, fibLast får värdet av fibCurrent.
                //
                for (int i = 2; i <= n; i++)
                {
                    fibCurrent = fibLast + fibSecondLast;
                    fibSecondLast = fibLast;
                    fibLast = fibCurrent;
                }
            }
            return fibCurrent; //Och returnera svaret!
        }


    }
}
