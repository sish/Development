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
    /// Formulär för Övningsuppgift 3C
    /// </summary>
    public partial class Uppg3C : Form
    {
        
        public Uppg3C()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            //Läs in texter från textboxarna och anropa metoden som
            //kontrollerar om de är identiskt lika.
            //Visa resultatet i en MessageBox.
            //
            if (ÄrLika(textBox.Text, textBox2.Text))
                MessageBox.Show("Ja, texterna är identiskt lika");
            else
                MessageBox.Show("Nej, texterna är inte identiskt lika");
        }

       /// <summary>
       /// Är två texter identiskt lika?
       /// (Jämförelsen skiljer på VERSALER och gemener.)
       /// </summary>
       /// <param name="text1">Första texten</param>
       /// <param name="text2">Andra texten</param>
       /// <returns>True om texterna är lika, false annars</returns>
        private bool ÄrLika(string text1, string text2)
        {
            return (text1 == text2);
        }
    }
}
