using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HackRank
{
    class Leet_Two_Sum
    {
        public static void Execute()
        {
            //int[] inpList = new int[] { 2, 7, 11, 15 };
            //int target = 96;
            //int[] inpList = new int[] { 3, 2, 4 };
            //int target = 6;
            int[] inpList = new int[] { 3, 3 };
            int target = 6;


            int[] rtnList = new int[2];
            rtnList = TwoSum(inpList, target);

            Console.WriteLine("entries:[" + rtnList[0] + "," + rtnList[1] + "]");
        }

        //--------------------------------------------------------------------------------------------------------
        public static int[] TwoSum(int[] nums, int target)
        {
            Console.WriteLine("------- TwoSum -------");
            for (int idx1 = 0; idx1 < nums.Length; idx1++)
            {
                for (int idx2 = idx1+1; idx2 < nums.Length; idx2++)
                {
                    Console.WriteLine("indexes: [{0},{1}]", idx1, idx2);
                    Console.WriteLine("entries: [{0},{1}]", nums[idx1], nums[idx2]);
                    if ((nums[idx1] + nums[idx2]) == target)
                    {
                        return new int[] { idx1, idx2 };
                    }
                }
            }
            return new int[2];
        }

        //--------------------------------------------------------------------------------------------------------
        private static int[] getDataFromFile(String dataFile)
        {
            String dataDir = @"C:\Users\jdugger01\source\repos\HackRank\Data";
            string text = System.IO.File.ReadAllText(Path.Combine(dataDir, dataFile));
            return Array.ConvertAll(text.Split("\n"), s => int.Parse(s));
        }
    }

}
