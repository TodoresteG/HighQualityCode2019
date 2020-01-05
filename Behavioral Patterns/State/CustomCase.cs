namespace State
{
    using System;
    using System.Text;

    public class CustomCase : IWritingState
    {
        public void Write(string words)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < words.Length; i++)
            {
                if (i % 2 == 0)
                {
                    sb.Append(words[i].ToString().ToUpper());
                }
                else
                {
                    sb.Append(words[i].ToString().ToLower());
                }
            }

            Console.WriteLine(sb);
        }
    }
}
