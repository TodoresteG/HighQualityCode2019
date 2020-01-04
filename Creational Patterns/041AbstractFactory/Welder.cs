namespace _041AbstractFactory
{
    public class Welder : IDoorFittingExpert
    {
        public string GetDescription()
        {
            return "I can only fit iron doors";
        }
    }
}
