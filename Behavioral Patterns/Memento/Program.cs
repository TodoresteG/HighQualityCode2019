namespace Memento
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var editor = new Editor();

            //Type some stuff
            editor.Type("This is the first sentence.");
            editor.Type("This is second.");

            // Save the state to restore to : This is the first sentence. This is second.
            editor.Save();

            //Type some more
            editor.Type("This is third.");

            //Output the content
            Console.WriteLine(editor.Content); // This is the first sentence. This is second. This is third.

            //Restoring to last saved state
            editor.Restore();

            Console.Write(editor.Content); // This is the first sentence. This is second
        }
    }
}
