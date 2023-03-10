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
        public string Name="";
        public List<Cell> Points = new List<Cell>();
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

        private void ActiveChange(bool value)
        {
            for (int i = 0; i < Points.Count; i++)
            {
                Points[i].BackColor = value ? Color.LemonChiffon : Color.Transparent;
            }
        }

        //public Cell Sum = new Cell();
        //public Cell Ones = new Cell();
        //public Cell Twos = new Cell();
        //public Cell Threes = new Cell();
        //public Cell Fours = new Cell();
        //public Cell Fives = new Cell();
        //public Cell Sixes = new Cell();
        //public Cell Single_Pair = new Cell();
        //public Cell Double_Pair = new Cell();
        //public Cell Drill = new Cell();
        //public Cell FullHouse = new Cell();
        //public Cell Small_Row = new Cell();
        //public Cell Large_Row = new Cell();
        //public Cell Poker = new Cell();
        //public Cell Chance = new Cell();
        //public Cell Yahtzee = new Cell();

        public Player(string name)
        {
            Name = name;
            Active = false;
            List<string> values = new List<string>() { "1-es", "2-es", "3-as", "4-es", "5-ös", "6-os", "1 pár", "2 pár", "drill", "póker", "fullhouse", "kis sor", "nagy sor", "yahtzee", "esély", "összesen" };
            for (int i = 0; i < values.Count; i++)
            {
                Points.Add(new Cell(values[i]));
            }
        }
    }
}
