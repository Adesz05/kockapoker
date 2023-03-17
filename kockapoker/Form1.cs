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
        public static List<Dice> Dices = new List<Dice>();
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
            Random r = new Random();
            for (int i = 0; i < playercount; i++)
            {
                Players.Add(new Player(funnynames[r.Next(0, funnynames.Count)]));
                funnynames.Remove(Players[i].Name);
                LabelGen(Players[i], i, playercount);

            }
            Players[0].Active = true;
        }

        private void LabelGen(Player player, int i, int playercount)
        {
            TablePanel.Controls.Add(new Label()
            {
                Size = new Size(TablePanel.Width / (playercount + 1), TablePanel.Height / (player.Points.Count + 1)),
                Location = new Point((i + 1) * (TablePanel.Size.Width / (playercount + 1)), 0),
                Text = player.Name,
                TextAlign = ContentAlignment.MiddleCenter,
                BorderStyle = BorderStyle.FixedSingle
            });
        }

        private void RowGen()
        {
            List<string> values = new List<string>() {"1", "2", "3", "4", "5", "6", "1 pár", "2 pár", "drill", "póker", "fullhouse", "kis sor", "nagy sor", "yahtzee", "esély" };
            for (int i = 0; i < values.Count; i++)
            {
                Panel row = new Panel() {

                    Size = new Size(TablePanel.Width, TablePanel.Height/values.Count),
                    Location = new Point(0, (i + 1) * TablePanel.Height / values.Count),
                    BorderStyle = BorderStyle.FixedSingle,
                };
                TablePanel.Controls.Add(row);
                ColumnGen(row, i);
            }
        }

        private void ColumnGen(Panel row, int j)
        {
            row.Controls.Add(new Label()
            {
                Location=new Point(0,0),
                Text=Players[0].Points[j].Type, //nem látja a typeot
                TextAlign=ContentAlignment.MiddleCenter,
                BorderStyle=BorderStyle.FixedSingle,
                AutoSize=false,
                Size= new Size(TablePanel.Width / (Players.Count + 1), TablePanel.Height / (Players[0].Points.Count + 1))
        });
            for (int i = 0; i < Players.Count; i++)
            {
                Players[i].Points[j].Size = new Size(TablePanel.Width / (Players.Count + 1), TablePanel.Height / (Players[i].Points.Count+1));
                Players[i].Points[j].Location = new Point((i+1) * Players[i].Points[j].Size.Width, 0);
                Players[i].Points[j].Text = "???";
                row.Controls.Add(Players[i].Points[j]);
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
                Dices[i].Randomize();
                Dices[i].Click += new EventHandler(Dice_Click);
                this.Controls.Add(Dices[i]);
            }
            
        }
        //public static List<Dice> 

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
            
            CalculateResults(Players.Find(x => x.Active));
        }

        private void CalculateResults(Player player)
        {
            foreach (Cell cell in player.Points)
            {
                cell.Text = cell.Calculate(Dices).ToString();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
