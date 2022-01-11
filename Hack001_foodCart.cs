using System;
using System.Collections.Generic;
using System.Linq;

namespace HackRank
{
    class Hack001_foodCart
    {

        public static void runProc() {

            List<string> codeList1  = new List<string>() { "apple,apple", "banana,anything,banana" };
            List<string> shopList1  = new List<string>() { "orange", "apple", "apple", "banana" ,"orange", "banana" };

            Console.WriteLine("Iswinner: {0}", foo(codeList1, shopList1));
        }


        public static int foo(List<string> codeList, List<string> shoppingCart)
        {
            return 1; // everyone's a winner
        }


    }
}
