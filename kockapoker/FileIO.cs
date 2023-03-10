using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace kockapoker
{
    class FileIO
    {
        public static List<string> Read(string filename)
        {
            List<string> datas = new List<string>();
            try
            {
                StreamReader r = new StreamReader(filename);
                while (!r.EndOfStream)
                {
                    string temp = r.ReadLine();
                    if (!temp.Contains(" "))
                    {
                        datas.Add(temp);
                    }
                }
                r.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());

            }
            return datas;
        }
    }
}