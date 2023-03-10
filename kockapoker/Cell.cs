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
        public bool Confirmed { 
            get { return confirmed; }
            set
            {
                confirmed = value;
                BackColor = value ? Color.LemonChiffon : Color.Transparent;
            }
        }
        private bool confirmed;

        public Cell(string type)
        {
            Type = type;
            AutoSize = false;
            TextAlign = ContentAlignment.MiddleCenter;
            Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
            BorderStyle = BorderStyle.FixedSingle;
        }
    }
}
