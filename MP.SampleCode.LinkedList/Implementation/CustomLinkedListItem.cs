namespace MP.SampleCode.LinkedList.Implementation
{
    // Use of pointers in c# necesitates the introduction of "unsafe" code.
    // C# is really not a great language for memory manipulation.
    unsafe internal class CustomLinkedListItem<T>
    {
        public T* ThisValue { get; set; }

        public T ThisValueExplicit => *ThisValue;

        public CustomLinkedListItem<T>? NextItem { get; set; }
    }
}
