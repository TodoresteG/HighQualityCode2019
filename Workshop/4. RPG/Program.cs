namespace RPG
{
    using Contracts;
    using Characters;
    using Weapons;

    using System;

    public class Program
    {
        static void Main()
        {
            ICharacter warriorWithAxe = new Warrior(new Axe());
            ICharacter warriorWithSword = new Warrior(new Sword());
            ICharacter mageWithAxe = new Mage(new Axe());
            ICharacter mageWithSword = new Mage(new Sword());

            Console.WriteLine(warriorWithAxe);
            Console.WriteLine(warriorWithSword);
            Console.WriteLine(mageWithAxe);
            Console.WriteLine(mageWithSword);
        }
    }
}
