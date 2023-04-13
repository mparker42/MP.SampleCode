﻿using MP.SampleCode.StringCalculator.Exceptions;
using MP.SampleCode.StringCalculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.SampleCode.StringCalculator.Tests.Validators
{
    [TestClass]
    public class AdditionValidatorTests
    {
        private readonly AdditionValidatorTests _classUnderTest;

        public AdditionValidatorTests()
        {
            _classUnderTest = new AdditionValidatorTests();
        }

        [TestMethod]
        [DataRow(new[] { -52 }, "-52")]
        [DataRow(new[] { 585, -649 }, "-649")]
        [DataRow(new[] { -151, 721, -608 }, "-151, -608")]
        [DataRow(new[] { 416, -111, -741, -688 }, "-111, -741, -688")]
        [DataRow(new[] { -805, 399, -185, 100, 9 }, "-805, -185")]
        public void ArrayWithNegativeValuesFailsValidation(int[] testValue, string expectedFailures)
        {
            var exception = Assert.ThrowsException<NegativeItemsInAdditionException>(() => _classUnderTest.Validate(testValue));

            var expectedErrorMessage = string.Format(NegativeItemsInAdditionException.ErrorMessageTemplate, expectedFailures);

            Assert.AreEqual(expectedErrorMessage, exception.Message);
        }

        [TestMethod]
        [DataRow(new[] { 52 })]
        [DataRow(new[] { 585, 649 })]
        [DataRow(new[] { 151, 721, 608 })]
        [DataRow(new[] { 416, 111, 741, 688 })]
        [DataRow(new[] { 805, 399, 185, 100, 9 })]
        public void ArrayWithoutNegativeValuesPassesValidation(int[] testValue)
        {
            _classUnderTest.Validate(testValue);
        }
    }
}
