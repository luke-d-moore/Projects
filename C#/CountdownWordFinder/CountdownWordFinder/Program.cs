using System;
using System.Collections.Generic;
using System.Linq;

namespace CountdownWordFinder
{
    public class Program
    {
        static void Main(string[] args)
        {
            //initialize a dictionary fo all English Words on startup, so we have it pre processed for later
            var englishDictionary = new EnglishDictionary();

            //this is the sequence of letters that were chosen by the countdown contestants
            //hardcoded for testing
            var inputString = "zebertax";

            //break down the input string into all possible key values to be searched in the dictionary
            //found in alphabetical order as per the dictionary setup, looking for distinct alphabetical order combos
            //of any length up to length of input string
            //inputstring of "abc", gives a, b, c, ab, ac, bc, abc
            var permutationGenerator = new PermutationGenerator(inputString);

            FindWords(permutationGenerator.Keys, englishDictionary.AllWordsDict);
        }

        public static void FindWords(List<string> keys, Dictionary<string, string> allWordsDict)
        {
            foreach (var key in keys)
            {
                if (allWordsDict.TryGetValue(key, out var x))
                {
                    Console.WriteLine("Valid word : {0}", x);
                }
            }
        }
    }
}
