using Moq;
using MP.SampleCode.StringCalculator.Handlers;
using MP.SampleCode.StringCalculator.Interfaces.Services;
using MP.SampleCode.StringCalculator.Interfaces.Validators;
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
        private readonly Mock<IAdditionValidator> _mockAdditionValidator;

        private readonly StringCalculatorAddHandler _classUnderTest;

        public StringCalculatorAddHandlerTests()
        {
            _mockParserService = _mockRepository.Create<IStringParserService>();
            _mockAdditionService = _mockRepository.Create<IAdditionService>();
            _mockAdditionValidator = _mockRepository.Create<IAdditionValidator>();

            _classUnderTest = new StringCalculatorAddHandler
            (
                _mockParserService.Object,
                _mockAdditionService.Object,
                _mockAdditionValidator.Object
            );
        }

        public void SetupCommonInvocations(string input, int[] parserResponse, int[] discardResponse, int additionResponse)
        {
            // Setup in the order they should be called
            _mockParserService
                .Setup(s => s.ParseAsArrayOfNumbers(input))
                .Returns(() => parserResponse);

            _mockAdditionValidator
                .Setup(v => v.Validate(parserResponse));

            _mockAdditionService
                .Setup(s => s.DiscardLargeNumbersInAnArray(parserResponse))
                .Returns(() => discardResponse);

            _mockAdditionService
                .Setup(s => s.AddAllNumbersInAnArray(discardResponse))
                .Returns(() => additionResponse);
        }

        public void VerifyCommonInvocations(string input, int[] parserResponse, int[] discardResponse)
        {
            _mockParserService
                .Verify
                (
                    s => s.ParseAsArrayOfNumbers(input),
                    Times.Once
                );

            _mockAdditionValidator
                .Verify
                (
                    v => v.Validate(parserResponse),
                    Times.Once
                );

            _mockAdditionService
                .Verify
                (
                    s => s.DiscardLargeNumbersInAnArray(parserResponse),
                    Times.Once
                );

            _mockAdditionService
                .Verify
                (
                    s => s.AddAllNumbersInAnArray(discardResponse),
                    Times.Once
                );
        }

        // After we have some handling for simple parsing, introduce a method for doing the addition and test it for one value.
        [TestMethod]
        public void HandlerParsesStringWithOneValue()
        {
            var input = "Some Input";

            var parserResponseArray = new[] { 51 };

            var discardResponseArray = new[] { 451 };

            var additionResponse = 24451;

            SetupCommonInvocations(input, parserResponseArray, discardResponseArray, additionResponse);

            var result = _classUnderTest.Add(input);

            VerifyCommonInvocations(input, parserResponseArray, discardResponseArray);

            Assert.AreEqual(additionResponse, result);
        }

        [TestMethod]
        public void HandlerParsesStringWithTwoValues()
        {
            var input = "Some Input";

            var parserResponseArray = new[] { 51, 244 };

            var discardResponseArray = new[] { 451, 244 };

            var additionResponse = 24451;

            SetupCommonInvocations(input, parserResponseArray, discardResponseArray, additionResponse);

            var result = _classUnderTest.Add(input);

            VerifyCommonInvocations(input, parserResponseArray, discardResponseArray);

            Assert.AreEqual(additionResponse, result);
        }
    }
}
