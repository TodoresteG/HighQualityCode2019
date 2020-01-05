namespace Command
{
    using System;

    // Receiver
    public class LightBulb
    {
        public void TurnOn() 
        {
            Console.WriteLine("LightBulb has been lit");
        }

        public void TurnOff() 
        {
            Console.WriteLine("Darnkess..");
        }
    }
}
