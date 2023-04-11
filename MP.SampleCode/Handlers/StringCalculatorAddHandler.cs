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

        public StringCalculatorAddHandler(IStringParserService stringParserService)
        {
            _stringParserService = stringParserService;
        }

        public int Add(string valuesToAdd)
        {
            throw new NotImplementedException();
        }
    }
}
