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
                        return Numbers(dices, 1);
                        break;
                    case "2-es":
                        return Numbers(dices, 2);
                        break;
                    case "3-as":
                        return Numbers(dices, 3);
                        break;
                    case "4-es":
                        return Numbers(dices, 4);
                        break;
                    case "5-ös":
                        return Numbers(dices, 5);
                        break;
                    case "6-os":
                        return Numbers(dices, 6);
                        break;
                    case "1 pár":
                        return OnePair(dices);
                        break;
                    case "2 pár":
                        return TwoPair(dices);
                        break;
                    case "Drill":
                        return ThreeOrFourOfAKind(dices, 3);
                        break;
                    case "Póker":
                        return ThreeOrFourOfAKind(dices, 4);
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

        private int ThreeOrFourOfAKind(List<Dice> dices, int v)
        {
            for (int i = 1; i < 7; i++)
            {
                if (dices.Count(x => x.Value == i) >= v)
                {
                    return dices.Sum(x => x.Value = i);
                }
            }

            return 0;
        }


        private int Numbers(List<Dice> dices, int number)
        {
            return dices.Count(x => x.Value == number) * number; 
        }
    }
}
