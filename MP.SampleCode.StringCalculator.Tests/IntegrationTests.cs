using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.SampleCode.StringCalculator.Tests
{
    [TestClass]
    public class IntegrationTests
    {
        // First test as the start of code that confirms an empty string is treated as an array with one zero in it.
        [TestMethod]
        [DataRow("", DisplayName = "Confirm an empty string parses as an array with one zero in it")]
        [DataRow(null, DisplayName = "Confirm null parses as an array with one zero in it")]
        public void EmptyStringSumsToZeroTest(string? testValue)
        {
            var result = Program.Main(new[] { testValue });

            Assert.AreEqual(0, result);
        }

        public static IEnumerable<object[]> SingleNumberTestData
        {
            get
            {
                // Without an explicit requirement, test every number up to 100.
                for (var i = 0; i < 100; i++)
                {
                    yield return new object[] { i.ToString(), i };
                }
            }
        }

        // Second test, passing one number is treated as an array with the passed number in it.
        [TestMethod]
        [DynamicData(nameof(SingleNumberTestData))]
        public void StringWithOneNumberSumsToOneNumberTest(string? testValue, int expectedResult)
        {
            var result = Program.Main(new[] { testValue });

            Assert.AreEqual(expectedResult, result);
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
                        yield return new object[] { $"{i},{j}", i + j };
                    }
                }
            }
        }

        // Third test, passing two numbers is treated as an array with the passed number in it.
        [TestMethod]
        [DynamicData(nameof(TwoNumbersTestData))]
        public void StringWithTwoNumbersSumsTwoNumbersTest(string? testValue, int expectedResult)
        {
            var result = Program.Main(new[] { testValue });

            Assert.AreEqual(expectedResult, result);
        }

        // A couple of tests to ensure any number of items can be passed
        [TestMethod]
        [DataRow("52", 52)]
        [DataRow("585,649", 1234)]
        [DataRow("151,721,608", 1480)]
        [DataRow("416,111,741,688", 1956)]
        [DataRow("805,399,185,100,9", 1498)]
        public void ArrayWithAnyNumberSumsCorrectly(string? testValue, int expectedResult)
        {
            var result = Program.Main(new[] { testValue });

            Assert.AreEqual(expectedResult, result);
        }

        public static IEnumerable<object[]> AnyNumberTestData
        {
            get
            {
                const int numberToSum = 43;

                for (var i = 1; i < 500; i++)
                {
                    var rowArray = Enumerable.Repeat(numberToSum, i).ToArray();

                    yield return new object[] { string.Join(",", rowArray), i * numberToSum };
                }
            }
        }

        [TestMethod]
        [DynamicData(nameof(AnyNumberTestData))]
        public void ArrayWithAnyLargeNumberCollectionSumsCorrectly(string? testValue, int expectedResult)
        {
            var result = Program.Main(new[] { testValue });

            Assert.AreEqual(expectedResult, result);
        }
    }
}
