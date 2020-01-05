namespace Command
{
    // Invoker
    public class RemoteControl
    {
        public void Submit(ICommand command) 
        {
            command.Execute();
        }
    }
}
