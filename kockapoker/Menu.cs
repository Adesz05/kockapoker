using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kockapoker
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            //sets the number of players to 2
            PlayerCountCBox.SelectedIndex = 0;
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            //shows game form
            new Form1(Convert.ToInt32(PlayerCountCBox.SelectedItem)).Show();
            this.Hide();
        }
    }
}
