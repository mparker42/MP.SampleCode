using MP.SampleCode.StringCalculator.Interfaces.Handlers;
using MP.SampleCode.StringCalculator.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.SampleCode.StringCalculator.Handlers
{
    public class StringCalculatorAddHandler : IStringCalculatorAddHandler
    {
        private readonly IStringParserService _stringParserService;
        private readonly IAdditionService _additionService;

        public StringCalculatorAddHandler
        (
            IStringParserService stringParserService,
            IAdditionService additionService
        )
        {
            _stringParserService = stringParserService;
            _additionService = additionService;
        }

        public int Add(string? valuesToAdd)
        {
            var parsedResult = _stringParserService.ParseAsArrayOfNumbers(valuesToAdd);

            if (parsedResult.Length == 1)
            {
                return parsedResult[0];
            }

            return _additionService.AddAllNumbersInAnArray(parsedResult);
        }
    }
}
