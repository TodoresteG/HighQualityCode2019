namespace _041AbstractFactory
{
    public interface IDoorFactory
    {
        IDoor MakeDoor();

        IDoorFittingExpert MakeFittingExpert();
    }
}
