using FindPrimeNumbers.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FindPrimeNumbers.Classes
{
    public class MultipleRemover : IMultipleRemover
    {
        public MultipleRemover()
        {

        }

        public List<int> RemoveMultiples(List<int> NumberList, int Factor)
        {
            var newNumberList = new List<int>();
            if (Factor >=1 && NumberList != null && NumberList.Any())
            {
                foreach (int i in NumberList)
                {
                    if (i % Factor != 0)
                    {
                        newNumberList.Add(i);
                    }
                }
            }
            else
            {
                return NumberList;
            }

            return newNumberList;
        }

    }
}
