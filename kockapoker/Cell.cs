using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace kockapoker
{
    public class Cell : Label
    {
        public string Type;
        public int Value;
        public bool Confirmed;

        public Cell(string type)
        {
            Type = type;
            AutoSize = false;
            Confirmed = false;
            TextAlign = ContentAlignment.MiddleCenter;
            Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
            BorderStyle = BorderStyle.FixedSingle;
        }
        public int Calculate(List<Dice> dices)
        {
            if (Confirmed)
            {
                return Value;
            }
            else
            {
                switch (Type)
                {
                    case "1-es":

                        break;
                    case "2-es":

                        break;
                    case "3-as":

                        break;
                    case "4-es":

                        break;
                    case "5-ös":

                        break;
                    case "6-os":

                        break;
                    case "1 pár":
                        return OnePair(dices);
                        break;
                    case "2 pár":
                        return TwoPair(dices);
                        break;
                    case "Drill":

                        break;
                    case "Póker":

                        break;
                    case "Fullhouse":

                        break;
                    case "Kis sor":

                        break;
                    case "Nagy sor":

                        break;
                    case "Yahtzee":

                        break;
                    case "Esély":

                        break;
                    default:
                        break;
                }
            }
            return 0;
        }

        private int TwoPair(List<Dice> dices)
        {
            dices.OrderBy(x => x.Value);
            List<Dice> pairs = dices.FindAll(x => dices.Count(y => y.Value == x.Value) >= 2);
            if (pairs.Count >= 4)
            {
                return 2 * (pairs[0].Value + pairs.Last().Value);
            }
            return 0;
        }

        private int OnePair(List<Dice> dices)
        {
            int max = 0;
            foreach (Dice item in dices)
            {
                if (dices.Count(x => x.Value == item.Value) >= 2 && item.Value*2 > max)
                {
                    max = item.Value * 2;
                }
            }
            return max;
        }
    }
}
