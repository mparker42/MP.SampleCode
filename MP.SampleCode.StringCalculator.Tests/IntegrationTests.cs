using MP.SampleCode.StringCalculator.Exceptions;
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

        // Test support for new lines in addition to commas
        [TestMethod]
        [DataRow("52\n,", 52)]
        [DataRow("52\n", 52)]
        [DataRow("585\n,649", 1234)]
        [DataRow("585\n649", 1234)]
        [DataRow("151,721\n,608", 1480)]
        [DataRow("151,721\n608", 1480)]
        [DataRow("416,111,741,688", 1956)]
        [DataRow("416\n,111,741\n,688", 1956)]
        [DataRow("416\n,111,741\n688", 1956)]
        [DataRow("416\n111,741\n688", 1956)]
        [DataRow("805\n399\n185,100,9", 1498)]
        public void ArrayWithNewLinesSumsCorrectly(string? testValue, int expectedResult)
        {
            var result = Program.Main(new[] { testValue });

            Assert.AreEqual(expectedResult, result);
        }

        // A test for ; as a separator
        [TestMethod]
        [DataRow("//;\n52", 52)]
        [DataRow("//;\n585;649", 1234)]
        [DataRow("//;\n151;721;608", 1480)]
        [DataRow("//;\n416;111;741;688", 1956)]
        [DataRow("//;\n805;399;185;100;9", 1498)]
        public void ArrayWithSemicolonSeparatorSumsCorrectly(string? testValue, int expectedResult)
        {
            var result = Program.Main(new[] { testValue });

            Assert.AreEqual(expectedResult, result);
        }

        // A test for c as a separator
        [TestMethod]
        [DataRow("//c\n52", 52)]
        [DataRow("//c\n585c649", 1234)]
        [DataRow("//c\n151c721c608", 1480)]
        [DataRow("//c\n416c111c741c688", 1956)]
        [DataRow("//c\n805c399c185c100c9", 1498)]
        public void ArrayWithCSeparatorSumsCorrectly(string? testValue, int expectedResult)
        {
            var result = Program.Main(new[] { testValue });

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [DataRow("-52", "-52")]
        [DataRow("585,-649", "-649")]
        [DataRow("-151,721,-608", "-151, -608")]
        [DataRow("416,-111,-741,-688", "-111, -741, -688")]
        [DataRow("-805,399,-185,100,9", "-805, -185")]
        public void ArrayWithNegativeValuesFailsValidation(string testValue, string expectedFailures)
        {
            var exception = Assert.ThrowsException<NegativeItemsInAdditionException>(() => Program.Main(new[] { testValue }));

            var expectedErrorMessage = string.Format(NegativeItemsInAdditionException.ErrorMessageTemplate, expectedFailures);

            Assert.AreEqual(expectedErrorMessage, exception.Message);
        }
    }
}
