namespace Mediator
{
    public class User
    {
        private string name;
        private IChatRoomMediator chatRoom;

        public User(string name, IChatRoomMediator chatRoom)
        {
            this.name = name;
            this.chatRoom = chatRoom;
        }

        public string GetName() 
        {
            return this.name;
        }

        public void Send(string message) 
        {
            this.chatRoom.ShowMessage(this, message);
        }
    }
}
