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
    public partial class Form1 : Form
    {
        static List<Dice> Dices = new List<Dice>();
        public Form1()
        {
            InitializeComponent();
            DiceGen();
            RowGen();
        }

        private void RowGen()
        {
            List<string> values = new List<string>() {"", "1", "2", "3", "4", "5", "6", "1 pár", "2 pár", "drill", "póker", "fullhouse", "kis sor", "nagy sor", "yahtzee", "esély", "összesen:" };
            for (int i = 0; i < values.Count; i++)
            {
                Panel row = new Panel() {

                    Size = new Size(TablePanel.Width, TablePanel.Height/values.Count),
                    Location = new Point(0, i * TablePanel.Height / values.Count),
                    BorderStyle = BorderStyle.FixedSingle,
                };
                TablePanel.Controls.Add(row);
            }
        }

        private void DiceGen()
        {
            for (int i = 0; i < 5; i++)
            {
                Dices.Add(new Dice()
                {
                    Location = new Point(50+50*i, 50),
                    Size=new Size(50,50),
                    SizeMode=PictureBoxSizeMode.Zoom,
                });
                Dices[i].Click += new EventHandler(Dice_Click);
                this.Controls.Add(Dices[i]);
            }
        }

        private void Dice_Click(object sender, EventArgs e)
        {
            Dice clicked = sender as Dice;
            clicked.Locked = !clicked.Locked;
        }

        private void RollDiceBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Dices.Count; i++)
            {
                Dices[i].Randomize();
            }
        }


    }
}
