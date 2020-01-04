namespace _041AbstractFactory
{
    public class Carpenter : IDoorFittingExpert
    {
        public string GetDescription()
        {
            return "I can only fit wooden doors";
        }
    }
}
