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
