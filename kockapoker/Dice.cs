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
        public int Value
        {
            get { return _value; }
            set
            {
                _value = value;
                BackgroundImage = SetImage(value);
            }
        }
        public bool Locked
        {
            get { return locked; }
            set
            {
                locked = value;
                Image = value ? Properties.Resources.locked : null;
            }
        }

        private Random r = new Random();
        private bool locked = false; 
        private int _value;



        private Image SetImage(int value)
        {
            return Image.FromFile($"{value}.png");
        }

        public Dice()
        {
            Randomize();
        }
        public void Randomize()
        {
            if (!Locked)
            {
                Value = r.Next(1, 7);
                Thread.Sleep(1);
            }
        }
    }
}
