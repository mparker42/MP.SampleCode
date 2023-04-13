namespace MP.SampleCode.StringCalculator.Interfaces.Services
{
    public interface IAdditionService
    {
        int[] DiscardLargeNumbersInAnArray(int[] provisionalNumbersToAddTogether);

        int AddAllNumbersInAnArray(int[] numbersToAddTogether);
    }
}
