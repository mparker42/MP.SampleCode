using MP.SampleCode.StringCalculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.SampleCode.StringCalculator.Tests.Services
{
    [TestClass]
    public class StringParserServiceTests
    {
        private readonly StringParserService _classUnderTest;

        public StringParserServiceTests()
        {
            _classUnderTest = new StringParserService();
        }

        // First test as the start of code that confirms an empty string is treated as an array with one zero in it.
        [TestMethod]
        [DataRow("", DisplayName = "Confirm an empty string parses as an array with one zero in it")]
        [DataRow(null, DisplayName = "Confirm null parses as an array with one zero in it")]
        public void EmptyStringParsesAsZeroTest(string? testValue)
        {
            var result = _classUnderTest.ParseAsArrayOfNumbers(testValue);

            CollectionAssert.AreEquivalent(new[] { 0 }, result);
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
        public void StringWithOneNumberParsesAsOneNumberTest(string? testValue, int expectedResult)
        {
            var result = _classUnderTest.ParseAsArrayOfNumbers(testValue);

            CollectionAssert.AreEquivalent(new[] { expectedResult }, result);
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
                        yield return new object[] { $"{i},{j}", new[] { i, j } };
                    }
                }
            }
        }

        // Third test, passing two numbers is treated as an array with the passed number in it.
        [TestMethod]
        [DynamicData(nameof(TwoNumbersTestData))]
        public void StringWithTwoNumbersParsesAsTwoNumbersTest(string? testValue, int[] expectedResult)
        {
            var result = _classUnderTest.ParseAsArrayOfNumbers(testValue);

            CollectionAssert.AreEquivalent(expectedResult, result);
        }

        // A couple of tests to ensure any number of items can be passed
        [TestMethod]
        [DataRow("52", new[] { 52 })]
        [DataRow("585,649", new[] { 585, 649 })]
        [DataRow("151,721,608", new[] { 151, 721, 608 })]
        [DataRow("416,111,741,688", new[] { 416, 111, 741, 688 })]
        [DataRow("805,399,185,100,9", new[] { 805, 399, 185, 100, 9 })]
        public void ArrayWithAnyNumberParsesCorrectly(string? testValue, int[] expectedResult)
        {
            var result = _classUnderTest.ParseAsArrayOfNumbers(testValue);

            CollectionAssert.AreEquivalent(expectedResult, result);
        }

        public static IEnumerable<object[]> AnyNumberTestData
        {
            get
            {
                const int numberToRepeat = 43;

                for (var i = 1; i < 500; i++)
                {
                    var rowArray = Enumerable.Repeat(numberToRepeat, i).ToArray();

                    yield return new object[] { string.Join(",", rowArray), rowArray };
                }
            }
        }

        [TestMethod]
        [DynamicData(nameof(AnyNumberTestData))]
        public void ArrayWithAnyLargeNumberCollectionParsesCorrectly(string? testValue, int[] expectedResult)
        {
            var result = _classUnderTest.ParseAsArrayOfNumbers(testValue);

            CollectionAssert.AreEquivalent(expectedResult, result);
        }

        // Test support for new lines in addition to commas
        [TestMethod]
        [DataRow("52\n,", new[] { 52 })]
        [DataRow("52\n", new[] { 52 })]
        [DataRow("585\n,649", new[] { 585, 649 })]
        [DataRow("585\n649", new[] { 585, 649 })]
        [DataRow("151,721\n,608", new[] { 151, 721, 608 })]
        [DataRow("151,721\n608", new[] { 151, 721, 608 })]
        [DataRow("416,111,741,688", new[] { 416, 111, 741, 688 })]
        [DataRow("416\n,111,741\n,688", new[] { 416, 111, 741, 688 })]
        [DataRow("416\n,111,741\n688", new[] { 416, 111, 741, 688 })]
        [DataRow("416\n111,741\n688", new[] { 416, 111, 741, 688 })]
        [DataRow("805\n399\n185,100,9", new[] { 805, 399, 185, 100, 9 })]
        public void ArrayWithNewLinesParsesCorrectly(string? testValue, int[] expectedResult)
        {
            var result = _classUnderTest.ParseAsArrayOfNumbers(testValue);

            CollectionAssert.AreEquivalent(expectedResult, result);
        }

        // A test for ; as a separator
        [TestMethod]
        [DataRow("//;\n52", new[] { 52 })]
        [DataRow("//;\n585;649", new[] { 585, 649 })]
        [DataRow("//;\n151;721;608", new[] { 151, 721, 608 })]
        [DataRow("//;\n416;111;741;688", new[] { 416, 111, 741, 688 })]
        [DataRow("//;\n805;399;185;100;9", new[] { 805, 399, 185, 100, 9 })]
        public void ArrayWithSemicolonSeparatorParsesCorrectly(string? testValue, int[] expectedResult)
        {
            var result = _classUnderTest.ParseAsArrayOfNumbers(testValue);

            CollectionAssert.AreEquivalent(expectedResult, result);
        }

        // A test for c as a separator
        [TestMethod]
        [DataRow("//c\n52", new[] { 52 })]
        [DataRow("//c\n585c649", new[] { 585, 649 })]
        [DataRow("//c\n151c721c608", new[] { 151, 721, 608 })]
        [DataRow("//c\n416c111c741c688", new[] { 416, 111, 741, 688 })]
        [DataRow("//c\n805c399c185c100c9", new[] { 805, 399, 185, 100, 9 })]
        public void ArrayWithCSeparatorParsesCorrectly(string? testValue, int[] expectedResult)
        {
            var result = _classUnderTest.ParseAsArrayOfNumbers(testValue);

            CollectionAssert.AreEquivalent(expectedResult, result);
        }
    }
}
