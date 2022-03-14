using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace HackRank
{
    class Leet_Three_Sum
    {

        static long findZeroTime = 0;
        static long findZeroLoops = 0;
        static long checkDupeTime = 0;
        static long checkDupeLoops = 0;

        public static void Execute()
        {

            int[] datList = getDataFromFile("Leet_Sum3V2.dat");
            //int[] datList = new int[] {-1,0,1,2,-1,-4};
            //int[] inpList = new int[] { 1, 2, -2, -1 };
            //int[] inpList = new int[] {};

            int target = 0;

            Console.WriteLine("------- ThreeSum -------");
            var rtnNums = FindZeroEntry(datList, target);
            //foreach (IList<int> tmp in rtnNums) {
            //    Console.WriteLine("  return: [{0},{1},{2}]", tmp[0], tmp[1], tmp[2]);
            //}
            Console.WriteLine("findZero       :{0} : {1}", findZeroTime, findZeroLoops);
            Console.WriteLine("CheckDuplicate :{0} : {1}", checkDupeTime, checkDupeLoops);

        }

        //--------------------------------------------------------------------------------------------------------
        public static List<List<int>> FindZeroEntry(int[] nums, int target) {
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Reset();
            stopwatch.Start();

            List<List<int>> rtnList = new List<List<int>>();
            List<int[]> rtnList2 = new List<int[]>();

            if (nums.Count() < 3) { return rtnList; }

            for (int idx1 = 0; idx1 < nums.Length; idx1++)
            {
                for (int idx2 = idx1 + 1; idx2 < nums.Length; idx2++)
                {
                    LoopProcSequential(rtnList, nums, target, idx1, idx2);
                    //LoopProcParallel(rtnList, nums, target, idx1, idx2);
                }
            }
            var arrayWriteTime = stopwatch.ElapsedMilliseconds;
            findZeroTime += arrayWriteTime;
            findZeroLoops += 1;

            Console.WriteLine("FindZeroEntry:" + arrayWriteTime);
            return rtnList;
        }

        //--------------------------------------------------------------------------------------------------------
        private static void LoopProcSequential(List<List<int>> rtnList, int[] nums, int target, int idx1, int idx2) {
            for (int idx3 = idx2 + 1; idx3 < nums.Length; idx3++)
            {
                if ((nums[idx1] + nums[idx2] + nums[idx3]) == target)
                {
                    int[] tmpArray1 = { nums[idx1], nums[idx2], nums[idx3] };
                    if (!HasDuplicate(rtnList, tmpArray1)) {
                        //rtnList.Add(tmpArray1.ToList());
                    }
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------
        private static bool HasDuplicate(List<List<int>> inpList, int[] tstList) {
            if (inpList.Count == 0) { return false; }
            Array.Sort(tstList);
            foreach (List<int> tmpList in inpList) {
                if (      tmpList[0] == tstList[0] 
                      &&  tmpList[1] == tstList[1] 
                      &&  tmpList[2] == tstList[2]
                   ) {
                    return true;
                }
            }
            return false;
        }

        //--------------------------------------------------------------------------------------------------------
        private static int[] getDataFromFile(String dataFile) {
            String dataDir = @"C:\Users\jdugger01\source\repos\HackRank\Data";
            string text = System.IO.File.ReadAllText(Path.Combine(dataDir, dataFile));
            return Array.ConvertAll(text.Split("\n"), s=> int.Parse(s));
        }

        ////--------------------------------------------------------------------------------------------------------
        //private static void LoopProcParallel(List<IList<int>> rtnList, int[] nums, int target, int idx1, int idx2)
        //{
        //    Parallel.For(idx2 + 1, nums.Length, idx3 =>
        //    {
        //        int val1 = nums[idx1];
        //        int val2 = nums[idx2];
        //        int val3 = nums[idx3];
        //        if ((val1 + val2 + val3) == target)
        //        {
        //            List<int> tmp = CheckDuplicate(rtnList, new List<int> { val1, val2, val3 });
        //            if (tmp.Count > 0)
        //            {
        //                rtnList.Add(tmp);
        //                //Console.WriteLine("  return: [{0},{1},{2}]", tmp[0], tmp[1], tmp[2]);
        //            }
        //        }
        //    });
        //}



    }

}
