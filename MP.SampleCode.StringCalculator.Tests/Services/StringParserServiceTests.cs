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
        private StringParserService _classUnderTest;

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
    }
}
