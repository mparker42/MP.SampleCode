using Moq;
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

        private readonly StringCalculatorAddHandler _classUnderTest;

        public StringCalculatorAddHandlerTests()
        {
            _mockParserService = _mockRepository.Create<IStringParserService>();

            _classUnderTest = new StringCalculatorAddHandler(_mockParserService.Object);
        }

        // After we have some handling for simple parsing, introduce a method for doing the addition and test it for one value.
        [TestMethod]
        public void HandlerParsesStringWithOneValue()
        {
            var input = "Some Input";

            var response = 24451;

            _mockParserService
                .Setup(s => s.ParseAsArrayOfNumbers(input))
                .Returns(() => new[] { response });

            _classUnderTest.Add(input);

            _mockParserService
                .Verify
                (
                    s => s.ParseAsArrayOfNumbers(input),
                    Times.Once
                );
        }
    }
}
