namespace Visitor
{
    // Visitor
    public interface IAnimalOperation
    {
        void VisitMonkey(Monkey monkey);

        void VisitLion(Lion lion);

        void VisitDolphin(Dolphin dolphin);
    }
}
