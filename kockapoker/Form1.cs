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
        static List<Player> Players = new List<Player>();
        public Form1(int playercount)
        {
            InitializeComponent();
            DiceGen();
            PlayerGen(playercount, FileIO.Read("funnynames.txt"));
            RowGen();
        }

        private void PlayerGen(int playercount, List<string> funnynames)
        {
            for (int i = 0; i < playercount; i++)
            {
                Players.Add(new Player(funnynames[new Random().Next(0, funnynames.Count)]));
                funnynames.Remove(Players[i].Name);
            }

        }

        private void RowGen()
        {
            List<string> values = new List<string>() {"1", "2", "3", "4", "5", "6", "1 pár", "2 pár", "drill", "póker", "fullhouse", "kis sor", "nagy sor", "yahtzee", "esély", "összesen:" };
            for (int i = 0; i < values.Count; i++)
            {
                Panel row = new Panel() {

                    Size = new Size(TablePanel.Width, TablePanel.Height/values.Count),
                    Location = new Point(0, i * TablePanel.Height / values.Count),
                    BorderStyle = BorderStyle.FixedSingle,
                };
                TablePanel.Controls.Add(row);
                ColumnGen(row, i);
            }
        }

        private void ColumnGen(Panel row, int j)
        {
            for (int i = 0; i < Players.Count; i++)
            {
                int temp = Convert.ToInt32($"{i}");
                Players[temp].Points[j].Size = new Size(TablePanel.Width / Players.Count, TablePanel.Height / Players[temp].Points.Count);
                Players[temp].Points[j].Location = new Point(temp * Players[temp].Points[j].Size.Width, 0);
                Players[temp].Points[j].Text = "???";
                row.Controls.Add(Players[temp].Points[j]);
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
                    BackgroundImageLayout = ImageLayout.Zoom
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

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
