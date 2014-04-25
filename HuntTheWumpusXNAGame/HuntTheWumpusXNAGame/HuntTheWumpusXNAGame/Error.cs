using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HuntTheWumpusXNAGame
{
    public partial class Error : Form
    {
        string text;
        public Error(Exception e)
        {
            InitializeComponent();
            text = e.ToString();
            label1.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Game1.Exit();
        }

    }
}
