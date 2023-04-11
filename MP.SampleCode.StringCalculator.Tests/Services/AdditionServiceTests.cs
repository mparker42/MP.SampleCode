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
    }
}
