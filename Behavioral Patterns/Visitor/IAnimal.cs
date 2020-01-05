namespace Visitor
{
    // Visitee
    public interface IAnimal
    {
        void Accept(IAnimalOperation operation);
    }
}
