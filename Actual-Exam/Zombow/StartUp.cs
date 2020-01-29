namespace Zombow
{
    using Core;
    using Core.Contracts;
    using IO;
    using IO.Contracts;
    using Models.Bows;
    using Models.Bows.Contracts;
    using Models.Hordes;
    using Models.Hordes.Contracts;
    using Models.Players;

    public class StartUp
    {
        private static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            //IController controller = new Controller();

            IZombieHorde horde = new ZombieHorde();
            MainPlayer mainPlayer = new MainPlayer();

            IBowFactory bowFactory = new BowFactory();

            ICommandInterpreter commandInterpreter = new CommandInterpreter(horde, mainPlayer, bowFactory);

            IEngine engine = new Engine(reader, writer, commandInterpreter);
            engine.Run();
        }
    }
}