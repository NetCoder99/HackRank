using System;
using System.Collections.Generic;
using System.Text;

namespace HackRank
{
    class E004_palindrome
    {

        public static void runProc()
        {
            int loopCntr = 0;
            int frstNmbr = 999;
            int lastNmbr = 999;
            int crntNmbr;
            int maxPaln = -1;

            Console.WriteLine(frstNmbr * lastNmbr);
            while (frstNmbr > 0) {
                while (lastNmbr > frstNmbr)
                {
                    loopCntr++;
                    crntNmbr = frstNmbr * lastNmbr;
                    if (isPalindrome(crntNmbr))
                    {
                        if (crntNmbr > maxPaln) {
                            maxPaln = crntNmbr;
                            break;
                        }
                        Console.WriteLine(frstNmbr + ":" + lastNmbr + ":" + ":" + maxPaln + ":" + crntNmbr);
                    }
                    lastNmbr--;
                }

                lastNmbr = 999;
                frstNmbr--;
            }
            Console.WriteLine("maxPaln:" + maxPaln);
            Console.WriteLine("loopCntr:" + loopCntr);

        }

        private static bool isPalindrome(int inpValue) {
            string str1 = inpValue.ToString();
            char[] tmp = inpValue.ToString().ToCharArray();
            Array.Reverse(tmp);
            string str2 = new String(tmp);
            if (str1.Equals(str2)) { return true; }
            else { return false; }
        }
    }
}
