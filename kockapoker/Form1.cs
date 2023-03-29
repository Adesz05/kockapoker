using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace kockapoker
{
    public partial class Form1 : Form
    {
        //Generating list for dices
        public static List<Dice> Dices = new List<Dice>();
        
        //Generating list for players
        static List<Player> Players = new List<Player>();
        
        //Defines the count of rolls
        public static int RollCount = 0;
        
        public Form1(int playercount)
        {
            InitializeComponent();
            //Generating the play area
            DiceGen();
            PlayerGen(playercount, FileIO.Read("funnynames.txt"));
            RowGen();
        }

        public static void NextPlayer()
        {
            //Checing if the game ended
            EndGameCheck();


            for (int i = 0; i < Players.Count; i++)
            {
                //Clearing column
                ClearColumn(Players[i]);
                
                //if we find the which players turn it is
                if (Players[i].Active)
                {
                    Players[i].Active = false;
                    //we make the next player active
                    Players[i == Players.Count - 1 ? 0 : i + 1].Active = true;
                    //resetting rollcount
                    RollCount = 0;
                    break;
                }
            }
            //Once the player choose their points it removes the locking of the dices
            ClearDices();
        }

        private static void EndGameCheck()
        {
            //If the number of players who are having empty points are zero
            if (Players.Count(x => HasEmpty(x.Points)) == 0)
            {
                //It shows win message
                WinMessage();
            }
        }

        private static void WinMessage()
        {
            //If you click yes
            if (DialogResult.Yes == MessageBox.Show(FinalMessage(), "Játék vége", MessageBoxButtons.YesNo))
            {
                //You can play again
                Application.Restart();
            }
            else
            {
                //Or you can exit
                Application.Exit();
            }
        }

        private static string FinalMessage()
        {

            string text = "A győztes";
            //Checking if multiple players have the same highest points and its a draw
            List<Player> winner_s = Players.FindAll(m => m.Points.Sum(n => n.Value) == Players.Max(x => x.Points.Sum(y => y.Value)));
            //if we have one winner only
            if (winner_s.Count == 1)
            {
                text += $" {winner_s[0].Name} {winner_s.Last().Points.Sum(x => x.Value)} pont\nSzeretnétek új játékot kezdeni?";
            }
            //If it is a draw we show all players names and points
            else
            {
                //It goes trough all of the winners
                foreach (Player player in winner_s)
                {
                    text += $"\n{player.Name} {winner_s.Last().Points.Sum(x => x.Value)} pont";
                }
                text += "\nSzeretnétek új játékot kezdeni?";
            }
            return text;
        }

        private static bool HasEmpty(List<Cell> points)
        {
            //Checks if there are any empty cells in a column
            foreach (Cell point in points)
            {
                if (!point.Confirmed)
                {
                    return true;
                }
            }
            return false;
        }

        private static void ClearDices()
        {
            //removes locking from all dices that are locked
            for (int i = 0; i < Dices.Count; i++)
            {
                Dices[i].Locked = false;
            }
        }

        private static void ClearColumn(Player player)
        {

            for (int i = 0; i < player.Points.Count; i++)
            {
                //If the player saved their points it changes the other cells text to blank
                if (!player.Points[i].Confirmed)
                {
                    player.Points[i].Text = "";
                }
            }
        }
        //Generating random player names
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

        //Generating the player name labels
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
        //Generating the labels, where we can see the options
        private void RowGen()
        {
            // These are all the options 
            List<string> values = new List<string>() {"1", "2", "3", "4", "5", "6", "1 pár", "2 pár", "drill", "póker", "fullhouse", "kis sor", "nagy sor", "yahtzee", "esély" };
            for (int i = 0; i < values.Count; i++)
            {
                Panel row = new Panel() {

                    Size = new Size(TablePanel.Width, TablePanel.Height/(values.Count+1)),
                    Location = new Point(0, (i + 1) * TablePanel.Height / (values.Count+1)),
                    BorderStyle = BorderStyle.FixedSingle,
                };
                TablePanel.Controls.Add(row);
                ColumnGen(row, i);
            }
        }
        //Generating  both players points.
        private void ColumnGen(Panel row, int j)
        {
            LabelColumnGen(row, j);
            for (int i = 0; i < Players.Count; i++)
            {
                Players[i].Points[j].Size = new Size(TablePanel.Width / (Players.Count + 1), TablePanel.Height / (Players[i].Points.Count+1));
                Players[i].Points[j].Location = new Point((i+1) * Players[i].Points[j].Size.Width, 0);
                row.Controls.Add(Players[i].Points[j]);
            }
        }

        //Generating the labels, where we can choose between the points we want.
        private void LabelColumnGen(Panel row, int j)
        {
            row.Controls.Add(new Label()
            {
                Location = new Point(0, 0),
                Text = Players[0].Points[j].Type,
                TextAlign = ContentAlignment.MiddleCenter,
                BorderStyle = BorderStyle.FixedSingle,
                AutoSize = false,
                Size = new Size(TablePanel.Width / (Players.Count + 1), TablePanel.Height / (Players[0].Points.Count + 1))
            });
        }

        //Generating the dices and giving them position, size, and numbers.
        private void DiceGen()
        {
            for (int i = 0; i < 5; i++)
            {
                Dices.Add(new Dice()
                {
                    Location = new Point(50+60*i, 150),
                    Size=new Size(50,50),
                    SizeMode=PictureBoxSizeMode.Zoom,
                    BackgroundImageLayout = ImageLayout.Zoom
            });
                Dices[i].Randomize();
                Dices[i].Click += new EventHandler(Dice_Click);
                this.Controls.Add(Dices[i]);
            }
            
        }

        //After clicking the dices, we can  lock them, so when we  roll, the locked numbers stays the same.
        private void Dice_Click(object sender, EventArgs e)
        {
            if (RollCount!=0)
            {
                Dice clicked = sender as Dice;
                clicked.Locked = !clicked.Locked;
            }
        }

        //After clicking the Roll Dice button, we got 5 new  numbers on the dices.
        private void RollDiceBtn_Click(object sender, EventArgs e)
        {
            //If we roll less than 3 times we can roll again
            if (RollCount != 3)
            {
                for (int i = 0; i < Dices.Count; i++)
                {
                    //Randomizing the dices numbers
                    Dices[i].Randomize();
                }
                CalculateResults(Players.Find(x => x.Active));
                RollCount++;
            }
        }

        //Calculating the results of the players.
        private void CalculateResults(Player player)
        {
            foreach (Cell cell in player.Points)
            {
                if (!cell.Confirmed)
                {
                    cell.Text = cell.Calculate(Dices).ToString();
                }
            }
        }
        //Closing the form.
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
