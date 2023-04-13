namespace MP.SampleCode.StringCalculator.Exceptions
{
    public class NegativeItemsInAdditionException : Exception
    {
        public const string ErrorMessageTemplate = "negatives not allowed; provided negative values: {0}";

        public NegativeItemsInAdditionException(params int[] negativeValues) :
            base(string.Format(ErrorMessageTemplate, string.Join(", ", negativeValues)))
        { }
    }
}
