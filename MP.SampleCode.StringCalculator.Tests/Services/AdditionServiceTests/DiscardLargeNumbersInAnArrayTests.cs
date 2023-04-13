using MP.SampleCode.StringCalculator.Interfaces.Services;
using MP.SampleCode.StringCalculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.SampleCode.StringCalculator.Tests.Services.AdditionServiceTests
{
    [TestClass]
    public class DiscardLargeNumbersInAnArrayTests
    {
        private readonly AdditionService _classUnderTest;

        public DiscardLargeNumbersInAnArrayTests()
        {
            _classUnderTest = new AdditionService();
        }

        [TestMethod]
        [DataRow(new[] { 52 })]
        [DataRow(new[] { 585, 649 })]
        [DataRow(new[] { 151, 721, 608 })]
        [DataRow(new[] { 416, 111, 741, 688 })]
        [DataRow(new[] { 805, 399, 185, 100, 9 })]
        [DataRow(new[] { 805, 399, 185, 100, 9, 999 })]
        [DataRow(new[] { 805, 399, 185, 100, 9, 1000 })]
        public void NumbersUnderAndIncludingOneThousandArePreserved(int[] testValue)
        {
            var result = _classUnderTest.DiscardLargeNumbersInAnArray(testValue);

            CollectionAssert.AreEqual(testValue, result);
        }

        [TestMethod]
        [DataRow(new[] { 1052 }, new int[0])]
        [DataRow(new[] { 5850, 1649 }, new int[0])]
        [DataRow(new[] { 5850, 164 }, new[] { 164 })]
        [DataRow(new[] { 1510, 7210, 608 }, new[] { 608 })]
        [DataRow(new[] { 416, 1111, 7418, 6888 }, new[] { 416 })]
        [DataRow(new[] { 8052, 3996, 1854, 100, 9 }, new[] { 100, 9 })]
        [DataRow(new[] { 805, 3998, 1850, 100, 9, 99999 }, new[] { 805, 100, 9 })]
        [DataRow(new[] { 805, 399, 185, 1001, 9, 18000 }, new[] { 805, 399, 185, 9 })]
        public void NumbersOverOneThousandAreDiscarded(int[] testValue, int[] expectedResult)
        {
            var result = _classUnderTest.DiscardLargeNumbersInAnArray(testValue);

            CollectionAssert.AreEqual(expectedResult, result);
        }
    }
}
