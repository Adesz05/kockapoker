using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kockapoker
{
    class Player
    {
        public string Name="";
        public List<Cell> Points = new List<Cell>();
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
            List<string> values = new List<string>() { "1", "2", "3", "4", "5", "6", "1 pár", "2 pár", "drill", "póker", "fullhouse", "kis sor", "nagy sor", "yahtzee", "esély", "összesen" };
            for (int i = 0; i < values.Count; i++)
            {
                Points.Add(new Cell(values[i]));
            }
        }
    }
}
