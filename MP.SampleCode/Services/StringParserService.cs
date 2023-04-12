using MP.SampleCode.StringCalculator.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MP.SampleCode.StringCalculator.Services
{
    public class StringParserService : IStringParserService
    {
        private const string _regexPattern = "[,\n]";

        public int[] ParseAsArrayOfNumbers(string? input)
        {
            // If null or an empty string is passed then return an array with 0 in it.
            if (string.IsNullOrWhiteSpace(input))
            {
                return new[] { 0 };
            }

            // First split the input based off the only supported separator.
            var splitNumbers = Regex.Split
            (
                input,
                _regexPattern,
                RegexOptions.Multiline
            );

            // Then int parse the result.
            var resultsEnumerable =
                splitNumbers
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(x => int.Parse(x));

            // Finally return the enumerable as an array.
            return resultsEnumerable.ToArray();
        }
    }
}
