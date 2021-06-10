using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup dictionary to store all restricted numbers and messages
            var dictionary = new Dictionary<int, string>();

            //setup the start and end points
            int start = 1;
            int end = 100;

            //standard fizzbuzz setup
            dictionary.Add(3, "Fizz");
            dictionary.Add(5, "Buzz");
            dictionary.Add(15, "FizzBuzz");

            //setup any extra restrictions
            dictionary.Add(7, "Bop");

            FizzBuzz(start, end, dictionary);

        }

        static void FizzBuzz(int start, int end, Dictionary<int, string> dictionary)
        {
            for (int i = start; i <= end; i++)
            {
                var output = "";

                foreach (KeyValuePair<int, string> item in dictionary.OrderByDescending(item => item.Key))
                {
                    if (i % item.Key == 0)
                    {
                        output += item.Value;
                        break;
                    }
                }

                if (output == "")
                {
                    output = i.ToString();
                }

                Console.WriteLine(output);
            }
        }
    }
}
