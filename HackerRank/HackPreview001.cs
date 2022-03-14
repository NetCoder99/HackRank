using System;
using System.Collections.Generic;
using System.Text;

namespace HackRank
{
    class HackPreview001
    {
        private static int nmbr = 10;
        public static void FizzBuzz(int nmbr) {
            if (nmbr > 2 * (Math.Pow(10, 5))) { throw new Exception("Input value outside of allowed range"); }

            for (int idx = 1; idx <= nmbr; idx++) {
                if ((idx % 3) == 0 && (idx % 5) == 0) {
                    Console.WriteLine("FizzBuzz");
                } 
                else if ((idx % 3) == 0) {
                    Console.WriteLine("Fizz");
                }
                else if ((idx % 5) == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else 
                {
                    Console.WriteLine(idx);
                }
            }

        }
    }
}
