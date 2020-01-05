namespace Visitor
{
    using System;

    public class Monkey : IAnimal
    {
        public void Shout() 
        {
            Console.WriteLine("Oooh o aaa aa a");
        }

        public void Accept(IAnimalOperation operation)
        {
            operation.VisitMonkey(this);
        }
    }
}
