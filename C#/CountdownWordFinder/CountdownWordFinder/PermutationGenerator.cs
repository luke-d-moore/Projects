using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountdownWordFinder
{
    public class PermutationGenerator
    {
        public PermutationGenerator(string input)
        {
            Keys = new List<string>();
            //write code to break down the input string into all possible permutations

            //Hardcoded for testing
            Keys.Add("bee");
            Keys.Add("aberz");

        }

        public List<string> Keys;
    }
}
