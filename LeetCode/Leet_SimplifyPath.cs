using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HackRank.LeetCode
{

    // Input    "/a/./b/../../c/"
    // Input    "/a /b/ ../ ../ c/"
    // Input    "/a /b/ ../ ../ c"

    // Output   "/a/./b/../../c"
    // Expected "/c"


    class Leet_SimplifyPath
    {
        public void Execute()
        {
            //Console.WriteLine(SimplifyPath("//home//path//path2//"));
            Console.WriteLine(SimplifyPath("/a/./b/../../c/"));
        }

        public string SimplifyPath(string path)
        {
            path = path.TrimEnd("/".ToCharArray());
            path = Regex.Replace(path, @"//", @"/");
            path = Regex.Replace(path, @"/\./", @"/");


            if (string.IsNullOrEmpty(path)) { return ""; }
            if (path.TrimEnd("/".ToCharArray()).Length == 1) { return "/"; }

            string regexExpr = @"(/\w+)|(\..)";
            MatchCollection matchList = Regex.Matches(path, regexExpr);
            var list = matchList.Cast<Match>().Select(match => match.Value).ToList();

            // if "../" -- go up one level
            // if "./"  -- stay at level

            return "";
        }


    }
}
