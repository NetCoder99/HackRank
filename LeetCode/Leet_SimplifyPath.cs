using System;
using System.Collections.Generic;
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
            Console.WriteLine(SimplifyPath("//home//path//path2//"));
        }

        public string SimplifyPath(string path)
        {
            path = path.TrimEnd("/".ToCharArray());
            path = Regex.Replace(path, @"//", @"/");
            path = Regex.Replace(path, @"/./", @"/");

            if (string.IsNullOrEmpty(path)) { return ""; }
            if (path.TrimEnd("/".ToCharArray()).Length == 1) { return "/"; }
             

            // if "../" -- go up one level
            // if "./"  -- stay at level

            return "";
        }


    }
}
