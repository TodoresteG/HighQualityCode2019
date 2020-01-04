namespace _041AbstractFactory
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var woodenDoorFactory = new WoodenDoorFactory();

            var woodenDoor = woodenDoorFactory.MakeDoor();
            var carpenter = woodenDoorFactory.MakeFittingExpert();

            Console.WriteLine(woodenDoor.GetDescription());
            Console.WriteLine(carpenter.GetDescription());

            var ironDoorFactory = new IronDoorFactory();

            var ironDoor = ironDoorFactory.MakeDoor();
            var welder = ironDoorFactory.MakeFittingExpert();

            Console.WriteLine(ironDoor.GetDescription());
            Console.WriteLine(welder.GetDescription());
        }
    }
}
