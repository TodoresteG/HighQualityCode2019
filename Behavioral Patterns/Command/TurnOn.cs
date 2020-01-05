namespace Command
{
    using System;

    // Command
    public class TurnOn : ICommand
    {
        private LightBulb lightBulb;

        public TurnOn(LightBulb lightBulb)
        {
            this.lightBulb = lightBulb ?? throw new ArgumentException("Light bulb cannot be null");
        }

        public void Execute()
        {
            this.lightBulb.TurnOn();
        }

        public void Undo()
        {
            this.lightBulb.TurnOff();
        }

        public void Redo()
        {
            this.Execute();
        }
    }
}
