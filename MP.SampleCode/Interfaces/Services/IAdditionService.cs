using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.SampleCode.StringCalculator.Interfaces.Services
{
    public interface IAdditionService
    {
        int[] DiscardLargeNumbersInAnArray(int[] provisionalNumbersToAddTogether);

        int AddAllNumbersInAnArray(int[] numbersToAddTogether);
    }
}
