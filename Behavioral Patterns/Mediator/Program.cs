namespace Mediator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var mediator = new ChatRoom();

            var john = new User("John", mediator);
            var jane = new User("Jane", mediator);

            john.Send("Hi there!");
            jane.Send("Hey!");
        }
    }
}
