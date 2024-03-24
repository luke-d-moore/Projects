using NUnit.Framework;
using FindPrimeNumbers.Classes;
using System.Linq;

namespace FindPrimeNumbersTests
{
    public class InitialListGeneratorTests
    {
        [Test]
        public void InitialListGenerator_PositiveNumberGreaterThanThree_ReturnsTrue()
        {
            var listGenerator = new InitialListGenerator(6);

            var List = listGenerator.GetNumberList();

            Assert.IsTrue(List.Any() && List.Count() ==2 && List.Contains(3) && List.Contains(5) && !List.Contains(2) && !List.Contains(4) && !List.Contains(6));
        }

        [Test]
        public void InitialListGenerator_PositiveNumberEqualsThree_ReturnsTrue()
        {
            var listGenerator = new InitialListGenerator(3);

            var List = listGenerator.GetNumberList();

            Assert.IsTrue(List.Any() && List.Count() ==1 && List.Contains(3) && !List.Contains(2));
        }

        [Test]
        public void InitialListGenerator_NegativeNumber_ReturnsTrue()
        {
            var listGenerator = new InitialListGenerator(-6);

            var List = listGenerator.GetNumberList();

            Assert.IsTrue(!List.Any());
        }

        [Test]
        public void InitialListGenerator_Zero_ReturnsTrue()
        {
            var listGenerator = new InitialListGenerator(0);

            var List = listGenerator.GetNumberList();

            Assert.IsTrue(!List.Any());
        }
    }
}