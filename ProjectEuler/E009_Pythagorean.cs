using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace HackRank
{
    class E009_Pythagorean
    {
        static int intA;
        static int intB;
        static int intC;

        public static void runProc()
        {
            Console.WriteLine("isTriplet:" + isTriplet(3, 4, 5));
            for (intA = 1; intA < 1000; intA++)
            {
                for (intB = 1; intB < 1000; intB++)
                {
                    for (intC = 1; intC < 1000; intC++)
                    {
                        if (getSum(intA, intB, intC) == 1000) {
                            //Console.WriteLine("Candidate found: {0}:{1}:{2}", intA, intB, intC);
                            if (isTriplet(intA, intB, intC)) {
                                Console.WriteLine("Triple found: {0}:{1}:{2}:{3}", intA, intB, intC, intA*intB*intC);
                            }
                        }
                    }
                }
            }

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
