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

        //Generating cells and giving them color,font style and click
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
        //Confirming a point
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

        //Calculate the points for every option
        public int Calculate(List<Dice> dices)
        {
            switch (Type)
            {
                
                case "1-es":
                    //Add all the Ones
                    return Numbers(dices, 1);
                        
                case "2-es":
                    //Add all the Twos
                    return Numbers(dices, 2);
                        
                case "3-as":
                    //Add all the Threes
                    return Numbers(dices, 3);
                        
                case "4-es":
                    //Add all the Fours
                    return Numbers(dices, 4);
                        
                case "5-ös":
                    //Add all the Fives
                    return Numbers(dices, 5);
                        
                case "6-os":
                    //Add all the Sixes
                    return Numbers(dices, 6);
                        
                case "1 pár":
                    //Add the pair value
                    return OnePair(dices);
                        
                case "2 pár":
                    //Add the two pairs value
                    return TwoPair(dices);
                        
                case "Drill":
                    //Add the drill  value
                    return ThreeOrFourOfAKind(dices, 3);
                        
                case "Póker":
                    //Add the poker value
                    return ThreeOrFourOfAKind(dices, 4);
                        
                case "Fullhouse":
                    //Add 25 points 
                    return Fullhouse(dices);
                        
                case "Kis sor":
                    //Add 30 points
                    return SmallRow(dices);

                case "Nagy sor":
                    //Add 40points
                    return BigRow(dices);
                        
                case "Yahtzee":
                    //Add 50 points
                    return Yahtzee(dices);

                case "Esély":
                    //Sum all the dicwes value
                    return Chance(dices);
                        
                default:
                    return 0;     
            }
        }
        //Checks if we have fullhouse, if we dont, then we got 0 points for that
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
        //Copies a list of the dices
        private List<Dice> CopyDices(List<Dice> dices)
        {
            List<Dice> copy = new List<Dice>();
            for (int i = 0; i < dices.Count; i++)
            {
                copy.Add(dices[i]);
            }
            return copy;
        }

        //Checks if we have a small row, if we dont, then we got 0 points for that
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
        //If the 2 number the same removes 1 of them
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
        //Checks if we have a big row, if we dont, then we got 0 points for that
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
        //Checks if we have a yahtzee, if we dont, then we got 0 points for that
        private int Yahtzee(List<Dice> dices)
        {
            return dices.Count(x => x.Value == dices[0].Value) == dices.Count ? 50 : 0;
        }
        //Summs all the dices values
        private int Chance(List<Dice> dices)
        {
            return dices.Sum(x => x.Value);
        }
        //Checks if we have a two pair, if we dont, then we got 0 points for that
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

        //Checks if we have a one pair, if we dont, then we got 0 points for that
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
        //Checks if we have a drill or poker, if we dont, then we got 0 points for that
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

        //Checks th numbers from 1-6, and summs them up
        private int Numbers(List<Dice> dices, int number)
        {
            return dices.Count(x => x.Value == number) * number; 
            
        }
    }
}
