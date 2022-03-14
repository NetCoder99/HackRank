using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace HackRank
{
    class Leet_Three_SumV2
    {

        static long findZeroTime = 0;
        static long findZeroLoops = 0;
        static long checkDupeTime = 0;
        static long checkDupeLoops = 0;

        public static void Execute()
        {
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Reset();
            stopwatch.Start();

            int[] datList = getDataFromFile("Leet_Sum3V3.dat");
            //int[] datList = new int[] {-1,0,1,2,-1,-4};
            //int[] inpList = new int[] { 1, 2, -2, -1 };
            //int[] inpList = new int[] {};

            int target = 0;

            Console.WriteLine("------- ThreeSum -------");
            var rtnNums = FindZeroEntry(datList, target);
            var procsssTime = stopwatch.ElapsedMilliseconds;

            //foreach (IList<int> tmp in rtnNums) {
            //    Console.WriteLine("  return: [{0},{1},{2}]", tmp[0], tmp[1], tmp[2]);
            //}

            Console.WriteLine("findZeroLoops  :{0} ", findZeroLoops.ToString("N0"));
            Console.WriteLine("procsssTime    :{0}", procsssTime);

        }

        //--------------------------------------------------------------------------------------------------------
        public static List<int[]> FindZeroEntry(int[] nums, int target) {
            int[] numsAsc = (int[])nums.Clone();
            int[] numsDsc = (int[])nums.Clone();

            Array.Sort(numsAsc);
            Array.Sort(numsDsc);
            Array.Reverse(numsDsc);



            Array.Sort(nums);
            List<int[]> rtnList = new List<int[]>();

            if (nums.Count() < 3) { return rtnList; }

            for (int idx1 = 0; idx1 < nums.Length; idx1++)
            {
                //Console.WriteLine("idx1: [{0}] {1}", idx1, nums[idx1]);
                for (int idx2 = idx1 + 1; idx2 < nums.Length; idx2++)
                {
                    //Console.WriteLine(" idx2: [{0}] {1}", idx2, nums[idx2]);
                    LoopProcSequentialDsc(rtnList, nums, target, idx1, idx2);
                }
            }

            return rtnList;
        }

        //--------------------------------------------------------------------------------------------------------
        private static void LoopProcSequentialDsc(List<int[]> rtnList, int[] nums, int target, int idx1, int idx2)
        {
            findZeroLoops += 1;
            //Console.WriteLine(" tmp: {0} + {1} + {2} = {3}", nums[idx1], nums[idx2], nums[idx1]+nums[idx2]);

            for (int idx3 = nums.Length-1; idx3 > -1; idx3--)
            {
                Console.WriteLine(" tmp: {0,4}[{1,2}] + {2,6}[{3,2}] + {4,6}[{5,2}] = {6,6}", nums[idx1], idx1, nums[idx2], idx2, nums[idx3], idx3, nums[idx1] + nums[idx2] + nums[idx3]);
                if (nums[idx1] < 0 ) {
                    if (nums[idx1] + nums[idx2] + nums[idx3] < 0) {
                        return;
                    }
                }
                if ((nums[idx1] + nums[idx2] + nums[idx3]) == target)
                {
                    int[] tmpArray1 = { nums[idx1], nums[idx2], nums[idx3] };
                    if (!HasDuplicate(rtnList, tmpArray1))
                    {
                        rtnList.Add(tmpArray1);
                    }
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------
        private static void LoopProcSequential(List<int[]> rtnList, int[] nums, int target, int idx1, int idx2)
        {
            for (int idx3 = idx2 + 1; idx3 < nums.Length; idx3++)
            {
                if (idx1 == 0) {
                    Console.WriteLine("tmp: {0}", nums[idx1] + nums[idx2] + nums[idx3]);
                }
                findZeroLoops += 1;
                if ((nums[idx1] + nums[idx2] + nums[idx3]) == target)
                {
                    int[] tmpArray1 = { nums[idx1], nums[idx2], nums[idx3] };
                    if (!HasDuplicate(rtnList, tmpArray1))
                    {
                        rtnList.Add(tmpArray1);
                    }
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------
        private static bool HasDuplicate(List<int[]> inpList, int[] tstList) {
            if (inpList.Count == 0) { return false; }
            Array.Sort(tstList);
            foreach (int[] tmpList in inpList) {
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
            List<string> tmp = text.Split('\n').ToList();
            if (String.IsNullOrEmpty(tmp.Last())) {
                tmp.Remove(tmp.Last());
            }
            return Array.ConvertAll(tmp.ToArray(), s=> int.Parse(s));
        }



        ////--------------------------------------------------------------------------------------------------------
        //private static void LoopProcSequentialDsc(List<int[]> rtnList, int[] nums, int target, int idx1, int idx2)
        //{
        //    for (int idx3 = nums.Length - 1; idx3 > idx2; idx3--)
        //    {
        //        findZeroLoops += 1;
        //        int tmpTrgt = nums[idx1] + nums[idx2] + nums[idx3];
        //        //Console.WriteLine("tmpTrgt: [{0}]{1}:[{2}]{3}={4}", idx1, nums[idx1], idx2, nums[idx2], tmpTrgt);

        //        if (nums[idx1] < 0 && tmpTrgt < 0) { return; }

        //        if ((nums[idx1] + nums[idx2] + nums[idx3]) == target)
        //        {
        //            int[] tmpArray1 = { nums[idx1], nums[idx2], nums[idx3] };
        //            if (!HasDuplicate(rtnList, tmpArray1))
        //            {
        //                rtnList.Add(tmpArray1);
        //            }
        //        }
        //    }
        //}

        ////--------------------------------------------------------------------------------------------------------
        //private static void LoopProcSequentialAsc(List<int[]> rtnList, int[] nums, int target, int idx1, int idx2)
        //{
        //    for (int idx3 = nums.Length - 1; idx3 > idx2; idx3--)
        //    {
        //        findZeroLoops += 1;
        //        int tmpTrgt = nums[idx1] + nums[idx2] + nums[idx3];
        //        //Console.WriteLine("tmpTrgt: [{0}]{1}:[{2}]{3}={4}", idx1, nums[idx1], idx2, nums[idx2], tmpTrgt);
        //        if (nums[idx1] < 0 && tmpTrgt < 0) { return; }
        //        if ((nums[idx1] + nums[idx2] + nums[idx3]) == target)
        //        {
        //            int[] tmpArray1 = { nums[idx1], nums[idx2], nums[idx3] };
        //            if (!HasDuplicate(rtnList, tmpArray1))
        //            {
        //                rtnList.Add(tmpArray1);
        //            }
        //        }
        //    }
        //}



    }



}
