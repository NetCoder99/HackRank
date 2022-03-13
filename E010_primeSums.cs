using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HackRank
{
    class E010_primeSums
    {
        static long sumPrimes = 0;
        static List<long> primeArray = new List<long>();
        //static int limit = 2000000;
        static int limit = 1000;

        public static void runProc()
        {
            for (int idx = 1; idx < limit; idx = idx+1)
            {
                if (IsPrime.CheckForPrime(idx))
                {
                    primeArray.Add(idx);
                    sumPrimes += idx; 
                }
            }
            Console.WriteLine("sumPrimes:" + primeArray.Sum()); ;
            Console.WriteLine("sumPrimes:" + sumPrimes);
        }
   }
}
