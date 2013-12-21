using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dotnetprogrammering_del_1
{
    public partial class NavForm : Form
    {
        public NavForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ExtraOmGrafik().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Uppg2A().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Uppg2B().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Uppg3C().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Uppg3D().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new Uppg4A().Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new Uppg4B().Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new Uppg4C().Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new Uppg5A().Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            new Uppg5B().Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            new Uppg5C().Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            new ExtraStränghantering().Show();
        }

    }
}
