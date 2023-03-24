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
            Value = 0;
            Type = type;
            AutoSize = false;
            Confirmed = false;
            ForeColor = Color.Red;
            TextAlign = ContentAlignment.MiddleCenter;
            Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
            BorderStyle = BorderStyle.FixedSingle;
            this.Click += delegate (object sender, EventArgs e) { Confirm(); };
        }

        private void Confirm()
        {
            if (!Confirmed && Text != "")
            {
                Value = Convert.ToInt32(Text);
                Confirmed = true;
                ForeColor = Color.Black;
                Form1.NextPlayer();
            }
        }

        public int Calculate(List<Dice> dices)
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

        private int Fullhouse(List<Dice> dices)
        {
            List<Dice> dicescopy = CopyDices(dices);
            for (int i = 0; i < dices.Count-2; i++)
            {
                if (dices.Count(x => x.Value == dices[i].Value) == 3)
                {
                    dicescopy.RemoveAll(x => x.Value == dices[i].Value);
                    if (dicescopy[0].Value == dicescopy[1].Value)
                    {
                        return 25;
                    }
                    return 0;
                }
            }
            return Yahtzee(dices) == 50 ? 25 : 0;
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
            dicescopy = dicescopy.OrderBy(x => x.Value).ToList();
            dicescopy = RemoveDuplicates(dicescopy);
            for (int i = 0; i < dicescopy.Count-1; i++)
            {
                if (dicescopy[i].Value + 1 == dicescopy[i + 1].Value)
                {
                    if (i == dicescopy.Count-2)
                    {
                        return 30;
                    }
                }
                else if (i != 0)
                {
                    return 0;
                }
            }
            return 0;

        }

        private List<Dice> RemoveDuplicates(List<Dice> dicescopy)
        {
            for (int i = 0; i < dicescopy.Count - 1; i++)
            {
                if (dicescopy[i].Value == dicescopy[i + 1].Value)
                {
                    dicescopy.Remove(dicescopy[i]);
                    break;
                }
            }
            return dicescopy;
        }

        private int BigRow(List<Dice> dices)
        {
            dices = dices.OrderBy(x => x.Value).ToList();

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
            dices=dices.OrderBy(x => x.Value).ToList();
            List<Dice> pairs = dices.FindAll(x => dices.Count(y => y.Value == x.Value) >= 2);
            if (pairs.Count >= 4)
            {
                return 2 * (pairs[0].Value + pairs.Last().Value);
            }
            return 0;
        }

        private void DiceLog(List<Dice> dices)
        {
            string str = "";
            for (int i = 0; i < dices.Count; i++)
            {
                str += dices[i].Value.ToString() + " ";
            }
            MessageBox.Show(str);
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
                    return dices.FindAll(y => y.Value == i).Sum(x => x.Value);
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
