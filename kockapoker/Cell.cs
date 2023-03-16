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

                        
                    case "2-es":

                        
                    case "3-as":

                        
                    case "4-es":

                        
                    case "5-ös":

                        
                    case "6-os":

                        
                    case "1 pár":

                        
                    case "2 pár":

                        
                    case "Drill":

                        
                    case "Póker":

                        
                    case "Fullhouse":
                        return Fullhouse(dices);
                        
                    case "Kis sor":
                        return SmallRow(dices);

                    case "Nagy sor":
                        return BigRow(dices);
                        
                    case "Yahtzee":
                        return Yahtzee(dices);

                    case "Esély":
                        return Chance(dices);
                        
                    default:
                        return 0;
                        
                }
            }
        }

        private int Fullhouse(List<Dice> dices)
        {
            int drill=0;
            for (int i = 0; i < dices.Count; i++)
            {
                drill = dices.Find(x => dices.Count(y => y.Value == x.Value) == 3).Value;
            }
            if (drill==0)
            {
                return 0;
            }
            else
            {
                dices.RemoveAll(x => x.Value==drill);
                return (dices[0].Value == dices[1].Value) ? 25 : 0;
            }

        }

        private int SmallRow(List<Dice> dices)
        {
            dices.RemoveAll(x => dices.Count(y => y.Value == x.Value) >= 2);
            if (dices.Count<4)
            {
                return 0;
            }
            return BigRow(dices) != 0 ? 30 : 0;
        }

        private int BigRow(List<Dice> dices)
        {
            dices.OrderBy(x => x. Value);
            for (int i = 0; i < dices.Count-1; i++)
            {
                if (dices[i].Value + 1 != dices[i+1].Value)
                {
                    return 0;
                }
            }
            return 40;

                
                    
        }

        private int Yahtzee(List<Dice> dices)
        {
            return dices.Count(x => x.Value == dices[0].Value) == dices.Count ? 50 : 0;
            //int szamlalo = 0;
            //for (int i = 1; i < dices.Count; i++)
            //{
            //    if (dices[0].Value==dices[i].Value)
            //    {
            //        szamlalo++;
            //    }
            //}
            //if (szamlalo==4)
            //{
            //    return 50;
            //}
        }

        private int Chance(List<Dice> dices)
        {
            return dices.Sum(x => x.Value);
        }
    }
}
