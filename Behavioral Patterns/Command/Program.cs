namespace Command
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var lightBulb = new LightBulb();

            var turnOn = new TurnOn(lightBulb);
            var turnOff = new TurnOff(lightBulb);

            var remote = new RemoteControl();

            remote.Submit(turnOn);
            remote.Submit(turnOff);
        }
    }
}
