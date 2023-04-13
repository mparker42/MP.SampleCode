using MP.SampleCode.StringCalculator.Exceptions;
using MP.SampleCode.StringCalculator.Interfaces.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.SampleCode.StringCalculator.Validators
{
    public class AdditionValidator : IAdditionValidator
    {
        public void Validate(int[] values)
        {
            var negativeValues = values
                .Where(v => v < 0)
                .ToArray();

            if(negativeValues.Length > 0)
            {
                throw new NegativeItemsInAdditionException(negativeValues);
            }
        }
    }
}
