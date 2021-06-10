using NUnit.Framework;
using FindPrimeNumbers.Classes;
using FindPrimeNumbers.Interfaces;
using System.Linq;
using System.Collections.Generic;
using Moq;

namespace FindPrimeNumbersTests
{
    public class PrimeGeneratorTests
    {

        private Mock<IInitialListGenerator> _MockListGenerator;
        private Mock<IMultipleRemover> _MockMultipleRemover;
        private PrimeGenerator _PrimeGenerator;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _MockListGenerator = new Mock<IInitialListGenerator>();
            _MockMultipleRemover = new Mock<IMultipleRemover>();
        }

        [Test]
        public void FindPrimeNumbers_ValidInput_ReturnsTrue()
        {
            var seq = new MockSequence();
            var originalList = new List<int>();
            originalList.Add(3);
            originalList.Add(7);
            originalList.Add(9);
            var newList = new List<int>();
            newList.Add(7);
            _MockMultipleRemover.InSequence(seq).Setup(m => m.RemoveMultiples(originalList, It.IsAny<int>())).Returns(newList);
            _MockMultipleRemover.InSequence(seq).Setup(m => m.RemoveMultiples(newList, It.IsAny<int>())).Returns(new List<int>());
            _MockListGenerator.Setup(o => o.GetNumberList()).Returns(originalList);
            _PrimeGenerator = new PrimeGenerator(_MockListGenerator.Object, _MockMultipleRemover.Object);

            var list = _PrimeGenerator.GetPrimeNumbers();

            Assert.IsTrue(list.Any() && list.Contains(1) && list.Contains(3) && list.Contains(7) && list.Count() == 3);
        }

        [Test]
        public void FindPrimeNumbers_EmptyList_ReturnsTrue()
        {
            var newList = new List<int>();
            _MockListGenerator.Setup(o => o.GetNumberList()).Returns(newList);
            _PrimeGenerator = new PrimeGenerator(_MockListGenerator.Object, _MockMultipleRemover.Object);


            var list = _PrimeGenerator.GetPrimeNumbers();

            Assert.IsTrue(list.Any() && list.Contains(1) && list.Count() == 1);
        }

        [Test]
        public void FindPrimeNumbers_NullList_ReturnsTrue()
        {
            var newList = new List<int>();
            newList = null;
            _MockListGenerator.Setup(o => o.GetNumberList()).Returns(newList);
            _PrimeGenerator = new PrimeGenerator(_MockListGenerator.Object, _MockMultipleRemover.Object);


            var list = _PrimeGenerator.GetPrimeNumbers();

            Assert.IsTrue(list.Any() && list.Contains(1) && list.Count() == 1);
        }

    }
}