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
                        
                    case "2-es":
                        return Numbers(dices, 2);
                        
                    case "3-as":
                        return Numbers(dices, 3);
                        
                    case "4-es":
                        return Numbers(dices, 4);
                        
                    case "5-ös":
                        return Numbers(dices, 5);
                        
                    case "6-os":
                        return Numbers(dices, 6);
                        
                    case "1 pár":
                        return OnePair(dices);
                        
                    case "2 pár":
                        return TwoPair(dices);
                        
                    case "Drill":
                        return ThreeOrFourOfAKind(dices, 3);
                        
                    case "Póker":
                        return ThreeOrFourOfAKind(dices, 4);
                        
                    case "Fullhouse":
                        //return Fullhouse(dices);
                        
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
            List<Dice> dicescopy = CopyDices(dices);
            int drill=0;
            for (int i = 0; i < dicescopy.Count; i++)
            {
                int temp = dicescopy.Find(x => dicescopy.Count(y => y.Value == x.Value) == 3).Value;
                if (temp!=0)
                {
                    drill = temp;
                    break;
                }
            }
            if (drill==0)
            {
                return 0;
            }
            else
            {
                dicescopy.RemoveAll(x => x.Value==drill);
                return (dicescopy[0].Value == dicescopy[1].Value) ? 25 : 0;
            }

        }

        private List<Dice> CopyDices(List<Dice> dices)
        {
            List<Dice> copy = new List<Dice>();
            for (int i = 0; i < dices.Count; i++)
            {
                copy.Add(dices[i]);
            }
            return copy;
        }

        private int SmallRow(List<Dice> dices)
        {
            List<Dice> dicescopy = CopyDices(dices);
            dicescopy.RemoveAll(x => dicescopy.Count(y => y.Value == x.Value) >= 2);
            if (dices.Count<4)
            {
                return 0;
            }
            return BigRow(dicescopy) != 0 ? 30 : 0;
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
        }
        private int Chance(List<Dice> dices)
        {
            return dices.Sum(x => x.Value);
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
            //if (number==2)
            //{
            //    string text = "";
            //    for (int i = 0; i < dices.Count; i++)
            //    {
            //        text += $"{dices[i].Value} - ";
            //    }
            //    MessageBox.Show(text);
            //}
            return dices.Count(x => x.Value == number) * number; 
            
        }
    }
}
