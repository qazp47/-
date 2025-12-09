using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_1
{
    struct Color
    {
        public byte R;
        public byte G;
        public byte B;
        public Color(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }
        public override string ToString()
        {
            return $"RGB({R}, {G}, {B})";
        }
    }
    class Program
    {
        static void Main()
        {
            var cl = new Color(255, 128, 0);
            var c2 = cl;
            c2.R = 100;

            Console.WriteLine(cl);
            Console.WriteLine(c2);
        }
    }
}