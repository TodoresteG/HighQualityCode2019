namespace State
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var editor = new TextEditor();

            editor.Type("First line");

            editor.SetState(new UpperCase());

            editor.Type("Second Line");
            editor.Type("Third Line");

            editor.SetState(new LowerCase());

            editor.Type("Fourth Line");
            editor.Type("Fifthe Line");

            editor.SetState(new CustomCase());

            editor.Type("Should be mixed up");
        }
    }
}
