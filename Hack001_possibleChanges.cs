using System;
using System.Collections.Generic;
using System.Text;

namespace HackRank
{
    class Hack001_possibleChanges
    {
        public static List<string> runProc(List<string> usernames) {
            List<string> rtnList = new List<string>();
            foreach (string userName in usernames) {
                char[] tmpArr = userName.ToCharArray();
                Array.Sort(tmpArr);
                int tmpIdx = userName.IndexOf(tmpArr[0]);
                if (tmpIdx == 0)
                { rtnList.Add("NO"); }
                else 
                { rtnList.Add("YES");}
            }
            return rtnList;
        }
    }
}
