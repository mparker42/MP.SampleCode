using MP.SampleCode.StringCalculator.Interfaces.Services;
using MP.SampleCode.StringCalculator.Interfaces.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.SampleCode.StringCalculator.Services
{
    public class AdditionService : IAdditionService
    {
        public int[] DiscardLargeNumbersInAnArray(int[] provisionalNumbersToAddTogether)
        {
            return provisionalNumbersToAddTogether
                .Where(p => p <= 1000)
                .ToArray();
        }

        public int AddAllNumbersInAnArray(int[] numbersToAddTogether)
        {
            var runningTotal = 0;

            foreach (var number in numbersToAddTogether)
            {
                runningTotal += number;
            }

            return runningTotal;
        }
    }
}
