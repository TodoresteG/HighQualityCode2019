namespace Mediator
{
    using System;

    // Mediator
    public class ChatRoom : IChatRoomMediator
    {
        public void ShowMessage(User user, string message)
        {
            Console.WriteLine($"{DateTime.UtcNow.ToString("MMMM dd, H:mm")} [{user.GetName()}]:{message}");
        }
    }
}
