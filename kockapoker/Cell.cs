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

                        break;
                    case "2 pár":

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
    }
}
