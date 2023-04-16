namespace MP.SampleCode.LinkedList.Tests.Models
{
    public class ListTestClass
    {
        public override string ToString()
        {
            return ExampleProperty.ToString();
        }

        public string ExampleProperty { get; set; } = "";
    }
}
