using MP.SampleCode.StringCalculator.Interfaces.Services;
using MP.SampleCode.StringCalculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.SampleCode.StringCalculator.Tests.Services
{
    [TestClass]
    public class AdditionServiceTests
    {
        private readonly AdditionService _classUnderTest;

        public AdditionServiceTests()
        {
            _classUnderTest = new AdditionService();
        }

        public static IEnumerable<object[]> SingleNumberTestData
        {
            get
            {
                // Without an explicit requirement, test every number up to 100.
                for (var i = 0; i < 100; i++)
                {
                    yield return new object[] { i };
                }
            }
        }

        // Test passing an array with one number returns the number.
        [TestMethod]
        [DynamicData(nameof(SingleNumberTestData))]
        public void ArrayWithOneNumberReturnsThatNumber(int testValue)
        {
            var result = _classUnderTest.AddAllNumbersInAnArray(new[] { testValue });

            Assert.AreEqual(testValue, result);
        }

        public static IEnumerable<object[]> TwoNumbersTestData
        {
            get
            {
                // Without an explicit requirement, test every number up to 100 summed with every other number up to 100.
                for (var i = 0; i < 100; i++)
                {
                    for (var j = 0; j < 100; j++)
                    {
                        yield return new object[] { new[] { i, j }, i + j };
                    }
                }
            }
        }

        // Test passing two numbers returns the numbers summed together.
        [TestMethod]
        [DynamicData(nameof(TwoNumbersTestData))]
        public void ArrayWithTwoNumbersSumsThemTogether(int[] testValue, int expectedResult)
        {
            var result = _classUnderTest.AddAllNumbersInAnArray(testValue);

            Assert.AreEqual(expectedResult, result);
        }

        // Test passing any length of number array returns the numbers summed together.
        [TestMethod]
        [DataRow(new[] { 52 }, 52)]
        [DataRow(new[] { 585, 649 }, 1234)]
        [DataRow(new[] { 151, 721, 608 }, 1480)]
        [DataRow(new[] { 416, 111, 741, 688 }, 1956)]
        [DataRow(new[] { 805, 399, 185, 100, 9 }, 1498)]
        public void ArrayWithAnyNumberSumsThemTogether(int[] testValue, int expectedResult)
        {
            var result = _classUnderTest.AddAllNumbersInAnArray(testValue);

            Assert.AreEqual(expectedResult, result);
        }

        public static IEnumerable<object[]> AnyNumberTestData
        {
            get
            {
                const int numberToSum = 43;

                for (var i = 1; i < 500; i++)
                {
                    yield return new object[] { Enumerable.Repeat(numberToSum, i).ToArray(), i * numberToSum };
                }
            }
        }

        // Test passing two numbers returns the numbers summed together.
        [TestMethod]
        [DynamicData(nameof(AnyNumberTestData))]
        public void ArrayWithAnyLargeNumberCollectionSumsThemTogether(int[] testValue, int expectedResult)
        {
            var result = _classUnderTest.AddAllNumbersInAnArray(testValue);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
