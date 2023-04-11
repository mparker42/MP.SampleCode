using Moq;
using MP.SampleCode.StringCalculator.Handlers;
using MP.SampleCode.StringCalculator.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.SampleCode.StringCalculator.Tests.Handlers
{
    [TestClass]
    public class StringCalculatorAddHandlerTests : BaseTests
    {
        private readonly Mock<IStringParserService> _mockParserService;
        private readonly Mock<IAdditionService> _mockAdditionService;

        private readonly StringCalculatorAddHandler _classUnderTest;

        public StringCalculatorAddHandlerTests()
        {
            _mockParserService = _mockRepository.Create<IStringParserService>();
            _mockAdditionService = _mockRepository.Create<IAdditionService>();

            _classUnderTest = new StringCalculatorAddHandler(_mockParserService.Object, _mockAdditionService.Object);
        }

        // After we have some handling for simple parsing, introduce a method for doing the addition and test it for one value.
        [TestMethod]
        public void HandlerParsesStringWithOneValue()
        {
            var input = "Some Input";

            var parserResponse = 24451;

            _mockParserService
                .Setup(s => s.ParseAsArrayOfNumbers(input))
                .Returns(() => new[] { parserResponse });

            var result = _classUnderTest.Add(input);

            _mockParserService
                .Verify
                (
                    s => s.ParseAsArrayOfNumbers(input),
                    Times.Once
                );

            Assert.AreEqual(parserResponse, result);
        }

        [TestMethod]
        public void HandlerParsesStringWithTwoValues()
        {
            var input = "Some Input";

            var parserResponse = new[] { 24451, 1224 };

            var additionResponse = 32;

            _mockParserService
                .Setup(s => s.ParseAsArrayOfNumbers(input))
                .Returns(() => parserResponse);

            _mockAdditionService
                .Setup(s => s.AddAllNumbersInAnArray(parserResponse))
                .Returns(() => additionResponse);

            var result = _classUnderTest.Add(input);

            _mockParserService
                .Verify
                (
                    s => s.ParseAsArrayOfNumbers(input),
                    Times.Once
                );

            _mockAdditionService
                .Verify
                (
                    s => s.AddAllNumbersInAnArray(parserResponse),
                    Times.Once
                );

            Assert.AreEqual(additionResponse, result);
        }
    }
}
