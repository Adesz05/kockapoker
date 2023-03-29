using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace kockapoker
{
    class Player
    {
        //player name
        public string Name="";
        //player points
        public List<Cell> Points = new List<Cell>();
        //player active variable
        public bool Active
        {
            get { return active; }
            set
            {
                active = value;
                ActiveChange(value);
            }
        }
        private bool active;

        //If the player is active the players cells back color change
        private void ActiveChange(bool value)
        {
            for (int i = 0; i < Points.Count; i++)
            {
                Points[i].BackColor = value ? Color.LemonChiffon : Color.Transparent;
            }
        }

        //Constructor
        public Player(string name)
        {
            Name = name;
            Active = false;
            List<string> values = new List<string>() { "1-es", "2-es", "3-as", "4-es", "5-ös", "6-os", "1 pár", "2 pár", "Drill", "Póker", "Fullhouse", "Kis sor", "Nagy sor", "Yahtzee", "Esély" };
            for (int i = 0; i < values.Count; i++)
            {
                Points.Add(new Cell(values[i]));
            }
        }
    }
}
