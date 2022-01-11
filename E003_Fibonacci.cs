using System;
using System.Collections.Generic;
using System.Text;

namespace HackRank
{
    class E003_Fibonacci
    {
        private static int maxNmbr = 4000000;

        public static void runProc() {
            int lastNmbr = 1;
            int crntNmbr = 2;
            int tempNmbr;
            int result = crntNmbr;
            List<int> evenNmbrs = new List<int>();
            Console.WriteLine(lastNmbr);
            Console.WriteLine(crntNmbr);

            while (crntNmbr < maxNmbr) {
                tempNmbr = lastNmbr + crntNmbr;
                lastNmbr = crntNmbr;
                Console.WriteLine(tempNmbr);
                if ((tempNmbr % 2) == 0) {
                    result += tempNmbr;
                }
                crntNmbr = tempNmbr;
            }
            Console.WriteLine("result:" + result);

        }
    }
}
