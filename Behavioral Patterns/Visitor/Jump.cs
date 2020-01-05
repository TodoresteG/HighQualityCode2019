namespace Visitor
{
    using System;

    public class Jump : IAnimalOperation
    {
        public void VisitDolphin(Dolphin dolphin)
        {
            Console.WriteLine("Dolphin is jumping");
        }

        public void VisitLion(Lion lion)
        {
            Console.WriteLine("Lion is jumping");
        }

        public void VisitMonkey(Monkey monkey)
        {
            Console.WriteLine("Monkey is jumping");
        }
    }
}
