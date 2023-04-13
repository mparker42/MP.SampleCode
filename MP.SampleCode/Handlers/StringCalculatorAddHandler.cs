using MP.SampleCode.StringCalculator.Interfaces.Handlers;
using MP.SampleCode.StringCalculator.Interfaces.Services;
using MP.SampleCode.StringCalculator.Interfaces.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.SampleCode.StringCalculator.Handlers
{
    public class StringCalculatorAddHandler : IStringCalculatorAddHandler
    {
        private readonly IStringParserService _stringParserService;
        private readonly IAdditionService _additionService;
        private readonly IAdditionValidator _validator;

        public StringCalculatorAddHandler
        (
            IStringParserService stringParserService,
            IAdditionService additionService,
            IAdditionValidator validator
        )
        {
            _stringParserService = stringParserService;
            _additionService = additionService;
            _validator = validator;
        }

        public int Add(string? valuesToAdd)
        {
            var parsedResult = _stringParserService.ParseAsArrayOfNumbers(valuesToAdd);

            // Before we do any addition, validate the result.
            // Do this here to keep the services simple.
            _validator.Validate(parsedResult);

            if (parsedResult.Length == 1)
            {
                return parsedResult[0];
            }

            return _additionService.AddAllNumbersInAnArray(parsedResult);
        }
    }
}
