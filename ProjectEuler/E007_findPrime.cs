using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace HackRank
{
    class E007_findPrime
    {
        public static void runProc()
        {
            int crntNmbr = 0;
            int maxPrimeNmbrs = 10001;
            List<long> primeArray = new List<long>();

            while (primeArray.Count() < maxPrimeNmbrs) {
                crntNmbr++;
                if (IsPrime.CheckForPrime(crntNmbr))
                {
                    primeArray.Add(crntNmbr);
                }
            }


            //for (int idx = 2; idx <= maxPrimeNmbrs; idx++)
            //{
            //    if (IsPrime.CheckForPrime(idx)) {
            //        primeArray.Add(idx);
            //        if (primeArray.Count() >= maxPrimeNmbrs)
            //        { break;  }
            //    }
            //}
            Console.WriteLine(primeArray.Last());
        }
    }
}
