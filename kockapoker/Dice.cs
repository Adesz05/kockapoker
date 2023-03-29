using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace kockapoker
{
    public partial class Dice : PictureBox
    {
        //Value of the dice
        public int Value
        {
            get { return _value; }
            set
            {
                //if the value changes we change the picture
                _value = value;
                BackgroundImage = SetImage(value);
            }
        }
        //Locked variable
        public bool Locked
        {
            get { return locked; }
            set
            {
                //if the value changes we change the picture
                locked = value;
                Image = value ? Properties.Resources.locked : null;
            }
        }

        private Random r = new Random();
        private bool locked = false; 
        private int _value;


        //setting image by value
        private Image SetImage(int value)
        {
            return Image.FromFile($"{value}.png");
        }
        //Constructor
        public Dice()
        {

        }
        //Randomizing dice
        public void Randomize()
        {
            if (!Locked)
            {
                Value = r.Next(1, 7);
                //sleeping the program for 15 miliseconds to get actual random numbers
                Thread.Sleep(15);
            }
        }
    }
}
