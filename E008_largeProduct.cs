using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace HackRank
{
    class E008_largeProduct
    {
        
        static string bigNumber = getBigNumberAsString();
        static int smplSize = 13;
        static long maxProduct;

        public static void runProc()
        {
            for (int idx = 0; idx < bigNumber.Length - 12; idx++) {
                string tmpStr = bigNumber.Substring(idx, smplSize);
                long tmpProduct = getProduct(tmpStr);
                Console.WriteLine("tmpProduct:" + tmpProduct);
                if (tmpProduct > maxProduct) {
                    maxProduct = tmpProduct;
                }

            }

            Console.WriteLine(bigNumber.Length);
            Console.WriteLine(maxProduct);
        }

        public static long getProduct(string inpValue) {
            if (inpValue.Length < smplSize) { return -1; }
            //if (inpValue.Contains("0")) { return -1;  }

            char[] tmpValues = inpValue.ToCharArray();
            long rtnValue = 1;
            foreach (char cVal in tmpValues) {
                rtnValue = (rtnValue * long.Parse(cVal.ToString()));
            }
            return rtnValue;
        }

        public static string getBigNumberAsString() {
            string 
            rtnStr  = "73167176531330624919225119674426574742355349194934";
            rtnStr += "96983520312774506326239578318016984801869478851843";
            rtnStr += "85861560789112949495459501737958331952853208805511";
            rtnStr += "12540698747158523863050715693290963295227443043557";
            rtnStr += "66896648950445244523161731856403098711121722383113";
            rtnStr += "62229893423380308135336276614282806444486645238749";
            rtnStr += "30358907296290491560440772390713810515859307960866";
            rtnStr += "70172427121883998797908792274921901699720888093776";
            rtnStr += "65727333001053367881220235421809751254540594752243";
            rtnStr += "52584907711670556013604839586446706324415722155397";
            rtnStr += "53697817977846174064955149290862569321978468622482";
            rtnStr += "83972241375657056057490261407972968652414535100474";
            rtnStr += "82166370484403199890008895243450658541227588666881";
            rtnStr += "16427171479924442928230863465674813919123162824586";
            rtnStr += "17866458359124566529476545682848912883142607690042";
            rtnStr += "24219022671055626321111109370544217506941658960408";
            rtnStr += "07198403850962455444362981230987879927244284909188";
            rtnStr += "84580156166097919133875499200524063689912560717606";
            rtnStr += "05886116467109405077541002256983155200055935729725";
            rtnStr += "71636269561882670428252483600823257530420752963450";
            return rtnStr;
        }
    }
}
