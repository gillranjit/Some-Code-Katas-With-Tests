using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp1
{
    public static class StringExtensions
    {
        const string INVALID = "INVALID";

        static Func<string, string, bool> validAndHasPattern = (baseString, pattern) => !baseString.Contains(INVALID) && baseString.Contains(pattern);
        static Func<string, string, bool> validAndDoesNotHavePattern = (baseString, pattern) => !baseString.Contains(INVALID) && !baseString.Contains(pattern);

        public static string TestStringForPattern(this string testString, string pattern, bool testForPresenceOfPattern = true, bool isSuccessive = true)
        {
            if (testForPresenceOfPattern && validAndHasPattern(testString, pattern)) return isSuccessive ? testString.RemovePatternFromString(pattern): testString;
            else if (!testForPresenceOfPattern && validAndDoesNotHavePattern(testString, pattern)) return testString;
            return  string.Concat(INVALID, testString);
        }
        private static string RemovePatternFromString(this string testString, string pattern)
        {
            return testString.Remove(testString.IndexOf(pattern), pattern.Length);
        }
    }
}
