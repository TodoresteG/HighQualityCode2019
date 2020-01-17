namespace AirCombat
{
    using Core;
    using Core.Contracts;
    using Entities.AirCrafts.Factories;
    using Entities.AirCrafts.Factories.Contracts;
    using Entities.Parts.Factories;
    using Entities.Parts.Factories.Contracts;
    using IO;
    using IO.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IAirCraftFactory airCraftFactory = new AirCraftFactory();
            IPartFactory partFactory = new PartFactory();

            IBattleOperator battleOperator = new BattleOperator();
            //IManager manager = new Manager(battleOperator, airCraftFactory, partFactory);

            ICommandInterpreter commandInterpreter = new CommandInterpreter(battleOperator, airCraftFactory, partFactory);

            IEngine engine = new Engine(
                reader,
                writer,
                commandInterpreter);

            engine.Run();
        }
    }
}
