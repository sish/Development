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
    /// Formulär för Lektionsuppgift 1A-B
    /// </summary>
    public partial class ExtraOmGrafik : Form
    {
        public ExtraOmGrafik()
        {
            InitializeComponent();
        }

        private void btnRita1A_Click(object sender, EventArgs e)
        {
            Graphics paper;     //Variabel som lagrar grafik-objektet vi ska rita på.
            SolidBrush brushRed;    //Variabel som lagrar den röda penseln.
            SolidBrush brushYellow;     //Variabel som lagrar den gula penseln.

            paper = paintBox.CreateGraphics();  //Sätt paper till paintBox:s grafikobjekt
            brushRed = new SolidBrush(Color.Red);   //Skapa den röda penseln.
            brushYellow = new SolidBrush(Color.Yellow);     //Skapa den gula penseln.
            paper.FillRectangle(brushRed, 300, 200, 50, 30);    //Rita den röda rektangeln.
            paper.FillEllipse(brushYellow, 50, 40, 40, 40);     //Rita den gula rektangeln.
        }

        private void btnSudda_Click(object sender, EventArgs e)
        {
            //Detta behöver ni inte förstå än.
           Graphics paper = paintBox.CreateGraphics();
           paper.Clear(Color.White);
        }

        private void btnRita1B_Click(object sender, EventArgs e)
        {
            Graphics paper;     //Deklarera en Graphics-variabel     
            SolidBrush brush;   //Deklarera en Brush-variabel
            paper = paintBox.CreateGraphics();      //Tilldela paper paintBox:s grafikobjekt
            brush = new SolidBrush(Color.Blue);     //Skapa en SolidBrush och sätt brush-variabeln till den.

            paper.FillRectangle(brush, 150, 150, 64, 40);   //Rita den blå bakgrunden på flaggan

            brush.Color = Color.Yellow;     //Byt färg på penseln

            //Rita det gula korset på flaggan
            paper.FillRectangle(brush, 150, 166, 64, 8);        
            paper.FillRectangle(brush, 170, 150, 8, 40);

            //Byt färg på penseln och rita gräsmattan
            brush.Color = Color.Green;
            paper.FillRectangle(brush, 0, 300, paintBox.Width, paintBox.Height - 300);

            //Byt färg på penseln och rita flaggstången
            brush.Color = Color.LightGray;
            paper.FillRectangle(brush, 142, 150, 8, 160);
        }
    }
}
