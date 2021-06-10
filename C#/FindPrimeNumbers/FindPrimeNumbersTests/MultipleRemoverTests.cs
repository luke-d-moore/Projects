using NUnit.Framework;
using FindPrimeNumbers.Classes;
using System.Linq;
using System.Collections.Generic;

namespace FindPrimeNumbersTests
{
    public class MultipleRemoverTests
    {
        private List<int> _NumberList = new List<int>();
        [SetUp]
        public void Setup()
        {
            _NumberList = new List<int>();
            _NumberList.Add(3);
            _NumberList.Add(6);
            _NumberList.Add(9);
            _NumberList.Add(19);
        }

        [Test]
        public void MultipleRemover_ListOfNumbersAndPositiveFactor_ReturnsTrue()
        {
            var multipleRemover = new MultipleRemover();

            var List = multipleRemover.RemoveMultiples(_NumberList, 3);

            Assert.IsTrue(List.Any() && List.Count() ==1 && List.Contains(19) && !List.Contains(3) && !List.Contains(6) && !List.Contains(9));
        }

        [Test]
        public void MultipleRemover_ListOfNumbersAndZeroFactor_ReturnsTrue()
        {
            var multipleRemover = new MultipleRemover();

            var List = multipleRemover.RemoveMultiples(_NumberList, 0);

            Assert.IsTrue(List.Any() && List.Count() == _NumberList.Count());
        }

        [Test]
        public void MultipleRemover_ListOfNumbersAndNegativeFactor_ReturnsTrue()
        {
            var multipleRemover = new MultipleRemover();

            var List = multipleRemover.RemoveMultiples(_NumberList, -1);

            Assert.IsTrue(List.Any() && List.Count() == _NumberList.Count());
        }

        [Test]
        public void MultipleRemover_NullListAndPositiveFactor_ReturnsTrue()
        {
            var multipleRemover = new MultipleRemover();

            var List = multipleRemover.RemoveMultiples(null, 3);

            Assert.IsTrue(List==null);
        }

        [Test]
        public void MultipleRemover_EmptyListAndPositiveFactor_ReturnsTrue()
        {
            var multipleRemover = new MultipleRemover();

            var List = multipleRemover.RemoveMultiples(new List<int>(), 3);

            Assert.IsTrue(!List.Any());
        }
    }
}