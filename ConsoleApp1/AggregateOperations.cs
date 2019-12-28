using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class AggregateOperations
    {
        public static IEnumerable<Tuple<int, int>> PrintAgggregateResults(string numericString, bool shouldPrinResults = false)
        {
            IEnumerable<Tuple<int, int>> result = null;
            if (Int64.TryParse(numericString, out _))
            {
                var collectionOfIntegers = ReturnNumbersInaAString(numericString).ToList();
                result = ReturnFrequencyOfNumber(collectionOfIntegers).ToList().OrderByDescending(i => i.Item2);
                foreach (Tuple<int, int> frequencyResult in result)
                {
                    if(shouldPrinResults) Console.WriteLine(frequencyResult.Item1 + ":" + frequencyResult.Item2);
                }
            }
            return result;
        }

        private static IEnumerable<Tuple<int, int>> ReturnFrequencyOfNumber(IEnumerable<int> collectionOfIntegers)
        {
            for (int counter = 0; counter < 10; counter++)
            {
                if (collectionOfIntegers.Any(x => x == counter))
                    yield return new Tuple<int, int>(counter, (collectionOfIntegers as IList<int>).Count(n => n == counter));
            }
        }
        private static IEnumerable<int> ReturnNumbersInaAString(string numericString)
        {
            foreach (char numericChar in numericString)
            {
                yield return Int32.Parse(numericChar.ToString());
            }
        }
    }
}
