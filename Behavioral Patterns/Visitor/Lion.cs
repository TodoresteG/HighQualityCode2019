namespace Visitor
{
    using System;

    public class Lion : IAnimal
    {
        public void Roar() 
        {
            Console.WriteLine("Roaaar");
        }

        public void Accept(IAnimalOperation operation)
        {
            operation.VisitLion(this);
        }
    }
}
