using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_Game
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

      

        private void btnTwoPlayer_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form fr1 = new shess();
            fr1.ShowDialog();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/benhamida24244");
        }
    }
}
