using FindPrimeNumbers.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;

namespace FindPrimeNumbers.Classes
{
    public class PrimeGenerator : IPrimeGenerator
    {
        private List<int> _PrimeNumberList;
        private List<int> _NumberList;
        private IMultipleRemover _MultipleRemover;
        public PrimeGenerator(IInitialListGenerator initialListGenerator, IMultipleRemover multipleRemover)
        {
            _NumberList = initialListGenerator.GetNumberList();
            _MultipleRemover = multipleRemover;
            FindPrimeNumbers();
        }

        public List<int> GetPrimeNumbers()
        {
            return _PrimeNumberList;
        }

        private void FindPrimeNumbers()
        {
            _PrimeNumberList = new List<int>();
            _PrimeNumberList.Add(1);

            if (_NumberList != null && _NumberList.Any())
            {
                var root = Math.Ceiling(Math.Sqrt(_NumberList.Last()));
                while (_NumberList.Any() && _NumberList[0] <= root)
                {
                    _PrimeNumberList.Add(_NumberList[0]);
                    _NumberList = _MultipleRemover.RemoveMultiples(_NumberList, _NumberList[0]);
                }
                _PrimeNumberList.AddRange(_NumberList);
            }

        }

    }
}
