namespace State
{
    using System;

    public class DefaultText : IWritingState
    {
        public void Write(string words)
        {
            Console.WriteLine(words);
        }
    }
}
