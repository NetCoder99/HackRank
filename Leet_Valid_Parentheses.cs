using System;
using System.Collections;

namespace HackRank
{
    class Leet_Valid_Parentheses
    {
        static string tst0 = "([)]";

        static string tst1 = "()";
        static string tst2 = "(())";
        static string tst3 = "())";
        static string tst4 = "([()()])";
        static string tst5 = "([{(})()])";
        static string tst6 = "([(())({})])";


        public static void Execute()
        {
            Console.WriteLine("IsValid 0: {0} : {1}", tst0, IsValid(tst0));
            Console.WriteLine("IsValid 1: {0} : {1}", tst1, IsValid(tst1));
            Console.WriteLine("IsValid 2: {0} : {1}", tst2, IsValid(tst2));
            Console.WriteLine("IsValid 3: {0} : {1}", tst3, IsValid(tst3));
            Console.WriteLine("IsValid 5: {0} : {1}", tst4, IsValid(tst4));
            Console.WriteLine("IsValid 6: {0} : {1}", tst5, IsValid(tst5));
        }

        public static bool IsValid(string s)
        {
            Stack testStack   = new Stack();

            foreach (char c in s)
            {
                if (c.Equals('(') || c.Equals('[') || c.Equals('{')) {
                    testStack.Push(c);
                    continue;
                }

                if (c.Equals(')')) {
                    if (!CheckStack(testStack, '(')) { return false; }
                }

                if (c.Equals(']'))
                {
                    if (!CheckStack(testStack, '[')) { return false; }
                }

                if (c.Equals('}'))
                {
                    if (!CheckStack(testStack, '{')) { return false; }
                }

            }
            if (testStack.Count == 0) { return true; }
            else { return false; }
        }

        private static bool CheckStack(Stack chkStack, char leftChar)
        {
            if (chkStack.Count == 0)
            { return false; }
            if (chkStack.Peek().Equals(leftChar))
            {
                chkStack.Pop();
                return true;
            }
            else
            { return false; }
        }
    }
}
