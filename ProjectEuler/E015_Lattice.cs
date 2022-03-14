using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Drawing;

namespace HackRank
{
    class E015_Lattice
    {

        Point p1 = new Point();

        public static void runProc()
        {
        }

        public static int getSum(int a, int b, int c)
        {
            return a+b+c;
        }

        public static bool isTriplet(int a, int b, int c) {
            if ((a * a) + (b * b) == (c * c))
            { return true; }
            else
            { return false; }
        }

   }
}
