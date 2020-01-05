namespace Command
{
    using System;

    // Command
    public class TurnOff : ICommand
    {
        private LightBulb lightBulb;

        public TurnOff(LightBulb lightBulb)
        {
            this.lightBulb = lightBulb ?? throw new ArgumentException("Light bulb cannot be null");
        }

        public void Execute()
        {
            this.lightBulb.TurnOff();
        }

        public void Undo()
        {
            this.lightBulb.TurnOn();
        }

        public void Redo()
        {
            this.Execute();
        }
    }
}
