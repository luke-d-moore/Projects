using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountdownWordFinder
{
    public class EnglishDictionary
    {
        public EnglishDictionary()
        {
            AllWordsDict = new Dictionary<string, string>();

            //here is where we want to retreive a collection of all english words
            //then make them into a dictionary for use later
            //Hardcoded for testing
            var list = new List<string> { "bee", "zebra", "mouse", "bird" };

            foreach(var word in list)
            {
                //put the letters of every word in alphabetical order as the key
                var key = string.Concat(word.OrderBy(c => c));
                if (!AllWordsDict.ContainsKey(key))
                {
                    AllWordsDict.Add(key, word);
                }
            }
        }

        public Dictionary<string, string> AllWordsDict;
    }
}
