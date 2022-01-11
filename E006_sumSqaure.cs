using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace HackRank
{
    class E006_sumSqaure
    {

        public static void runProc()
        {
            int maxNmbr = 100;
            int tmpSum = 0;
            long sumOfSquares = 0;
            long squareOfSums = 0;
            for (int idx = 1; idx <= maxNmbr; idx++)
            {
                sumOfSquares += idx * idx;
                tmpSum += idx;
            }
            squareOfSums = tmpSum * tmpSum;
            Console.WriteLine("sumOfSquares:" + sumOfSquares);
            Console.WriteLine("squareOfSums:" + squareOfSums);
            Console.WriteLine(squareOfSums - sumOfSquares);
        }
    }
}
