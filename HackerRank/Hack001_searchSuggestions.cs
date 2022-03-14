using System;
using System.Collections.Generic;
using System.Linq;

namespace HackRank
{
    class Hack002_searchSuggestions
    {

        public static void runProc() {
            List<string> repoList = new List<string>() { "mobile", "mouse", "moneypot", "monitor", "mousepad" };
            string query1 = "mo"; 
            string query2 = "mou";
            string query3 = "mous";
            string query4 = "mouse";

            List<List<string>> results4 = searchSuggestions(repoList, query4);

            Console.WriteLine(results4);
        }

        public static List<List<string>> searchSuggestions(List<string> repository, string customerQuery)
        {
            if (customerQuery.Length < 2) { return new List<List<string>>();  }
            repository.Sort();
            List<List<string>> rtnList = new List<List<string>>();
            for (int idx = 2; idx < customerQuery.Length+1; idx++) {
                string qry = customerQuery.Substring(0, idx);
                rtnList.Add(repository.FindAll(f => f.StartsWith(qry)).Take(3).ToList());
            }
            return rtnList;
        }

    }
}
