namespace HAD
{
    using Contracts;
    using Core;
    using Core.Factory;
    using IO;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IHeroFactory heroFactory = new HeroFactory();

            //IManager heroManager = new HeroManager(heroFactory);
            ICommandProcessor commandProcessor = new CommandProcessor(heroFactory);

            var engine = new Engine(reader, writer, commandProcessor);
            engine.Run();
        }
    }
}
