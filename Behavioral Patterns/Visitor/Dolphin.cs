namespace Visitor
{
    using System;

    public class Dolphin : IAnimal
    {
        public void Speak() 
        {
            Console.WriteLine("Tuit tuuuit");
        }

        public void Accept(IAnimalOperation operation)
        {
            operation.VisitDolphin(this);
        }
    }
}
