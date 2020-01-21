using TheTankGame.Entities.Parts.Factories;
using TheTankGame.Entities.Parts.Factories.Contracts;

namespace TheTankGame
{
    using Core;
    using Core.Contracts;
    using IO;
    using IO.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            //IReader reader = new ConsoleReader();
            //IWriter writer = new ConsoleWriter();

            //IBattleOperator battleOperator = new TankBattleOperator();
            //IManager manager = new TankManager(battleOperator);

            //ICommandInterpreter commandInterpreter = new CommandInterpreter(manager);

            //IEngine engine = new Engine(
            //    reader,
            //    writer,
            //    commandInterpreter);

            //engine.Run();

            IPartFactory partFactory = new PartFactory();

            string partType = "ArsenalPart";
            string model = "Test";
            double weight = -5;
            decimal price = 5.5m;
            int additionalParameter = 4;

            partFactory.CreatePart(partType, model, weight, price, additionalParameter);
        }
    }
}
