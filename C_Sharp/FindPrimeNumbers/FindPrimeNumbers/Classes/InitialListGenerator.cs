using FindPrimeNumbers.Interfaces;
using System.Collections.Generic;

namespace FindPrimeNumbers.Classes
{
    public class InitialListGenerator : IInitialListGenerator
    {
        private int _MaxNumber;
        private List<int> _NumberList;

        public InitialListGenerator(int maxNumber)
        {
            _MaxNumber = maxNumber;
            GenerateList();
        }

        public List<int> GetNumberList()
        {
            return _NumberList;
        }

        private void GenerateList()
        {

            int i = 3;
            var GeneratedList = new List<int>();

            if (_MaxNumber >= 3)
            {
                while (i <= _MaxNumber)
                {
                    if (i % 2 != 0)
                    {
                        GeneratedList.Add(i);
                    }
                    i += 2;
                }
            }

            _NumberList = GeneratedList;
        }
    }
}
