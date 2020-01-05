namespace Visitor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var lion = new Lion();
            var monkey = new Monkey();
            var dolphin = new Dolphin();

            var speak = new Speak();
            var jump = new Jump();

            lion.Accept(speak);
            lion.Accept(jump);

            monkey.Accept(speak);
            monkey.Accept(jump);

            dolphin.Accept(speak);
            dolphin.Accept(jump);
        }
    }
}
