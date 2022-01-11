using System;
using System.Collections.Generic;
using System.Text;

namespace HackRank
{
    class IsPrime
    {
        public static bool CheckForPrime(long inpValue) {
            if (inpValue == 2 || inpValue == 3)
                return true;

            if (inpValue <= 1 || inpValue % 2 == 0 || inpValue % 3 == 0)
                return false;

            for (int i = 5; i * i <= inpValue; i += 6)
            {
                if (inpValue % i == 0 || inpValue % (i + 2) == 0)
                    return false;
            }

            return true;
        }
    }
}
