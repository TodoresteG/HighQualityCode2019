namespace SimpleFactory
{
    using System;

    public class Program
    {
        public static void Main()
        {
            FanFactory fanFactory = new FanFactory();
            IFan ceilingFan = fanFactory.CreateFan(FanType.CeilingFan);
            IFan tableFan = fanFactory.CreateFan(FanType.TableFan);

            ceilingFan.SwitchOn();
            tableFan.SwitchOff();

            Console.WriteLine(ceilingFan.GetState());
            Console.WriteLine(tableFan.GetState());

        }
    }
}