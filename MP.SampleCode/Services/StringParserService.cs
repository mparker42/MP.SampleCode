using MP.SampleCode.StringCalculator.Interfaces.Services;
using System.Text.RegularExpressions;

namespace MP.SampleCode.StringCalculator.Services
{
    public class StringParserService : IStringParserService
    {
        private const string
            // Match on any comma or new line in a string. For the newline detection, the multiline flag must be enabled.
            _stockSplitRegexPattern = "[,\n]",

            // Match any string begining with // that is followed by one character before the end of the line.
            _customSplitFinderRegexPattern = "^\\/\\/(.{1})\n";

        public int[] ParseAsArrayOfNumbers(string? input)
        {
            // If null or an empty string is passed then return an array with 0 in it.
            if (string.IsNullOrWhiteSpace(input))
            {
                return new[] { 0 };
            }

            IEnumerable<string> splitNumbers;

            var customDelimiter = Regex.Match(input, _customSplitFinderRegexPattern);

            if (customDelimiter.Success)
            {
                var splitCharacter = customDelimiter.Groups[1].Value;
                var stringStart = customDelimiter.Value;

                splitNumbers = input
                    [stringStart.Length..]
                    .Split(splitCharacter);
            }
            else
            {
                // First split the input based off the only supported separator.
                splitNumbers = Regex.Split
                (
                    input,
                    _stockSplitRegexPattern,
                    RegexOptions.Multiline
                )
                .Where(s => !string.IsNullOrWhiteSpace(s));
            }

            // Then int parse the result.
            var resultsEnumerable =
                splitNumbers
                .Select(x => int.Parse(x));

            // Finally return the enumerable as an array.
            return resultsEnumerable.ToArray();
        }
    }
}
